namespace VHMIS
{
    partial class DentalDialog
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
            this.button1 = new System.Windows.Forms.Button();
            this.button16 = new System.Windows.Forms.Button();
            this.label46 = new System.Windows.Forms.Label();
            this.diagnosisCbx = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.serviceLbl = new System.Windows.Forms.Label();
            this.diagLbl = new System.Windows.Forms.Label();
            this.LabLbl = new System.Windows.Forms.Label();
            this.diagnosisQty = new System.Windows.Forms.TextBox();
            this.serviceQty = new System.Windows.Forms.TextBox();
            this.label47 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.labQty = new System.Windows.Forms.TextBox();
            this.labStatus = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.statusCbx = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.noteTxt = new System.Windows.Forms.TextBox();
            this.button17 = new System.Windows.Forms.Button();
            this.label52 = new System.Windows.Forms.Label();
            this.operationCbx = new System.Windows.Forms.ComboBox();
            this.diagCostTxt = new System.Windows.Forms.TextBox();
            this.labCbx = new System.Windows.Forms.ComboBox();
            this.labCostTxt = new System.Windows.Forms.TextBox();
            this.label45 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.opCostTxt = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.toothTxt = new System.Windows.Forms.TextBox();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = global::VHMIS.Properties.Resources.Cancel_16;
            this.button1.Location = new System.Drawing.Point(647, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(36, 21);
            this.button1.TabIndex = 190;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button16
            // 
            this.button16.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.button16.FlatAppearance.BorderSize = 0;
            this.button16.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button16.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button16.Location = new System.Drawing.Point(592, 89);
            this.button16.Margin = new System.Windows.Forms.Padding(2);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(64, 24);
            this.button16.TabIndex = 193;
            this.button16.Text = "Add";
            this.button16.UseVisualStyleBackColor = false;
            this.button16.Click += new System.EventHandler(this.button16_Click);
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Location = new System.Drawing.Point(14, 88);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(87, 13);
            this.label46.TabIndex = 191;
            this.label46.Text = "Diagnosis(ICD10)";
            // 
            // diagnosisCbx
            // 
            this.diagnosisCbx.FormattingEnabled = true;
            this.diagnosisCbx.Items.AddRange(new object[] {
            "+",
            "-",
            "Unknown"});
            this.diagnosisCbx.Location = new System.Drawing.Point(119, 85);
            this.diagnosisCbx.Name = "diagnosisCbx";
            this.diagnosisCbx.Size = new System.Drawing.Size(101, 21);
            this.diagnosisCbx.TabIndex = 192;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.serviceLbl);
            this.groupBox3.Controls.Add(this.diagLbl);
            this.groupBox3.Controls.Add(this.LabLbl);
            this.groupBox3.Controls.Add(this.diagnosisQty);
            this.groupBox3.Controls.Add(this.serviceQty);
            this.groupBox3.Controls.Add(this.label47);
            this.groupBox3.Controls.Add(this.label22);
            this.groupBox3.Controls.Add(this.labQty);
            this.groupBox3.Controls.Add(this.labStatus);
            this.groupBox3.Controls.Add(this.comboBox1);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.statusCbx);
            this.groupBox3.Controls.Add(this.button3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.noteTxt);
            this.groupBox3.Controls.Add(this.button17);
            this.groupBox3.Controls.Add(this.label52);
            this.groupBox3.Controls.Add(this.operationCbx);
            this.groupBox3.Controls.Add(this.diagCostTxt);
            this.groupBox3.Controls.Add(this.label46);
            this.groupBox3.Controls.Add(this.button16);
            this.groupBox3.Controls.Add(this.diagnosisCbx);
            this.groupBox3.Controls.Add(this.labCbx);
            this.groupBox3.Controls.Add(this.labCostTxt);
            this.groupBox3.Controls.Add(this.label45);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.opCostTxt);
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Location = new System.Drawing.Point(3, 39);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(680, 240);
            this.groupBox3.TabIndex = 194;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Requests";
            // 
            // serviceLbl
            // 
            this.serviceLbl.AutoSize = true;
            this.serviceLbl.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serviceLbl.ForeColor = System.Drawing.Color.DimGray;
            this.serviceLbl.Location = new System.Drawing.Point(486, 62);
            this.serviceLbl.Name = "serviceLbl";
            this.serviceLbl.Size = new System.Drawing.Size(33, 15);
            this.serviceLbl.TabIndex = 240;
            this.serviceLbl.Text = "Total";
            // 
            // diagLbl
            // 
            this.diagLbl.AutoSize = true;
            this.diagLbl.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.diagLbl.ForeColor = System.Drawing.Color.DimGray;
            this.diagLbl.Location = new System.Drawing.Point(486, 91);
            this.diagLbl.Name = "diagLbl";
            this.diagLbl.Size = new System.Drawing.Size(33, 15);
            this.diagLbl.TabIndex = 239;
            this.diagLbl.Text = "Total";
            // 
            // LabLbl
            // 
            this.LabLbl.AutoSize = true;
            this.LabLbl.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabLbl.ForeColor = System.Drawing.Color.DimGray;
            this.LabLbl.Location = new System.Drawing.Point(486, 33);
            this.LabLbl.Name = "LabLbl";
            this.LabLbl.Size = new System.Drawing.Size(33, 15);
            this.LabLbl.TabIndex = 238;
            this.LabLbl.Text = "Total";
            // 
            // diagnosisQty
            // 
            this.diagnosisQty.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.diagnosisQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.diagnosisQty.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.diagnosisQty.Location = new System.Drawing.Point(427, 88);
            this.diagnosisQty.Multiline = true;
            this.diagnosisQty.Name = "diagnosisQty";
            this.diagnosisQty.Size = new System.Drawing.Size(49, 21);
            this.diagnosisQty.TabIndex = 237;
            this.diagnosisQty.Text = "1";
            this.diagnosisQty.TextChanged += new System.EventHandler(this.diagnosisQty_TextChanged);
            // 
            // serviceQty
            // 
            this.serviceQty.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.serviceQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.serviceQty.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serviceQty.Location = new System.Drawing.Point(427, 59);
            this.serviceQty.Multiline = true;
            this.serviceQty.Name = "serviceQty";
            this.serviceQty.Size = new System.Drawing.Size(49, 21);
            this.serviceQty.TabIndex = 236;
            this.serviceQty.Text = "1";
            this.serviceQty.TextChanged += new System.EventHandler(this.serviceQty_TextChanged);
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label47.ForeColor = System.Drawing.Color.DimGray;
            this.label47.Location = new System.Drawing.Point(486, 15);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(33, 15);
            this.label47.TabIndex = 235;
            this.label47.Text = "Total";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(430, 17);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(47, 13);
            this.label22.TabIndex = 234;
            this.label22.Text = "Quantity";
            // 
            // labQty
            // 
            this.labQty.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labQty.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labQty.Location = new System.Drawing.Point(428, 32);
            this.labQty.Multiline = true;
            this.labQty.Name = "labQty";
            this.labQty.Size = new System.Drawing.Size(49, 21);
            this.labQty.TabIndex = 233;
            this.labQty.Text = "1";
            this.labQty.TextChanged += new System.EventHandler(this.labQty_TextChanged);
            // 
            // labStatus
            // 
            this.labStatus.FormattingEnabled = true;
            this.labStatus.Items.AddRange(new object[] {
            "Complete",
            "Not Done"});
            this.labStatus.Location = new System.Drawing.Point(335, 31);
            this.labStatus.Name = "labStatus";
            this.labStatus.Size = new System.Drawing.Size(87, 21);
            this.labStatus.TabIndex = 203;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Complete",
            "Not Done"});
            this.comboBox1.Location = new System.Drawing.Point(334, 88);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(87, 21);
            this.comboBox1.TabIndex = 202;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(332, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 14);
            this.label3.TabIndex = 201;
            this.label3.Text = "Status";
            // 
            // statusCbx
            // 
            this.statusCbx.FormattingEnabled = true;
            this.statusCbx.Items.AddRange(new object[] {
            "Complete",
            "Not Done"});
            this.statusCbx.Location = new System.Drawing.Point(334, 61);
            this.statusCbx.Name = "statusCbx";
            this.statusCbx.Size = new System.Drawing.Size(87, 21);
            this.statusCbx.TabIndex = 200;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.OrangeRed;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button3.Location = new System.Drawing.Point(591, 199);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(65, 24);
            this.button3.TabIndex = 199;
            this.button3.Text = "Save";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 198;
            this.label2.Text = "Notes";
            // 
            // noteTxt
            // 
            this.noteTxt.BackColor = System.Drawing.SystemColors.ControlLight;
            this.noteTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.noteTxt.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noteTxt.Location = new System.Drawing.Point(119, 127);
            this.noteTxt.Multiline = true;
            this.noteTxt.Name = "noteTxt";
            this.noteTxt.Size = new System.Drawing.Size(434, 57);
            this.noteTxt.TabIndex = 197;
            // 
            // button17
            // 
            this.button17.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.button17.FlatAppearance.BorderSize = 0;
            this.button17.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button17.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button17.Location = new System.Drawing.Point(592, 61);
            this.button17.Margin = new System.Windows.Forms.Padding(2);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(65, 24);
            this.button17.TabIndex = 196;
            this.button17.Text = "Add";
            this.button17.UseVisualStyleBackColor = false;
            this.button17.Click += new System.EventHandler(this.button17_Click);
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Location = new System.Drawing.Point(14, 61);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(99, 13);
            this.label52.TabIndex = 194;
            this.label52.Text = "Procedures/Service";
            this.label52.Click += new System.EventHandler(this.label52_Click);
            // 
            // operationCbx
            // 
            this.operationCbx.FormattingEnabled = true;
            this.operationCbx.Items.AddRange(new object[] {
            "+",
            "-",
            "Unknown"});
            this.operationCbx.Location = new System.Drawing.Point(119, 58);
            this.operationCbx.Name = "operationCbx";
            this.operationCbx.Size = new System.Drawing.Size(101, 21);
            this.operationCbx.TabIndex = 195;
            this.operationCbx.SelectedIndexChanged += new System.EventHandler(this.operationCbx_SelectedIndexChanged);
            // 
            // diagCostTxt
            // 
            this.diagCostTxt.BackColor = System.Drawing.SystemColors.ControlLight;
            this.diagCostTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.diagCostTxt.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.diagCostTxt.Location = new System.Drawing.Point(226, 88);
            this.diagCostTxt.Multiline = true;
            this.diagCostTxt.Name = "diagCostTxt";
            this.diagCostTxt.Size = new System.Drawing.Size(102, 18);
            this.diagCostTxt.TabIndex = 139;
            // 
            // labCbx
            // 
            this.labCbx.FormattingEnabled = true;
            this.labCbx.Location = new System.Drawing.Point(119, 31);
            this.labCbx.Name = "labCbx";
            this.labCbx.Size = new System.Drawing.Size(101, 21);
            this.labCbx.TabIndex = 138;
            this.labCbx.SelectedIndexChanged += new System.EventHandler(this.labCbx_SelectedIndexChanged);
            // 
            // labCostTxt
            // 
            this.labCostTxt.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.labCostTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.labCostTxt.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labCostTxt.Location = new System.Drawing.Point(226, 33);
            this.labCostTxt.Name = "labCostTxt";
            this.labCostTxt.Size = new System.Drawing.Size(103, 19);
            this.labCostTxt.TabIndex = 137;
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label45.Location = new System.Drawing.Point(226, 17);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(28, 14);
            this.label45.TabIndex = 136;
            this.label45.Text = "Cost";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(16, 33);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(63, 13);
            this.label16.TabIndex = 133;
            this.label16.Text = "Lab request";
            // 
            // opCostTxt
            // 
            this.opCostTxt.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.opCostTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.opCostTxt.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.opCostTxt.Location = new System.Drawing.Point(226, 60);
            this.opCostTxt.Name = "opCostTxt";
            this.opCostTxt.Size = new System.Drawing.Size(102, 19);
            this.opCostTxt.TabIndex = 126;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button2.Location = new System.Drawing.Point(592, 33);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(64, 24);
            this.button2.TabIndex = 135;
            this.button2.Text = "Request";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 197;
            this.label1.Text = "Tooth/Parameter";
            // 
            // toothTxt
            // 
            this.toothTxt.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.toothTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.toothTxt.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toothTxt.Location = new System.Drawing.Point(122, 8);
            this.toothTxt.Name = "toothTxt";
            this.toothTxt.Size = new System.Drawing.Size(103, 19);
            this.toothTxt.TabIndex = 241;
            // 
            // DentalDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(694, 291);
            this.Controls.Add(this.toothTxt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.button1);
            this.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DentalDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DentalDialog";
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button16;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.ComboBox diagnosisCbx;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox diagCostTxt;
        private System.Windows.Forms.ComboBox labCbx;
        private System.Windows.Forms.TextBox labCostTxt;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox opCostTxt;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button17;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.ComboBox operationCbx;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox noteTxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox statusCbx;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox labStatus;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox labQty;
        private System.Windows.Forms.TextBox diagnosisQty;
        private System.Windows.Forms.TextBox serviceQty;
        private System.Windows.Forms.Label serviceLbl;
        private System.Windows.Forms.Label diagLbl;
        private System.Windows.Forms.Label LabLbl;
        private System.Windows.Forms.TextBox toothTxt;
    }
}