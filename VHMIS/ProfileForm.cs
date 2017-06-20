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
    public partial class ProfileForm : Form
    {
        Roles _role;
        string originalPassword;
        Organisation _org;
        WebCam webcam;
        string OrgID = "";
        DataTable t;
        Dictionary<string, string> storeDictionary = new Dictionary<string, string>();
        public ProfileForm(string orgID)
        {
            InitializeComponent();
            webcam = new WebCam();
            webcam.InitializeWebCam(ref imgVideo);
            autocomplete();
            string exists = "";
            try
            {
                exists = Organisation.ListOrganisation().First().Id;
            }
            catch { }
            if (String.IsNullOrEmpty(exists))
            {
                OrgID = Guid.NewGuid().ToString();
                Helper.orgID = OrgID;
                MemoryStream stream = ImageToStream(imgCapture.Image, System.Drawing.Imaging.ImageFormat.Jpeg);
                string fullimage = ImageToBase64(stream);
                _org = new Organisation(OrgID, nameTxt.Text, codeTxt.Text, registrationTxt.Text, contactTxt.Text, addressTxt.Text, tinTxt.Text, vatTxt.Text, emailTxt.Text, nationalityTxt.Text, "", accountTxt.Text, statusCbx.Text,DateTime.Now.AddMonths(3).ToString("dd-MM-yyyy"), fullimage, DateTime.Now.ToString("dd-MM-yyyy H:mm:ss"), DateTime.Now.ToString("dd-MM-yyyy H:mm:ss"), countsTxt.Text, companyCode.Text, "");
                DBConnect.Insert(_org);

            }
            else
            {

                Helper.orgID = exists;
                OrgID = exists;
                Profile(exists);

            }
            LoadStores();

        }
        private void Profile(string ID)
        {

            nameTxt.Text = Global._org.First(k => k.Id.Contains(ID)).Name;
            codeTxt.Text = Global._org.First(k => k.Id.Contains(ID)).Code;
            registrationTxt.Text = Global._org.First(k => k.Id.Contains(ID)).Registration;
            contactTxt.Text = Global._org.First(k => k.Id.Contains(ID)).Contact;
            addressTxt.Text = Global._org.First(k => k.Id.Contains(ID)).Address;
            tinTxt.Text = Global._org.First(k => k.Id.Contains(ID)).Tin;
            vatTxt.Text = Global._org.First(k => k.Id.Contains(ID)).Vat;
            nationalityTxt.Text = Global._org.First(k => k.Id.Contains(ID)).Country;
            emailTxt.Text = Global._org.First(k => k.Id.Contains(ID)).Email;
            originalPassword = Global._org.First(k => k.Id.Contains(ID)).Initialpassword;
            accountTxt.Text = Global._org.First(k => k.Id.Contains(ID)).Account;
            statusCbx.Text = Global._org.First(k => k.Id.Contains(ID)).Status;
            expireDate.Text = Global._org.First(k => k.Id.Contains(ID)).Expires;


            Image img = Base64ToImage(Global._org.First(k => k.Id.Contains(ID)).Image);
            System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(img);
            //Bitmap bps = new Bitmap(bmp, 50, 50);
            imgCapture.Image = bmp;
            imgCapture.SizeMode = PictureBoxSizeMode.StretchImage;
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
        public MemoryStream ImageToStream(Image image, System.Drawing.Imaging.ImageFormat format)
        {
            MemoryStream ms = new MemoryStream();
            image.Save(ms, format);
            return ms;
        }
        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
        private void autocomplete()
        {
            AutoCompleteStringCollection AutoItem = new AutoCompleteStringCollection();
            for (int w = 0; w < CountryArrays.Names.Count(); w++)
            {
                AutoItem.Add(CountryArrays.Names[w]);
            }

            nationalityTxt.AutoCompleteMode = AutoCompleteMode.Suggest;
            nationalityTxt.AutoCompleteSource = AutoCompleteSource.CustomSource;
            nationalityTxt.AutoCompleteCustomSource = AutoItem;
        }
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
        private void saveBtn_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            try
            {
                if (Users.ListUsers().Count() < 1)
                {
                    MessageBox.Show("Please add atleast a single user");
                    return;
                }
            }
            catch
            {

                return;
            }
            if (Branch.ListBranch().Count() < 1)
            {
                MessageBox.Show("Please add a branch");
                return;
            }
            if (String.IsNullOrEmpty(Helper.BranchID))
            {
                MessageBox.Show("Please select a store/Shop");
                storeCbx.BackColor = Color.Red;
                return;
            }
            string password = "";

            if (nameTxt.Text == "")
            {
                nameTxt.BackColor = Color.Red;
                return;
            }
            if (codeTxt.Text == "")
            {
                codeTxt.BackColor = Color.Red;
                return;
            }
            if (initialTxt.Text != "")
            {
                password = Helper.MD5Hash(initialTxt.Text);
            }
            else
            {
                password = originalPassword;
            }
            string id = Guid.NewGuid().ToString();

            MemoryStream stream = ImageToStream(imgCapture.Image, System.Drawing.Imaging.ImageFormat.Jpeg);
            string fullimage = ImageToBase64(stream);
            _org = new Organisation(id, nameTxt.Text, codeTxt.Text, registrationTxt.Text, contactTxt.Text, addressTxt.Text, tinTxt.Text, vatTxt.Text, emailTxt.Text, nationalityTxt.Text, password, accountTxt.Text, statusCbx.Text, Convert.ToDateTime(expireDate.Text).ToString("dd-MM-yyyy"), fullimage, DateTime.Now.ToString("dd-MM-yyyy H:mm:ss"), DateTime.Now.ToString("dd-MM-yyyy H:mm:ss"), countsTxt.Text, companyCode.Text, Helper.BranchID);
            DBConnect.Update(_org, OrgID);
            Helper.orgID = OrgID;
            DBConnect.Update(_org, OrgID);
            MessageBox.Show("Information Updated ");
            Close();

            string SQL = "UPDATE organisation SET counts = '" + DateTime.Now.ToString("dd-MM-yyyy H:mm:ss") + "' WHERE id= '" + id + "'";

            DBConnect.Execute(SQL);
            MessageBox.Show("Information Saved");
            Close();
            if (Global._users.Count() < 1)
            {
                Helper.orgID = id;
                string ids = Guid.NewGuid().ToString();
                _role = new Roles(ids, "Administrator", "All item pos daily purchases merchandise inventory expenses cash flow suppliers users suppliers catgories transactions ledgers logs profile ", "create update delete log ", DateTime.Now.ToString("dd-MM-yyyy H:mm:ss"), Helper.orgID);

                DBConnect.Insert(_role);
                Global._roles.Add(_role);
               
            }
            this.DialogResult = DialogResult.OK;
            this.Dispose();
            nameTxt.Text = "";
            codeTxt.Text = "";
        }

        private void bntStart_Click(object sender, EventArgs e)
        {
            webcam.Start();
        }

        private void bntStop_Click(object sender, EventArgs e)
        {
            webcam.Stop();
        }

        private void bntContinue_Click(object sender, EventArgs e)
        {
            webcam.Continue();
        }

        private void bntCapture_Click(object sender, EventArgs e)
        {
            imgCapture.Image = imgVideo.Image;
            imgCapture.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void button4_Click(object sender, EventArgs e)
        {
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

        private void button6_Click(object sender, EventArgs e)
        {
            if (Branch.ListBranch().Count() < 1)
            {
                MessageBox.Show("Please add a branch first");
                return;
            }
            using (PractitionerRegistration form = new PractitionerRegistration())
            {
                // DentalDialog form1 = new DentalDialog(item.Text, TransactorID);
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    autocompleteUsers();

                }
            }
        }
        private void autocompleteUsers()
        {
            AutoCompleteStringCollection AutoItem = new AutoCompleteStringCollection();
            foreach (Users r in Users.ListUsers())
            {
                AutoItem.Add(r.Contact);
            }
            contactTxt.AutoCompleteMode = AutoCompleteMode.Suggest;
            contactTxt.AutoCompleteSource = AutoCompleteSource.CustomSource;
            contactTxt.AutoCompleteCustomSource = AutoItem;

           
        }
        private void LoadStores()
        {
            foreach (Branch s in Global._branch.ToList())
            {

                if (!storeDictionary.ContainsKey(s.Name))
                {
                    storeDictionary.Add(s.Name, s.Id);
                    storeCbx.Items.Add(s.Name);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            using (BranchDialog form = new BranchDialog())
            {
                // DentalDialog form1 = new DentalDialog(item.Text, TransactorID);
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    // MessageBox.Show(form.state);
                    LoadStores();
                }
            }
        }

        private void storeCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Helper.BranchID = storeDictionary[storeCbx.Text];
            }
            catch { }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Branch.ListBranch().Count() < 1)
            {
                MessageBox.Show("Please add a branch");
                return;
            }
            if (String.IsNullOrEmpty(Helper.BranchID))
            {
                MessageBox.Show("Please select a store/Shop");
                storeCbx.BackColor = Color.Red;
                return;
            }
            Helper.BranchID = storeDictionary[storeCbx.Text];
            if (storeCbx.Text == "")
            {
                storeCbx.BackColor = Color.PaleVioletRed;
                return;
            }
            MemoryStream stream = ImageToStream(imgCapture.Image, System.Drawing.Imaging.ImageFormat.Jpeg);
            string fullimage = ImageToBase64(stream);
            _org = new Organisation(OrgID, nameTxt.Text, codeTxt.Text, registrationTxt.Text, contactTxt.Text, addressTxt.Text, tinTxt.Text, vatTxt.Text, emailTxt.Text, nationalityTxt.Text, "", accountTxt.Text, statusCbx.Text, Convert.ToDateTime(expireDate.Text).ToString("dd-MM-yyyy"), fullimage, DateTime.Now.ToString("dd-MM-yyyy H:mm:ss"),Convert.ToDateTime(syncDate.Text).ToString("dd-MM-yyyy H:mm:ss"), countsTxt.Text, companyCode.Text, Helper.BranchID);
            if (OrgID != "")
            {
                DBConnect.Update(_org, OrgID);
                MessageBox.Show("Information Updated ");
                this.DialogResult = DialogResult.OK;
                this.Dispose();
            }
        }
    }
}
