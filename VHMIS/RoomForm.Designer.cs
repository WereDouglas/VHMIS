namespace VHMIS
{
    partial class RoomForm
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
            this.dtGrid = new System.Windows.Forms.DataGridView();
            this.practitionerCbx = new System.Windows.Forms.ComboBox();
            this.codeTxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.roomTxt = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.descriptionTxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.saveBtn = new System.Windows.Forms.Button();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.contactTxt = new System.Windows.Forms.TextBox();
            this.userLbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtGrid)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtGrid
            // 
            this.dtGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtGrid.Location = new System.Drawing.Point(0, 0);
            this.dtGrid.Name = "dtGrid";
            this.dtGrid.Size = new System.Drawing.Size(787, 470);
            this.dtGrid.TabIndex = 0;
            // 
            // practitionerCbx
            // 
            this.practitionerCbx.FormattingEnabled = true;
            this.practitionerCbx.Location = new System.Drawing.Point(19, 201);
            this.practitionerCbx.Name = "practitionerCbx";
            this.practitionerCbx.Size = new System.Drawing.Size(180, 21);
            this.practitionerCbx.TabIndex = 139;
            this.practitionerCbx.SelectedIndexChanged += new System.EventHandler(this.practitionerCbx_SelectedIndexChanged);
            // 
            // codeTxt
            // 
            this.codeTxt.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.codeTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.codeTxt.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codeTxt.Location = new System.Drawing.Point(19, 73);
            this.codeTxt.Name = "codeTxt";
            this.codeTxt.Size = new System.Drawing.Size(180, 19);
            this.codeTxt.TabIndex = 131;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 185);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 130;
            this.label2.Text = "Practitioner";
            // 
            // roomTxt
            // 
            this.roomTxt.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.roomTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.roomTxt.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roomTxt.Location = new System.Drawing.Point(19, 33);
            this.roomTxt.Name = "roomTxt";
            this.roomTxt.Size = new System.Drawing.Size(180, 19);
            this.roomTxt.TabIndex = 129;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.Snow;
            this.button2.Location = new System.Drawing.Point(22, 319);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(61, 35);
            this.button2.TabIndex = 128;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(16, 17);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(35, 13);
            this.label16.TabIndex = 119;
            this.label16.Text = "Name";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.userLbl);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.contactTxt);
            this.groupBox1.Controls.Add(this.practitionerCbx);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.descriptionTxt);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.codeTxt);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.roomTxt);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.saveBtn);
            this.groupBox1.Location = new System.Drawing.Point(9, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(212, 460);
            this.groupBox1.TabIndex = 125;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add/Update";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 134;
            this.label4.Text = "Description";
            // 
            // descriptionTxt
            // 
            this.descriptionTxt.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.descriptionTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.descriptionTxt.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descriptionTxt.Location = new System.Drawing.Point(19, 111);
            this.descriptionTxt.Multiline = true;
            this.descriptionTxt.Name = "descriptionTxt";
            this.descriptionTxt.Size = new System.Drawing.Size(180, 71);
            this.descriptionTxt.TabIndex = 133;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 132;
            this.label3.Text = "Code";
            // 
            // saveBtn
            // 
            this.saveBtn.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.saveBtn.FlatAppearance.BorderSize = 0;
            this.saveBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveBtn.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveBtn.ForeColor = System.Drawing.Color.Snow;
            this.saveBtn.Location = new System.Drawing.Point(140, 319);
            this.saveBtn.Margin = new System.Windows.Forms.Padding(2);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(59, 35);
            this.saveBtn.TabIndex = 124;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = false;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.dtGrid);
            this.splitContainer2.Size = new System.Drawing.Size(1019, 470);
            this.splitContainer2.SplitterDistance = 228;
            this.splitContainer2.TabIndex = 126;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1019, 499);
            this.splitContainer1.SplitterDistance = 25;
            this.splitContainer1.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Rooms";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = global::VHMIS.Properties.Resources.Cancel_16;
            this.button1.Location = new System.Drawing.Point(971, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(36, 21);
            this.button1.TabIndex = 1;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 235);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 141;
            this.label5.Text = "Contact";
            // 
            // contactTxt
            // 
            this.contactTxt.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.contactTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.contactTxt.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contactTxt.Location = new System.Drawing.Point(22, 253);
            this.contactTxt.Name = "contactTxt";
            this.contactTxt.Size = new System.Drawing.Size(180, 19);
            this.contactTxt.TabIndex = 140;
            // 
            // userLbl
            // 
            this.userLbl.AutoSize = true;
            this.userLbl.Location = new System.Drawing.Point(24, 275);
            this.userLbl.Name = "userLbl";
            this.userLbl.Size = new System.Drawing.Size(12, 13);
            this.userLbl.TabIndex = 142;
            this.userLbl.Text = "#";
            // 
            // RoomForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1019, 499);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RoomForm";
            this.Text = "RoomForm";
            ((System.ComponentModel.ISupportInitialize)(this.dtGrid)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtGrid;
        private System.Windows.Forms.ComboBox practitionerCbx;
        private System.Windows.Forms.TextBox codeTxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox roomTxt;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox descriptionTxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox contactTxt;
        private System.Windows.Forms.Label userLbl;
    }
}