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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DentalDialog));
            this.label46 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.toothTxt = new System.Windows.Forms.TextBox();
            this.diagnosisCbx = new System.Windows.Forms.TextBox();
            this.orderLbl = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.noteTxt = new System.Windows.Forms.TextBox();
            this.dtGrid = new System.Windows.Forms.DataGridView();
            this.button3 = new System.Windows.Forms.Button();
            this.myTreeView = new System.Windows.Forms.TreeView();
            this.totalLbl = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGrid)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label46
            // 
            this.label46.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label46.AutoSize = true;
            this.label46.Location = new System.Drawing.Point(5, 40);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(87, 13);
            this.label46.TabIndex = 191;
            this.label46.Text = "Diagnosis(ICD10)";
            this.label46.Click += new System.EventHandler(this.label46_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.BackColor = System.Drawing.Color.White;
            this.groupBox3.Controls.Add(this.tableLayoutPanel1);
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(974, 314);
            this.groupBox3.TabIndex = 194;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Diagnosis";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 43.51464F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 56.48536F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 289F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 449F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.button1, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.toothTxt, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label46, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.diagnosisCbx, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.orderLbl, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.noteTxt, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.dtGrid, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.button3, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.myTreeView, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.totalLbl, 2, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 20);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 191F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(962, 288);
            this.tableLayoutPanel1.TabIndex = 249;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 5);
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
            this.toothTxt.Location = new System.Drawing.Point(100, 3);
            this.toothTxt.Name = "toothTxt";
            this.toothTxt.Size = new System.Drawing.Size(120, 19);
            this.toothTxt.TabIndex = 241;
            // 
            // diagnosisCbx
            // 
            this.diagnosisCbx.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.diagnosisCbx.BackColor = System.Drawing.SystemColors.ControlLight;
            this.diagnosisCbx.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.diagnosisCbx.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.diagnosisCbx.Location = new System.Drawing.Point(100, 33);
            this.diagnosisCbx.Name = "diagnosisCbx";
            this.diagnosisCbx.Size = new System.Drawing.Size(120, 26);
            this.diagnosisCbx.TabIndex = 245;
            this.diagnosisCbx.Leave += new System.EventHandler(this.diagnosisCbx_Leave);
            // 
            // orderLbl
            // 
            this.orderLbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.orderLbl.AutoSize = true;
            this.orderLbl.Location = new System.Drawing.Point(361, 5);
            this.orderLbl.Name = "orderLbl";
            this.orderLbl.Size = new System.Drawing.Size(12, 13);
            this.orderLbl.TabIndex = 252;
            this.orderLbl.Text = "#";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(350, 40);
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
            this.noteTxt.Location = new System.Drawing.Point(515, 27);
            this.noteTxt.Multiline = true;
            this.noteTxt.Name = "noteTxt";
            this.noteTxt.Size = new System.Drawing.Size(431, 39);
            this.noteTxt.TabIndex = 197;
            // 
            // dtGrid
            // 
            this.dtGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtGrid.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dtGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableLayoutPanel1.SetColumnSpan(this.dtGrid, 2);
            this.dtGrid.Location = new System.Drawing.Point(226, 72);
            this.dtGrid.Name = "dtGrid";
            this.dtGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dtGrid.RowHeadersVisible = false;
            this.dtGrid.Size = new System.Drawing.Size(733, 185);
            this.dtGrid.TabIndex = 251;
            this.dtGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtGrid_CellClick);
            this.dtGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtGrid_CellEndEdit);
            // 
            // button3
            // 
            this.button3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button3.Location = new System.Drawing.Point(684, 263);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(106, 22);
            this.button3.TabIndex = 199;
            this.button3.Text = "Save";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // myTreeView
            // 
            this.myTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.myTreeView.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.myTreeView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tableLayoutPanel1.SetColumnSpan(this.myTreeView, 2);
            this.myTreeView.Location = new System.Drawing.Point(3, 72);
            this.myTreeView.Name = "myTreeView";
            this.myTreeView.ShowNodeToolTips = true;
            this.myTreeView.Size = new System.Drawing.Size(217, 185);
            this.myTreeView.TabIndex = 250;
            this.myTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.myTreeView_AfterSelect);
            // 
            // totalLbl
            // 
            this.totalLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.totalLbl.AutoSize = true;
            this.totalLbl.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalLbl.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.totalLbl.Location = new System.Drawing.Point(456, 260);
            this.totalLbl.Name = "totalLbl";
            this.totalLbl.Size = new System.Drawing.Size(53, 26);
            this.totalLbl.TabIndex = 253;
            this.totalLbl.Text = "Total";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Location = new System.Drawing.Point(12, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(980, 320);
            this.panel1.TabIndex = 195;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Folder-24 (1).png");
            this.imageList1.Images.SetKeyName(1, "Document-32.png");
            this.imageList1.Images.SetKeyName(2, "Folder-24.png");
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = global::VHMIS.Properties.Resources.Cancel_16;
            this.button1.Location = new System.Drawing.Point(923, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(36, 18);
            this.button1.TabIndex = 190;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // DentalDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(1003, 345);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DentalDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DentalDialog";
            this.groupBox3.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGrid)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox noteTxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox toothTxt;
        private System.Windows.Forms.TextBox diagnosisCbx;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dtGrid;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label orderLbl;
        private System.Windows.Forms.TreeView myTreeView;
        private System.Windows.Forms.Label totalLbl;
    }
}