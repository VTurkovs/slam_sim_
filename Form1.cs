using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using static slam_sim_.Simulation.Common;
using slam_sim_.Simulation;


namespace slam_sim_
{
    public partial class Form1 : Form
    {
        public bool SimulationOn { get; set; } = false;

        private EnvironmentInfo EnvMeta { get; set; }
        private SensorInfo SensorMeta { get; set; }
        private RobotInfo RobotMeta { get; set; }
        private ParticleInfo ParticleMeta { get; set; }

        private bool mouseDown = false;
        private bool drawRobot = false;

        private List<List<Point>> obstacleList = new List<List<Point>>();
        private int lineCounter = -1;

        private Bitmap bitmap;
        Pen obstaclePen = new Pen(Brushes.Black, 1.0f);
        Pen particlePen = new Pen(Brushes.DarkMagenta, 1.0f);

        Pen bearingPen = new Pen(Brushes.OrangeRed, 1.0f);
        SolidBrush robotBrush = new SolidBrush(Color.LightGray);
        SolidBrush odoRobotBrush = new SolidBrush(Color.LightGreen);

        private Pose odoPoseNow;
        private Pose odoPosePrev;
        private double traveledOdo;
        private double traveledReal;
        private List<Point> trajectoryOdo = new List<Point>();
        private List<Point> trajectoryReal = new List<Point>();
        private int trajCounter = 0;
        private bool drawTrajectory = true;
        Pen trajOdoPen = new Pen(Brushes.LightGreen, 1.0f);
        Pen trajRealPen = new Pen(Brushes.LightGray, 1.0f);

        private Robot robot;
        private Simulation.Environment environment;

        private bool[] keyDown = { false, false, false, false };

        private bool updating;
        private bool DoMapping;


        public Form1()
        {
            InitializeComponent();

            EnvMeta = new EnvironmentInfo(MapPanel.Height, 
                MapPanel.Width, 
                decimal.ToInt32(MapScaleSpinBttn.Value), 
                (double)ObstacleWidthSpinBttn.Value);
            SensorMeta = new SensorInfo(decimal.ToInt32(SensorAngleSpinBttn.Value),
                (double)SensorDistanceSpinBttn.Value,
                (double)SigmaHitSpinBttn.Value,
                (double)ZHitSpinBttn.Value,
                (double)ZRandSpinBttn.Value,
                (double)ZMaxSpinBttn.Value);
            RobotMeta = new RobotInfo((double)a1SpinBttn.Value, 
                (double)a2SpinBttn.Value, 
                (double)a3SpinBttn.Value, 
                (double)a4SpinBttn.Value,
                (double)RobotRadiusSpinBttn.Value, 
                (double)RobotTransStepSpinBttn.Value, 
                (double)RobotRotStepSpinBttn.Value, 
                new Point(EnvMeta.Width / 2, EnvMeta.Height / 2));
            ParticleMeta = new ParticleInfo(0, ResampleMethod.Multinomial);
            ParticleList.View = View.Details;
        }

        private void UpdateRate_Tick(object sender, EventArgs e)
        {
            if (updating || !SimulationOn || !drawRobot) return;
            
            bool moved = false;
            odoPosePrev = new Pose(odoPoseNow.X, odoPoseNow.Y, odoPoseNow.Theta);
            double dTrans = RobotMeta.TranslationStep * EnvMeta.Scale;
            double dRot = Deg2rad(RobotMeta.RotationStep);
            if (keyDown[(int)Key.Left])
            {
                moved = true;
                odoPoseNow.Theta -= dRot;
            }
            if (keyDown[(int)Key.Up])
            {
                moved = true;
                odoPoseNow.Y += dTrans * Math.Sin(odoPoseNow.Theta);
                odoPoseNow.X += dTrans * Math.Cos(odoPoseNow.Theta);
            }
            if (keyDown[(int)Key.Right])
            {
                moved = true;
                odoPoseNow.Theta += dRot;
            }
            if (keyDown[(int)Key.Down])
            {
                moved = true;
                odoPoseNow.Y -= dTrans * Math.Sin(odoPoseNow.Theta);
                odoPoseNow.X -= dTrans * Math.Cos(odoPoseNow.Theta);
            }

            if (!moved) return;
            updating = true;

            traveledOdo += Distance(odoPosePrev, odoPoseNow);
            trajectoryOdo.Add(new Point((int)odoPoseNow.X, (int)odoPoseNow.Y));

            Pose tempRoboPose = new Pose(robot.Pose);
            robot.Move(odoPosePrev, odoPoseNow);

            trajectoryReal.Add(new Point((int)robot.Pose.X, (int)robot.Pose.Y));
            traveledReal += Distance(tempRoboPose, robot.Pose);

            TravelOdoValLbl.Text = (traveledOdo / environment.EnvInfo.Scale).ToString();
            TravelValLbl.Text = Math.Round(traveledReal / environment.EnvInfo.Scale, 2).ToString();
            trajCounter++;

            UpdateParticleList();

            MapPanel.Refresh();
            updating = false;
        }

        private void UpdateParticleList()
        {
            ParticleList.Items[0].SubItems[1].Text = Math.Round(robot.Pose.X).ToString();
            ParticleList.Items[0].SubItems[2].Text = Math.Round(robot.Pose.Y).ToString();
            ParticleList.Items[0].SubItems[3].Text = Math.Round(Rad2deg(NormAngle(robot.Pose.Theta))).ToString();

            ParticleList.Items[1].SubItems[1].Text = Math.Round(odoPoseNow.X).ToString();
            ParticleList.Items[1].SubItems[2].Text = Math.Round(odoPoseNow.Y).ToString();
            ParticleList.Items[1].SubItems[3].Text = Math.Round(Rad2deg(NormAngle(odoPoseNow.Theta))).ToString();

            if (robot.Particles == null) return;
            int i = 0;

            foreach (Particle particle in robot.Particles)
            {
                ParticleList.Items[i + 2].SubItems[1].Text = Math.Round(particle.Pose.X).ToString();
                ParticleList.Items[i + 2].SubItems[2].Text = Math.Round(particle.Pose.Y).ToString();
                ParticleList.Items[i + 2].SubItems[3].Text = Math.Round(Rad2deg(NormAngle(particle.Pose.Theta))).ToString();
                ParticleList.Items[i + 2].SubItems[4].Text = Math.Round(particle.Weight, 5).ToString();

                i++;
            }
        }

        private void ToggleSimBttn_Click(object sender, EventArgs e)
        {
            SimulationOn = !SimulationOn;
            ToggleSimBttn.Text = SimulationOn ? "Stop Simulation" : "Start Simulation";

            DrawStop.Checked = true;
            if (!SimulationOn)
            {
                UpdateMapCheckBox.Enabled = true;
                return;
            }
            if (!drawRobot)
            {
                ToggleSimBttn_Click(sender, e);
                return;
            }

            UpdateMapCheckBox.Enabled = false;

            environment = new Simulation.Environment(ref obstacleList, obstaclePen, EnvMeta);
            DoMapping = UpdateMapCheckBox.Checked;
            robot = new Robot(RobotMeta, ParticleMeta, SensorMeta, environment, DoMapping);
            odoPoseNow = new Pose(RobotMeta.Location);
            odoPosePrev = new Pose(RobotMeta.Location);

            bitmap = new Bitmap(EnvMeta.Width, EnvMeta.Height, PixelFormat.Format32bppArgb);

            traveledOdo = 0.0;
            traveledReal = 0.0;
            
            trajectoryOdo = new List<Point>();
            trajectoryReal = new List<Point>();
            trajectoryOdo.Add(RobotMeta.Location);
            trajectoryReal.Add(RobotMeta.Location);
            trajCounter = 1;

            // Update Particle list
            ParticleList.Items.Clear();
            ParticleList.Items.Add(new ListViewItem(new string[] 
            { "Robot", RobotMeta.Location.X.ToString(), RobotMeta.Location.Y.ToString(), "0", "N" }));
            ParticleList.Items.Add(new ListViewItem(new string[]
            { "Odometry", RobotMeta.Location.X.ToString(), RobotMeta.Location.Y.ToString(), "0", "N" }));

            int i = 0;
            if (robot.Particles == null) return;
            foreach (Particle particle in robot.Particles)
            {
                ParticleList.Items.Add(new ListViewItem(new string[]
                { i.ToString(), Math.Round(particle.Pose.X).ToString(), Math.Round(particle.Pose.Y).ToString(), 
                    Math.Round(Rad2deg(particle.Pose.Theta)).ToString(), Math.Round(particle.Weight, 5).ToString() }));
                i++;
            }
        }


        private void DrawRobotPose(Graphics g, ref Pose pose, ref SolidBrush roboBrush, 
            ref Pen orientationPen, bool drawSensor = false) 
        {
            // Robot
            int r = (int)RobotMeta.Radius * EnvMeta.Scale;
            if (r < 2) r = 2;

            g.FillEllipse(roboBrush, (float)pose.X - r, (float)pose.Y - r, 2 * r, 2 * r);

            // Sensor and direction
            double x2 = Math.Cos(pose.Theta) * r + pose.X;
            double y2 = Math.Sin(pose.Theta) * r + pose.Y;

            if (drawSensor)
            {
                double sensorAngle = SensorMeta.SweepAngle;
                double sensorDistance = SensorMeta.MaxDistance * EnvMeta.Scale;
                if (sensorAngle == 1.0)
                {
                    x2 = Math.Cos(pose.Theta) * sensorDistance + pose.X;
                    y2 = Math.Sin(pose.Theta) * sensorDistance + pose.Y;
                }
                else
                {
                    sensorAngle *= 0.5;
                    g.DrawPie(orientationPen,
                        (float)(pose.X - sensorDistance), (float)(pose.Y - sensorDistance),
                        (float)(2.0 * sensorDistance), (float)(2.0 * sensorDistance),
                        (float)(Rad2deg(pose.Theta) - sensorAngle), (float)(sensorAngle * 2.0));
                }
            }
            g.DrawLine(orientationPen, (float)pose.X, (float)pose.Y, (float)x2, (float)y2);
        }

        private void MapPanel_Paint(object sender, PaintEventArgs e)
        {
            if (DoMapping && ParticleList.SelectedItems.Count > 0 && ParticleList.SelectedIndices[0] > 1)
            {
                int index = ParticleList.SelectedIndices[0] - 2;
                if (index > robot.ParticleMeta.Count) return;
                e.Graphics.DrawImage(robot.Particles[index].Env.GetBitmap(ref bitmap), new Point(0, 0));
                DrawRobotPose(e.Graphics, ref robot.Particles[index].Pose, ref robotBrush, ref bearingPen, true);

                return;
            }
            if (!SimulationOn)
            {
                if (obstacleList != null)
                {
                    foreach (List<Point> line in obstacleList)
                    {
                        if (line == null || line.Count < 2) continue;
                        e.Graphics.DrawLines(obstaclePen, line.ToArray());
                    }
                }
                if (!drawRobot) return;
                odoPoseNow = new Pose(RobotMeta.Location.X, RobotMeta.Location.Y, 0);
                DrawRobotPose(e.Graphics, ref odoPoseNow, ref odoRobotBrush, ref bearingPen, true);
                return;
            }

            if (environment == null || robot == null) return;
            // Obstacles
            e.Graphics.DrawImage(environment.GetBitmap(ref bitmap), new Point(0, 0));

            // Robot
            if (!drawRobot) return;

            DrawRobotPose(e.Graphics, ref odoPoseNow, ref odoRobotBrush, ref bearingPen);

            DrawRobotPose(e.Graphics, ref robot.Pose, ref robotBrush, ref bearingPen, true);

            if (drawTrajectory && trajCounter >= 2)
            {
                e.Graphics.DrawLines(trajOdoPen, trajectoryOdo.ToArray());
                e.Graphics.DrawLines(trajRealPen, trajectoryReal.ToArray());
            }
            // Particles
            Particle[] particlePoses = robot.Particles;
            if (particlePoses == null) return;
            foreach (Particle particle in particlePoses)
            {
                e.Graphics.DrawLine(particlePen, (float)particle.Pose.X, (float)particle.Pose.Y,
                    (float)particle.Pose.X + 1, (float)particle.Pose.Y + 1);
            }
        }

        private void MapPanel_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            if (SimulationOn) return;
            if (DrawObstacle.Checked)
            {
                if (obstacleList == null) obstacleList = new List<List<Point>>();
                obstacleList.Add(new List<Point>());
                lineCounter++;
            }
            if (DrawRobot.Checked)
            {
                RobotMeta = new RobotInfo((double)a1SpinBttn.Value,
                    (double)a2SpinBttn.Value,
                    (double)a3SpinBttn.Value,
                    (double)a4SpinBttn.Value,
                    (double)RobotRadiusSpinBttn.Value,
                    (double)RobotTransStepSpinBttn.Value,
                    (double)RobotRotStepSpinBttn.Value,
                    e.Location);
                drawRobot = true;
            }
            MapPanel.Refresh();
        }

        private void MapPanel_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void MapPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (!mouseDown || SimulationOn) return;
            if (DrawObstacle.Checked && lineCounter >= 0)
            {
                if (obstacleList[lineCounter] == null) obstacleList[lineCounter] = new List<Point>();
                obstacleList[lineCounter].Add(e.Location);
                if (obstacleList[lineCounter].Count < 2) return;
                MapPanel.Refresh();
            }
        }

        private void MapPanel_Resize(object sender, EventArgs e)
        {

            // Clear environment from obstacles

            // Clear environment from robot

            // Clear environment from particles

        }

        private void MapPanel_Click(object sender, EventArgs e)
        {
            SimOptions.Select();
        }

        

        private void SaveEnvBttn_Click(object sender, EventArgs e)
        {
            DrawStop.Checked = true;
            if (SimulationOn) return;
            EnvMeta = new EnvironmentInfo(decimal.ToInt32(HeightSpinBttn.Value),
                decimal.ToInt32(WidthSpinBttn.Value),
                decimal.ToInt32(MapScaleSpinBttn.Value), 0.01 * (double)ObstacleWidthSpinBttn.Value);

            Size newSize = new Size(EnvMeta.Width, EnvMeta.Height);
            if (MapPanel.Size != newSize)
            {
                int dx = newSize.Width - MapPanel.Size.Width;
                SimOptions.Location = new Point(SimOptions.Location.X + dx, SimOptions.Location.Y);
                ToggleSimBttn.Location = new Point(ToggleSimBttn.Location.X + dx, ToggleSimBttn.Location.Y);
                ParticleList.Location = new Point(ParticleList.Location.X + dx, ParticleList.Location.Y);
                MapPanel.Size = newSize;
            }
        }

        private void SaveRobotBttn_Click(object sender, EventArgs e)
        {
            if (SimulationOn) return;
            Point p = RobotMeta.Location;
            RobotMeta = new RobotInfo((double)a1SpinBttn.Value,
                (double)a2SpinBttn.Value,
                (double)a3SpinBttn.Value,
                (double)a4SpinBttn.Value,
                (double)RobotRadiusSpinBttn.Value,
                (double)RobotTransStepSpinBttn.Value,
                (double)RobotRotStepSpinBttn.Value,
                p);
        }

        private void SaveSensorBttn_Click(object sender, EventArgs e)
        {
            if (SimulationOn) return;
            SensorMeta = new SensorInfo(decimal.ToInt32(SensorAngleSpinBttn.Value),
                (double)SensorDistanceSpinBttn.Value,
                (double)SigmaHitSpinBttn.Value,
                (double)ZHitSpinBttn.Value,
                (double)ZRandSpinBttn.Value,
                (double)ZMaxSpinBttn.Value);
        }

        private void SaveParticleBttn_Click(object sender, EventArgs e)
        {
            if (SimulationOn) return;
            ResampleMethod r;
            if (MultinomialResample.Checked)
                r = ResampleMethod.Multinomial;
            else if (SystematicResample.Checked)
                r = ResampleMethod.Systematic;
            else if (StratifiedResample.Checked)
                r = ResampleMethod.Stratified;
            else
                throw new System.ArgumentOutOfRangeException("Resample method", "Particle resample method not implemented");
            ParticleMeta = new ParticleInfo(decimal.ToInt32(ParticleCountSpinBttn.Value), r);
        }

        
        private void DefaultEnvBttn_Click(object sender, EventArgs e)
        {
            HeightSpinBttn.Value = HeightSpinBttn.Minimum;
            WidthSpinBttn.Value = WidthSpinBttn.Minimum;
            MapScaleSpinBttn.Value = 10.0M;

            if (!SimulationOn)
            {
                // Clear obstacles
                obstacleList = new List<List<Point>>();
                lineCounter = -1;
                // Don't draw robot
                drawRobot = false;
                MapPanel.Refresh();
            }

            SaveEnvBttn_Click(sender, e);
        }

        private void DefaultRobotBttn_Click(object sender, EventArgs e)
        {
            a1SpinBttn.Value = 1e-6M;
            a2SpinBttn.Value = 1e-6M;
            a3SpinBttn.Value = 1e-6M; ;
            a4SpinBttn.Value = 1e-6M; ;
            RobotRadiusSpinBttn.Value = 1.0M;
            RobotTransStepSpinBttn.Value = 1.0M;
            RobotRotStepSpinBttn.Value = 10M;
            
            SaveRobotBttn_Click(sender, e);
        }

        private void DefaultSensorBttn_Click(object sender, EventArgs e)
        {
            SensorAngleSpinBttn.Value = 90.0M;
            SensorDistanceSpinBttn.Value = 7.0M;
            SigmaHitSpinBttn.Value = 0.5M;
            ZHitSpinBttn.Value = 0.5M;
            ZRandSpinBttn.Value = 0.5M;
            ZMaxSpinBttn.Value = 0.5M;

            SaveSensorBttn_Click(sender, e);
        }

        private void DefaultParticleBttn_Click(object sender, EventArgs e)
        {
            ParticleCountSpinBttn.Value = 50.0M;
            MultinomialResample.Checked = true;
            
            SaveParticleBttn_Click(sender, e);
        }



        private void SimOptions_Selecting(object sender, TabControlCancelEventArgs e)
        {
            DrawStop.Checked = true;
        }

        private void SimOptions_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    keyDown[(int)Key.Left] = false;
                    break;
                case Keys.Up:
                    keyDown[(int)Key.Up] = false;
                    break;
                case Keys.Right:
                    keyDown[(int)Key.Right] = false;
                    break;
                case Keys.Down:
                    keyDown[(int)Key.Down] = false;
                    break;
                default:
                    break;
            }
        }

        private void SimOptions_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    keyDown[(int)Key.Left] = true;
                    break;
                case Keys.Up:
                    keyDown[(int)Key.Up] = true;
                    break;
                case Keys.Right:
                    keyDown[(int)Key.Right] = true;
                    break;
                case Keys.Down:
                    keyDown[(int)Key.Down] = true;
                    break;
                default:
                    break;
            }
        }

        private void SimOptions_Deselecting(object sender, TabControlCancelEventArgs e)
        {
            if (SimOptions.SelectedTab == EnvironmentPage) SaveEnvBttn_Click(sender, e);
            else if (SimOptions.SelectedTab == RobotPage) SaveRobotBttn_Click(sender, e);
            else if (SimOptions.SelectedTab == SensorPage) SaveSensorBttn_Click(sender, e);
            else if (SimOptions.SelectedTab == ParticlePage) SaveParticleBttn_Click(sender, e);
        }

        private void ParticleList_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (!SimulationOn) return;
            MapPanel.Refresh();
        }

    }

    
}

