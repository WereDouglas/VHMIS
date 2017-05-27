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
    public partial class InPatient : Form
    {
        Dictionary<string, string> IdDictionary = new Dictionary<string, string>();
        Dictionary<string, string> numberDictionary = new Dictionary<string, string>();
        Dictionary<string, string> userDictionary = new Dictionary<string, string>();
        Dictionary<string, string> patientDictionary = new Dictionary<string, string>();
        Dictionary<string, string> clinicDictionary = new Dictionary<string, string>();
        Dictionary<string, string> roomDictionary = new Dictionary<string, string>();
        Dictionary<string, string> wardDictionary = new Dictionary<string, string>();

        DataTable t;
        List<Patient> _patientList = new List<Patient>();
        List<Users> _userList = new List<Users>();
        string patientID;
        string userID;
        string wardID;
        string clinicID;

        List<Queue> _queues = new List<Queue>();
        List<Queue> _todayList = new List<Queue>();
        Queue _queue;
        DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();
        DataGridViewButtonColumn btnEdit = new DataGridViewButtonColumn();

        bool loaded = false;
        string today;
        public InPatient()
        {
            _patientList = Global._patients;
            _userList = Global._users;
            InitializeComponent();
            autocompleteNumber();

            autocompleteID();
            autocompleteUsers();
            autocompletePatient();
            autocompleteClinics();
            autocompleteWards();
            openedDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            btnDelete.Name = "btnDelete";
            btnDelete.Text = "Complete";
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Width = 60;
            btnDelete.CellTemplate.Style.BackColor = Color.Green;
            btnDelete.UseColumnTextForButtonValue = true;
            btnDelete.HeaderText = "Complete";

            btnEdit.Name = "btnEdit";
            btnEdit.Text = "Visit";
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Width = 60;
            btnEdit.CellTemplate.Style.BackColor = Color.Orange;
            btnEdit.UseColumnTextForButtonValue = true;
            btnEdit.HeaderText = "Edit";
            today = DateTime.Now.ToString("yyyy-MM-dd");
            _queues = Global._queues;
            _todayList = Global._queues;//.Where(r => r.Dated.Contains(today)).ToList();
            
            foreach (Clinics d in Global._clinics)
            {
                clinicCbx.Items.Add(d.Name);
            }
            foreach (Wards d in Global._wards)
            {
                roomCbx.Items.Add(d.Name);
            }

        }
        private void autocompleteUsers()
        {
            AutoCompleteStringCollection AutoItem = new AutoCompleteStringCollection();
            foreach (Users u in Global._users)
            {
                AutoItem.Add(u.Surname + " " + u.Lastname);
                userDictionary.Add(u.Surname + " " + u.Lastname, u.Id);
            }
            practitionerTxt.AutoCompleteMode = AutoCompleteMode.Suggest;
            practitionerTxt.AutoCompleteSource = AutoCompleteSource.CustomSource;
            practitionerTxt.AutoCompleteCustomSource = AutoItem;

        }
        private void autocompleteClinics()
        {
            AutoCompleteStringCollection AutoItem = new AutoCompleteStringCollection();
            foreach (Clinics u in Global._clinics)
            {
                AutoItem.Add(u.Name);
                clinicDictionary.Add(u.Name, u.Id);
            }
            clinicCbx.AutoCompleteMode = AutoCompleteMode.Suggest;
            clinicCbx.AutoCompleteSource = AutoCompleteSource.CustomSource;
            clinicCbx.AutoCompleteCustomSource = AutoItem;

        }
        private void autocompleteWards()
        {
            AutoCompleteStringCollection AutoItem = new AutoCompleteStringCollection();
            foreach (Wards u in Global._wards)
            {
                AutoItem.Add(u.Name);
                wardDictionary.Add(u.Name, u.Id);
            }
            roomCbx.AutoCompleteMode = AutoCompleteMode.Suggest;
            roomCbx.AutoCompleteSource = AutoCompleteSource.CustomSource;
            roomCbx.AutoCompleteCustomSource = AutoItem;

        }
        private void autocompletePatient()
        {
            AutoCompleteStringCollection AutoItem = new AutoCompleteStringCollection();
            foreach (Patient p in Global._patients)
            {
                AutoItem.Add(p.Surname + " " + p.Lastname);
                patientDictionary.Add(p.Surname + " " + p.Lastname, p.Id);
            }

            patientTxt.AutoCompleteMode = AutoCompleteMode.Suggest;
            patientTxt.AutoCompleteSource = AutoCompleteSource.CustomSource;
            patientTxt.AutoCompleteCustomSource = AutoItem;
        }

        private void autocompleteNumber()
        {
            AutoCompleteStringCollection AutoItem = new AutoCompleteStringCollection();
            foreach (Patient p in Global._patients)
            {
                AutoItem.Add(p.Contact);
                numberDictionary.Add(p.Contact, p.Id);
            }

           contactTxt.AutoCompleteMode = AutoCompleteMode.Suggest;
            contactTxt.AutoCompleteSource = AutoCompleteSource.CustomSource;
            contactTxt.AutoCompleteCustomSource = AutoItem;

        }
        private void autocompleteID()
        {
            AutoCompleteStringCollection AutoItem = new AutoCompleteStringCollection();
            foreach (Patient p in Global._patients)
            {
                AutoItem.Add(p.Id);
                IdDictionary.Add(p.PatientNo, p.Id);
            }

            numberTxt.AutoCompleteMode = AutoCompleteMode.Suggest;
            numberTxt.AutoCompleteSource = AutoCompleteSource.CustomSource;
            numberTxt.AutoCompleteCustomSource = AutoItem;

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
        
        private void contactTxt_Leave(object sender, EventArgs e)
        {
            if (contactTxt.Text != "")
            {
                try
                {
                    patientID = numberDictionary[contactTxt.Text];
                }
                catch { }
            }
            else if (numberTxt.Text != "")
            {


                try
                {
                    patientID = IdDictionary[numberTxt.Text];
                }
                catch { }
            }
            if (patientID != "")
            {

                LoadPatient(patientID);
                
            }
        }
        private void LoadPatient(string patientID)
        {

            surnametTxt.Text = Global._patients.First(k => k.Id.Contains(patientID)).Surname;
            lastnameTxt.Text = Global._patients.First(k => k.Id.Contains(patientID)).Lastname;
            contactTxt.Text = Global._patients.First(k => k.Id.Contains(patientID)).Contact;
            emailTxt.Text = Global._patients.First(k => k.Id.Contains(patientID)).Email;
            dobTxt.Text = Global._patients.First(k => k.Id.Contains(patientID)).Dob;
            nationalityTxt.Text = Global._patients.First(k => k.Id.Contains(patientID)).Nationality;
            genderCbx.Text = Global._patients.First(k => k.Id.Contains(patientID)).Gender;
            kinTxt.Text = Global._patients.First(k => k.Id.Contains(patientID)).Kin;
            kincontactTxt.Text = Global._patients.First(k => k.Id.Contains(patientID)).Kincontact;
            addressTxt.Text = Global._patients.First(k => k.Id.Contains(patientID)).Address;


            Image img = Base64ToImage(Global._patients.First(k => k.Id.Contains(patientID)).Image);
            System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(img);
            //Bitmap bps = new Bitmap(bmp, 50, 50);
            imgCapture.Image = bmp;
            imgCapture.SizeMode = PictureBoxSizeMode.StretchImage;


        }
        public System.Drawing.Image Base64ToImage(string bases)
        {
            byte[] imageBytes = Convert.FromBase64String(bases);
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
            ms.Write(imageBytes, 0, imageBytes.Length);
            System.Drawing.Image image = System.Drawing.Image.FromStream(ms, true);
            return image;
        }
        int follow;
        private void button2_Click(object sender, EventArgs e)
        {
            int next;
            if (_todayList.Count() < 1)
            {
                next = 1;
            }
            else
            {
                follow = _todayList.Max(t => Convert.ToInt32(t.Follow));
                next = follow + 1;
            }

            if (patientID == "" || userID == "")
            {
                MessageBox.Show("Please input the input the patient OR the practitioner  ");
                return;
            }
            string id = Guid.NewGuid().ToString();

            _queue = new Queue(id, next.ToString(), patientID, userID, roomCbx.Text, clinicCbx.Text, priorityCbx.Text, Convert.ToDateTime(this.openedDate.Text).ToString("yyyy-MM-dd"), DateTime.Now.ToString("dd-MM-yyyy H:mm:ss"),departmentCbx.Text);

            if (DBConnect.Insert(_queue) != "")
            {
                Global._queues.Add(_queue);
                patientTxt.Text = "";
                practitionerTxt.Text = "";
                MessageBox.Show("Information Saved");
               

            }
            else
            {
                return;

            }
        }

        private void patientTxt_Leave(object sender, EventArgs e)
        {
            try
            {
                patientID = patientDictionary[patientTxt.Text];

                LoadPatient(patientID);
            }
            catch { }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void departmentCbx_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
