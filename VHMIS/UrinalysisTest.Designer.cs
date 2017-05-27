namespace VHMIS
{
    partial class UrinalysisTest
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
            SpPerfChart.ChartPen chartPen1 = new SpPerfChart.ChartPen();
            SpPerfChart.ChartPen chartPen2 = new SpPerfChart.ChartPen();
            SpPerfChart.ChartPen chartPen3 = new SpPerfChart.ChartPen();
            SpPerfChart.ChartPen chartPen4 = new SpPerfChart.ChartPen();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UrinalysisTest));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.perfChart = new SpPerfChart.PerfChart();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.chkBxTimerEnabled = new System.Windows.Forms.CheckBox();
            this.bgWrkTimer = new System.ComponentModel.BackgroundWorker();
            this.button9 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.button9);
            this.splitContainer1.Panel2.Controls.Add(this.chkBxTimerEnabled);
            this.splitContainer1.Panel2.Controls.Add(this.textBox2);
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Size = new System.Drawing.Size(877, 463);
            this.splitContainer1.SplitterDistance = 179;
            this.splitContainer1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.perfChart);
            this.panel1.Location = new System.Drawing.Point(6, 7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(679, 180);
            this.panel1.TabIndex = 0;
            // 
            // perfChart
            // 
            this.perfChart.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner;
            this.perfChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.perfChart.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.perfChart.Location = new System.Drawing.Point(0, 0);
            this.perfChart.Name = "perfChart";
            this.perfChart.PerfChartStyle.AntiAliasing = true;
            chartPen1.Color = System.Drawing.Color.LightGreen;
            chartPen1.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            chartPen1.Width = 1F;
            this.perfChart.PerfChartStyle.AvgLinePen = chartPen1;
            this.perfChart.PerfChartStyle.BackgroundColorBottom = System.Drawing.Color.MediumTurquoise;
            this.perfChart.PerfChartStyle.BackgroundColorTop = System.Drawing.Color.LemonChiffon;
            chartPen2.Color = System.Drawing.Color.Crimson;
            chartPen2.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            chartPen2.Width = 1F;
            this.perfChart.PerfChartStyle.ChartLinePen = chartPen2;
            chartPen3.Color = System.Drawing.Color.DarkOliveGreen;
            chartPen3.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            chartPen3.Width = 1F;
            this.perfChart.PerfChartStyle.HorizontalGridPen = chartPen3;
            this.perfChart.PerfChartStyle.ShowAverageLine = true;
            this.perfChart.PerfChartStyle.ShowHorizontalGridLines = true;
            this.perfChart.PerfChartStyle.ShowVerticalGridLines = true;
            chartPen4.Color = System.Drawing.Color.DarkOliveGreen;
            chartPen4.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            chartPen4.Width = 1F;
            this.perfChart.PerfChartStyle.VerticalGridPen = chartPen4;
            this.perfChart.ScaleMode = SpPerfChart.ScaleMode.Relative;
            this.perfChart.Size = new System.Drawing.Size(679, 180);
            this.perfChart.TabIndex = 2;
            this.perfChart.TimerInterval = 100;
            this.perfChart.TimerMode = SpPerfChart.TimerMode.Disabled;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(6, 198);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox2.Size = new System.Drawing.Size(253, 253);
            this.textBox2.TabIndex = 130;
            // 
            // chkBxTimerEnabled
            // 
            this.chkBxTimerEnabled.AutoSize = true;
            this.chkBxTimerEnabled.Location = new System.Drawing.Point(277, 209);
            this.chkBxTimerEnabled.Name = "chkBxTimerEnabled";
            this.chkBxTimerEnabled.Size = new System.Drawing.Size(94, 17);
            this.chkBxTimerEnabled.TabIndex = 138;
            this.chkBxTimerEnabled.Text = "Timer Enabled";
            this.chkBxTimerEnabled.UseVisualStyleBackColor = true;
            this.chkBxTimerEnabled.CheckedChanged += new System.EventHandler(this.chkBxTimerEnabled_CheckedChanged);
            // 
            // bgWrkTimer
            // 
            this.bgWrkTimer.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWrkTimer_DoWork);
            this.bgWrkTimer.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWrkTimer_RunWorkerCompleted);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(512, 204);
            this.button9.Margin = new System.Windows.Forms.Padding(2);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(170, 24);
            this.button9.TabIndex = 139;
            this.button9.Text = "Run Diagnosis";
            this.button9.UseVisualStyleBackColor = true;
            // 
            // UrinalysisTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(877, 463);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UrinalysisTest";
            this.Text = "UrinalysisTest";
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private SpPerfChart.PerfChart perfChart;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.CheckBox chkBxTimerEnabled;
        private System.ComponentModel.BackgroundWorker bgWrkTimer;
        private System.Windows.Forms.Button button9;
    }
}