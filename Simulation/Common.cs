using System;
using System.Drawing;

namespace slam_sim_.Simulation
{

    class Common
    {
        public static double Deg2rad(double degrees) { return degrees * Math.PI / 180.0; }
        public static double Rad2deg(double radians) { return radians / Math.PI * 180.0; }
        public static double NormAngle(double radians) 
        {
            while (radians > Math.PI) radians -= Math.PI * 2;
            while (radians < -Math.PI) radians += Math.PI * 2;
            return radians;
        }


        public static double Distance(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow(x1 - x2, 2.0) + Math.Pow(y1 - y2, 2.0));
        }
        public static double Distance(Pose pose1, Pose point2)
        {
            return Math.Sqrt(Math.Pow(pose1.X - point2.X, 2.0) + Math.Pow(pose1.Y - point2.Y, 2.0));
        }
        public static double Distance(Point point1, Point point2)
        {
            return Math.Sqrt(Math.Pow(point1.X - point2.X, 2.0) + Math.Pow(point1.Y - point2.Y, 2.0));
        }

        public struct EnvironmentInfo
        {
            public int Height { get; private set; }
            public int Width { get; private set; }
            public int Scale { get; private set; }
            public bool Set { get; private set; }
            public double ObstWidth { get; private set; }
            public EnvironmentInfo(int height, int width, int scale, double obstWidth)
            {
                Height = height;
                Width = width;
                Scale = scale;
                ObstWidth = obstWidth;
                Set = true;
            }
        }

        public struct RobotInfo
        {
            public double a1 { get; private set; }
            public double a2 { get; private set; }
            public double a3 { get; private set; }
            public double a4 { get; private set; }

            public double Radius { get; private set; }
            public double TranslationStep { get; private set; }
            public double RotationStep { get; private set; }
            public Point Location { get; private set; }
            public bool Set { get; private set; }

            public RobotInfo(double a1, double a2, double a3, double a4, double r, double t, double rot, Point L)
            {
                this.a1 = a1;
                this.a2 = a2;
                this.a3 = a3;
                this.a4 = a4;
                Radius = r;
                TranslationStep = t;
                RotationStep = rot;
                Location = L;
                Set = true;
            }
        }

        public struct ParticleInfo
        {
            public int Count { get; private set; }
            public ResampleMethod Resample { get; private set; }
            public bool Set { get; private set; }

            public ParticleInfo(int c, ResampleMethod r)
            {
                Count = c;
                Resample = r;
                Set = true;
            }
        }

        public struct SensorInfo
        {
            public int SweepAngle { get; private set; }
            public double MaxDistance { get; private set; }
            public bool Set { get; private set; }
            public double SigmaHit { get; private set; }
            public double ZHit { get; private set; }
            public double ZRand { get; private set; }
            public double ZMax { get; private set; }
            public double BeamWidth { get; private set; }

            public SensorInfo(int s, double d, double sigma, double zhit, double zrand, double zmax)
            {
                SweepAngle = s;
                MaxDistance = d;
                SigmaHit = sigma;
                ZHit = zhit;
                ZRand = zrand;
                ZMax = zmax;
                BeamWidth = 1.0;
                Set = true;
            }
        }

        public class Pose
        {
            public Pose(Pose p)
            {
                X = p.X;
                Y = p.Y;
                Theta = p.Theta;
            }
            public Pose(Point p)
            {
                X = p.X;
                Y = p.Y;
                Theta = 0;
            }
            public Pose(double x, double y, double theta)
            {
                X = x;
                Y = y;
                Theta = theta;
            }
            public double X { get; set; }
            public double Y { get; set; }
            public double Theta { get; set; }
        }

        public class Particle
        {
            public Pose Pose;
            public double Weight;
            public Environment Env;
            public Particle(Pose pose, double weight)
            {
                Pose = new Pose(pose);
                Weight = weight;
            }
            public Particle(Pose pose, double weight, ref Environment e)
            {
                Pose = new Pose(pose);
                Weight = weight;
                Env = new Environment(ref e);
            }
            public Particle(ref Particle particle)
            {
                Pose = new Pose(particle.Pose);
                Weight = particle.Weight;
                if (particle.Env == null) return;
                Env = new Environment(ref particle.Env, true);
            }
        }

        public class Sensor
        {
            // By default consider sensor beam at every degree
            public SensorInfo Meta { get; private set; }
            public PointF[] UnitVectors { get; private set; }
            public double MinAngle { get; private set; }
            public double MaxAngle { get; private set; }

            public Sensor(SensorInfo sensorInfo)
            {
                Meta = sensorInfo;
                MinAngle = Deg2rad(-sensorInfo.SweepAngle / 2);
                MaxAngle = Deg2rad(sensorInfo.SweepAngle / 2);
                CreateUnitVectors();
            }
            private void CreateUnitVectors()
            {
                UnitVectors = new PointF[Meta.SweepAngle];
                if (Meta.SweepAngle == 1)
                {
                    UnitVectors[0] = new PointF(1, 0);
                    return;
                }
                double halfSweep = 0.5 * Meta.SweepAngle;
                for (int i = 0; i < Meta.SweepAngle; i++)
                {
                    UnitVectors[i] = new PointF((float)Math.Cos(Deg2rad(i - halfSweep)),
                        (float)Math.Sin(Deg2rad(i - halfSweep)));
                }
            }
        }

        public enum Key
        {
            Left = 0,
            Up = 1,
            Right = 2,
            Down = 3
        }

        public enum ResampleMethod
        {
            Multinomial = 0,
            Systematic = 1,
            Stratified = 2
        }

        public static double Sample(double bSquared, Random r)
        {
            double b = Math.Sqrt(bSquared);
            double sum = 0.0;
            for (int i = 0; i < 12; i++)
            {
                sum += r.NextDouble() * 2 * b - b;
            }
            return sum * 0.5;
        }

        public static double Prob(double x, double sigma)
        {
            return 1.0 / Math.Sqrt(2.0 * Math.PI * sigma) * Math.Exp(-1.0 / 2.0 * Math.Pow(x, 2.0) / sigma);
        }

        
    }
    static class Com 
    {
        public static void Populate<T>(this T[,] arr, T value, int height, int width)
        {
            for (int i = 0; i < height; i++)
                for (int j = 0; j < width; j++)
                    arr[i, j] = value;
        }
    }
}
