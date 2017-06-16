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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.noteTxt = new System.Windows.Forms.TextBox();
            this.diagnosisCbx = new System.Windows.Forms.TextBox();
            this.codeTxt = new System.Windows.Forms.TextBox();
            this.toothTxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label52 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label47 = new System.Windows.Forms.Label();
            this.LabLbl = new System.Windows.Forms.Label();
            this.serviceLbl = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labStatus = new System.Windows.Forms.ComboBox();
            this.label45 = new System.Windows.Forms.Label();
            this.labQty = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.labCostTxt = new System.Windows.Forms.TextBox();
            this.diagLbl = new System.Windows.Forms.Label();
            this.serviceQty = new System.Windows.Forms.TextBox();
            this.labCbx = new System.Windows.Forms.ComboBox();
            this.operationCbx = new System.Windows.Forms.ComboBox();
            this.diagnosisQty = new System.Windows.Forms.TextBox();
            this.diagCostTxt = new System.Windows.Forms.TextBox();
            this.button17 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.statusCbx = new System.Windows.Forms.ComboBox();
            this.opCostTxt = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labChk = new System.Windows.Forms.CheckBox();
            this.serviceChk = new System.Windows.Forms.CheckBox();
            this.otherChk = new System.Windows.Forms.CheckBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = global::VHMIS.Properties.Resources.Cancel_16;
            this.button1.Location = new System.Drawing.Point(749, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(36, 21);
            this.button1.TabIndex = 190;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button16
            // 
            this.button16.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button16.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.button16.FlatAppearance.BorderSize = 0;
            this.button16.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button16.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button16.Location = new System.Drawing.Point(718, 86);
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
            this.label46.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label46.AutoSize = true;
            this.label46.Location = new System.Drawing.Point(17, 120);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(87, 13);
            this.label46.TabIndex = 191;
            this.label46.Text = "Diagnosis(ICD10)";
            this.label46.Click += new System.EventHandler(this.label46_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.White;
            this.groupBox3.Controls.Add(this.tableLayoutPanel1);
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(800, 240);
            this.groupBox3.TabIndex = 194;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Diagnosis";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 8;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 56F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 136F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 106F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 78F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 61F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel1.Controls.Add(this.label46, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.button1, 7, 0);
            this.tableLayoutPanel1.Controls.Add(this.label52, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label22, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.label47, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.LabLbl, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.serviceLbl, 5, 2);
            this.tableLayoutPanel1.Controls.Add(this.label3, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.labStatus, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.label45, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.labQty, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.label16, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.labCostTxt, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.diagLbl, 5, 3);
            this.tableLayoutPanel1.Controls.Add(this.serviceQty, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.labCbx, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.operationCbx, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.diagnosisQty, 4, 3);
            this.tableLayoutPanel1.Controls.Add(this.comboBox1, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.statusCbx, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.opCostTxt, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.diagnosisCbx, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.noteTxt, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.labChk, 6, 1);
            this.tableLayoutPanel1.Controls.Add(this.button2, 7, 1);
            this.tableLayoutPanel1.Controls.Add(this.button17, 7, 2);
            this.tableLayoutPanel1.Controls.Add(this.button16, 7, 3);
            this.tableLayoutPanel1.Controls.Add(this.serviceChk, 6, 2);
            this.tableLayoutPanel1.Controls.Add(this.otherChk, 6, 3);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.toothTxt, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.diagCostTxt, 5, 4);
            this.tableLayoutPanel1.Controls.Add(this.label17, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.codeTxt, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.comboBox2, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.textBox1, 4, 4);
            this.tableLayoutPanel1.Controls.Add(this.button3, 7, 5);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 20);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 73F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(788, 214);
            this.tableLayoutPanel1.TabIndex = 249;
            // 
            // noteTxt
            // 
            this.noteTxt.BackColor = System.Drawing.SystemColors.ControlLight;
            this.noteTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tableLayoutPanel1.SetColumnSpan(this.noteTxt, 5);
            this.noteTxt.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noteTxt.Location = new System.Drawing.Point(124, 144);
            this.noteTxt.Multiline = true;
            this.noteTxt.Name = "noteTxt";
            this.noteTxt.Size = new System.Drawing.Size(524, 67);
            this.noteTxt.TabIndex = 197;
            // 
            // diagnosisCbx
            // 
            this.diagnosisCbx.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.diagnosisCbx.BackColor = System.Drawing.SystemColors.ControlLight;
            this.diagnosisCbx.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.diagnosisCbx.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.diagnosisCbx.Location = new System.Drawing.Point(124, 115);
            this.diagnosisCbx.Name = "diagnosisCbx";
            this.diagnosisCbx.Size = new System.Drawing.Size(148, 26);
            this.diagnosisCbx.TabIndex = 245;
            this.diagnosisCbx.Leave += new System.EventHandler(this.diagnosisCbx_Leave);
            // 
            // codeTxt
            // 
            this.codeTxt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.codeTxt.BackColor = System.Drawing.SystemColors.ControlLight;
            this.codeTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.codeTxt.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codeTxt.Location = new System.Drawing.Point(282, 115);
            this.codeTxt.Multiline = true;
            this.codeTxt.Name = "codeTxt";
            this.codeTxt.Size = new System.Drawing.Size(121, 23);
            this.codeTxt.TabIndex = 247;
            // 
            // toothTxt
            // 
            this.toothTxt.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.toothTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.toothTxt.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toothTxt.Location = new System.Drawing.Point(124, 3);
            this.toothTxt.Name = "toothTxt";
            this.toothTxt.Size = new System.Drawing.Size(148, 19);
            this.toothTxt.TabIndex = 241;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 197;
            this.label1.Text = "Tooth/Parameter";
            // 
            // label52
            // 
            this.label52.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label52.AutoSize = true;
            this.label52.Location = new System.Drawing.Point(11, 63);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(99, 13);
            this.label52.TabIndex = 194;
            this.label52.Text = "Procedures/Service";
            this.label52.Click += new System.EventHandler(this.label52_Click);
            // 
            // label22
            // 
            this.label22.BackColor = System.Drawing.Color.Transparent;
            this.label22.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label22.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label22.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.Maroon;
            this.label22.Location = new System.Drawing.Point(520, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(50, 28);
            this.label22.TabIndex = 234;
            this.label22.Text = "Qty";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label47
            // 
            this.label47.BackColor = System.Drawing.Color.Transparent;
            this.label47.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label47.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label47.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label47.ForeColor = System.Drawing.Color.Maroon;
            this.label47.Location = new System.Drawing.Point(576, 0);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(72, 28);
            this.label47.TabIndex = 235;
            this.label47.Text = "Total";
            this.label47.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LabLbl
            // 
            this.LabLbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LabLbl.AutoSize = true;
            this.LabLbl.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabLbl.ForeColor = System.Drawing.Color.DimGray;
            this.LabLbl.Location = new System.Drawing.Point(595, 34);
            this.LabLbl.Name = "LabLbl";
            this.LabLbl.Size = new System.Drawing.Size(33, 15);
            this.LabLbl.TabIndex = 238;
            this.LabLbl.Text = "Total";
            // 
            // serviceLbl
            // 
            this.serviceLbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.serviceLbl.AutoSize = true;
            this.serviceLbl.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serviceLbl.ForeColor = System.Drawing.Color.DimGray;
            this.serviceLbl.Location = new System.Drawing.Point(595, 62);
            this.serviceLbl.Name = "serviceLbl";
            this.serviceLbl.Size = new System.Drawing.Size(33, 15);
            this.serviceLbl.TabIndex = 240;
            this.serviceLbl.Text = "Total";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Maroon;
            this.label3.Location = new System.Drawing.Point(414, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 28);
            this.label3.TabIndex = 201;
            this.label3.Text = "Status";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labStatus
            // 
            this.labStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labStatus.FormattingEnabled = true;
            this.labStatus.Items.AddRange(new object[] {
            "Complete",
            "Not Done"});
            this.labStatus.Location = new System.Drawing.Point(414, 31);
            this.labStatus.Name = "labStatus";
            this.labStatus.Size = new System.Drawing.Size(100, 21);
            this.labStatus.TabIndex = 203;
            // 
            // label45
            // 
            this.label45.BackColor = System.Drawing.Color.Transparent;
            this.label45.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label45.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label45.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label45.ForeColor = System.Drawing.Color.Maroon;
            this.label45.Location = new System.Drawing.Point(278, 0);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(130, 28);
            this.label45.TabIndex = 136;
            this.label45.Text = "Cost";
            this.label45.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labQty
            // 
            this.labQty.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labQty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labQty.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labQty.Location = new System.Drawing.Point(520, 31);
            this.labQty.Multiline = true;
            this.labQty.Name = "labQty";
            this.labQty.Size = new System.Drawing.Size(50, 21);
            this.labQty.TabIndex = 233;
            this.labQty.Text = "1";
            this.labQty.TextChanged += new System.EventHandler(this.labQty_TextChanged);
            // 
            // label16
            // 
            this.label16.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(29, 35);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(63, 13);
            this.label16.TabIndex = 133;
            this.label16.Text = "Lab request";
            // 
            // labCostTxt
            // 
            this.labCostTxt.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.labCostTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.labCostTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labCostTxt.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labCostTxt.Location = new System.Drawing.Point(278, 31);
            this.labCostTxt.Name = "labCostTxt";
            this.labCostTxt.Size = new System.Drawing.Size(130, 19);
            this.labCostTxt.TabIndex = 137;
            // 
            // diagLbl
            // 
            this.diagLbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.diagLbl.AutoSize = true;
            this.diagLbl.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.diagLbl.ForeColor = System.Drawing.Color.DimGray;
            this.diagLbl.Location = new System.Drawing.Point(595, 90);
            this.diagLbl.Name = "diagLbl";
            this.diagLbl.Size = new System.Drawing.Size(33, 15);
            this.diagLbl.TabIndex = 239;
            this.diagLbl.Text = "Total";
            // 
            // serviceQty
            // 
            this.serviceQty.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.serviceQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.serviceQty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.serviceQty.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serviceQty.Location = new System.Drawing.Point(520, 58);
            this.serviceQty.Multiline = true;
            this.serviceQty.Name = "serviceQty";
            this.serviceQty.Size = new System.Drawing.Size(50, 23);
            this.serviceQty.TabIndex = 236;
            this.serviceQty.Text = "1";
            this.serviceQty.TextChanged += new System.EventHandler(this.serviceQty_TextChanged);
            // 
            // labCbx
            // 
            this.labCbx.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labCbx.FormattingEnabled = true;
            this.labCbx.Location = new System.Drawing.Point(124, 31);
            this.labCbx.Name = "labCbx";
            this.labCbx.Size = new System.Drawing.Size(148, 21);
            this.labCbx.TabIndex = 138;
            this.labCbx.SelectedIndexChanged += new System.EventHandler(this.labCbx_SelectedIndexChanged);
            // 
            // operationCbx
            // 
            this.operationCbx.Dock = System.Windows.Forms.DockStyle.Fill;
            this.operationCbx.FormattingEnabled = true;
            this.operationCbx.Location = new System.Drawing.Point(124, 58);
            this.operationCbx.Name = "operationCbx";
            this.operationCbx.Size = new System.Drawing.Size(148, 21);
            this.operationCbx.TabIndex = 195;
            this.operationCbx.SelectedIndexChanged += new System.EventHandler(this.operationCbx_SelectedIndexChanged);
            // 
            // diagnosisQty
            // 
            this.diagnosisQty.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.diagnosisQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.diagnosisQty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.diagnosisQty.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.diagnosisQty.Location = new System.Drawing.Point(520, 87);
            this.diagnosisQty.Multiline = true;
            this.diagnosisQty.Name = "diagnosisQty";
            this.diagnosisQty.Size = new System.Drawing.Size(50, 22);
            this.diagnosisQty.TabIndex = 237;
            this.diagnosisQty.Text = "1";
            this.diagnosisQty.TextChanged += new System.EventHandler(this.diagnosisQty_TextChanged);
            // 
            // diagCostTxt
            // 
            this.diagCostTxt.BackColor = System.Drawing.SystemColors.ControlLight;
            this.diagCostTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.diagCostTxt.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.diagCostTxt.Location = new System.Drawing.Point(576, 115);
            this.diagCostTxt.Multiline = true;
            this.diagCostTxt.Name = "diagCostTxt";
            this.diagCostTxt.Size = new System.Drawing.Size(72, 22);
            this.diagCostTxt.TabIndex = 139;
            // 
            // button17
            // 
            this.button17.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button17.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.button17.FlatAppearance.BorderSize = 0;
            this.button17.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button17.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button17.Location = new System.Drawing.Point(717, 57);
            this.button17.Margin = new System.Windows.Forms.Padding(2);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(65, 24);
            this.button17.TabIndex = 196;
            this.button17.Text = "Add";
            this.button17.UseVisualStyleBackColor = false;
            this.button17.Click += new System.EventHandler(this.button17_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Complete",
            "Not Done"});
            this.comboBox1.Location = new System.Drawing.Point(414, 87);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(100, 21);
            this.comboBox1.TabIndex = 202;
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button2.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button2.Location = new System.Drawing.Point(718, 30);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(64, 23);
            this.button2.TabIndex = 135;
            this.button2.Text = "Request";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // statusCbx
            // 
            this.statusCbx.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusCbx.FormattingEnabled = true;
            this.statusCbx.Items.AddRange(new object[] {
            "Complete",
            "Not Done"});
            this.statusCbx.Location = new System.Drawing.Point(414, 58);
            this.statusCbx.Name = "statusCbx";
            this.statusCbx.Size = new System.Drawing.Size(100, 21);
            this.statusCbx.TabIndex = 200;
            // 
            // opCostTxt
            // 
            this.opCostTxt.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.opCostTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.opCostTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.opCostTxt.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.opCostTxt.Location = new System.Drawing.Point(278, 58);
            this.opCostTxt.Name = "opCostTxt";
            this.opCostTxt.Size = new System.Drawing.Size(130, 19);
            this.opCostTxt.TabIndex = 126;
            // 
            // label17
            // 
            this.label17.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label17.Location = new System.Drawing.Point(327, 91);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(31, 14);
            this.label17.TabIndex = 248;
            this.label17.Text = "Code";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 171);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 198;
            this.label2.Text = "Notes";
            // 
            // button3
            // 
            this.button3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button3.BackColor = System.Drawing.Color.OrangeRed;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button3.Location = new System.Drawing.Point(717, 143);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(65, 68);
            this.button3.TabIndex = 199;
            this.button3.Text = "Save";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Location = new System.Drawing.Point(12, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(806, 258);
            this.panel1.TabIndex = 195;
            // 
            // labChk
            // 
            this.labChk.BackColor = System.Drawing.Color.Transparent;
            this.labChk.Location = new System.Drawing.Point(654, 31);
            this.labChk.Name = "labChk";
            this.labChk.Size = new System.Drawing.Size(55, 17);
            this.labChk.TabIndex = 249;
            this.labChk.Text = "Paid";
            this.labChk.UseVisualStyleBackColor = false;
            // 
            // serviceChk
            // 
            this.serviceChk.BackColor = System.Drawing.Color.Transparent;
            this.serviceChk.Location = new System.Drawing.Point(654, 58);
            this.serviceChk.Name = "serviceChk";
            this.serviceChk.Size = new System.Drawing.Size(55, 17);
            this.serviceChk.TabIndex = 250;
            this.serviceChk.Text = "Paid";
            this.serviceChk.UseVisualStyleBackColor = false;
            // 
            // otherChk
            // 
            this.otherChk.BackColor = System.Drawing.Color.Transparent;
            this.otherChk.Location = new System.Drawing.Point(654, 87);
            this.otherChk.Name = "otherChk";
            this.otherChk.Size = new System.Drawing.Size(55, 17);
            this.otherChk.TabIndex = 251;
            this.otherChk.Text = "Paid";
            this.otherChk.UseVisualStyleBackColor = false;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Complete",
            "Not Done"});
            this.comboBox2.Location = new System.Drawing.Point(414, 115);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(100, 21);
            this.comboBox2.TabIndex = 252;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(520, 115);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(50, 22);
            this.textBox1.TabIndex = 253;
            this.textBox1.Text = "1";
            // 
            // DentalDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(830, 282);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DentalDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DentalDialog";
            this.groupBox3.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button16;
        private System.Windows.Forms.Label label46;
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
        private System.Windows.Forms.TextBox diagnosisCbx;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox codeTxt;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.CheckBox labChk;
        private System.Windows.Forms.CheckBox serviceChk;
        private System.Windows.Forms.CheckBox otherChk;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.TextBox textBox1;
    }
}