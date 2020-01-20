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
            this.ToggleSimBttn = new System.Windows.Forms.Button();
            this.UpdateRate = new System.Windows.Forms.Timer(this.components);
            this.ParticleList = new System.Windows.Forms.ListView();
            this.ParticleNoCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ParticleX = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ParticleY = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ParticleTheta = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ParticleWeightCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SimOptions = new slam_sim_.MyTabControl();
            this.EnvironmentPage = new System.Windows.Forms.TabPage();
            this.UpdateMapCheckBox = new System.Windows.Forms.CheckBox();
            this.TravelOdoValLbl = new System.Windows.Forms.Label();
            this.TravelOdoLbl = new System.Windows.Forms.Label();
            this.TravelValLbl = new System.Windows.Forms.Label();
            this.TravelLbl = new System.Windows.Forms.Label();
            this.ObstacleWidthLbl = new System.Windows.Forms.Label();
            this.ScaleLbl = new System.Windows.Forms.Label();
            this.ObstacleWidthSpinBttn = new System.Windows.Forms.NumericUpDown();
            this.MapScaleSpinBttn = new System.Windows.Forms.NumericUpDown();
            this.DefaultEnvBttn = new System.Windows.Forms.Button();
            this.DrawOptionsFrame = new System.Windows.Forms.GroupBox();
            this.DrawStop = new System.Windows.Forms.RadioButton();
            this.DrawObstacle = new System.Windows.Forms.RadioButton();
            this.DrawRobot = new System.Windows.Forms.RadioButton();
            this.GridSizeFrame = new System.Windows.Forms.GroupBox();
            this.WidthSpinBttn = new System.Windows.Forms.NumericUpDown();
            this.HeightLbl = new System.Windows.Forms.Label();
            this.HeightSpinBttn = new System.Windows.Forms.NumericUpDown();
            this.WidthLbl = new System.Windows.Forms.Label();
            this.SaveEnvBttn = new System.Windows.Forms.Button();
            this.RobotPage = new System.Windows.Forms.TabPage();
            this.DefaultRobotBttn = new System.Windows.Forms.Button();
            this.SaveRobotBttn = new System.Windows.Forms.Button();
            this.RobotRotStepLbl = new System.Windows.Forms.Label();
            this.RobotTransStepLbl = new System.Windows.Forms.Label();
            this.RobotRadiusLbl = new System.Windows.Forms.Label();
            this.RobotRotStepSpinBttn = new System.Windows.Forms.NumericUpDown();
            this.RobotTransStepSpinBttn = new System.Windows.Forms.NumericUpDown();
            this.RobotRadiusSpinBttn = new System.Windows.Forms.NumericUpDown();
            this.MotionErrFrame = new System.Windows.Forms.GroupBox();
            this.a4Lbl = new System.Windows.Forms.Label();
            this.a3Lbl = new System.Windows.Forms.Label();
            this.a2Lbl = new System.Windows.Forms.Label();
            this.a1Lbl = new System.Windows.Forms.Label();
            this.a4SpinBttn = new System.Windows.Forms.NumericUpDown();
            this.a3SpinBttn = new System.Windows.Forms.NumericUpDown();
            this.a2SpinBttn = new System.Windows.Forms.NumericUpDown();
            this.a1SpinBttn = new System.Windows.Forms.NumericUpDown();
            this.SensorPage = new System.Windows.Forms.TabPage();
            this.ZMaxLbl = new System.Windows.Forms.Label();
            this.ZRandLbl = new System.Windows.Forms.Label();
            this.ZHitLbl = new System.Windows.Forms.Label();
            this.SigmaHitLbl = new System.Windows.Forms.Label();
            this.SensorDistanceLbl = new System.Windows.Forms.Label();
            this.SensorAngleLbl = new System.Windows.Forms.Label();
            this.ZMaxSpinBttn = new System.Windows.Forms.NumericUpDown();
            this.ZRandSpinBttn = new System.Windows.Forms.NumericUpDown();
            this.ZHitSpinBttn = new System.Windows.Forms.NumericUpDown();
            this.SigmaHitSpinBttn = new System.Windows.Forms.NumericUpDown();
            this.SensorDistanceSpinBttn = new System.Windows.Forms.NumericUpDown();
            this.SensorAngleSpinBttn = new System.Windows.Forms.NumericUpDown();
            this.DefaultSensorBttn = new System.Windows.Forms.Button();
            this.SaveSensorBttn = new System.Windows.Forms.Button();
            this.ParticlePage = new System.Windows.Forms.TabPage();
            this.DefaultParticleBttn = new System.Windows.Forms.Button();
            this.SaveParticleBttn = new System.Windows.Forms.Button();
            this.ResampleMethFrame = new System.Windows.Forms.GroupBox();
            this.StratifiedResample = new System.Windows.Forms.RadioButton();
            this.SystematicResample = new System.Windows.Forms.RadioButton();
            this.MultinomialResample = new System.Windows.Forms.RadioButton();
            this.ParticleCountLbl = new System.Windows.Forms.Label();
            this.ParticleCountSpinBttn = new System.Windows.Forms.NumericUpDown();
            this.SimOptions.SuspendLayout();
            this.EnvironmentPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ObstacleWidthSpinBttn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MapScaleSpinBttn)).BeginInit();
            this.DrawOptionsFrame.SuspendLayout();
            this.GridSizeFrame.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WidthSpinBttn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HeightSpinBttn)).BeginInit();
            this.RobotPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RobotRotStepSpinBttn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RobotTransStepSpinBttn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RobotRadiusSpinBttn)).BeginInit();
            this.MotionErrFrame.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.a4SpinBttn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.a3SpinBttn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.a2SpinBttn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.a1SpinBttn)).BeginInit();
            this.SensorPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ZMaxSpinBttn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ZRandSpinBttn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ZHitSpinBttn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SigmaHitSpinBttn)).BeginInit();
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
            // ToggleSimBttn
            // 
            this.ToggleSimBttn.Location = new System.Drawing.Point(600, 540);
            this.ToggleSimBttn.Name = "ToggleSimBttn";
            this.ToggleSimBttn.Size = new System.Drawing.Size(188, 43);
            this.ToggleSimBttn.TabIndex = 2;
            this.ToggleSimBttn.Text = "Start Simulation";
            this.ToggleSimBttn.UseVisualStyleBackColor = true;
            this.ToggleSimBttn.Click += new System.EventHandler(this.ToggleSimBttn_Click);
            // 
            // UpdateRate
            // 
            this.UpdateRate.Enabled = true;
            this.UpdateRate.Interval = 150;
            this.UpdateRate.Tick += new System.EventHandler(this.UpdateRate_Tick);
            // 
            // ParticleList
            // 
            this.ParticleList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ParticleNoCol,
            this.ParticleX,
            this.ParticleY,
            this.ParticleTheta,
            this.ParticleWeightCol});
            this.ParticleList.FullRowSelect = true;
            this.ParticleList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.ParticleList.HideSelection = false;
            this.ParticleList.Location = new System.Drawing.Point(868, 32);
            this.ParticleList.MultiSelect = false;
            this.ParticleList.Name = "ParticleList";
            this.ParticleList.Size = new System.Drawing.Size(343, 489);
            this.ParticleList.TabIndex = 3;
            this.ParticleList.UseCompatibleStateImageBehavior = false;
            this.ParticleList.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.ParticleList_ItemSelectionChanged);
            // 
            // ParticleNoCol
            // 
            this.ParticleNoCol.Text = "No.";
            // 
            // ParticleX
            // 
            this.ParticleX.Text = "X";
            this.ParticleX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ParticleY
            // 
            this.ParticleY.Text = "Y";
            this.ParticleY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ParticleTheta
            // 
            this.ParticleTheta.Text = "Theta";
            this.ParticleTheta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ParticleWeightCol
            // 
            this.ParticleWeightCol.Text = "Weight";
            this.ParticleWeightCol.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            this.SimOptions.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.SimOptions_Selecting);
            this.SimOptions.Deselecting += new System.Windows.Forms.TabControlCancelEventHandler(this.SimOptions_Deselecting);
            this.SimOptions.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SimOptions_KeyUp);
            this.SimOptions.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.SimOptions_PreviewKeyDown);
            // 
            // EnvironmentPage
            // 
            this.EnvironmentPage.Controls.Add(this.UpdateMapCheckBox);
            this.EnvironmentPage.Controls.Add(this.TravelOdoValLbl);
            this.EnvironmentPage.Controls.Add(this.TravelOdoLbl);
            this.EnvironmentPage.Controls.Add(this.TravelValLbl);
            this.EnvironmentPage.Controls.Add(this.TravelLbl);
            this.EnvironmentPage.Controls.Add(this.ObstacleWidthLbl);
            this.EnvironmentPage.Controls.Add(this.ScaleLbl);
            this.EnvironmentPage.Controls.Add(this.ObstacleWidthSpinBttn);
            this.EnvironmentPage.Controls.Add(this.MapScaleSpinBttn);
            this.EnvironmentPage.Controls.Add(this.DefaultEnvBttn);
            this.EnvironmentPage.Controls.Add(this.DrawOptionsFrame);
            this.EnvironmentPage.Controls.Add(this.GridSizeFrame);
            this.EnvironmentPage.Controls.Add(this.SaveEnvBttn);
            this.EnvironmentPage.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.EnvironmentPage.Location = new System.Drawing.Point(4, 22);
            this.EnvironmentPage.Name = "EnvironmentPage";
            this.EnvironmentPage.Padding = new System.Windows.Forms.Padding(3);
            this.EnvironmentPage.Size = new System.Drawing.Size(324, 485);
            this.EnvironmentPage.TabIndex = 1;
            this.EnvironmentPage.Text = "Environment";
            this.EnvironmentPage.UseVisualStyleBackColor = true;
            // 
            // UpdateMapCheckBox
            // 
            this.UpdateMapCheckBox.AutoSize = true;
            this.UpdateMapCheckBox.Location = new System.Drawing.Point(124, 392);
            this.UpdateMapCheckBox.Name = "UpdateMapCheckBox";
            this.UpdateMapCheckBox.Size = new System.Drawing.Size(84, 17);
            this.UpdateMapCheckBox.TabIndex = 9;
            this.UpdateMapCheckBox.Text = "Update map";
            this.UpdateMapCheckBox.UseVisualStyleBackColor = true;
            // 
            // TravelOdoValLbl
            // 
            this.TravelOdoValLbl.AutoSize = true;
            this.TravelOdoValLbl.Location = new System.Drawing.Point(159, 354);
            this.TravelOdoValLbl.Name = "TravelOdoValLbl";
            this.TravelOdoValLbl.Size = new System.Drawing.Size(0, 13);
            this.TravelOdoValLbl.TabIndex = 8;
            // 
            // TravelOdoLbl
            // 
            this.TravelOdoLbl.AutoSize = true;
            this.TravelOdoLbl.Location = new System.Drawing.Point(40, 354);
            this.TravelOdoLbl.Name = "TravelOdoLbl";
            this.TravelOdoLbl.Size = new System.Drawing.Size(109, 13);
            this.TravelOdoLbl.TabIndex = 8;
            this.TravelOdoLbl.Text = "Traveled odometry(m)";
            // 
            // TravelValLbl
            // 
            this.TravelValLbl.AutoSize = true;
            this.TravelValLbl.Location = new System.Drawing.Point(159, 319);
            this.TravelValLbl.Name = "TravelValLbl";
            this.TravelValLbl.Size = new System.Drawing.Size(0, 13);
            this.TravelValLbl.TabIndex = 8;
            // 
            // TravelLbl
            // 
            this.TravelLbl.AutoSize = true;
            this.TravelLbl.Location = new System.Drawing.Point(40, 319);
            this.TravelLbl.Name = "TravelLbl";
            this.TravelLbl.Size = new System.Drawing.Size(66, 13);
            this.TravelLbl.TabIndex = 8;
            this.TravelLbl.Text = "Traveled (m)";
            // 
            // ObstacleWidthLbl
            // 
            this.ObstacleWidthLbl.AutoSize = true;
            this.ObstacleWidthLbl.Location = new System.Drawing.Point(39, 229);
            this.ObstacleWidthLbl.Name = "ObstacleWidthLbl";
            this.ObstacleWidthLbl.Size = new System.Drawing.Size(100, 13);
            this.ObstacleWidthLbl.TabIndex = 8;
            this.ObstacleWidthLbl.Text = "Obstacle width (cm)";
            // 
            // ScaleLbl
            // 
            this.ScaleLbl.AutoSize = true;
            this.ScaleLbl.Location = new System.Drawing.Point(39, 277);
            this.ScaleLbl.Name = "ScaleLbl";
            this.ScaleLbl.Size = new System.Drawing.Size(113, 13);
            this.ScaleLbl.TabIndex = 8;
            this.ScaleLbl.Text = "Scale (cells to meters):";
            // 
            // ObstacleWidthSpinBttn
            // 
            this.ObstacleWidthSpinBttn.Location = new System.Drawing.Point(180, 227);
            this.ObstacleWidthSpinBttn.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ObstacleWidthSpinBttn.Name = "ObstacleWidthSpinBttn";
            this.ObstacleWidthSpinBttn.Size = new System.Drawing.Size(74, 20);
            this.ObstacleWidthSpinBttn.TabIndex = 7;
            this.ObstacleWidthSpinBttn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ObstacleWidthSpinBttn.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // MapScaleSpinBttn
            // 
            this.MapScaleSpinBttn.Location = new System.Drawing.Point(180, 275);
            this.MapScaleSpinBttn.Maximum = new decimal(new int[] {
            10,
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
            10,
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
            this.DrawOptionsFrame.Controls.Add(this.DrawObstacle);
            this.DrawOptionsFrame.Controls.Add(this.DrawRobot);
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
            // DrawRobot
            // 
            this.DrawRobot.AutoSize = true;
            this.DrawRobot.Location = new System.Drawing.Point(179, 35);
            this.DrawRobot.Name = "DrawRobot";
            this.DrawRobot.Size = new System.Drawing.Size(82, 17);
            this.DrawRobot.TabIndex = 0;
            this.DrawRobot.Text = "Draw Robot";
            this.DrawRobot.UseVisualStyleBackColor = true;
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
            // SaveEnvBttn
            // 
            this.SaveEnvBttn.Location = new System.Drawing.Point(188, 445);
            this.SaveEnvBttn.Name = "SaveEnvBttn";
            this.SaveEnvBttn.Size = new System.Drawing.Size(130, 34);
            this.SaveEnvBttn.TabIndex = 0;
            this.SaveEnvBttn.Text = "Save Environment";
            this.SaveEnvBttn.UseVisualStyleBackColor = true;
            this.SaveEnvBttn.Click += new System.EventHandler(this.SaveEnvBttn_Click);
            // 
            // RobotPage
            // 
            this.RobotPage.Controls.Add(this.DefaultRobotBttn);
            this.RobotPage.Controls.Add(this.SaveRobotBttn);
            this.RobotPage.Controls.Add(this.RobotRotStepLbl);
            this.RobotPage.Controls.Add(this.RobotTransStepLbl);
            this.RobotPage.Controls.Add(this.RobotRadiusLbl);
            this.RobotPage.Controls.Add(this.RobotRotStepSpinBttn);
            this.RobotPage.Controls.Add(this.RobotTransStepSpinBttn);
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
            this.DefaultRobotBttn.Click += new System.EventHandler(this.DefaultRobotBttn_Click);
            // 
            // SaveRobotBttn
            // 
            this.SaveRobotBttn.Location = new System.Drawing.Point(188, 445);
            this.SaveRobotBttn.Name = "SaveRobotBttn";
            this.SaveRobotBttn.Size = new System.Drawing.Size(130, 34);
            this.SaveRobotBttn.TabIndex = 7;
            this.SaveRobotBttn.Text = "Save Robot";
            this.SaveRobotBttn.UseVisualStyleBackColor = true;
            this.SaveRobotBttn.Click += new System.EventHandler(this.SaveRobotBttn_Click);
            // 
            // RobotRotStepLbl
            // 
            this.RobotRotStepLbl.Location = new System.Drawing.Point(41, 303);
            this.RobotRotStepLbl.Name = "RobotRotStepLbl";
            this.RobotRotStepLbl.Size = new System.Drawing.Size(87, 32);
            this.RobotRotStepLbl.TabIndex = 3;
            this.RobotRotStepLbl.Text = "Robot rotation step (degrees):";
            // 
            // RobotTransStepLbl
            // 
            this.RobotTransStepLbl.Location = new System.Drawing.Point(33, 258);
            this.RobotTransStepLbl.Name = "RobotTransStepLbl";
            this.RobotTransStepLbl.Size = new System.Drawing.Size(90, 27);
            this.RobotTransStepLbl.TabIndex = 3;
            this.RobotTransStepLbl.Text = "Robot translation step (m):";
            // 
            // RobotRadiusLbl
            // 
            this.RobotRadiusLbl.AutoSize = true;
            this.RobotRadiusLbl.Location = new System.Drawing.Point(33, 222);
            this.RobotRadiusLbl.Name = "RobotRadiusLbl";
            this.RobotRadiusLbl.Size = new System.Drawing.Size(87, 13);
            this.RobotRadiusLbl.TabIndex = 3;
            this.RobotRadiusLbl.Text = "Robot radius (m):";
            // 
            // RobotRotStepSpinBttn
            // 
            this.RobotRotStepSpinBttn.Location = new System.Drawing.Point(134, 303);
            this.RobotRotStepSpinBttn.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.RobotRotStepSpinBttn.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.RobotRotStepSpinBttn.Name = "RobotRotStepSpinBttn";
            this.RobotRotStepSpinBttn.Size = new System.Drawing.Size(120, 20);
            this.RobotRotStepSpinBttn.TabIndex = 2;
            this.RobotRotStepSpinBttn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.RobotRotStepSpinBttn.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // RobotTransStepSpinBttn
            // 
            this.RobotTransStepSpinBttn.DecimalPlaces = 1;
            this.RobotTransStepSpinBttn.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.RobotTransStepSpinBttn.Location = new System.Drawing.Point(134, 256);
            this.RobotTransStepSpinBttn.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.RobotTransStepSpinBttn.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.RobotTransStepSpinBttn.Name = "RobotTransStepSpinBttn";
            this.RobotTransStepSpinBttn.Size = new System.Drawing.Size(120, 20);
            this.RobotTransStepSpinBttn.TabIndex = 2;
            this.RobotTransStepSpinBttn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.RobotTransStepSpinBttn.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
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
            0});
            // 
            // MotionErrFrame
            // 
            this.MotionErrFrame.Controls.Add(this.a4Lbl);
            this.MotionErrFrame.Controls.Add(this.a3Lbl);
            this.MotionErrFrame.Controls.Add(this.a2Lbl);
            this.MotionErrFrame.Controls.Add(this.a1Lbl);
            this.MotionErrFrame.Controls.Add(this.a4SpinBttn);
            this.MotionErrFrame.Controls.Add(this.a3SpinBttn);
            this.MotionErrFrame.Controls.Add(this.a2SpinBttn);
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
            // a4SpinBttn
            // 
            this.a4SpinBttn.DecimalPlaces = 9;
            this.a4SpinBttn.Increment = new decimal(new int[] {
            1,
            0,
            0,
            524288});
            this.a4SpinBttn.Location = new System.Drawing.Point(112, 138);
            this.a4SpinBttn.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.a4SpinBttn.Name = "a4SpinBttn";
            this.a4SpinBttn.Size = new System.Drawing.Size(120, 20);
            this.a4SpinBttn.TabIndex = 0;
            this.a4SpinBttn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.a4SpinBttn.Value = new decimal(new int[] {
            1,
            0,
            0,
            393216});
            // 
            // a3SpinBttn
            // 
            this.a3SpinBttn.DecimalPlaces = 9;
            this.a3SpinBttn.Increment = new decimal(new int[] {
            1,
            0,
            0,
            524288});
            this.a3SpinBttn.Location = new System.Drawing.Point(112, 105);
            this.a3SpinBttn.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.a3SpinBttn.Name = "a3SpinBttn";
            this.a3SpinBttn.Size = new System.Drawing.Size(120, 20);
            this.a3SpinBttn.TabIndex = 0;
            this.a3SpinBttn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.a3SpinBttn.Value = new decimal(new int[] {
            1,
            0,
            0,
            393216});
            // 
            // a2SpinBttn
            // 
            this.a2SpinBttn.DecimalPlaces = 9;
            this.a2SpinBttn.Increment = new decimal(new int[] {
            1,
            0,
            0,
            524288});
            this.a2SpinBttn.Location = new System.Drawing.Point(112, 70);
            this.a2SpinBttn.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.a2SpinBttn.Name = "a2SpinBttn";
            this.a2SpinBttn.Size = new System.Drawing.Size(120, 20);
            this.a2SpinBttn.TabIndex = 0;
            this.a2SpinBttn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.a2SpinBttn.Value = new decimal(new int[] {
            1,
            0,
            0,
            393216});
            // 
            // a1SpinBttn
            // 
            this.a1SpinBttn.DecimalPlaces = 9;
            this.a1SpinBttn.Increment = new decimal(new int[] {
            1,
            0,
            0,
            589824});
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
            this.a1SpinBttn.Value = new decimal(new int[] {
            1,
            0,
            0,
            393216});
            // 
            // SensorPage
            // 
            this.SensorPage.Controls.Add(this.ZMaxLbl);
            this.SensorPage.Controls.Add(this.ZRandLbl);
            this.SensorPage.Controls.Add(this.ZHitLbl);
            this.SensorPage.Controls.Add(this.SigmaHitLbl);
            this.SensorPage.Controls.Add(this.SensorDistanceLbl);
            this.SensorPage.Controls.Add(this.SensorAngleLbl);
            this.SensorPage.Controls.Add(this.ZMaxSpinBttn);
            this.SensorPage.Controls.Add(this.ZRandSpinBttn);
            this.SensorPage.Controls.Add(this.ZHitSpinBttn);
            this.SensorPage.Controls.Add(this.SigmaHitSpinBttn);
            this.SensorPage.Controls.Add(this.SensorDistanceSpinBttn);
            this.SensorPage.Controls.Add(this.SensorAngleSpinBttn);
            this.SensorPage.Controls.Add(this.DefaultSensorBttn);
            this.SensorPage.Controls.Add(this.SaveSensorBttn);
            this.SensorPage.Location = new System.Drawing.Point(4, 22);
            this.SensorPage.Name = "SensorPage";
            this.SensorPage.Padding = new System.Windows.Forms.Padding(3);
            this.SensorPage.Size = new System.Drawing.Size(324, 485);
            this.SensorPage.TabIndex = 2;
            this.SensorPage.Text = "Sensor";
            this.SensorPage.UseVisualStyleBackColor = true;
            // 
            // ZMaxLbl
            // 
            this.ZMaxLbl.AutoSize = true;
            this.ZMaxLbl.Location = new System.Drawing.Point(50, 278);
            this.ZMaxLbl.Name = "ZMaxLbl";
            this.ZMaxLbl.Size = new System.Drawing.Size(39, 13);
            this.ZMaxLbl.TabIndex = 12;
            this.ZMaxLbl.Text = "Z_max";
            // 
            // ZRandLbl
            // 
            this.ZRandLbl.AutoSize = true;
            this.ZRandLbl.Location = new System.Drawing.Point(50, 232);
            this.ZRandLbl.Name = "ZRandLbl";
            this.ZRandLbl.Size = new System.Drawing.Size(41, 13);
            this.ZRandLbl.TabIndex = 12;
            this.ZRandLbl.Text = "Z_rand";
            // 
            // ZHitLbl
            // 
            this.ZHitLbl.AutoSize = true;
            this.ZHitLbl.Location = new System.Drawing.Point(50, 186);
            this.ZHitLbl.Name = "ZHitLbl";
            this.ZHitLbl.Size = new System.Drawing.Size(31, 13);
            this.ZHitLbl.TabIndex = 12;
            this.ZHitLbl.Text = "Z_hit";
            // 
            // SigmaHitLbl
            // 
            this.SigmaHitLbl.AutoSize = true;
            this.SigmaHitLbl.Location = new System.Drawing.Point(44, 145);
            this.SigmaHitLbl.Name = "SigmaHitLbl";
            this.SigmaHitLbl.Size = new System.Drawing.Size(53, 13);
            this.SigmaHitLbl.TabIndex = 12;
            this.SigmaHitLbl.Text = "Sigma_hit";
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
            this.SensorAngleLbl.Location = new System.Drawing.Point(44, 53);
            this.SensorAngleLbl.Name = "SensorAngleLbl";
            this.SensorAngleLbl.Size = new System.Drawing.Size(119, 34);
            this.SensorAngleLbl.TabIndex = 12;
            this.SensorAngleLbl.Text = "Sensor sweep angle (degrees):";
            // 
            // ZMaxSpinBttn
            // 
            this.ZMaxSpinBttn.DecimalPlaces = 3;
            this.ZMaxSpinBttn.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.ZMaxSpinBttn.Location = new System.Drawing.Point(169, 278);
            this.ZMaxSpinBttn.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ZMaxSpinBttn.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.ZMaxSpinBttn.Name = "ZMaxSpinBttn";
            this.ZMaxSpinBttn.Size = new System.Drawing.Size(120, 20);
            this.ZMaxSpinBttn.TabIndex = 11;
            this.ZMaxSpinBttn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ZMaxSpinBttn.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            // 
            // ZRandSpinBttn
            // 
            this.ZRandSpinBttn.DecimalPlaces = 3;
            this.ZRandSpinBttn.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.ZRandSpinBttn.Location = new System.Drawing.Point(169, 232);
            this.ZRandSpinBttn.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ZRandSpinBttn.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.ZRandSpinBttn.Name = "ZRandSpinBttn";
            this.ZRandSpinBttn.Size = new System.Drawing.Size(120, 20);
            this.ZRandSpinBttn.TabIndex = 11;
            this.ZRandSpinBttn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ZRandSpinBttn.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            // 
            // ZHitSpinBttn
            // 
            this.ZHitSpinBttn.DecimalPlaces = 3;
            this.ZHitSpinBttn.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.ZHitSpinBttn.Location = new System.Drawing.Point(169, 186);
            this.ZHitSpinBttn.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ZHitSpinBttn.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.ZHitSpinBttn.Name = "ZHitSpinBttn";
            this.ZHitSpinBttn.Size = new System.Drawing.Size(120, 20);
            this.ZHitSpinBttn.TabIndex = 11;
            this.ZHitSpinBttn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ZHitSpinBttn.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            // 
            // SigmaHitSpinBttn
            // 
            this.SigmaHitSpinBttn.DecimalPlaces = 2;
            this.SigmaHitSpinBttn.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.SigmaHitSpinBttn.Location = new System.Drawing.Point(169, 145);
            this.SigmaHitSpinBttn.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.SigmaHitSpinBttn.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.SigmaHitSpinBttn.Name = "SigmaHitSpinBttn";
            this.SigmaHitSpinBttn.Size = new System.Drawing.Size(120, 20);
            this.SigmaHitSpinBttn.TabIndex = 11;
            this.SigmaHitSpinBttn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.SigmaHitSpinBttn.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            // 
            // SensorDistanceSpinBttn
            // 
            this.SensorDistanceSpinBttn.DecimalPlaces = 1;
            this.SensorDistanceSpinBttn.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.SensorDistanceSpinBttn.Location = new System.Drawing.Point(169, 100);
            this.SensorDistanceSpinBttn.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
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
            7,
            0,
            0,
            0});
            // 
            // SensorAngleSpinBttn
            // 
            this.SensorAngleSpinBttn.Location = new System.Drawing.Point(169, 53);
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
            90,
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
            this.DefaultSensorBttn.Click += new System.EventHandler(this.DefaultSensorBttn_Click);
            // 
            // SaveSensorBttn
            // 
            this.SaveSensorBttn.Location = new System.Drawing.Point(188, 445);
            this.SaveSensorBttn.Name = "SaveSensorBttn";
            this.SaveSensorBttn.Size = new System.Drawing.Size(130, 34);
            this.SaveSensorBttn.TabIndex = 9;
            this.SaveSensorBttn.Text = "Save Sensor";
            this.SaveSensorBttn.UseVisualStyleBackColor = true;
            this.SaveSensorBttn.Click += new System.EventHandler(this.SaveSensorBttn_Click);
            // 
            // ParticlePage
            // 
            this.ParticlePage.Controls.Add(this.DefaultParticleBttn);
            this.ParticlePage.Controls.Add(this.SaveParticleBttn);
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
            // DefaultParticleBttn
            // 
            this.DefaultParticleBttn.Location = new System.Drawing.Point(6, 444);
            this.DefaultParticleBttn.Name = "DefaultParticleBttn";
            this.DefaultParticleBttn.Size = new System.Drawing.Size(129, 35);
            this.DefaultParticleBttn.TabIndex = 12;
            this.DefaultParticleBttn.Text = "Default Particle";
            this.DefaultParticleBttn.UseVisualStyleBackColor = true;
            this.DefaultParticleBttn.Click += new System.EventHandler(this.DefaultParticleBttn_Click);
            // 
            // SaveParticleBttn
            // 
            this.SaveParticleBttn.Location = new System.Drawing.Point(188, 445);
            this.SaveParticleBttn.Name = "SaveParticleBttn";
            this.SaveParticleBttn.Size = new System.Drawing.Size(130, 34);
            this.SaveParticleBttn.TabIndex = 11;
            this.SaveParticleBttn.Text = "Save Particle";
            this.SaveParticleBttn.UseVisualStyleBackColor = true;
            this.SaveParticleBttn.Click += new System.EventHandler(this.SaveParticleBttn_Click);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(1240, 593);
            this.Controls.Add(this.ParticleList);
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
            ((System.ComponentModel.ISupportInitialize)(this.ObstacleWidthSpinBttn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MapScaleSpinBttn)).EndInit();
            this.DrawOptionsFrame.ResumeLayout(false);
            this.DrawOptionsFrame.PerformLayout();
            this.GridSizeFrame.ResumeLayout(false);
            this.GridSizeFrame.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WidthSpinBttn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HeightSpinBttn)).EndInit();
            this.RobotPage.ResumeLayout(false);
            this.RobotPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RobotRotStepSpinBttn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RobotTransStepSpinBttn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RobotRadiusSpinBttn)).EndInit();
            this.MotionErrFrame.ResumeLayout(false);
            this.MotionErrFrame.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.a4SpinBttn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.a3SpinBttn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.a2SpinBttn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.a1SpinBttn)).EndInit();
            this.SensorPage.ResumeLayout(false);
            this.SensorPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ZMaxSpinBttn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ZRandSpinBttn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ZHitSpinBttn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SigmaHitSpinBttn)).EndInit();
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
        private System.Windows.Forms.Button SaveEnvBttn;
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
        private System.Windows.Forms.Label ScaleLbl;
        private System.Windows.Forms.Label RobotRadiusLbl;
        private System.Windows.Forms.NumericUpDown RobotRadiusSpinBttn;
        private System.Windows.Forms.GroupBox MotionErrFrame;
        private System.Windows.Forms.Label a4Lbl;
        private System.Windows.Forms.Label a3Lbl;
        private System.Windows.Forms.Label a2Lbl;
        private System.Windows.Forms.Label a1Lbl;
        private System.Windows.Forms.NumericUpDown a4SpinBttn;
        private System.Windows.Forms.NumericUpDown a3SpinBttn;
        private System.Windows.Forms.NumericUpDown a2SpinBttn;
        private System.Windows.Forms.NumericUpDown a1SpinBttn;
        private System.Windows.Forms.Label ParticleCountLbl;
        private System.Windows.Forms.NumericUpDown ParticleCountSpinBttn;
        private System.Windows.Forms.GroupBox ResampleMethFrame;
        private System.Windows.Forms.RadioButton StratifiedResample;
        private System.Windows.Forms.RadioButton SystematicResample;
        private System.Windows.Forms.RadioButton MultinomialResample;
        private System.Windows.Forms.Button DefaultRobotBttn;
        private System.Windows.Forms.Button SaveRobotBttn;
        private System.Windows.Forms.Label SensorDistanceLbl;
        private System.Windows.Forms.Label SensorAngleLbl;
        private System.Windows.Forms.NumericUpDown SensorDistanceSpinBttn;
        private System.Windows.Forms.NumericUpDown SensorAngleSpinBttn;
        private System.Windows.Forms.Button DefaultSensorBttn;
        private System.Windows.Forms.Button SaveSensorBttn;
        private System.Windows.Forms.Button DefaultParticleBttn;
        private System.Windows.Forms.Button SaveParticleBttn;
        private System.Windows.Forms.Label RobotRotStepLbl;
        private System.Windows.Forms.Label RobotTransStepLbl;
        private System.Windows.Forms.NumericUpDown RobotRotStepSpinBttn;
        private System.Windows.Forms.NumericUpDown RobotTransStepSpinBttn;
        private System.Windows.Forms.Timer UpdateRate;
        private MyTabControl SimOptions;
        private Label ZMaxLbl;
        private Label ZRandLbl;
        private Label ZHitLbl;
        private Label SigmaHitLbl;
        private NumericUpDown ZMaxSpinBttn;
        private NumericUpDown ZRandSpinBttn;
        private NumericUpDown ZHitSpinBttn;
        private NumericUpDown SigmaHitSpinBttn;
        private Label TravelLbl;
        private Label TravelValLbl;
        private Label TravelOdoValLbl;
        private Label TravelOdoLbl;
        private ListView ParticleList;
        private ColumnHeader ParticleNoCol;
        private ColumnHeader ParticleWeightCol;
        private ColumnHeader ParticleX;
        private ColumnHeader ParticleY;
        private ColumnHeader ParticleTheta;
        private Label ObstacleWidthLbl;
        private NumericUpDown ObstacleWidthSpinBttn;
        private CheckBox UpdateMapCheckBox;
    }
}

