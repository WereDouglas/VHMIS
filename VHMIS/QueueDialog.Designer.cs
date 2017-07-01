namespace VHMIS
{
    partial class QueueDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QueueDialog));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.myTreeView = new System.Windows.Forms.TreeView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.orderLbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.remarksTxt = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.departmentCbx = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.roomCbx = new System.Windows.Forms.ComboBox();
            this.openedDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.priorityCbx = new System.Windows.Forms.ComboBox();
            this.patientTxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.practitionerTxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.dtGrid = new System.Windows.Forms.DataGridView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.paidChk = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2.616279F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 97.38372F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 294F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 348F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Controls.Add(this.myTreeView, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label9, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.dtGrid, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.button1, 4, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.139186F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 94.86082F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(948, 529);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // myTreeView
            // 
            this.myTreeView.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.myTreeView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.myTreeView.Location = new System.Drawing.Point(278, 30);
            this.myTreeView.Name = "myTreeView";
            this.myTreeView.ShowNodeToolTips = true;
            this.myTreeView.Size = new System.Drawing.Size(288, 496);
            this.myTreeView.TabIndex = 195;
            this.myTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.myTreeView_AfterSelect);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.orderLbl);
            this.panel1.Controls.Add(this.paidChk);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.remarksTxt);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.departmentCbx);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.roomCbx);
            this.panel1.Controls.Add(this.openedDate);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.priorityCbx);
            this.panel1.Controls.Add(this.patientTxt);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.practitionerTxt);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(10, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(262, 496);
            this.panel1.TabIndex = 0;
            // 
            // orderLbl
            // 
            this.orderLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.orderLbl.AutoSize = true;
            this.orderLbl.Location = new System.Drawing.Point(101, 22);
            this.orderLbl.Name = "orderLbl";
            this.orderLbl.Size = new System.Drawing.Size(12, 13);
            this.orderLbl.TabIndex = 197;
            this.orderLbl.Text = "#";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 190;
            this.label1.Text = "Date";
            // 
            // remarksTxt
            // 
            this.remarksTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.remarksTxt.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.remarksTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.remarksTxt.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.remarksTxt.Location = new System.Drawing.Point(103, 249);
            this.remarksTxt.Multiline = true;
            this.remarksTxt.Name = "remarksTxt";
            this.remarksTxt.Size = new System.Drawing.Size(124, 44);
            this.remarksTxt.TabIndex = 188;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(26, 259);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 13);
            this.label7.TabIndex = 187;
            this.label7.Text = "Remarks";
            // 
            // departmentCbx
            // 
            this.departmentCbx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.departmentCbx.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.departmentCbx.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.departmentCbx.FormattingEnabled = true;
            this.departmentCbx.Location = new System.Drawing.Point(104, 137);
            this.departmentCbx.Margin = new System.Windows.Forms.Padding(4);
            this.departmentCbx.Name = "departmentCbx";
            this.departmentCbx.Size = new System.Drawing.Size(124, 21);
            this.departmentCbx.TabIndex = 186;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 140);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 13);
            this.label6.TabIndex = 185;
            this.label6.Text = "Department/Clinic";
            // 
            // roomCbx
            // 
            this.roomCbx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.roomCbx.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.roomCbx.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roomCbx.FormattingEnabled = true;
            this.roomCbx.Location = new System.Drawing.Point(103, 165);
            this.roomCbx.Margin = new System.Windows.Forms.Padding(4);
            this.roomCbx.Name = "roomCbx";
            this.roomCbx.Size = new System.Drawing.Size(124, 21);
            this.roomCbx.TabIndex = 184;
            this.roomCbx.SelectedIndexChanged += new System.EventHandler(this.roomCbx_SelectedIndexChanged);
            // 
            // openedDate
            // 
            this.openedDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.openedDate.Location = new System.Drawing.Point(103, 57);
            this.openedDate.Name = "openedDate";
            this.openedDate.Size = new System.Drawing.Size(124, 21);
            this.openedDate.TabIndex = 182;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 175);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 181;
            this.label5.Text = "Room";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(26, 224);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 13);
            this.label8.TabIndex = 178;
            this.label8.Text = "Priority:";
            // 
            // priorityCbx
            // 
            this.priorityCbx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.priorityCbx.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.priorityCbx.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.priorityCbx.FormattingEnabled = true;
            this.priorityCbx.Items.AddRange(new object[] {
            "High",
            "Medium",
            "Low"});
            this.priorityCbx.Location = new System.Drawing.Point(103, 221);
            this.priorityCbx.Margin = new System.Windows.Forms.Padding(4);
            this.priorityCbx.Name = "priorityCbx";
            this.priorityCbx.Size = new System.Drawing.Size(124, 21);
            this.priorityCbx.TabIndex = 179;
            // 
            // patientTxt
            // 
            this.patientTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.patientTxt.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.patientTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.patientTxt.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.patientTxt.Location = new System.Drawing.Point(103, 111);
            this.patientTxt.Name = "patientTxt";
            this.patientTxt.Size = new System.Drawing.Size(124, 19);
            this.patientTxt.TabIndex = 177;
            this.patientTxt.Leave += new System.EventHandler(this.patientTxt_Leave);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 176;
            this.label3.Text = "Patient";
            // 
            // practitionerTxt
            // 
            this.practitionerTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.practitionerTxt.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.practitionerTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.practitionerTxt.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.practitionerTxt.Location = new System.Drawing.Point(103, 85);
            this.practitionerTxt.Name = "practitionerTxt";
            this.practitionerTxt.Size = new System.Drawing.Size(124, 19);
            this.practitionerTxt.TabIndex = 175;
            this.practitionerTxt.Leave += new System.EventHandler(this.practitionerTxt_Leave);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 174;
            this.label2.Text = "Practictioner";
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label9.Location = new System.Drawing.Point(10, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(262, 27);
            this.label9.TabIndex = 191;
            this.label9.Text = "New Visit/Consultation";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackgroundImage = global::VHMIS.Properties.Resources.Cancel_16;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(930, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(15, 18);
            this.button1.TabIndex = 2;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dtGrid
            // 
            this.dtGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtGrid.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dtGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGrid.Location = new System.Drawing.Point(572, 30);
            this.dtGrid.Name = "dtGrid";
            this.dtGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dtGrid.RowHeadersVisible = false;
            this.dtGrid.Size = new System.Drawing.Size(342, 496);
            this.dtGrid.TabIndex = 194;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Folder-24 (1).png");
            this.imageList1.Images.SetKeyName(1, "Document-32.png");
            this.imageList1.Images.SetKeyName(2, "Folder-24.png");
            // 
            // paidChk
            // 
            this.paidChk.AutoSize = true;
            this.paidChk.Location = new System.Drawing.Point(104, 318);
            this.paidChk.Name = "paidChk";
            this.paidChk.Size = new System.Drawing.Size(47, 17);
            this.paidChk.TabIndex = 193;
            this.paidChk.Text = "Paid";
            this.paidChk.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button2.Location = new System.Drawing.Point(104, 384);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(124, 23);
            this.button2.TabIndex = 217;
            this.button2.Text = "Save";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // QueueDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(972, 553);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "QueueDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "QueueDialog";
            this.Load += new System.EventHandler(this.QueueDialog_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox remarksTxt;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox departmentCbx;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox roomCbx;
        private System.Windows.Forms.DateTimePicker openedDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox priorityCbx;
        private System.Windows.Forms.TextBox patientTxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox practitionerTxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label orderLbl;
        private System.Windows.Forms.DataGridView dtGrid;
        private System.Windows.Forms.TreeView myTreeView;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.CheckBox paidChk;
        private System.Windows.Forms.Button button2;
    }
}