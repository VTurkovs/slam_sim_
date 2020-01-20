using System;
using System.Linq;
using static slam_sim_.Simulation.Common;

namespace slam_sim_.Simulation
{
    class Robot
    {
        public Pose Pose;
        public RobotInfo Meta { get; private set; }
        public ParticleInfo ParticleMeta { get; private set; }
        public Particle[] Particles { get; private set; }

        private Sensor Sensor;
        private Random r;
        public Environment Environment;
        public bool DoMapping { get; private set; }

        public Robot(RobotInfo robotInfo, ParticleInfo particleInfo, SensorInfo sensorInfo, Environment env, bool doMapping = false)
        {
            r = new Random();

            // Robot
            Pose = new Pose(robotInfo.Location);
            Meta = robotInfo;

            // Sensor
            Sensor = new Sensor(sensorInfo);

            // Environment
            Environment = env;

            DoMapping = doMapping;
            // Particle
            ParticleMeta = particleInfo;
            if (ParticleMeta.Count <= 0) return;
            Particles = new Particle[ParticleMeta.Count];
            float w = 1.0f / ParticleMeta.Count;
            for (int i = 0; i < ParticleMeta.Count; i++)
            {
                if (DoMapping) Particles[i] = new Particle(Pose, w, ref Environment);
                else Particles[i] = new Particle(Pose, w);
            }
        }

        public void Move(Pose prevPose, Pose newPose)
        {
            r = new Random();

            // Precalculate deltas
            double d_rot_1 = Math.Atan2(newPose.Y - prevPose.Y, newPose.X - prevPose.X) - prevPose.Theta;
            double d_trans = Math.Sqrt(Math.Pow(prevPose.Y - newPose.Y, 2.0) + Math.Pow(prevPose.X - newPose.X, 2.0));
            double d_rot_2 = newPose.Theta - prevPose.Theta - d_rot_1;

            double d_rot_1_s = Math.Pow(d_rot_1, 2.0);
            double d_trans_s = Math.Pow(d_trans, 2.0);
            double d_rot_2_s = Math.Pow(d_rot_2, 2.0);

            double[,] deltas = new double[,] 
                { { d_rot_1, d_rot_1_s }, { d_trans, d_trans_s }, { d_rot_2, d_rot_2_s } };

            // Move robot
            MovePose(ref Pose, deltas);

            Pose[] points = Environment.GetPointCloud(ref Sensor, ref Pose);

            if (ParticleMeta.Count <= 0 || Particles == null) return;

            // Move particles and calculate weight
            for (int i = 0; i < ParticleMeta.Count; i++) 
            {
                MovePose(ref Particles[i].Pose, deltas);
                Particles[i].Weight = Environment.SensorModel(ref Sensor, ref Particles[i].Pose, ref points);

                if (!DoMapping) continue;
                Particles[i].Env.UpdateMap(ref Sensor, ref Particles[i].Pose, ref points);
            }

            //return;

            // Normalize
            double sum = 1.0 / Particles.Sum(x => x.Weight);
            Array.ForEach(Particles, p => { p.Weight *= sum; });

            switch (ParticleMeta.Resample)
            {
                case ResampleMethod.Multinomial:
                    MultinomialResample();
                    break;
                case ResampleMethod.Systematic:
                    SystematicResample();
                    break;
                case ResampleMethod.Stratified:
                    StratifiedResample();
                    break;
                default:
                    break;
            }
        }

        private void MovePose(ref Pose pose, double[,] deltas)
        {
            double d_rot_1_p = deltas[0, 0] - Sample(Meta.a1 * deltas[0, 1] + Meta.a2 * deltas[1, 1], r);
            double d_trans_p = deltas[1, 0] - Sample(Meta.a3 * deltas[1, 1] + Meta.a4 * deltas[0, 1] + Meta.a4 * deltas[2, 1], r);
            double d_rot_2_p = deltas[2, 0] - Sample(Meta.a1 * deltas[2, 1] + Meta.a2 * deltas[1, 1], r);

            Pose tempPose = new Pose(
                pose.X + d_trans_p * Math.Cos(pose.Theta + d_rot_1_p),
                pose.Y + d_trans_p * Math.Sin(pose.Theta + d_rot_1_p),
                pose.Theta + d_rot_1_p + d_rot_2_p);

            if (Environment.IsFree(ref tempPose, Meta.Radius * Environment.EnvInfo.Scale))
            {
                pose.X += d_trans_p * Math.Cos(pose.Theta + d_rot_1_p);
                pose.Y += d_trans_p * Math.Sin(pose.Theta + d_rot_1_p);
            }
            pose.Theta += d_rot_1_p + d_rot_2_p;
        }


        private double[] CumulativeSum() 
        {
            if (ParticleMeta.Count <= 0) return null;
            double[] sum = new double[ParticleMeta.Count];
            sum[0] = Particles[0].Weight;
            for (int i = 1; i < ParticleMeta.Count; i++)
            {
                sum[i] = sum[i - 1] + Particles[i].Weight;
            }
            return sum;
        }

        private void MultinomialResample() 
        {
            double[] Q = CumulativeSum();
            Particle[] tempParticles = new Particle[ParticleMeta.Count];
            for (int n = 0; n < ParticleMeta.Count; n++)
            {
                double u = r.NextDouble();
                int m = 0;
                while (m < ParticleMeta.Count && Q[m] < u)
                {
                    m++;
                }
                tempParticles[n] = new Particle(ref Particles[m]);
            }
            tempParticles.CopyTo(Particles, 0);
        }

        private void StratifiedResample()
        {
            double[] Q = CumulativeSum();
            Particle[] tempParticles = new Particle[ParticleMeta.Count];
            int m = 0;
            for (int n = 0; n < ParticleMeta.Count; n++)
            {
                double u = r.NextDouble() * 1 / ParticleMeta.Count + n / ParticleMeta.Count;
                while (m < ParticleMeta.Count && Q[m] < u)
                {
                    m++;
                }
                tempParticles[n] = new Particle(ref Particles[m]);
            }
            tempParticles.CopyTo(Particles, 0);
        }

        private void SystematicResample()
        {
            double[] Q = CumulativeSum();
            Particle[] tempParticles = new Particle[ParticleMeta.Count];
            double u0 = r.NextDouble() * 1 / ParticleMeta.Count;
            int m = 0;
            for (int n = 0; n < ParticleMeta.Count; n++)
            {
                double u = u0 + n / ParticleMeta.Count;
                while (m < ParticleMeta.Count && Q[m] < u)
                {
                    m++;
                }
                tempParticles[n] = new Particle(ref Particles[m]);
            }
            tempParticles.CopyTo(Particles, 0);
        }
    }
}