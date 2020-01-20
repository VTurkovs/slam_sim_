using KdTree;
using KdTree.Math;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using static slam_sim_.Simulation.Common;

namespace slam_sim_.Simulation
{
    public struct ColorARGB
    {
        public byte B;
        public byte G;
        public byte R;
        public byte A;

        public ColorARGB(Color color)
        {
            A = color.A;
            R = color.R;
            G = color.G;
            B = color.B;
        }

        public ColorARGB(byte a, byte r, byte g, byte b)
        {
            A = a;
            R = r;
            G = g;
            B = b;
        }

        public Color ToColor()
        {
            return Color.FromArgb(A, R, G, B);
        }
    }
    class Environment
    {
        private const float occupied = 0.8f;
        private const float free = 0.2f;
        private readonly float l_occ = (float)Math.Log10((double)occupied / (1 - occupied));
        private readonly float l_free = (float)Math.Log10((double)free / (1 - free));
        private readonly float l_occ_f =(float)Math.Log10(0.95/0.05);
        private readonly float l_free_f = (float)Math.Log10(0.05 / 0.95);
        public float[,] Map { get; private set; }
        public float[,] LogOdds { get; private set; }

        public EnvironmentInfo EnvInfo { get; private set; }

        private KdTree<float, int> kdTree;

        public Environment(ref List<List<Point>> obstacles, Pen obstaclePen, EnvironmentInfo envInfo)
        {
            Map = new float[envInfo.Width, envInfo.Height];
            LogOdds = new float[envInfo.Width, envInfo.Height];
            kdTree = new KdTree<float, int>(2, new FloatMath(), AddDuplicateBehavior.Skip);
            EnvInfo = envInfo;

            if (obstacles == null) return;
            Bitmap bitmap = new Bitmap(envInfo.Width, envInfo.Height, PixelFormat.Format32bppPArgb);
            Graphics g = Graphics.FromImage(bitmap);
            foreach (List<Point> line in obstacles)
            {
                if (line == null || line.Count < 2) continue;
                g.DrawLines(obstaclePen, line.ToArray());
            }
            for (int x = 0; x < envInfo.Width; x++)
            {
                for (int y = 0; y < envInfo.Height; y++)
                {
                    LogOdds[x, y] = 0f;
                    //Map[x, y] = 0.5f; // occupied
                    if (bitmap.GetPixel(x, y).ToArgb() != obstaclePen.Color.ToArgb()) continue;
                    kdTree.Add(new[] { (float)x, y }, obstaclePen.Color.ToArgb());
                    Map[x, y] = 1f; // occupied
                    LogOdds[x, y] = 1f;
                }
            }
        }

        public Environment(ref Environment e, bool copyAll = false)
        {
            Map = new float[e.EnvInfo.Width, e.EnvInfo.Height];
            Map.Populate(0.5f, e.EnvInfo.Height, e.EnvInfo.Width);
            LogOdds = new float[e.EnvInfo.Width, e.EnvInfo.Height];
            kdTree = new KdTree<float, int>(2, new FloatMath(), AddDuplicateBehavior.Skip);
            EnvInfo = e.EnvInfo;

            if (!copyAll) return;
            Buffer.BlockCopy(e.Map, 0, Map, 0, e.Map.Length * sizeof(float));
            Buffer.BlockCopy(e.LogOdds, 0, LogOdds, 0, e.LogOdds.Length * sizeof(float));
            foreach (var item in e.kdTree.ToList())
            {
                kdTree.Append(item);
            }
        }

        public unsafe Bitmap GetBitmap(ref Bitmap bitmap)
        {
            //bitmap = new Bitmap(EnvInfo.Width, EnvInfo.Height, PixelFormat.Format32bppPArgb);
            if (bitmap == null) return null;

            Bitmap Image = new Bitmap(EnvInfo.Width, EnvInfo.Height);
            BitmapData bitmapData = Image.LockBits(
                new Rectangle(0, 0, EnvInfo.Width, EnvInfo.Height),
                ImageLockMode.ReadWrite,
                PixelFormat.Format32bppArgb
            );
            ColorARGB* startingPosition = (ColorARGB*)bitmapData.Scan0;


            for (int i = 0; i < EnvInfo.Width; i++)
                for (int j = 0; j < EnvInfo.Height; j++)
                {
                    double color = Map[j, i];
                    byte rgb = (byte)(color * 255);

                    ColorARGB* position = startingPosition + j + i * EnvInfo.Width;
                    position->A = 255;
                    position->R = (byte)(255 - rgb);
                    position->G = (byte)(255 - rgb);
                    position->B = (byte)(255 - rgb);
                }

            Image.UnlockBits(bitmapData);
            return Image;
        }

        public bool IsFree(ref Pose p, double radius)
        {
            if (Map == null || p.X - radius < 0 || p.X + radius >= EnvInfo.Width || p.Y - radius < 0 || p.Y + radius >= EnvInfo.Height) return false;
            KdTreeNode<float, int>[] nodes = kdTree.GetNearestNeighbours(new[] { (float)p.X, (float)p.Y }, 1);
            if (!nodes.Any()) return true;
            return Distance(nodes[0].Point[0], nodes[0].Point[1], p.X, p.Y) >= radius;
        }

        public Pose[] GetPointCloud(ref Sensor s, ref Pose pose)
        {
            Pose[] points = new Pose[s.Meta.SweepAngle];
            double poseCos = Math.Cos(pose.Theta);
            double poseSin = Math.Sin(pose.Theta);
            for (int i = 0; i < s.Meta.SweepAngle; i++)
            {
                bool obstacle = false;
                for (int j = 0; j <= s.Meta.MaxDistance * EnvInfo.Scale; j++)
                {
                    double x1 = j * s.UnitVectors[i].X;
                    double y1 = j * s.UnitVectors[i].Y;
                    double x = pose.X + x1 * poseCos - y1 * poseSin;
                    double y = pose.Y + x1 * poseSin + y1 * poseCos;

                    if (Map == null || x < 0 || x >= EnvInfo.Width || y < 0 || y >= EnvInfo.Height) break;

                    if (Map[(int)x, (int)y] >= occupied) // occupied
                    {
                        points[i] = new Pose(Distance(pose.X, pose.Y, x, y), 0.0, Deg2rad(i));
                        obstacle = true;
                        break;
                    }
                }
                if (!obstacle) points[i] = new Pose(s.Meta.MaxDistance * EnvInfo.Scale, 0.0, Deg2rad(i));
            }
            return points;
        }

        public double SensorModel(ref Sensor s, ref Pose pose, ref Pose[] points)
        {
            double p = 1.0;

            double poseCos = Math.Cos(pose.Theta);
            double poseSin = Math.Sin(pose.Theta);
            double maxDist = EnvInfo.Scale * s.Meta.SigmaHit * 2;
            foreach (Pose point in points)
            {
                // X- distance, theta- angle
                if (point.X == EnvInfo.Scale * s.Meta.MaxDistance) continue;
                // point corresponding to sensor
                double xs = Math.Cos(point.Theta) * point.X;
                double ys = Math.Sin(point.Theta) * point.X;
                // point corresponding to global coord.
                double x = pose.X + xs * poseCos - ys * poseSin;
                double y = pose.Y + xs * poseSin + ys * poseCos;

                int dx = 0; int dy = 0;
                int xInt = (int)x; int yInt = (int)y;
                double dist = 0.0;
                if (!InBounds(xInt + dx, yInt + dy)) continue;
                if (Map[xInt + dx, yInt + dy] >= occupied) goto calcprob;

                int direction = 1;
                int inc = 1;
                while (inc <= maxDist)
                {
                    for (int i = 1; i <= inc; i++)
                    {
                        dx += direction;
                        if (Map[xInt + dx, yInt + dy] < occupied) continue;
                        dist = Distance(0.0, 0.0, dx, dy);
                        goto calcprob;
                    }
                    for (int i = 1; i <= inc; i++)
                    {
                        dy += direction;
                        if (Map[xInt + dx, yInt + dy] < occupied) continue;
                        dist = Distance(0.0, 0.0, dx, dy);
                        goto calcprob;
                    }
                    direction = -direction;
                    inc++;
                }
                dist = maxDist / 2.0;
            calcprob:
                p *= (s.Meta.ZHit * Prob(dist, s.Meta.SigmaHit) + s.Meta.ZRand / s.Meta.ZMax);
            }

            return p;
        }
        
        private bool InBounds(int x, int y) 
        {
            return !(x < 0 || x >= EnvInfo.Width || y < 0 || y >= EnvInfo.Height);
        }
        
        public void UpdateMap(ref Sensor s, ref Pose pose, ref Pose[] points)
        {
            if (LogOdds == null) return;
            double poseCos = Math.Cos(pose.Theta);
            double poseSin = Math.Sin(pose.Theta);
            double minAngleTan = Math.Tan(s.MinAngle);
            double maxAngleTan = Math.Tan(s.MaxAngle);
            for (int dx = 1; dx <= s.Meta.MaxDistance * EnvInfo.Scale; dx++)
            {
                for (int dy = (int)(dx * minAngleTan); dy <= maxAngleTan * dx; dy++)
                {
                    int x = (int)(pose.X + dx * poseCos - dy * poseSin);
                    int y = (int)(pose.Y + dx * poseSin + dy * poseCos);
                    if (!InBounds(x, y)) continue;
                    float l_0 = (float)Math.Log10(Map[x, y] / (1 - Map[x, y]));
                    float l_inv = InverseSensor(x, y, ref pose, ref s, ref points, l_0);
                    LogOdds[x, y] = LogOdds[x, y] + l_inv - l_0;
                    float prevProb = Map[x, y];
                    Map[x, y] = 1f - 1f / (1f + (float)Math.Exp(LogOdds[x, y]));
                    if (Map[x, y] >= occupied) kdTree.Add(new[] { (float)x, y }, 1);
                    else if (Map[x, y] <= free && prevProb >= occupied) kdTree.RemoveAt(new[] { (float)x, y });
                }
            }
        }

        private float InverseSensor(int xi, int yi, ref Pose xt, ref Sensor s, ref Pose[] z, float l_0)
        {
            double r = Distance(xi, yi, xt.X, xt.Y);
            double phi = Rad2deg(Math.Atan2(yi - xt.Y, xi - xt.X) - NormAngle(xt.Theta));
            int k = -1;
            double mindif = s.Meta.SweepAngle;
            for (int i = -s.Meta.SweepAngle / 2; i < s.Meta.SweepAngle / 2; i++)
            {
                double tempdif = Math.Abs(phi - i);
                if (tempdif >= mindif) continue;
                mindif = tempdif;
                k = i + s.Meta.SweepAngle / 2;
            }
            if (k < 0
                || r > Math.Min(s.Meta.MaxDistance* EnvInfo.Scale, z[k].X + EnvInfo.ObstWidth * EnvInfo.Scale / 2.0)
                || mindif > s.Meta.BeamWidth / 2) 
                return l_0;
            if (z[k].X < s.Meta.MaxDistance * EnvInfo.Scale
                && Math.Abs(r - z[k].X) < EnvInfo.ObstWidth * EnvInfo.Scale / 2.0) 
                return l_occ_f;
            if (r <= z[k].X) 
                return l_free_f;
            return l_0;
        }
    }
}
