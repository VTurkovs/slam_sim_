using System.Windows.Forms;
using System.ComponentModel;
using System.Linq;
namespace slam_sim_
{

    public class MyTabControl : TabControl
    {
        public MyTabControl()
        {
            SetStyle(ControlStyles.Selectable, true);
            bool s = CanSelect;
            //if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            //    SetStyle(ControlStyles.UserMouse, true);
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            var filteredKeys = new Keys[]{(Keys.Control | Keys.Tab),
            (Keys.Control | Keys.Shift | Keys.Tab),
            Keys.Left, Keys.Right, Keys.Home, Keys.End};
            if (filteredKeys.Contains(keyData))
                return true;
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }

    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.MapPanel = new System.Windows.Forms.Panel();
            this.SimOptions = new slam_sim_.MyTabControl();
            this.EnvironmentPage = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.MapScaleSpinBttn = new System.Windows.Forms.NumericUpDown();
            this.DefaultEnvBttn = new System.Windows.Forms.Button();
            this.DrawOptionsFrame = new System.Windows.Forms.GroupBox();
            this.DrawStop = new System.Windows.Forms.RadioButton();
            this.DrawRobot = new System.Windows.Forms.RadioButton();
            this.DrawObstacle = new System.Windows.Forms.RadioButton();
            this.GridSizeFrame = new System.Windows.Forms.GroupBox();
            this.WidthSpinBttn = new System.Windows.Forms.NumericUpDown();
            this.HeightLbl = new System.Windows.Forms.Label();
            this.HeightSpinBttn = new System.Windows.Forms.NumericUpDown();
            this.WidthLbl = new System.Windows.Forms.Label();
            this.UpdateEnvBttn = new System.Windows.Forms.Button();
            this.RobotPage = new System.Windows.Forms.TabPage();
            this.DefaultRobotBttn = new System.Windows.Forms.Button();
            this.UpdateRobotBttn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.RobotRadiusLbl = new System.Windows.Forms.Label();
            this.numericUpDown5 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown4 = new System.Windows.Forms.NumericUpDown();
            this.RobotRadiusSpinBttn = new System.Windows.Forms.NumericUpDown();
            this.MotionErrFrame = new System.Windows.Forms.GroupBox();
            this.a4Lbl = new System.Windows.Forms.Label();
            this.a3Lbl = new System.Windows.Forms.Label();
            this.a2Lbl = new System.Windows.Forms.Label();
            this.a1Lbl = new System.Windows.Forms.Label();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.a1SpinBttn = new System.Windows.Forms.NumericUpDown();
            this.SensorPage = new System.Windows.Forms.TabPage();
            this.SensorDistanceLbl = new System.Windows.Forms.Label();
            this.SensorAngleLbl = new System.Windows.Forms.Label();
            this.SensorDistanceSpinBttn = new System.Windows.Forms.NumericUpDown();
            this.SensorAngleSpinBttn = new System.Windows.Forms.NumericUpDown();
            this.DefaultSensorBttn = new System.Windows.Forms.Button();
            this.UpdateSensorBttn = new System.Windows.Forms.Button();
            this.ParticlePage = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.DefaultParticleBttn = new System.Windows.Forms.Button();
            this.UpdateParticleBttn = new System.Windows.Forms.Button();
            this.ResampleMethFrame = new System.Windows.Forms.GroupBox();
            this.StratifiedResample = new System.Windows.Forms.RadioButton();
            this.SystematicResample = new System.Windows.Forms.RadioButton();
            this.MultinomialResample = new System.Windows.Forms.RadioButton();
            this.ParticleCountLbl = new System.Windows.Forms.Label();
            this.ParticleCountSpinBttn = new System.Windows.Forms.NumericUpDown();
            this.ToggleSimBttn = new System.Windows.Forms.Button();
            this.UpdateRate = new System.Windows.Forms.Timer(this.components);
            this.SimOptions.SuspendLayout();
            this.EnvironmentPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MapScaleSpinBttn)).BeginInit();
            this.DrawOptionsFrame.SuspendLayout();
            this.GridSizeFrame.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WidthSpinBttn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HeightSpinBttn)).BeginInit();
            this.RobotPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RobotRadiusSpinBttn)).BeginInit();
            this.MotionErrFrame.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.a1SpinBttn)).BeginInit();
            this.SensorPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SensorDistanceSpinBttn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SensorAngleSpinBttn)).BeginInit();
            this.ParticlePage.SuspendLayout();
            this.ResampleMethFrame.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ParticleCountSpinBttn)).BeginInit();
            this.SuspendLayout();
            // 
            // MapPanel
            // 
            this.MapPanel.BackColor = System.Drawing.SystemColors.Window;
            this.MapPanel.Location = new System.Drawing.Point(10, 10);
            this.MapPanel.Name = "MapPanel";
            this.MapPanel.Size = new System.Drawing.Size(500, 500);
            this.MapPanel.TabIndex = 0;
            this.MapPanel.Click += new System.EventHandler(this.MapPanel_Click);
            this.MapPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.MapPanel_Paint);
            this.MapPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MapPanel_MouseDown);
            this.MapPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MapPanel_MouseMove);
            this.MapPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MapPanel_MouseUp);
            this.MapPanel.Resize += new System.EventHandler(this.MapPanel_Resize);
            // 
            // SimOptions
            // 
            this.SimOptions.Controls.Add(this.EnvironmentPage);
            this.SimOptions.Controls.Add(this.RobotPage);
            this.SimOptions.Controls.Add(this.SensorPage);
            this.SimOptions.Controls.Add(this.ParticlePage);
            this.SimOptions.Location = new System.Drawing.Point(530, 10);
            this.SimOptions.Name = "SimOptions";
            this.SimOptions.SelectedIndex = 0;
            this.SimOptions.Size = new System.Drawing.Size(332, 511);
            this.SimOptions.TabIndex = 1;
            this.SimOptions.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SimOptions_KeyUp);
            this.SimOptions.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.SimOptions_PreviewKeyDown);
            // 
            // EnvironmentPage
            // 
            this.EnvironmentPage.Controls.Add(this.label1);
            this.EnvironmentPage.Controls.Add(this.MapScaleSpinBttn);
            this.EnvironmentPage.Controls.Add(this.DefaultEnvBttn);
            this.EnvironmentPage.Controls.Add(this.DrawOptionsFrame);
            this.EnvironmentPage.Controls.Add(this.GridSizeFrame);
            this.EnvironmentPage.Controls.Add(this.UpdateEnvBttn);
            this.EnvironmentPage.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.EnvironmentPage.Location = new System.Drawing.Point(4, 22);
            this.EnvironmentPage.Name = "EnvironmentPage";
            this.EnvironmentPage.Padding = new System.Windows.Forms.Padding(3);
            this.EnvironmentPage.Size = new System.Drawing.Size(324, 485);
            this.EnvironmentPage.TabIndex = 1;
            this.EnvironmentPage.Text = "Environment";
            this.EnvironmentPage.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 231);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Scale (cells to meters):";
            // 
            // MapScaleSpinBttn
            // 
            this.MapScaleSpinBttn.Location = new System.Drawing.Point(180, 229);
            this.MapScaleSpinBttn.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.MapScaleSpinBttn.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.MapScaleSpinBttn.Name = "MapScaleSpinBttn";
            this.MapScaleSpinBttn.Size = new System.Drawing.Size(74, 20);
            this.MapScaleSpinBttn.TabIndex = 7;
            this.MapScaleSpinBttn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.MapScaleSpinBttn.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // DefaultEnvBttn
            // 
            this.DefaultEnvBttn.Location = new System.Drawing.Point(6, 444);
            this.DefaultEnvBttn.Name = "DefaultEnvBttn";
            this.DefaultEnvBttn.Size = new System.Drawing.Size(129, 35);
            this.DefaultEnvBttn.TabIndex = 6;
            this.DefaultEnvBttn.Text = "Default Environment";
            this.DefaultEnvBttn.UseVisualStyleBackColor = true;
            this.DefaultEnvBttn.Click += new System.EventHandler(this.DefaultEnvBttn_Click);
            // 
            // DrawOptionsFrame
            // 
            this.DrawOptionsFrame.Controls.Add(this.DrawStop);
            this.DrawOptionsFrame.Controls.Add(this.DrawRobot);
            this.DrawOptionsFrame.Controls.Add(this.DrawObstacle);
            this.DrawOptionsFrame.Location = new System.Drawing.Point(17, 113);
            this.DrawOptionsFrame.Name = "DrawOptionsFrame";
            this.DrawOptionsFrame.Size = new System.Drawing.Size(285, 90);
            this.DrawOptionsFrame.TabIndex = 5;
            this.DrawOptionsFrame.TabStop = false;
            this.DrawOptionsFrame.Text = "Draw";
            // 
            // DrawStop
            // 
            this.DrawStop.AutoSize = true;
            this.DrawStop.Checked = true;
            this.DrawStop.Location = new System.Drawing.Point(107, 58);
            this.DrawStop.Name = "DrawStop";
            this.DrawStop.Size = new System.Drawing.Size(86, 17);
            this.DrawStop.TabIndex = 2;
            this.DrawStop.TabStop = true;
            this.DrawStop.Text = "StopDrawing";
            this.DrawStop.UseVisualStyleBackColor = false;
            // 
            // DrawRobot
            // 
            this.DrawRobot.AutoSize = true;
            this.DrawRobot.Location = new System.Drawing.Point(179, 35);
            this.DrawRobot.Name = "DrawRobot";
            this.DrawRobot.Size = new System.Drawing.Size(82, 17);
            this.DrawRobot.TabIndex = 1;
            this.DrawRobot.Text = "Draw Robot";
            this.DrawRobot.UseVisualStyleBackColor = true;
            // 
            // DrawObstacle
            // 
            this.DrawObstacle.AutoSize = true;
            this.DrawObstacle.Location = new System.Drawing.Point(18, 35);
            this.DrawObstacle.Name = "DrawObstacle";
            this.DrawObstacle.Size = new System.Drawing.Size(100, 17);
            this.DrawObstacle.TabIndex = 0;
            this.DrawObstacle.Text = "Draw Obstacles";
            this.DrawObstacle.UseVisualStyleBackColor = true;
            // 
            // GridSizeFrame
            // 
            this.GridSizeFrame.Controls.Add(this.WidthSpinBttn);
            this.GridSizeFrame.Controls.Add(this.HeightLbl);
            this.GridSizeFrame.Controls.Add(this.HeightSpinBttn);
            this.GridSizeFrame.Controls.Add(this.WidthLbl);
            this.GridSizeFrame.Location = new System.Drawing.Point(17, 19);
            this.GridSizeFrame.Name = "GridSizeFrame";
            this.GridSizeFrame.Size = new System.Drawing.Size(277, 70);
            this.GridSizeFrame.TabIndex = 4;
            this.GridSizeFrame.TabStop = false;
            this.GridSizeFrame.Text = "Grid size";
            // 
            // WidthSpinBttn
            // 
            this.WidthSpinBttn.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.WidthSpinBttn.Location = new System.Drawing.Point(185, 31);
            this.WidthSpinBttn.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.WidthSpinBttn.Minimum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.WidthSpinBttn.Name = "WidthSpinBttn";
            this.WidthSpinBttn.Size = new System.Drawing.Size(76, 20);
            this.WidthSpinBttn.TabIndex = 1;
            this.WidthSpinBttn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.WidthSpinBttn.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // HeightLbl
            // 
            this.HeightLbl.AutoSize = true;
            this.HeightLbl.Location = new System.Drawing.Point(15, 33);
            this.HeightLbl.Name = "HeightLbl";
            this.HeightLbl.Size = new System.Drawing.Size(41, 13);
            this.HeightLbl.TabIndex = 2;
            this.HeightLbl.Text = "Height:";
            // 
            // HeightSpinBttn
            // 
            this.HeightSpinBttn.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.HeightSpinBttn.Location = new System.Drawing.Point(59, 31);
            this.HeightSpinBttn.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.HeightSpinBttn.Minimum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.HeightSpinBttn.Name = "HeightSpinBttn";
            this.HeightSpinBttn.Size = new System.Drawing.Size(76, 20);
            this.HeightSpinBttn.TabIndex = 1;
            this.HeightSpinBttn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.HeightSpinBttn.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // WidthLbl
            // 
            this.WidthLbl.AutoSize = true;
            this.WidthLbl.Location = new System.Drawing.Point(141, 33);
            this.WidthLbl.Name = "WidthLbl";
            this.WidthLbl.Size = new System.Drawing.Size(38, 13);
            this.WidthLbl.TabIndex = 2;
            this.WidthLbl.Text = "Width:";
            // 
            // UpdateEnvBttn
            // 
            this.UpdateEnvBttn.Location = new System.Drawing.Point(188, 445);
            this.UpdateEnvBttn.Name = "UpdateEnvBttn";
            this.UpdateEnvBttn.Size = new System.Drawing.Size(130, 34);
            this.UpdateEnvBttn.TabIndex = 0;
            this.UpdateEnvBttn.Text = "Update Environment";
            this.UpdateEnvBttn.UseVisualStyleBackColor = true;
            this.UpdateEnvBttn.Click += new System.EventHandler(this.UpdateEnvBttn_Click);
            // 
            // RobotPage
            // 
            this.RobotPage.Controls.Add(this.DefaultRobotBttn);
            this.RobotPage.Controls.Add(this.UpdateRobotBttn);
            this.RobotPage.Controls.Add(this.label3);
            this.RobotPage.Controls.Add(this.label2);
            this.RobotPage.Controls.Add(this.RobotRadiusLbl);
            this.RobotPage.Controls.Add(this.numericUpDown5);
            this.RobotPage.Controls.Add(this.numericUpDown4);
            this.RobotPage.Controls.Add(this.RobotRadiusSpinBttn);
            this.RobotPage.Controls.Add(this.MotionErrFrame);
            this.RobotPage.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.RobotPage.Location = new System.Drawing.Point(4, 22);
            this.RobotPage.Name = "RobotPage";
            this.RobotPage.Padding = new System.Windows.Forms.Padding(3);
            this.RobotPage.Size = new System.Drawing.Size(324, 485);
            this.RobotPage.TabIndex = 1;
            this.RobotPage.Text = "Robot";
            this.RobotPage.UseVisualStyleBackColor = true;
            // 
            // DefaultRobotBttn
            // 
            this.DefaultRobotBttn.Location = new System.Drawing.Point(6, 444);
            this.DefaultRobotBttn.Name = "DefaultRobotBttn";
            this.DefaultRobotBttn.Size = new System.Drawing.Size(129, 35);
            this.DefaultRobotBttn.TabIndex = 8;
            this.DefaultRobotBttn.Text = "Default Robot";
            this.DefaultRobotBttn.UseVisualStyleBackColor = true;
            // 
            // UpdateRobotBttn
            // 
            this.UpdateRobotBttn.Location = new System.Drawing.Point(188, 445);
            this.UpdateRobotBttn.Name = "UpdateRobotBttn";
            this.UpdateRobotBttn.Size = new System.Drawing.Size(130, 34);
            this.UpdateRobotBttn.TabIndex = 7;
            this.UpdateRobotBttn.Text = "Update Robot";
            this.UpdateRobotBttn.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 305);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Robot radius (m):";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 258);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Robot step (m):";
            // 
            // RobotRadiusLbl
            // 
            this.RobotRadiusLbl.AutoSize = true;
            this.RobotRadiusLbl.Location = new System.Drawing.Point(44, 217);
            this.RobotRadiusLbl.Name = "RobotRadiusLbl";
            this.RobotRadiusLbl.Size = new System.Drawing.Size(87, 13);
            this.RobotRadiusLbl.TabIndex = 3;
            this.RobotRadiusLbl.Text = "Robot radius (m):";
            // 
            // numericUpDown5
            // 
            this.numericUpDown5.DecimalPlaces = 1;
            this.numericUpDown5.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown5.Location = new System.Drawing.Point(134, 303);
            this.numericUpDown5.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown5.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown5.Name = "numericUpDown5";
            this.numericUpDown5.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown5.TabIndex = 2;
            this.numericUpDown5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown5.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // numericUpDown4
            // 
            this.numericUpDown4.DecimalPlaces = 1;
            this.numericUpDown4.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown4.Location = new System.Drawing.Point(134, 256);
            this.numericUpDown4.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown4.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown4.Name = "numericUpDown4";
            this.numericUpDown4.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown4.TabIndex = 2;
            this.numericUpDown4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown4.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // RobotRadiusSpinBttn
            // 
            this.RobotRadiusSpinBttn.DecimalPlaces = 1;
            this.RobotRadiusSpinBttn.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.RobotRadiusSpinBttn.Location = new System.Drawing.Point(134, 215);
            this.RobotRadiusSpinBttn.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.RobotRadiusSpinBttn.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.RobotRadiusSpinBttn.Name = "RobotRadiusSpinBttn";
            this.RobotRadiusSpinBttn.Size = new System.Drawing.Size(120, 20);
            this.RobotRadiusSpinBttn.TabIndex = 2;
            this.RobotRadiusSpinBttn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.RobotRadiusSpinBttn.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // MotionErrFrame
            // 
            this.MotionErrFrame.Controls.Add(this.a4Lbl);
            this.MotionErrFrame.Controls.Add(this.a3Lbl);
            this.MotionErrFrame.Controls.Add(this.a2Lbl);
            this.MotionErrFrame.Controls.Add(this.a1Lbl);
            this.MotionErrFrame.Controls.Add(this.numericUpDown3);
            this.MotionErrFrame.Controls.Add(this.numericUpDown2);
            this.MotionErrFrame.Controls.Add(this.numericUpDown1);
            this.MotionErrFrame.Controls.Add(this.a1SpinBttn);
            this.MotionErrFrame.Location = new System.Drawing.Point(22, 26);
            this.MotionErrFrame.Name = "MotionErrFrame";
            this.MotionErrFrame.Size = new System.Drawing.Size(284, 164);
            this.MotionErrFrame.TabIndex = 1;
            this.MotionErrFrame.TabStop = false;
            this.MotionErrFrame.Text = "Motion errors";
            // 
            // a4Lbl
            // 
            this.a4Lbl.AutoSize = true;
            this.a4Lbl.Location = new System.Drawing.Point(59, 140);
            this.a4Lbl.Name = "a4Lbl";
            this.a4Lbl.Size = new System.Drawing.Size(19, 13);
            this.a4Lbl.TabIndex = 1;
            this.a4Lbl.Text = "a4";
            // 
            // a3Lbl
            // 
            this.a3Lbl.AutoSize = true;
            this.a3Lbl.Location = new System.Drawing.Point(59, 107);
            this.a3Lbl.Name = "a3Lbl";
            this.a3Lbl.Size = new System.Drawing.Size(19, 13);
            this.a3Lbl.TabIndex = 1;
            this.a3Lbl.Text = "a3";
            // 
            // a2Lbl
            // 
            this.a2Lbl.AutoSize = true;
            this.a2Lbl.Location = new System.Drawing.Point(59, 72);
            this.a2Lbl.Name = "a2Lbl";
            this.a2Lbl.Size = new System.Drawing.Size(19, 13);
            this.a2Lbl.TabIndex = 1;
            this.a2Lbl.Text = "a2";
            // 
            // a1Lbl
            // 
            this.a1Lbl.AutoSize = true;
            this.a1Lbl.Location = new System.Drawing.Point(59, 34);
            this.a1Lbl.Name = "a1Lbl";
            this.a1Lbl.Size = new System.Drawing.Size(19, 13);
            this.a1Lbl.TabIndex = 1;
            this.a1Lbl.Text = "a1";
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.Location = new System.Drawing.Point(112, 138);
            this.numericUpDown3.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown3.TabIndex = 0;
            this.numericUpDown3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(112, 105);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown2.TabIndex = 0;
            this.numericUpDown2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(112, 70);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown1.TabIndex = 0;
            this.numericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // a1SpinBttn
            // 
            this.a1SpinBttn.Location = new System.Drawing.Point(112, 32);
            this.a1SpinBttn.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.a1SpinBttn.Name = "a1SpinBttn";
            this.a1SpinBttn.Size = new System.Drawing.Size(120, 20);
            this.a1SpinBttn.TabIndex = 0;
            this.a1SpinBttn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // SensorPage
            // 
            this.SensorPage.Controls.Add(this.SensorDistanceLbl);
            this.SensorPage.Controls.Add(this.SensorAngleLbl);
            this.SensorPage.Controls.Add(this.SensorDistanceSpinBttn);
            this.SensorPage.Controls.Add(this.SensorAngleSpinBttn);
            this.SensorPage.Controls.Add(this.DefaultSensorBttn);
            this.SensorPage.Controls.Add(this.UpdateSensorBttn);
            this.SensorPage.Location = new System.Drawing.Point(4, 22);
            this.SensorPage.Name = "SensorPage";
            this.SensorPage.Padding = new System.Windows.Forms.Padding(3);
            this.SensorPage.Size = new System.Drawing.Size(324, 485);
            this.SensorPage.TabIndex = 2;
            this.SensorPage.Text = "Sensor";
            this.SensorPage.UseVisualStyleBackColor = true;
            // 
            // SensorDistanceLbl
            // 
            this.SensorDistanceLbl.AutoSize = true;
            this.SensorDistanceLbl.Location = new System.Drawing.Point(44, 100);
            this.SensorDistanceLbl.Name = "SensorDistanceLbl";
            this.SensorDistanceLbl.Size = new System.Drawing.Size(103, 13);
            this.SensorDistanceLbl.TabIndex = 12;
            this.SensorDistanceLbl.Text = "Sensor distance (m):";
            // 
            // SensorAngleLbl
            // 
            this.SensorAngleLbl.AutoSize = true;
            this.SensorAngleLbl.Location = new System.Drawing.Point(44, 53);
            this.SensorAngleLbl.Name = "SensorAngleLbl";
            this.SensorAngleLbl.Size = new System.Drawing.Size(72, 13);
            this.SensorAngleLbl.TabIndex = 12;
            this.SensorAngleLbl.Text = "Sensor angle:";
            // 
            // SensorDistanceSpinBttn
            // 
            this.SensorDistanceSpinBttn.Location = new System.Drawing.Point(150, 100);
            this.SensorDistanceSpinBttn.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.SensorDistanceSpinBttn.Name = "SensorDistanceSpinBttn";
            this.SensorDistanceSpinBttn.Size = new System.Drawing.Size(120, 20);
            this.SensorDistanceSpinBttn.TabIndex = 11;
            this.SensorDistanceSpinBttn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.SensorDistanceSpinBttn.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // SensorAngleSpinBttn
            // 
            this.SensorAngleSpinBttn.Location = new System.Drawing.Point(150, 53);
            this.SensorAngleSpinBttn.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.SensorAngleSpinBttn.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.SensorAngleSpinBttn.Name = "SensorAngleSpinBttn";
            this.SensorAngleSpinBttn.Size = new System.Drawing.Size(120, 20);
            this.SensorAngleSpinBttn.TabIndex = 11;
            this.SensorAngleSpinBttn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.SensorAngleSpinBttn.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // DefaultSensorBttn
            // 
            this.DefaultSensorBttn.Location = new System.Drawing.Point(6, 444);
            this.DefaultSensorBttn.Name = "DefaultSensorBttn";
            this.DefaultSensorBttn.Size = new System.Drawing.Size(129, 35);
            this.DefaultSensorBttn.TabIndex = 10;
            this.DefaultSensorBttn.Text = "Default Sensor";
            this.DefaultSensorBttn.UseVisualStyleBackColor = true;
            // 
            // UpdateSensorBttn
            // 
            this.UpdateSensorBttn.Location = new System.Drawing.Point(188, 445);
            this.UpdateSensorBttn.Name = "UpdateSensorBttn";
            this.UpdateSensorBttn.Size = new System.Drawing.Size(130, 34);
            this.UpdateSensorBttn.TabIndex = 9;
            this.UpdateSensorBttn.Text = "Update Sensor";
            this.UpdateSensorBttn.UseVisualStyleBackColor = true;
            // 
            // ParticlePage
            // 
            this.ParticlePage.Controls.Add(this.label4);
            this.ParticlePage.Controls.Add(this.DefaultParticleBttn);
            this.ParticlePage.Controls.Add(this.UpdateParticleBttn);
            this.ParticlePage.Controls.Add(this.ResampleMethFrame);
            this.ParticlePage.Controls.Add(this.ParticleCountLbl);
            this.ParticlePage.Controls.Add(this.ParticleCountSpinBttn);
            this.ParticlePage.Location = new System.Drawing.Point(4, 22);
            this.ParticlePage.Name = "ParticlePage";
            this.ParticlePage.Padding = new System.Windows.Forms.Padding(3);
            this.ParticlePage.Size = new System.Drawing.Size(324, 485);
            this.ParticlePage.TabIndex = 3;
            this.ParticlePage.Text = "Particles";
            this.ParticlePage.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(47, 302);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(19, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "kk";
            // 
            // DefaultParticleBttn
            // 
            this.DefaultParticleBttn.Location = new System.Drawing.Point(6, 444);
            this.DefaultParticleBttn.Name = "DefaultParticleBttn";
            this.DefaultParticleBttn.Size = new System.Drawing.Size(129, 35);
            this.DefaultParticleBttn.TabIndex = 12;
            this.DefaultParticleBttn.Text = "Default Particle";
            this.DefaultParticleBttn.UseVisualStyleBackColor = true;
            // 
            // UpdateParticleBttn
            // 
            this.UpdateParticleBttn.Location = new System.Drawing.Point(188, 445);
            this.UpdateParticleBttn.Name = "UpdateParticleBttn";
            this.UpdateParticleBttn.Size = new System.Drawing.Size(130, 34);
            this.UpdateParticleBttn.TabIndex = 11;
            this.UpdateParticleBttn.Text = "Update Particle";
            this.UpdateParticleBttn.UseVisualStyleBackColor = true;
            // 
            // ResampleMethFrame
            // 
            this.ResampleMethFrame.Controls.Add(this.StratifiedResample);
            this.ResampleMethFrame.Controls.Add(this.SystematicResample);
            this.ResampleMethFrame.Controls.Add(this.MultinomialResample);
            this.ResampleMethFrame.Location = new System.Drawing.Point(21, 85);
            this.ResampleMethFrame.Name = "ResampleMethFrame";
            this.ResampleMethFrame.Size = new System.Drawing.Size(282, 148);
            this.ResampleMethFrame.TabIndex = 2;
            this.ResampleMethFrame.TabStop = false;
            this.ResampleMethFrame.Text = "Resample method";
            // 
            // StratifiedResample
            // 
            this.StratifiedResample.AutoSize = true;
            this.StratifiedResample.Location = new System.Drawing.Point(89, 99);
            this.StratifiedResample.Name = "StratifiedResample";
            this.StratifiedResample.Size = new System.Drawing.Size(66, 17);
            this.StratifiedResample.TabIndex = 0;
            this.StratifiedResample.Text = "Stratified";
            this.StratifiedResample.UseVisualStyleBackColor = true;
            // 
            // SystematicResample
            // 
            this.SystematicResample.AutoSize = true;
            this.SystematicResample.Location = new System.Drawing.Point(89, 65);
            this.SystematicResample.Name = "SystematicResample";
            this.SystematicResample.Size = new System.Drawing.Size(76, 17);
            this.SystematicResample.TabIndex = 0;
            this.SystematicResample.Text = "Systematic";
            this.SystematicResample.UseVisualStyleBackColor = true;
            // 
            // MultinomialResample
            // 
            this.MultinomialResample.AutoSize = true;
            this.MultinomialResample.Checked = true;
            this.MultinomialResample.Location = new System.Drawing.Point(89, 32);
            this.MultinomialResample.Name = "MultinomialResample";
            this.MultinomialResample.Size = new System.Drawing.Size(77, 17);
            this.MultinomialResample.TabIndex = 0;
            this.MultinomialResample.TabStop = true;
            this.MultinomialResample.Text = "Multinomial";
            this.MultinomialResample.UseVisualStyleBackColor = true;
            // 
            // ParticleCountLbl
            // 
            this.ParticleCountLbl.AutoSize = true;
            this.ParticleCountLbl.Location = new System.Drawing.Point(63, 42);
            this.ParticleCountLbl.Name = "ParticleCountLbl";
            this.ParticleCountLbl.Size = new System.Drawing.Size(75, 13);
            this.ParticleCountLbl.TabIndex = 1;
            this.ParticleCountLbl.Text = "Particle count:";
            // 
            // ParticleCountSpinBttn
            // 
            this.ParticleCountSpinBttn.Location = new System.Drawing.Point(171, 40);
            this.ParticleCountSpinBttn.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.ParticleCountSpinBttn.Name = "ParticleCountSpinBttn";
            this.ParticleCountSpinBttn.Size = new System.Drawing.Size(84, 20);
            this.ParticleCountSpinBttn.TabIndex = 0;
            this.ParticleCountSpinBttn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ParticleCountSpinBttn.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // ToggleSimBttn
            // 
            this.ToggleSimBttn.Location = new System.Drawing.Point(600, 538);
            this.ToggleSimBttn.Name = "ToggleSimBttn";
            this.ToggleSimBttn.Size = new System.Drawing.Size(188, 43);
            this.ToggleSimBttn.TabIndex = 2;
            this.ToggleSimBttn.Text = "Start/Stop Simulation";
            this.ToggleSimBttn.UseVisualStyleBackColor = true;
            this.ToggleSimBttn.Click += new System.EventHandler(this.ToggleSimBttn_Click);
            // 
            // UpdateRate
            // 
            this.UpdateRate.Enabled = true;
            this.UpdateRate.Tick += new System.EventHandler(this.UpdateRate_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(881, 593);
            this.Controls.Add(this.ToggleSimBttn);
            this.Controls.Add(this.SimOptions);
            this.Controls.Add(this.MapPanel);
            this.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "                                     ";
            this.SimOptions.ResumeLayout(false);
            this.EnvironmentPage.ResumeLayout(false);
            this.EnvironmentPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MapScaleSpinBttn)).EndInit();
            this.DrawOptionsFrame.ResumeLayout(false);
            this.DrawOptionsFrame.PerformLayout();
            this.GridSizeFrame.ResumeLayout(false);
            this.GridSizeFrame.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WidthSpinBttn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HeightSpinBttn)).EndInit();
            this.RobotPage.ResumeLayout(false);
            this.RobotPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RobotRadiusSpinBttn)).EndInit();
            this.MotionErrFrame.ResumeLayout(false);
            this.MotionErrFrame.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.a1SpinBttn)).EndInit();
            this.SensorPage.ResumeLayout(false);
            this.SensorPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SensorDistanceSpinBttn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SensorAngleSpinBttn)).EndInit();
            this.ParticlePage.ResumeLayout(false);
            this.ParticlePage.PerformLayout();
            this.ResampleMethFrame.ResumeLayout(false);
            this.ResampleMethFrame.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ParticleCountSpinBttn)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel MapPanel;
        private System.Windows.Forms.TabPage EnvironmentPage;
        private System.Windows.Forms.TabPage RobotPage;
        private System.Windows.Forms.Button ToggleSimBttn;
        private System.Windows.Forms.TabPage SensorPage;
        private System.Windows.Forms.Button UpdateEnvBttn;
        private System.Windows.Forms.NumericUpDown WidthSpinBttn;
        private System.Windows.Forms.Label WidthLbl;
        private System.Windows.Forms.NumericUpDown HeightSpinBttn;
        private System.Windows.Forms.Label HeightLbl;
        private System.Windows.Forms.GroupBox DrawOptionsFrame;
        private System.Windows.Forms.RadioButton DrawStop;
        private System.Windows.Forms.RadioButton DrawRobot;
        private System.Windows.Forms.RadioButton DrawObstacle;
        private System.Windows.Forms.GroupBox GridSizeFrame;
        private System.Windows.Forms.Button DefaultEnvBttn;
        private System.Windows.Forms.TabPage ParticlePage;
        private System.Windows.Forms.NumericUpDown MapScaleSpinBttn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label RobotRadiusLbl;
        private System.Windows.Forms.NumericUpDown RobotRadiusSpinBttn;
        private System.Windows.Forms.GroupBox MotionErrFrame;
        private System.Windows.Forms.Label a4Lbl;
        private System.Windows.Forms.Label a3Lbl;
        private System.Windows.Forms.Label a2Lbl;
        private System.Windows.Forms.Label a1Lbl;
        private System.Windows.Forms.NumericUpDown numericUpDown3;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.NumericUpDown a1SpinBttn;
        private System.Windows.Forms.Label ParticleCountLbl;
        private System.Windows.Forms.NumericUpDown ParticleCountSpinBttn;
        private System.Windows.Forms.GroupBox ResampleMethFrame;
        private System.Windows.Forms.RadioButton StratifiedResample;
        private System.Windows.Forms.RadioButton SystematicResample;
        private System.Windows.Forms.RadioButton MultinomialResample;
        private System.Windows.Forms.Button DefaultRobotBttn;
        private System.Windows.Forms.Button UpdateRobotBttn;
        private System.Windows.Forms.Label SensorDistanceLbl;
        private System.Windows.Forms.Label SensorAngleLbl;
        private System.Windows.Forms.NumericUpDown SensorDistanceSpinBttn;
        private System.Windows.Forms.NumericUpDown SensorAngleSpinBttn;
        private System.Windows.Forms.Button DefaultSensorBttn;
        private System.Windows.Forms.Button UpdateSensorBttn;
        private System.Windows.Forms.Button DefaultParticleBttn;
        private System.Windows.Forms.Button UpdateParticleBttn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDown5;
        private System.Windows.Forms.NumericUpDown numericUpDown4;
        private System.Windows.Forms.Timer UpdateRate;
        private System.Windows.Forms.Label label4;
        private MyTabControl SimOptions;
    }
}

