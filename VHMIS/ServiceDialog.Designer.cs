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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // serviceLbl
            // 
            this.serviceLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.serviceLbl.AutoSize = true;
            this.serviceLbl.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serviceLbl.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.serviceLbl.Location = new System.Drawing.Point(178, 226);
            this.serviceLbl.Name = "serviceLbl";
            this.serviceLbl.Size = new System.Drawing.Size(53, 26);
            this.serviceLbl.TabIndex = 245;
            this.serviceLbl.Text = "Total";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(3, 186);
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
            this.serviceQty.Location = new System.Drawing.Point(3, 202);
            this.serviceQty.Multiline = true;
            this.serviceQty.Name = "serviceQty";
            this.serviceQty.Size = new System.Drawing.Size(228, 21);
            this.serviceQty.TabIndex = 243;
            this.serviceQty.Text = "1";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(3, 40);
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
            this.parameterTxt.Location = new System.Drawing.Point(3, 56);
            this.parameterTxt.Multiline = true;
            this.parameterTxt.Name = "parameterTxt";
            this.parameterTxt.Size = new System.Drawing.Size(228, 21);
            this.parameterTxt.TabIndex = 241;
            // 
            // button18
            // 
            this.button18.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button18.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.button18.FlatAppearance.BorderSize = 0;
            this.button18.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button18.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button18.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button18.Location = new System.Drawing.Point(96, 327);
            this.button18.Margin = new System.Windows.Forms.Padding(2);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(110, 38);
            this.button18.TabIndex = 240;
            this.button18.Text = "Add";
            this.button18.UseVisualStyleBackColor = false;
            this.button18.Click += new System.EventHandler(this.button18_Click);
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.Location = new System.Drawing.Point(3, 146);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(37, 13);
            this.label56.TabIndex = 239;
            this.label56.Text = "Status";
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.Dock = System.Windows.Forms.DockStyle.Right;
            this.label55.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label55.ForeColor = System.Drawing.Color.SeaGreen;
            this.label55.Location = new System.Drawing.Point(182, 120);
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
            this.statusCbx.Location = new System.Drawing.Point(3, 162);
            this.statusCbx.Name = "statusCbx";
            this.statusCbx.Size = new System.Drawing.Size(228, 21);
            this.statusCbx.TabIndex = 237;
            // 
            // operationCbx
            // 
            this.operationCbx.FormattingEnabled = true;
            this.operationCbx.Location = new System.Drawing.Point(3, 16);
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
            this.opCostTxt.Location = new System.Drawing.Point(3, 96);
            this.opCostTxt.Name = "opCostTxt";
            this.opCostTxt.Size = new System.Drawing.Size(228, 21);
            this.opCostTxt.TabIndex = 235;
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Location = new System.Drawing.Point(3, 0);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(125, 13);
            this.label52.TabIndex = 234;
            this.label52.Text = "Procedures e.g Radiology";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 80);
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
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.284023F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 91.71597F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.Controls.Add(this.button1, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.button18, 1, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.06818F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 86.93182F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(309, 367);
            this.tableLayoutPanel1.TabIndex = 247;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label52);
            this.flowLayoutPanel1.Controls.Add(this.operationCbx);
            this.flowLayoutPanel1.Controls.Add(this.label27);
            this.flowLayoutPanel1.Controls.Add(this.parameterTxt);
            this.flowLayoutPanel1.Controls.Add(this.label4);
            this.flowLayoutPanel1.Controls.Add(this.opCostTxt);
            this.flowLayoutPanel1.Controls.Add(this.label55);
            this.flowLayoutPanel1.Controls.Add(this.label56);
            this.flowLayoutPanel1.Controls.Add(this.statusCbx);
            this.flowLayoutPanel1.Controls.Add(this.label22);
            this.flowLayoutPanel1.Controls.Add(this.serviceQty);
            this.flowLayoutPanel1.Controls.Add(this.serviceLbl);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(26, 45);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(251, 269);
            this.flowLayoutPanel1.TabIndex = 247;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(54, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 23);
            this.label1.TabIndex = 248;
            this.label1.Text = "Add Service/Procedure";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = global::VHMIS.Properties.Resources.Cancel_16;
            this.button1.Location = new System.Drawing.Point(284, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(22, 21);
            this.button1.TabIndex = 246;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ServiceDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(333, 391);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ServiceDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ServiceDialog";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
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
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}