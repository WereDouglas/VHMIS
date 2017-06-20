namespace VHMIS
{
    partial class EventDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EventDialog));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.departmentCbx = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.clinicCbx = new System.Windows.Forms.ComboBox();
            this.priorityCbx = new System.Windows.Forms.ComboBox();
            this.notifyChk = new System.Windows.Forms.CheckBox();
            this.endMinTxt = new System.Windows.Forms.TextBox();
            this.startMinTxt = new System.Windows.Forms.TextBox();
            this.detailsTxt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.endHrTxt = new System.Windows.Forms.ComboBox();
            this.startHrTxt = new System.Windows.Forms.ComboBox();
            this.patientTxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.practitionerTxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.openedDate = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.departmentCbx);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.button5);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label25);
            this.groupBox1.Controls.Add(this.clinicCbx);
            this.groupBox1.Controls.Add(this.priorityCbx);
            this.groupBox1.Controls.Add(this.notifyChk);
            this.groupBox1.Controls.Add(this.endMinTxt);
            this.groupBox1.Controls.Add(this.startMinTxt);
            this.groupBox1.Controls.Add(this.detailsTxt);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.endHrTxt);
            this.groupBox1.Controls.Add(this.startHrTxt);
            this.groupBox1.Controls.Add(this.patientTxt);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.practitionerTxt);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.openedDate);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(24, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(292, 418);
            this.groupBox1.TabIndex = 142;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add new appointment";
            // 
            // departmentCbx
            // 
            this.departmentCbx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.departmentCbx.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.departmentCbx.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.departmentCbx.FormattingEnabled = true;
            this.departmentCbx.Location = new System.Drawing.Point(92, 87);
            this.departmentCbx.Margin = new System.Windows.Forms.Padding(4);
            this.departmentCbx.Name = "departmentCbx";
            this.departmentCbx.Size = new System.Drawing.Size(181, 23);
            this.departmentCbx.TabIndex = 174;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 247);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 15);
            this.label8.TabIndex = 155;
            this.label8.Text = "Priority:";
            // 
            // button5
            // 
            this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button5.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button5.Location = new System.Drawing.Point(202, 374);
            this.button5.Margin = new System.Windows.Forms.Padding(2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(71, 29);
            this.button5.TabIndex = 154;
            this.button5.Text = "Create";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(13, 90);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(71, 15);
            this.label16.TabIndex = 173;
            this.label16.Text = "Department";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(89, 304);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 15);
            this.label6.TabIndex = 151;
            this.label6.Text = "Remarks/Reason";
            // 
            // label25
            // 
            this.label25.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(13, 60);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(39, 15);
            this.label25.TabIndex = 171;
            this.label25.Text = "Clinic";
            // 
            // clinicCbx
            // 
            this.clinicCbx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.clinicCbx.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.clinicCbx.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clinicCbx.FormattingEnabled = true;
            this.clinicCbx.Location = new System.Drawing.Point(92, 52);
            this.clinicCbx.Margin = new System.Windows.Forms.Padding(4);
            this.clinicCbx.Name = "clinicCbx";
            this.clinicCbx.Size = new System.Drawing.Size(181, 23);
            this.clinicCbx.TabIndex = 172;
            // 
            // priorityCbx
            // 
            this.priorityCbx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.priorityCbx.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.priorityCbx.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.priorityCbx.FormattingEnabled = true;
            this.priorityCbx.Items.AddRange(new object[] {
            "High",
            "Medium",
            "Low"});
            this.priorityCbx.Location = new System.Drawing.Point(92, 239);
            this.priorityCbx.Margin = new System.Windows.Forms.Padding(4);
            this.priorityCbx.Name = "priorityCbx";
            this.priorityCbx.Size = new System.Drawing.Size(181, 23);
            this.priorityCbx.TabIndex = 156;
            // 
            // notifyChk
            // 
            this.notifyChk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.notifyChk.AutoSize = true;
            this.notifyChk.Location = new System.Drawing.Point(92, 269);
            this.notifyChk.Name = "notifyChk";
            this.notifyChk.Size = new System.Drawing.Size(117, 19);
            this.notifyChk.TabIndex = 153;
            this.notifyChk.Text = "Send notification";
            this.notifyChk.UseVisualStyleBackColor = true;
            // 
            // endMinTxt
            // 
            this.endMinTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.endMinTxt.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.endMinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.endMinTxt.Location = new System.Drawing.Point(230, 213);
            this.endMinTxt.Name = "endMinTxt";
            this.endMinTxt.Size = new System.Drawing.Size(43, 16);
            this.endMinTxt.TabIndex = 150;
            // 
            // startMinTxt
            // 
            this.startMinTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.startMinTxt.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.startMinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.startMinTxt.Location = new System.Drawing.Point(230, 183);
            this.startMinTxt.Name = "startMinTxt";
            this.startMinTxt.Size = new System.Drawing.Size(43, 16);
            this.startMinTxt.TabIndex = 149;
            // 
            // detailsTxt
            // 
            this.detailsTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.detailsTxt.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.detailsTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.detailsTxt.Location = new System.Drawing.Point(90, 322);
            this.detailsTxt.Multiline = true;
            this.detailsTxt.Name = "detailsTxt";
            this.detailsTxt.Size = new System.Drawing.Size(181, 35);
            this.detailsTxt.TabIndex = 152;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 180);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 15);
            this.label4.TabIndex = 145;
            this.label4.Text = "Start time:";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 213);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 15);
            this.label5.TabIndex = 146;
            this.label5.Text = "End time:";
            // 
            // endHrTxt
            // 
            this.endHrTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.endHrTxt.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.endHrTxt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.endHrTxt.FormattingEnabled = true;
            this.endHrTxt.Items.AddRange(new object[] {
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18"});
            this.endHrTxt.Location = new System.Drawing.Point(92, 209);
            this.endHrTxt.Name = "endHrTxt";
            this.endHrTxt.Size = new System.Drawing.Size(82, 23);
            this.endHrTxt.TabIndex = 148;
            // 
            // startHrTxt
            // 
            this.startHrTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.startHrTxt.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.startHrTxt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startHrTxt.Items.AddRange(new object[] {
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23"});
            this.startHrTxt.Location = new System.Drawing.Point(92, 180);
            this.startHrTxt.Name = "startHrTxt";
            this.startHrTxt.Size = new System.Drawing.Size(82, 23);
            this.startHrTxt.TabIndex = 147;
            this.startHrTxt.SelectedIndexChanged += new System.EventHandler(this.startHrTxt_SelectedIndexChanged);
            // 
            // patientTxt
            // 
            this.patientTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.patientTxt.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.patientTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.patientTxt.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.patientTxt.Location = new System.Drawing.Point(92, 150);
            this.patientTxt.Name = "patientTxt";
            this.patientTxt.Size = new System.Drawing.Size(181, 19);
            this.patientTxt.TabIndex = 144;
            this.patientTxt.Leave += new System.EventHandler(this.patientTxt_Leave);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 154);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 15);
            this.label3.TabIndex = 143;
            this.label3.Text = "Patient";
            // 
            // practitionerTxt
            // 
            this.practitionerTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.practitionerTxt.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.practitionerTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.practitionerTxt.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.practitionerTxt.Location = new System.Drawing.Point(92, 118);
            this.practitionerTxt.Name = "practitionerTxt";
            this.practitionerTxt.Size = new System.Drawing.Size(181, 19);
            this.practitionerTxt.TabIndex = 142;
            this.practitionerTxt.Leave += new System.EventHandler(this.practitionerTxt_Leave);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 15);
            this.label2.TabIndex = 141;
            this.label2.Text = "Practictioner";
            // 
            // openedDate
            // 
            this.openedDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.openedDate.Location = new System.Drawing.Point(92, 22);
            this.openedDate.Name = "openedDate";
            this.openedDate.Size = new System.Drawing.Size(181, 23);
            this.openedDate.TabIndex = 92;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 15);
            this.label7.TabIndex = 93;
            this.label7.Text = "Date:";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.176471F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 93.82353F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 11F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(352, 424);
            this.tableLayoutPanel1.TabIndex = 143;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.DarkOrange;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(90, 374);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(71, 29);
            this.button1.TabIndex = 175;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // EventDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(376, 448);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EventDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EventDialog";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox departmentCbx;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.ComboBox clinicCbx;
        private System.Windows.Forms.ComboBox priorityCbx;
        private System.Windows.Forms.CheckBox notifyChk;
        private System.Windows.Forms.TextBox endMinTxt;
        private System.Windows.Forms.TextBox startMinTxt;
        private System.Windows.Forms.TextBox detailsTxt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox endHrTxt;
        private System.Windows.Forms.ComboBox startHrTxt;
        private System.Windows.Forms.TextBox patientTxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox practitionerTxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker openedDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button button1;
    }
}