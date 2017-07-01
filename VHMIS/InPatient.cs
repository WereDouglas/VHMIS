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
        Dictionary<string, string> operationCost = new Dictionary<string, string>();
        Dictionary<string, string> testCost = new Dictionary<string, string>();

        DataTable t;
        List<Patient> _patientList = new List<Patient>();
        List<Users> _userList = new List<Users>();
        string patientID;
       
        int follow;
       
        List<Queue> _queues = new List<Queue>();
        List<Queue> _todayList = new List<Queue>();
       
        private List<Services> _services;

        string userID;
        string queueID;
        string PatientID;
        DataTable tb;
       
        public InPatient(string QueueID, string patientID, string UserID)
        {
            _patientList = Global._patients;
            userID = UserID;
            _userList = Global._users;
            InitializeComponent();

            autocompleteNumber();
            autocompleteID();

            if (!String.IsNullOrEmpty(QueueID))
            {
                queueID = QueueID;
                LoadServices(Global._queues.First(y => y.Id.Contains(queueID)).No);

                PatientID = patientID;
                LoadPatient(patientID);
                queueNo.Text = Global._queues.First(y => y.Id.Contains(queueID)).No;
                LoadAdmission(queueNo.Text);
            }
            else
            {
                queueID = Guid.NewGuid().ToString();
            }



        }
        private void LoadServices(string visitID)
        {

            _services = Services.ListServices(visitID);
            tb = new DataTable();
            // create and execute query 
            tb.Columns.Add("id");//2 
            tb.Columns.Add("Parameter");//2
            tb.Columns.Add("Name");//2
            tb.Columns.Add("Department");//           
            tb.Columns.Add("Price");//
            tb.Columns.Add("Quantity");//
            tb.Columns.Add("Total");//
            tb.Columns.Add("Paid");//
            tb.Columns.Add("Notes");//
            tb.Columns.Add("Status");// 
            tb.Columns.Add("Results");//            
            tb.Columns.Add("Cancel");//
            tb.Columns.Add("departmentID");//

            foreach (Services r in _services)
            {
                tb.Rows.Add(new object[] { r.Id, r.Parameter, r.Name, Global._departments.First(e => e.Id.Contains(r.DepartmentID)).Name, r.Price, r.Qty, r.Total, r.Paid, r.Notes, r.Status, r.Results, "Cancel", r.DepartmentID });

            }
            dtServices.DataSource = tb;
            dtServices.AllowUserToAddRows = false;
            dtServices.Columns["Cancel"].DefaultCellStyle.BackColor = Color.OrangeRed;
            dtServices.Columns["id"].Visible = false;
            dtServices.Columns["departmentID"].Visible = false;
            dtServices.Columns["Cancel"].FillWeight = 80;
            totalLbl.Text = _services.Sum(f => Convert.ToDouble(f.Total)).ToString("n0");
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
            numberTxt.Text = Global._patients.First(k => k.Id.Contains(patientID)).PatientNo;
            patientTxt.Text = surnametTxt.Text + " " + lastnameTxt.Text;


            Image img = Base64ToImage(Global._patients.First(k => k.Id.Contains(patientID)).Image);
            System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(img);
            //Bitmap bps = new Bitmap(bmp, 50, 50);
            imgCapture.Image = bmp;
            imgCapture.SizeMode = PictureBoxSizeMode.StretchImage;


        }
        private void LoadAdmission(string no)
        {
            wardCbx.Text = Global._admit.First(k => k.No.Contains(no)).Ward;
            bedCbx.Text = Global._admit.First(k => k.No.Contains(no)).Bed;
          
            priorityCbx.Text = Global._admit.First(k => k.No.Contains(no)).Status;
            typeCbx.Text = Global._admit.First(k => k.No.Contains(no)).Type;
            enrollbyTxt.Text = Global._admit.First(k => k.No.Contains(no)).UserID;
            refTxt.Text = Global._admit.First(k => k.No.Contains(no)).Referral;
            remarksTxt.Text = Global._admit.First(k => k.No.Contains(no)).Remarks;


        }
        public System.Drawing.Image Base64ToImage(string bases)
        {
            byte[] imageBytes = Convert.FromBase64String(bases);
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
            ms.Write(imageBytes, 0, imageBytes.Length);
            System.Drawing.Image image = System.Drawing.Image.FromStream(ms, true);
            return image;
        }
    
      

      



        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void queueNo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                
                //string QueueID = Global._admit.First(p => p.No.Equals(queueNo.Text)).Id;
                string patientID = Global._admit.First(d => d.No.Equals(queueNo.Text)).PatientID;
                if (!String.IsNullOrEmpty(patientID))
                {
                    PatientID = patientID;
                    LoadPatient(patientID);
                    // queueID = QueueID;
                    LoadServices(queueNo.Text);
                    LoadAdmission(queueNo.Text);

                   
                }

            }
            catch { }
        }

        private void queueNo_Click(object sender, EventArgs e)
        {
            queueNo.Text = "VHMIS-" + DateTime.Now.ToString("dd-MM-yyyy") + "/ADMIT/" ;
        }

        private void bedCbx_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
