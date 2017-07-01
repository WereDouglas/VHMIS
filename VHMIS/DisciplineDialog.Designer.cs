namespace VHMIS
{
    partial class DisciplineDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DisciplineDialog));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.codeTxt = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.nameTxt = new System.Windows.Forms.TextBox();
            this.saveBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.codeTxt);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.nameTxt);
            this.panel1.Controls.Add(this.saveBtn);
            this.panel1.Location = new System.Drawing.Point(13, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(259, 239);
            this.panel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 137;
            this.label2.Text = "Code";
            // 
            // codeTxt
            // 
            this.codeTxt.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.codeTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.codeTxt.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codeTxt.Location = new System.Drawing.Point(45, 118);
            this.codeTxt.Name = "codeTxt";
            this.codeTxt.Size = new System.Drawing.Size(165, 19);
            this.codeTxt.TabIndex = 136;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.Snow;
            this.button2.Location = new System.Drawing.Point(48, 155);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(71, 35);
            this.button2.TabIndex = 135;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(45, 46);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(35, 13);
            this.label16.TabIndex = 132;
            this.label16.Text = "Name";
            // 
            // nameTxt
            // 
            this.nameTxt.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.nameTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nameTxt.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameTxt.Location = new System.Drawing.Point(45, 68);
            this.nameTxt.Name = "nameTxt";
            this.nameTxt.Size = new System.Drawing.Size(165, 19);
            this.nameTxt.TabIndex = 131;
            // 
            // saveBtn
            // 
            this.saveBtn.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.saveBtn.FlatAppearance.BorderSize = 0;
            this.saveBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveBtn.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveBtn.ForeColor = System.Drawing.Color.Snow;
            this.saveBtn.Location = new System.Drawing.Point(160, 155);
            this.saveBtn.Margin = new System.Windows.Forms.Padding(2);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(50, 35);
            this.saveBtn.TabIndex = 133;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = false;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(62, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 29);
            this.label1.TabIndex = 160;
            this.label1.Text = "Disciplines";
            // 
            // DisciplineDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Teal;
            this.ClientSize = new System.Drawing.Size(284, 265);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DisciplineDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DisciplineDialog";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox codeTxt;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox nameTxt;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Label label1;
    }
}