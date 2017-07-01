namespace VHMIS
{
    partial class RequestDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RequestDialog));
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.orderLbl = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel9 = new System.Windows.Forms.Panel();
            this.dtGrid = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.myTreeView2 = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.serviceLbl = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            this.panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGrid)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(38, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 23);
            this.label1.TabIndex = 248;
            this.label1.Text = "Services && Procedure";
            // 
            // panel3
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel3, 2);
            this.panel3.Controls.Add(this.orderLbl);
            this.panel3.Controls.Add(this.button1);
            this.panel3.Location = new System.Drawing.Point(248, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(699, 26);
            this.panel3.TabIndex = 251;
            // 
            // orderLbl
            // 
            this.orderLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.orderLbl.AutoSize = true;
            this.orderLbl.Location = new System.Drawing.Point(15, 7);
            this.orderLbl.Name = "orderLbl";
            this.orderLbl.Size = new System.Drawing.Size(12, 13);
            this.orderLbl.TabIndex = 247;
            this.orderLbl.Text = "#";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = global::VHMIS.Properties.Resources.Cancel_16;
            this.button1.Location = new System.Drawing.Point(674, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(22, 21);
            this.button1.TabIndex = 246;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel9
            // 
            this.panel9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel9.Controls.Add(this.dtGrid);
            this.panel9.Location = new System.Drawing.Point(248, 35);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(699, 350);
            this.panel9.TabIndex = 252;
            // 
            // dtGrid
            // 
            this.dtGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtGrid.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dtGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtGrid.Location = new System.Drawing.Point(0, 0);
            this.dtGrid.Name = "dtGrid";
            this.dtGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dtGrid.RowHeadersVisible = false;
            this.dtGrid.Size = new System.Drawing.Size(699, 350);
            this.dtGrid.TabIndex = 12;
            this.dtGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtGrid_CellClick);
            this.dtGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtGrid_CellContentClick);
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
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 705F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 13F));
            this.tableLayoutPanel1.Controls.Add(this.myTreeView2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel9, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(9, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.297873F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 91.70213F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 77F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(964, 466);
            this.tableLayoutPanel1.TabIndex = 248;
            // 
            // myTreeView2
            // 
            this.myTreeView2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.myTreeView2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.myTreeView2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.myTreeView2.ImageIndex = 0;
            this.myTreeView2.ImageList = this.imageList1;
            this.myTreeView2.Location = new System.Drawing.Point(14, 35);
            this.myTreeView2.Name = "myTreeView2";
            this.tableLayoutPanel1.SetRowSpan(this.myTreeView2, 2);
            this.myTreeView2.SelectedImageIndex = 2;
            this.myTreeView2.ShowNodeToolTips = true;
            this.myTreeView2.Size = new System.Drawing.Size(228, 418);
            this.myTreeView2.TabIndex = 10;
            this.myTreeView2.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.myTreeView2_AfterSelect);
            this.myTreeView2.Click += new System.EventHandler(this.myTreeView2_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Folder-24 (1).png");
            this.imageList1.Images.SetKeyName(1, "Document-32.png");
            this.imageList1.Images.SetKeyName(2, "Folder-24.png");
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.serviceLbl);
            this.panel2.Location = new System.Drawing.Point(248, 391);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(699, 72);
            this.panel2.TabIndex = 253;
            // 
            // serviceLbl
            // 
            this.serviceLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.serviceLbl.AutoSize = true;
            this.serviceLbl.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serviceLbl.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.serviceLbl.Location = new System.Drawing.Point(633, 23);
            this.serviceLbl.Name = "serviceLbl";
            this.serviceLbl.Size = new System.Drawing.Size(53, 26);
            this.serviceLbl.TabIndex = 245;
            this.serviceLbl.Text = "Total";
            // 
            // RequestDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(985, 490);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RequestDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RequestDialog";
            this.Load += new System.EventHandler(this.RequestDialog_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtGrid)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label serviceLbl;
        private System.Windows.Forms.TreeView myTreeView2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.DataGridView dtGrid;
        private System.Windows.Forms.Label orderLbl;
    }
}