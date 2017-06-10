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
    public partial class PractitionerRegistration : Form
    {
        WebCam webcam;
        Users _user;
        Dictionary<string, string> departmentDictionary = new Dictionary<string, string>();

        public PractitionerRegistration()
        {
            InitializeComponent();
            webcam = new WebCam();
            webcam.InitializeWebCam(ref imgVideo);
            autocomplete();

            foreach (Roles r in Global._roles)
            {
                rolesCbx.Items.Add(r.Title);
            }
            foreach (Departments d in Global._departments)
            {
                departmentCbx.Items.Add(d.Name);
                departmentDictionary.Add(d.Name, d.Id);
            }
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

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
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
        List<string> errorList = new List<string>();

        private void button2_Click(object sender, EventArgs e)
        {
            

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
        private void Number_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (surnameTxt.Text == "")
            {
                errorList.Add("Missing surname");
                surnameTxt.BackColor = Color.Red;
                UpdateErrors();
                return;
            }
            if (lastnameTxt.Text == "")
            {
                errorList.Add("Missing last name");
                lastnameTxt.BackColor = Color.Red;
                UpdateErrors();
                return;
            }
            if (pass2Txt.Text != passTxt.Text)
            {
                errorList.Add("passwords do not match");
                passTxt.BackColor = Color.Red;
                UpdateErrors();
                return;                

            }
            string role = "";
            if (mainRadioBtn.Checked)
            {

                role = "Main";
            }
            else if (subRadioBtn.Checked) { role = "Sub"; }
            else { role = "Other"; }


            string id = Guid.NewGuid().ToString();
            MemoryStream stream = ImageToStream(imgCapture.Image, System.Drawing.Imaging.ImageFormat.Jpeg);
            string fullimage = ImageToBase64(stream);
            _user = new Users(id, patientNoTxt.Text, contactTxt.Text, contact2Txt.Text, surnameTxt.Text, lastnameTxt.Text, emailTxt.Text, nationalityTxt.Text, addressTxt.Text, kinTxt.Text, kincontactTxt.Text, "", designationCbx.Text, rolesCbx.Text, genderCbx.Text, fullimage, clinicnameTxt.Text, role, Helper.MD5Hash(passTxt.Text), accountTxt.Text, statusCbx.Text, practiceTxt.Text, specialisationTxt.Text, subTxt.Text, DateTime.Now.ToString("dd-MM-yyyy H:m:s"),departmentCbx.Text, Helper.orgID);

            if (DBConnect.Insert(_user) != "")
            {
                //DBConnect.saveImage("users", fullimage, id);
                MessageBox.Show("Information Saved");
             
                Global._users.Add(_user);
                ViewUsers frm = new ViewUsers();
                frm.MdiParent = MainForm.ActiveForm;
                frm.Dock = DockStyle.Fill;
                frm.Show();
                this.Close();
            }
            else
            {


            }

        }

        private void bntStart_Click_1(object sender, EventArgs e)
        {
            webcam.Start();
        }

        private void bntStop_Click_1(object sender, EventArgs e)
        {
            webcam.Stop();
        }

        private void bntContinue_Click_1(object sender, EventArgs e)
        {
            webcam.Continue();
        }

        private void bntCapture_Click_1(object sender, EventArgs e)
        {
            imgCapture.Image = imgVideo.Image;
            imgCapture.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void button4_Click_1(object sender, EventArgs e)
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

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (pass2Txt.Text != passTxt.Text)
            {

                errorList.Add("passwords do not match");
                lastnameTxt.BackColor = Color.Red;
                return;

            }
            UpdateErrors();
        }
        private void UpdateErrors()
        {

            for (int t = 0; t < errorList.Count; t++)
            {

                errorsTxt.Text = errorsTxt.Text + " " + errorList[t];

            }

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void surnameTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void specialisationTxt_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
