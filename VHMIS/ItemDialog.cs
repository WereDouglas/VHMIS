using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VHMIS.Model;

namespace VHMIS
{
    public partial class ItemDialog : Form
    {
        WebCam webcam;
        Dictionary<string, string> departmentDictionary = new Dictionary<string, string>();
        Dictionary<string, string> supplierDictionary = new Dictionary<string, string>();
        Dictionary<string, string> itemDictionary = new Dictionary<string, string>();
        Transactor _transactor;
        Dosage _dosage;
        Item _item;
        Transaction _transaction;
        Stock _stock;
        string ItemID;
        Bill _bill;
        string SupplierID="";
    

        public ItemDialog()
        {
            InitializeComponent();
            autocomplete();
            autocompleteSupplier();
            autocompleteItem();
            foreach (Departments d in Global._departments)
            {
                departmentCbx.Items.Add(d.Name);
                departmentDictionary.Add(d.Name, d.Id);
            }
            webcam = new WebCam();
            webcam.InitializeWebCam(ref imgVideo);
            ItemID = Guid.NewGuid().ToString();
        }
        private void autocomplete()
        {
            AutoCompleteStringCollection AutoItem = new AutoCompleteStringCollection();
            for (int w = 0; w < CountryArrays.Names.Count(); w++)
            {

                AutoItem.Add(CountryArrays.Names[w]);

            }

            ctryTxt.AutoCompleteMode = AutoCompleteMode.Suggest;
            ctryTxt.AutoCompleteSource = AutoCompleteSource.CustomSource;
            ctryTxt.AutoCompleteCustomSource = AutoItem;
        }
        private void autocompleteSupplier()
        {
            AutoCompleteStringCollection AutoItem = new AutoCompleteStringCollection();
            foreach (Transactor u in Global._transactors)
            {
                AutoItem.Add(u.Name);
               supplierDictionary.Add(u.Name, u.Id);
            }

            supplierTxt.AutoCompleteMode = AutoCompleteMode.Suggest;
            supplierTxt.AutoCompleteSource = AutoCompleteSource.CustomSource;
            supplierTxt.AutoCompleteCustomSource = AutoItem;

        }
        private void autocompleteItem()
        {
            AutoCompleteStringCollection AutoItem = new AutoCompleteStringCollection();
            foreach (Item u in Global._items)
            {
                AutoItem.Add(u.Name);
                itemDictionary.Add(u.Name, u.Id);
            }

            nameTxt.AutoCompleteMode = AutoCompleteMode.Suggest;
            nameTxt.AutoCompleteSource = AutoCompleteSource.CustomSource;
            nameTxt.AutoCompleteCustomSource = AutoItem;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (nameTxt.Text == "")
            {
                nameTxt.BackColor = Color.Red;
                return;
            }
         
            if (saleTxt.Text == "")
            {
                saleTxt.BackColor = Color.Red;
                return;
            }
            if (qtyTxt.Text == "")
            {
                qtyTxt.BackColor = Color.Red;
                return;
            }
            if (purchaseTxt.Text == "")
            {
                purchaseTxt.BackColor = Color.Red;
                return;
            }
            if (!String.IsNullOrEmpty(ItemID))
            {
                if (Global._items.Where(t=>t.Id.Contains(ItemID)).ToList().Count()<1) {
                    MemoryStream stream = ImageToStream(imgCapture.Image, System.Drawing.Imaging.ImageFormat.Jpeg);
                    string fullimage = ImageToBase64(stream);
                    _item = new Item(ItemID, nameTxt.Text, codeTxt.Text, descriptionTxt.Text, mannufacturerTxt.Text, ctryTxt.Text, batchTxt.Text, purchaseTxt.Text, saleTxt.Text, compositionTxt.Text, Convert.ToDateTime(expireDate.Text).ToString("dd-MM-yyyy"), categoryCbx.Text, packageCbx.Text, barcodeTxt.Text, fullimage, DateTime.Now.ToString("dd-MM-yyyy H:mm:ss"), departmentCbx.Text,Convert.ToDateTime(manufactureDate.Text).ToString("dd-MM-yyyy"),genericTxt.Text,strengthTxt.Text, Helper.orgID);

                    if (DBConnect.Insert(_item) != "")
                    {
                        if (Global._stocks.Where(t => t.ItemID.Contains(ItemID)).Count() > 0)
                        {
                            double value = 0;
                            string qty = Global._stocks.First(t => t.ItemID.Contains(ItemID)).Quantity;
                            value = Convert.ToDouble(qty) + Convert.ToDouble(qtyTxt.Text);

                            string itemID = Global._stocks.First(t => t.ItemID.Contains(ItemID)).ItemID;
                            string SQL = "UPDATE stock SET qty = '" + value + "', WHERE itemID = '" + itemID + "'";
                            DBConnect.Execute(SQL);

                        }
                        else
                        {
                            double totalQty = Convert.ToDouble(purchaseTxt.Text) * Convert.ToDouble(qtyTxt.Text);
                            string id = Guid.NewGuid().ToString();
                            _stock = new Stock(id, ItemID, qtyTxt.Text, descriptionTxt.Text,DateTime.Now.ToString("dd-MM-yyyy H:mm:ss"),saleTxt.Text,purchaseTxt.Text,purchaseTxt.Text,purchaseTxt.Text,totalQty.ToString(), Helper.orgID);
                            DBConnect.Insert(_stock);
                            Global._stocks.Add(_stock);
                        }

                        if (Global._transactors.Where(t => t.Id.Contains(SupplierID)).Count() < 0)
                        {
                            MemoryStream streams = ImageToStream(pictureBox1.Image, System.Drawing.Imaging.ImageFormat.Jpeg);
                            string fullimages = ImageToBase64(streams);
                            string id = Guid.NewGuid().ToString();
                            _transactor = new Transactor(id, supplierNoTxt.Text, contactTxt.Text, supplierTxt.Text, emailTxt.Text, addressTxt.Text, fullimages, DateTime.Now.ToString("dd-MM-yyyy H:mm:ss"), "Supplier", Helper.orgID);
                            DBConnect.Insert(_transactor);
                            SupplierID = id;
                        }


                        if (!String.IsNullOrEmpty(noTxt.Text) && !String.IsNullOrEmpty(SupplierID)) {

                            string id = Guid.NewGuid().ToString();
                            _bill = new Bill(id, noTxt.Text,SupplierID,remarksTxt.Text,purchaseDate.Text,purchaseTxt.Text,balanceTxt.Text,methodCbx.Text,paidCbx.Text, DateTime.Now.ToString("dd-MM-yyyy H:mm:ss"),departmentCbx.Text, Convert.ToDateTime(dueDate.Text).ToString("dd-MM-yyyy"),chqTxt.Text,bankTxt.Text,"Purchase","","", Helper.orgID);
                            DBConnect.Insert(_bill);
                            string id2 = Guid.NewGuid().ToString();
                            _transaction = new Transaction(id2, noTxt.Text,ItemID, qtyTxt.Text,Convert.ToDateTime(purchaseDate.Text).ToString("dd-MM-yyyy"),purchaseTxt.Text,"Purchase", DateTime.Now.ToString("dd-MM-yyyy H:mm:ss"), Helper.orgID);
                            DBConnect.Insert(_transaction);
                        }

                        if (Global._dosages.Where(t => t.ItemID.Contains(ItemID)).Count() < 0)
                        {
                            string id = Guid.NewGuid().ToString();
                            _dosage = new Dosage(id, ItemID,doseTxt.Text,prescriptionTxt.Text,dosageQtyTxt.Text,minTxt.Text,maxTxt.Text, DateTime.Now.ToString("dd-MM-yyyy H:mm:ss"), Helper.orgID);
                            DBConnect.Insert(_dosage);
                        }

                        Global._items.Add(_item);
                        MessageBox.Show("Information Saved");
                        this.DialogResult = DialogResult.OK;
                        this.Dispose();
                    }
                    else
                    {
                        MessageBox.Show("No valid Item identification ");

                    }
                }
            }

        
        }
        static string base64String = null;
        public string ImageToBase64(MemoryStream images)
        {

            using (System.Drawing.Image image = System.Drawing.Image.FromStream(images))
            {
                using (MemoryStream m = new MemoryStream())
                {
                    image.Save(m, image.RawFormat);
                    byte[] imageBytes = m.ToArray();
                    base64String = Convert.ToBase64String(imageBytes);
                    return base64String;
                }
            }
        }
        public MemoryStream ImageToStream(Image image, System.Drawing.Imaging.ImageFormat format)
        {
            MemoryStream ms = new MemoryStream();
            image.Save(ms, format);
            return ms;
        }

        private void LabLbl_Click(object sender, EventArgs e)
        {

        }

        private void bntStart_Click(object sender, EventArgs e)
        {
            imgVideo.Visible = true;
            imgCapture.Visible = false;
            webcam.Start();
        }

        private void bntStop_Click(object sender, EventArgs e)
        {
            imgVideo.Visible = true;
            imgCapture.Visible = false;
            webcam.Stop();
        }

        private void bntCapture_Click(object sender, EventArgs e)
        {
            imgCapture.Visible = true;
            imgVideo.Visible = false;
            imgCapture.Image = imgVideo.Image;
            imgCapture.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void bntContinue_Click(object sender, EventArgs e)
        {
            imgVideo.Visible = true;
            imgCapture.Visible = false;
            webcam.Continue();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            imgCapture.Visible = true;
            imgVideo.Visible = false;
            // open file dialog 
            OpenFileDialog open = new OpenFileDialog();
            // image filters
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                // display image in picture box
                imgCapture.Image = new Bitmap(open.FileName);
                imgCapture.SizeMode = PictureBoxSizeMode.StretchImage;
                fileUrlTxtBx.Text = open.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            // image filters
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                // display image in picture box
                pictureBox1.Image = new Bitmap(open.FileName);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                fileUrlTxtBx.Text = open.FileName;
            }
        }

        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void imgVideo_Click(object sender, EventArgs e)
        {

        }
    }
}
