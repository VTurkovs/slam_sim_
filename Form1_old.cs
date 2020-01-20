using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace slam_sim_
{
    class Pose
    {
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
    enum Key
    {
        Left = 0,
        Up = 1,
        Right = 2,
        Down = 3
    }
    public partial class Form1 : Form
    {
        private double deg2rad(double degrees) { return degrees * Math.PI / 180.0; }
        private double rad2deg(double radians) { return radians / Math.PI * 180.0; }
        private bool simulationOn = false;
        private bool mouseDown = false;
        private List<List<Point>> obstacleList = new List<List<Point>>();
        private int lineCounter = 0;
        Pen obstaclePen = new Pen(Brushes.Black, 5.0f);
        Pen robotPen = new Pen(Brushes.Red, 1.0f);
        Pen particlePen = new Pen(Brushes.Gray, 1.0f);
        bool drawRobot = false;
        Pose robotPose;
        Pose robotPosePrev;
        private Pose[] particles;
        private int particleCount = 0;
        private bool[] keyPressed = { false, false, false, false };
        Random r = new Random();

        public Form1()
        {
            InitializeComponent();
            // Create simulation, robot, sensor, particle set, map
            Random r = new Random();
            Activate();

        }
        

        private void UpdateEnvBttn_Click(object sender, EventArgs e)
        {
            int w = MapPanel.Width;
            int h = MapPanel.Height;

            if (w == decimal.ToInt32(WidthSpinBttn.Value) && h == decimal.ToInt32(HeightSpinBttn.Value)) return;

            MapPanel.Width = decimal.ToInt32(WidthSpinBttn.Value);
            MapPanel.Height = decimal.ToInt32(HeightSpinBttn.Value);
            int dx = MapPanel.Width - w;
            SimOptions.Left += dx;
            ToggleSimBttn.Left += dx;
            MapPanel.Refresh();
            
        }

        private void DefaultEnvBttn_Click(object sender, EventArgs e)
        {
            HeightSpinBttn.Value = HeightSpinBttn.Minimum;
            WidthSpinBttn.Value = WidthSpinBttn.Minimum;
            MapScaleSpinBttn.Value = MapScaleSpinBttn.Minimum;
            DrawStop.Checked = true;
            drawRobot = false;

            MapPanel_Resize(sender, e);
            MapPanel.Refresh();
            UpdateEnvBttn_Click(sender, e);
        }


        private void ToggleSimBttn_Click(object sender, EventArgs e)
        {
            simulationOn = !simulationOn;
        }

        private void MapPanel_Paint(object sender, PaintEventArgs e)
        {
            if (drawRobot)
            {
                int r = decimal.ToInt32(MapScaleSpinBttn.Value * RobotRadiusSpinBttn.Value);
                if (r < 2) r = 2;
                // Get robot position
                e.Graphics.DrawEllipse(robotPen, (float)robotPose.X - r, (float)robotPose.Y - r, 2 * r, 2 * r);
                double x2 = Math.Cos(robotPose.Theta) * r + robotPose.X;
                double y2 = Math.Sin(robotPose.Theta) * r + robotPose.Y;
                e.Graphics.DrawLine(robotPen, (float)robotPose.X, (float)robotPose.Y, (float)x2, (float)y2);

                for (int i = 0; i < particleCount; i++) {
                    e.Graphics.DrawEllipse(particlePen, (float)particles[i].X - 1, (float)particles[i].Y - 1, 2, 2);
                }
            }
            foreach (List<Point> line in obstacleList)
            {
                if (line.Count < 2) continue;
                e.Graphics.DrawLines(obstaclePen, line.ToArray());
            }
        }

        private void MapPanel_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            if (DrawObstacle.Checked) obstacleList.Add(new List<Point>());
            if (DrawRobot.Checked)
            {
                robotPose = new Pose(Convert.ToSingle(e.Location.X), Convert.ToSingle(e.Location.Y), 0);
                drawRobot = true;
                particleCount = decimal.ToInt32(ParticleCountSpinBttn.Value);
                particles = new Pose[particleCount];
                
                for (int i = 0; i < particleCount; i++)
                {
                    particles[i] = new Pose(robotPose.X, robotPose.Y, robotPose.Theta);
                }
                MapPanel.Refresh();
            }
        }
        private void MapPanel_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
            if (DrawObstacle.Checked) lineCounter++;
        }
        private void MapPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (!mouseDown) return;
            if (DrawObstacle.Checked)
            {
                obstacleList[lineCounter].Add(e.Location);
                if (obstacleList[lineCounter].Count < 2) return;
                MapPanel.Refresh();
            }
        }

        private void MapPanel_Resize(object sender, EventArgs e)
        {
            obstacleList = new List<List<Point>>();
            lineCounter = 0;
            drawRobot = false;
        }

        private void UpdateRate_Tick(object sender, EventArgs e)
        {
            if (drawRobot)
            {
                robotPosePrev = new Pose(robotPose.X, robotPose.Y, robotPose.Theta);
                if (keyPressed[(int)Key.Left])
                {
                    robotPose.Theta -= (float)deg2rad(10.0);
                }
                if (keyPressed[(int)Key.Up])
                {
                    robotPose.Y += (float)(10.0 * Math.Sin(robotPose.Theta));
                    robotPose.X += (float)(10.0 * Math.Cos(robotPose.Theta));
                }
                if (keyPressed[(int)Key.Right])
                {
                    robotPose.Theta += (float)deg2rad(10.0);
                }
                if (keyPressed[(int)Key.Down])
                {
                    robotPose.Y -= (float)(10.0 * Math.Sin(robotPose.Theta));
                    robotPose.X -= (float)(10.0 * Math.Cos(robotPose.Theta));
                }
                
                    MoveParticles();
            }

            MapPanel.Refresh();
        }

        private double Sample(double bSquared)
        {
            double b = Math.Sqrt(bSquared);
            double sum = 0.0;
            for (int i = 0; i < 12; i++)
            {
                sum += r.NextDouble() * 2 * b - b;
            }
            return sum * 0.5;
        }
        private void MoveParticles()
        {
            double d_rot_1 = Math.Atan2(robotPose.Y - robotPosePrev.Y, robotPose.X - robotPosePrev.X) - robotPosePrev.Theta;
            double d_trans = Math.Sqrt(Math.Pow(robotPosePrev.Y - robotPose.Y, 2.0) + Math.Pow(robotPosePrev.X - robotPose.X, 2.0));
            double d_rot_2 = robotPose.Theta - robotPosePrev.Theta - d_rot_1;

            double d_rot_1_s = Math.Pow(d_rot_1, 2.0);
            double d_trans_s = Math.Pow(d_trans, 2.0);
            double d_rot_2_s = Math.Pow(d_rot_2, 2.0);

            double a1 = (double)a1SpinBttn.Value;
            double a2 = (double)a1SpinBttn.Value;
            double a3 = (double)a1SpinBttn.Value;
            double a4 = (double)a1SpinBttn.Value;
            for (int i = 0; i < particleCount; i++)
            {
                double d_rot_1_p = d_rot_1 - Sample(a1 * d_rot_1_s + a2 * d_trans_s);
                double d_trans_p = d_trans - Sample(a3 * d_trans_s + a4 * d_rot_1_s + a4 * d_rot_2_s);
                double d_rot_2_p = d_rot_2 - Sample(a1 * d_rot_2_s + a2 * d_trans_s);
                particles[i].X += d_trans_p * Math.Cos(particles[i].Theta + d_rot_1_p);
                particles[i].Y += d_trans_p * Math.Sin(particles[i].Theta + d_rot_1_p);
                particles[i].Theta += d_rot_1_p + d_rot_2_p;
            }
        }

        private void SimOptions_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    keyPressed[(int)Key.Left] = false;
                    break;
                case Keys.Up:
                    keyPressed[(int)Key.Up] = false;
                    break;
                case Keys.Right:
                    keyPressed[(int)Key.Right] = false;
                    break;
                case Keys.Down:
                    keyPressed[(int)Key.Down] = false;
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
                    keyPressed[(int)Key.Left] = true;
                    break;
                case Keys.Up:
                    keyPressed[(int)Key.Up] = true;
                    break;
                case Keys.Right:
                    keyPressed[(int)Key.Right] = true;
                    break;
                case Keys.Down:
                    keyPressed[(int)Key.Down] = true;
                    break;
                default:
                    break;
            }
        }

        private void MapPanel_Click(object sender, EventArgs e)
        {
            MapPanel.Select();
        }
    }
}
