using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using VHMIS.Model;

namespace VHMIS
{
    public partial class PharmacyForm : Form
    {
        public PharmacyForm()
        {
            InitializeComponent();
            LoadData();
            LoadDrugs();
            LoadStock();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (ItemDialog form = new ItemDialog())
            {
                // DentalDialog form1 = new DentalDialog(item.Text, TransactorID);
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    // MessageBox.Show(form.state);

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (TransactorDialog form = new TransactorDialog())
            {
                // DentalDialog form1 = new DentalDialog(item.Text, TransactorID);
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    // MessageBox.Show(form.state);

                }
            }
        }
        Transactor _transactor;
        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {

        }
        static string base64String = null;
        public System.Drawing.Image Base64ToImage(string bases)
        {
            byte[] imageBytes = Convert.FromBase64String(bases);
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
            ms.Write(imageBytes, 0, imageBytes.Length);
            System.Drawing.Image image = System.Drawing.Image.FromStream(ms, true);
            return image;
        }
        List<Transactor> _transactorList = new List<Transactor>();
        DataTable t;
        public void LoadData()
        {
            _transactorList = new List<Transactor>();
            _transactorList = Transactor.ListTransactors();

            t = new DataTable();
            t.Columns.Add(new DataColumn("Select", typeof(bool)));
            t.Columns.Add("id");//1
            t.Columns.Add(new DataColumn("Img", typeof(Bitmap)));//
            t.Columns.Add("No");//3
            t.Columns.Add("name");//4               
            t.Columns.Add("Contact");//6
            t.Columns.Add("Email");//7           
            t.Columns.Add("Address");//10           
            t.Columns.Add("Created");//14   
            t.Columns.Add("Type");//14           
            t.Columns.Add("image");//9         
            t.Columns.Add("Delete");//10

            Bitmap b = new Bitmap(50, 50);

            using (Graphics g = Graphics.FromImage(b))
            {
                g.DrawString("Loading...", this.Font, new SolidBrush(Color.Gray), 00, 00);
            }
            foreach (Transactor transactor in _transactorList)
            {

                t.Rows.Add(new object[] { false, transactor.Id, b, transactor.TransactorNo, transactor.Name, transactor.Contact, transactor.Email, transactor.Address, transactor.Created, transactor.Type, transactor.Image, "Delete" });

            }
            dtGrid.DataSource = t;
            ThreadPool.QueueUserWorkItem(delegate
            {
                foreach (DataRow row in t.Rows)
                {
                    try
                    {

                        Image img = Base64ToImage(row["image"].ToString());
                        System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(img);
                        Bitmap bps = new Bitmap(bmp, 50, 50);

                        row["Img"] = bps;

                    }
                    catch
                    {

                    }
                }
            });
            dtGrid.AllowUserToAddRows = false;
            dtGrid.Columns[11].DefaultCellStyle.BackColor = Color.Aquamarine;
            dtGrid.RowTemplate.Height = 60;
            dtGrid.Columns[1].Visible = false;
            dtGrid.Columns[10].Visible = false;
        }

        public void LoadDrugs()
        {

            t = new DataTable();
            t.Columns.Add(new DataColumn("Select", typeof(bool)));
            t.Columns.Add("id");//1
            t.Columns.Add(new DataColumn("Img", typeof(Bitmap)));//
            t.Columns.Add("Code");//3
            t.Columns.Add("name");//4               
            t.Columns.Add("Description");//6
            t.Columns.Add("Manufacturer");//7           
            t.Columns.Add("Country");//10           
            t.Columns.Add("Batch");//14   
            t.Columns.Add("Purchase price");//14     
            t.Columns.Add("Sale price");//14           
            t.Columns.Add("Compositon");//14
            t.Columns.Add("Expire");//14
            t.Columns.Add("Date of manufacture");//14
            t.Columns.Add("generic");//14
            t.Columns.Add("strength");//14
            t.Columns.Add("Category");//14
            t.Columns.Add("Package");//14
            t.Columns.Add("Barcode");//14
            t.Columns.Add("Department");//14
            t.Columns.Add("Created");//14
            t.Columns.Add("image");//21 
            t.Columns.Add("Delete");//22


            Bitmap b = new Bitmap(50, 50);

            using (Graphics g = Graphics.FromImage(b))
            {
                g.DrawString("Loading...", this.Font, new SolidBrush(Color.Gray), 00, 00);
            }
            foreach (Item d in Global._items)
            {

                t.Rows.Add(new object[] { false, d.Id, b, d.Code, d.Name, d.Description, d.Manufacturer, d.Country, d.Batch, d.Purchase_price, d.Sale_price, d.Composition, d.Expire,d.Date_manufactured,d.Generic,d.Strength,d.Category,d.Formulation, d.Barcode, d.Department, d.Created, d.Image, "Delete" });

            }
            dtDrugs.DataSource = t;
            ThreadPool.QueueUserWorkItem(delegate
            {
                foreach (DataRow row in t.Rows)
                {
                    try
                    {

                        Image img = Base64ToImage(row["image"].ToString());
                        System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(img);
                        Bitmap bps = new Bitmap(bmp, 50, 50);

                        row["Img"] = bps;

                    }
                    catch
                    {

                    }
                }
            });
            dtDrugs.AllowUserToAddRows = false;
            dtDrugs.Columns[22].DefaultCellStyle.BackColor = Color.Aquamarine;
            dtDrugs.RowTemplate.Height = 60;
            dtDrugs.Columns[21].Visible = false;
            dtDrugs.Columns[1].Visible = false;

        }

        public void LoadStock()
        {

            t = new DataTable();
            t.Columns.Add(new DataColumn("Select", typeof(bool)));
            t.Columns.Add("id");//1
            t.Columns.Add("name");//4               
            t.Columns.Add("Quantity");//6
            t.Columns.Add("Remarks");//7           
            t.Columns.Add("Created");//10           
            t.Columns.Add("Sale price");//14   
            t.Columns.Add("Purchase price");//14     
            t.Columns.Add("New Price");//14           
            t.Columns.Add("Previous price");//14
            t.Columns.Add("Total Value");//14
         


            Bitmap b = new Bitmap(50, 50);

            using (Graphics g = Graphics.FromImage(b))
            {
                g.DrawString("Loading...", this.Font, new SolidBrush(Color.Gray), 00, 00);
            }
            foreach (Stock d in Global._stocks)
            {

                t.Rows.Add(new object[] { false, d.Id, Global._items.First(r=>r.Id.Contains(d.ItemID)).Name, d.Quantity, d.Remarks, d.Created, d.Sale_price, d.Purchase_price, d.New_price, d.Previous_price, d.Total_qty });

            }
            dtStock.DataSource = t;            
            dtStock.AllowUserToAddRows = false;
            dtStock.Columns[10].DefaultCellStyle.BackColor = Color.Aquamarine;
            dtStock.RowTemplate.Height = 60;
          //  dtStock.Columns[21].Visible = false;
            dtStock.Columns[1].Visible = false;

        }

    }
}
