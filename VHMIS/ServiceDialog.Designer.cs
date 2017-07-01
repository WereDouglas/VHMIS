namespace VHMIS
{
    partial class ServiceDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServiceDialog));
            this.serviceLbl = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.serviceQty = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.parameterTxt = new System.Windows.Forms.TextBox();
            this.button18 = new System.Windows.Forms.Button();
            this.label56 = new System.Windows.Forms.Label();
            this.label55 = new System.Windows.Forms.Label();
            this.statusCbx = new System.Windows.Forms.ComboBox();
            this.operationCbx = new System.Windows.Forms.ComboBox();
            this.opCostTxt = new System.Windows.Forms.TextBox();
            this.label52 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.resultNotesTxt = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button11 = new System.Windows.Forms.Button();
            this.label44 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.testResultsTxt = new System.Windows.Forms.TextBox();
            this.examinationTxt = new System.Windows.Forms.TextBox();
            this.label36 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label38 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.perfChart = new SpPerfChart.PerfChart();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel9.SuspendLayout();
            this.SuspendLayout();
            // 
            // serviceLbl
            // 
            this.serviceLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.serviceLbl.AutoSize = true;
            this.serviceLbl.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serviceLbl.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.serviceLbl.Location = new System.Drawing.Point(134, 264);
            this.serviceLbl.Name = "serviceLbl";
            this.serviceLbl.Size = new System.Drawing.Size(53, 26);
            this.serviceLbl.TabIndex = 245;
            this.serviceLbl.Text = "Total";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(12, 224);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(47, 13);
            this.label22.TabIndex = 244;
            this.label22.Text = "Quantity";
            // 
            // serviceQty
            // 
            this.serviceQty.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.serviceQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.serviceQty.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serviceQty.Location = new System.Drawing.Point(12, 240);
            this.serviceQty.Multiline = true;
            this.serviceQty.Name = "serviceQty";
            this.serviceQty.Size = new System.Drawing.Size(228, 21);
            this.serviceQty.TabIndex = 243;
            this.serviceQty.Text = "1";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(12, 78);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(58, 13);
            this.label27.TabIndex = 242;
            this.label27.Text = "Parameter";
            // 
            // parameterTxt
            // 
            this.parameterTxt.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.parameterTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.parameterTxt.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.parameterTxt.Location = new System.Drawing.Point(12, 94);
            this.parameterTxt.Multiline = true;
            this.parameterTxt.Name = "parameterTxt";
            this.parameterTxt.Size = new System.Drawing.Size(228, 21);
            this.parameterTxt.TabIndex = 241;
            // 
            // button18
            // 
            this.button18.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button18.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.button18.FlatAppearance.BorderSize = 0;
            this.button18.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button18.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button18.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button18.Location = new System.Drawing.Point(84, 478);
            this.button18.Margin = new System.Windows.Forms.Padding(2);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(110, 25);
            this.button18.TabIndex = 240;
            this.button18.Text = "Add";
            this.button18.UseVisualStyleBackColor = false;
            this.button18.Click += new System.EventHandler(this.button18_Click);
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.Location = new System.Drawing.Point(12, 184);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(37, 13);
            this.label56.TabIndex = 239;
            this.label56.Text = "Status";
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label55.ForeColor = System.Drawing.Color.SeaGreen;
            this.label55.Location = new System.Drawing.Point(12, 158);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(49, 26);
            this.label55.TabIndex = 238;
            this.label55.Text = "Cost";
            // 
            // statusCbx
            // 
            this.statusCbx.FormattingEnabled = true;
            this.statusCbx.Items.AddRange(new object[] {
            "Complete",
            "Not Done"});
            this.statusCbx.Location = new System.Drawing.Point(12, 200);
            this.statusCbx.Name = "statusCbx";
            this.statusCbx.Size = new System.Drawing.Size(228, 21);
            this.statusCbx.TabIndex = 237;
            // 
            // operationCbx
            // 
            this.operationCbx.FormattingEnabled = true;
            this.operationCbx.Location = new System.Drawing.Point(12, 54);
            this.operationCbx.Name = "operationCbx";
            this.operationCbx.Size = new System.Drawing.Size(228, 21);
            this.operationCbx.TabIndex = 236;
            this.operationCbx.SelectedIndexChanged += new System.EventHandler(this.operationCbx_SelectedIndexChanged);
            // 
            // opCostTxt
            // 
            this.opCostTxt.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.opCostTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.opCostTxt.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.opCostTxt.Location = new System.Drawing.Point(12, 134);
            this.opCostTxt.Name = "opCostTxt";
            this.opCostTxt.Size = new System.Drawing.Size(228, 21);
            this.opCostTxt.TabIndex = 235;
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Location = new System.Drawing.Point(12, 38);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(125, 13);
            this.label52.TabIndex = 234;
            this.label52.Text = "Procedures e.g Radiology";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 13);
            this.label4.TabIndex = 233;
            this.label4.Text = "Services and Operations";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.727273F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 95.27273F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 448F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 328F));
            this.tableLayoutPanel1.Controls.Add(this.button18, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.button4, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel9, 2, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.297873F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 91.70213F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1044, 512);
            this.tableLayoutPanel1.TabIndex = 247;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label52);
            this.panel1.Controls.Add(this.operationCbx);
            this.panel1.Controls.Add(this.resultNotesTxt);
            this.panel1.Controls.Add(this.label27);
            this.panel1.Controls.Add(this.serviceLbl);
            this.panel1.Controls.Add(this.parameterTxt);
            this.panel1.Controls.Add(this.serviceQty);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label22);
            this.panel1.Controls.Add(this.opCostTxt);
            this.panel1.Controls.Add(this.statusCbx);
            this.panel1.Controls.Add(this.label55);
            this.panel1.Controls.Add(this.label56);
            this.panel1.Location = new System.Drawing.Point(15, 42);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(247, 403);
            this.panel1.TabIndex = 249;
            // 
            // resultNotesTxt
            // 
            this.resultNotesTxt.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.resultNotesTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.resultNotesTxt.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resultNotesTxt.Location = new System.Drawing.Point(12, 293);
            this.resultNotesTxt.Multiline = true;
            this.resultNotesTxt.Name = "resultNotesTxt";
            this.resultNotesTxt.Size = new System.Drawing.Size(228, 63);
            this.resultNotesTxt.TabIndex = 246;
            // 
            // panel3
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel3, 2);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.button1);
            this.panel3.Location = new System.Drawing.Point(270, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(697, 33);
            this.panel3.TabIndex = 251;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(47, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 23);
            this.label2.TabIndex = 252;
            this.label2.Text = "Results";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = global::VHMIS.Properties.Resources.Cancel_16;
            this.button1.Location = new System.Drawing.Point(672, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(22, 21);
            this.button1.TabIndex = 246;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(42, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 23);
            this.label1.TabIndex = 248;
            this.label1.Text = "Add Service/Procedure";
            // 
            // button4
            // 
            this.button4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button4.Location = new System.Drawing.Point(801, 475);
            this.button4.Margin = new System.Windows.Forms.Padding(2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(156, 32);
            this.button4.TabIndex = 143;
            this.button4.Text = "Complete";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button11);
            this.panel2.Controls.Add(this.label44);
            this.panel2.Controls.Add(this.label35);
            this.panel2.Controls.Add(this.testResultsTxt);
            this.panel2.Controls.Add(this.examinationTxt);
            this.panel2.Controls.Add(this.label36);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Controls.Add(this.label38);
            this.panel2.Location = new System.Drawing.Point(718, 42);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(322, 425);
            this.panel2.TabIndex = 250;
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(152, 274);
            this.button11.Margin = new System.Windows.Forms.Padding(2);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(156, 24);
            this.button11.TabIndex = 151;
            this.button11.Text = "Add image";
            this.button11.UseVisualStyleBackColor = true;
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(22, 280);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(36, 13);
            this.label44.TabIndex = 150;
            this.label44.Text = "Image";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(22, 197);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(42, 13);
            this.label35.TabIndex = 149;
            this.label35.Text = "Results";
            // 
            // testResultsTxt
            // 
            this.testResultsTxt.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.testResultsTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.testResultsTxt.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.testResultsTxt.Location = new System.Drawing.Point(15, 213);
            this.testResultsTxt.Multiline = true;
            this.testResultsTxt.Name = "testResultsTxt";
            this.testResultsTxt.Size = new System.Drawing.Size(294, 54);
            this.testResultsTxt.TabIndex = 148;
            // 
            // examinationTxt
            // 
            this.examinationTxt.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.examinationTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.examinationTxt.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.examinationTxt.Location = new System.Drawing.Point(16, 129);
            this.examinationTxt.Multiline = true;
            this.examinationTxt.Name = "examinationTxt";
            this.examinationTxt.Size = new System.Drawing.Size(294, 61);
            this.examinationTxt.TabIndex = 147;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(21, 104);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(65, 13);
            this.label36.TabIndex = 146;
            this.label36.Text = "Examination";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(14, 28);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(294, 63);
            this.textBox1.TabIndex = 145;
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(16, 12);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(35, 13);
            this.label38.TabIndex = 144;
            this.label38.Text = "Notes";
            // 
            // panel9
            // 
            this.panel9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel9.Controls.Add(this.perfChart);
            this.panel9.Location = new System.Drawing.Point(270, 42);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(442, 425);
            this.panel9.TabIndex = 252;
            // 
            // perfChart
            // 
            this.perfChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.perfChart.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.perfChart.Location = new System.Drawing.Point(6, 8);
            this.perfChart.Name = "perfChart";
            this.perfChart.PerfChartStyle.AntiAliasing = true;
            chartPen1.Color = System.Drawing.Color.LightGreen;
            chartPen1.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            chartPen1.Width = 1F;
            this.perfChart.PerfChartStyle.AvgLinePen = chartPen1;
            this.perfChart.PerfChartStyle.BackgroundColorBottom = System.Drawing.Color.DarkOliveGreen;
            this.perfChart.PerfChartStyle.BackgroundColorTop = System.Drawing.Color.YellowGreen;
            chartPen2.Color = System.Drawing.Color.Gold;
            chartPen2.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
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
            this.perfChart.Size = new System.Drawing.Size(435, 413);
            this.perfChart.TabIndex = 1;
            this.perfChart.TimerInterval = 100;
            this.perfChart.TimerMode = SpPerfChart.TimerMode.Disabled;
            // 
            // ServiceDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(1068, 536);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ServiceDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ServiceDialog";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label serviceLbl;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox serviceQty;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox parameterTxt;
        private System.Windows.Forms.Button button18;
        private System.Windows.Forms.Label label56;
        private System.Windows.Forms.Label label55;
        private System.Windows.Forms.ComboBox statusCbx;
        private System.Windows.Forms.ComboBox operationCbx;
        private System.Windows.Forms.TextBox opCostTxt;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox resultNotesTxt;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.TextBox testResultsTxt;
        private System.Windows.Forms.TextBox examinationTxt;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Panel panel9;
        private SpPerfChart.PerfChart perfChart;
    }
}