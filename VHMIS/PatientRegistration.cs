using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VHMIS.Model;

namespace VHMIS
{
    public partial class PatientRegistration : Form
    {
        Patient _patient;
        //  DBConnect DB;
        WebCam webcam;
        public PatientRegistration()
        {
            //  DB = new DBConnect();
            InitializeComponent();
            webcam = new WebCam();
            webcam.InitializeWebCam(ref imgVideo);
            autocomplete();
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

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void textBox18_TextChanged(object sender, EventArgs e)
        {

        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void textBox19_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            PatientProfile frm = new PatientProfile(null);
            frm.MdiParent = MainForm.ActiveForm;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void imgCapture_Click(object sender, EventArgs e)
        {

        }

        private void label30_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {

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
        private void button2_Click(object sender, EventArgs e)
        {
            if (surnameTxt.Text == "")
            {
                errorList.Add("Missing surname");
                surnameTxt.BackColor = Color.Red;
                return;
            }
            if (lastnameTxt.Text == "")
            {
                errorList.Add("Missing last name");
                lastnameTxt.BackColor = Color.Red;
                return;
            }

            string id = Guid.NewGuid().ToString();

            MemoryStream stream = ImageToStream(imgCapture.Image, System.Drawing.Imaging.ImageFormat.Jpeg);
            string fullimage = ImageToBase64(stream);
            _patient = new Patient(id, patientNoTxt.Text, contactTxt.Text, surnameTxt.Text, lastnameTxt.Text, emailTxt.Text, dobdateTimePicker1.Text, nationalityTxt.Text, addressTxt.Text, kinTxt.Text, kincontactTxt.Text, genderCbx.Text, fullimage, DateTime.Now.ToString("dd-MM-yyyy H:mm:ss"),religionCbx.Text,bloodCbx.Text);

            if (DBConnect.Insert(_patient) != "")
            {
                //string query = "insert into patient (id, patientNo,contact,surname,lastname,email,dob,nationality,address,kin,kincontact,gender,created) values ('"+ id + "', '"+ patientNoTxt.Text + "', '"+ contactTxt.Text + "', '" + surnameTxt.Text + "', '" + lastnameTxt.Text + "', '" + emailTxt.Text + "', '" +Convert.ToDateTime(dobdateTimePicker1.Text).ToString("dd-MM-yyyy") + "', '" + nationalityTxt.Text + "', '" + addressTxt.Text + "', '" + kinTxt.Text + "','" + kincontactTxt.Text + "', '" + genderCbx.Text + "','"+DateTime.Now.ToString("dd-MM-yyyy H:m:s")+"');";
                Global._patients.Add(_patient);
                MessageBox.Show("Information Saved");
            }
            else
            {


            }

        }

        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
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

        private void dobdateTimePicker1_CloseUp(object sender, EventArgs e)
        {
            fullageLbl.Text = (DateTime.Now.Year - Convert.ToDateTime(dobdateTimePicker1.Text).Year).ToString();
            ageTxt.Text = Helper.CalculateAge(Convert.ToDateTime(dobdateTimePicker1.Text)).ToString();
        }

        private void ageTxt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dobdateTimePicker1.Text = (DateTime.Now.AddYears(-Convert.ToInt32(ageTxt))).ToString();
            }
            catch
            {


            }
        }
        bool errors = true;
        List<string> errorList = new List<string>();

        private void emailTxt_Leave(object sender, EventArgs e)
        {
            if (!IsValidEmailAddress(emailTxt.Text))
            {
                //errors = true;
                emailTxt.BackColor = Color.Red;
                errorList.Add("Invalid email address");
            }
            else
            {
                errors = false;
                emailTxt.BackColor = Color.LightGreen;
            }
        }
        public bool IsValidEmailAddress(string email)
        {
            try
            {
                MailAddress ma = new MailAddress(email);

                return true;
            }
            catch
            {
                return false;
            }
        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}
