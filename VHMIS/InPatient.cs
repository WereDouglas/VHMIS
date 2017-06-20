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
        string userID;
        string wardID;
        string clinicID;
        int follow;
        double LabTotal = 0;
        string notify;
        Events _event;
        List<Queue> _queues = new List<Queue>();
        List<Queue> _todayList = new List<Queue>();
        Queue _queue;
        DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();
        DataGridViewButtonColumn btnEdit = new DataGridViewButtonColumn();

        bool loaded = false;
        string today;
        private List<Services> _services;
        private Services _service;

        private Lab _lab;
        private List<Lab> _labs;
        private Diagnosis _diag;
        private List<Diagnosis> _diags;
        double serviceTotal = 0;
        double procsTotal = 0;
    
        string queueID;
        string PatientID;
        DataTable tb;
        DataTable bb;
      
        public InPatient(string QueueID, string patientID, string UserID)
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
            openedDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            if (!String.IsNullOrEmpty(QueueID))
            {
                queueID = QueueID;
                LoadServices(queueID);
                LoadLabs(queueID);
                PatientID = patientID;
                LoadPatient(patientID);
            }
            else
            {
                queueID = Guid.NewGuid().ToString();
            }
          
            foreach (Clinics d in Global._clinics)
            {
                clinicCbx.Items.Add(d.Name);
            }
            foreach (Departments d in Global._departments)
            {
                departmentCbx.Items.Add(d.Name);
            }
            foreach (Wards d in Global._wards)
            {
                roomCbx.Items.Add(d.Name);
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
            tb.Columns.Add("Procedure");//
            tb.Columns.Add("Price");//
            tb.Columns.Add("Code");//
            tb.Columns.Add("status");//
            tb.Columns.Add("Quantity");//
            tb.Columns.Add("Cost");//
            tb.Columns.Add("Cancel");//

            foreach (Services r in _services)
            {
                tb.Rows.Add(new object[] { r.Id, r.Parameter, r.Name, r.DepartmentID, r.ProcedureID, r.Price, r.Code, r.Status, r.Qty, r.Total, "Cancel" });


            }
            dtServices.DataSource = tb;
            billGrid.DataSource = bb;
            dtServices.AllowUserToAddRows = false;
            dtServices.Columns[10].DefaultCellStyle.BackColor = Color.OrangeRed;
            dtServices.Columns[0].Visible = false;
            dtServices.Columns[10].FillWeight = 80;
        }
        private void LoadLabs(string visitID)
        {

            _labs = Lab.ListLab(visitID);
            tb = new DataTable();

            tb.Columns.Add("id");//2 
            tb.Columns.Add("Test");//2
            tb.Columns.Add("Cost");//
            tb.Columns.Add("Quantity");//
            tb.Columns.Add("Total");//
            tb.Columns.Add("Cancel");//
            foreach (Lab r in _labs)
            {
                tb.Rows.Add(new object[] { r.Id, r.Test, r.Cost, r.Qty, r.Total, "Cancel" });
            }
            dtLab.DataSource = tb;

            dtLab.AllowUserToAddRows = false;
            dtLab.Columns[5].DefaultCellStyle.BackColor = Color.OrangeRed;
            dtLab.Columns[0].Visible = false;
            // dtLab.Columns[3].Width = 20;
            dtLab.Columns[5].FillWeight = 20;

        }
        private void autocompleteUsers()
        {
            AutoCompleteStringCollection AutoItem = new AutoCompleteStringCollection();
            foreach (Users u in Global._users)
            {
                if (!userDictionary.ContainsKey(u.Surname + " " + u.Lastname)) {
                    userDictionary.Add(u.Surname + " " + u.Lastname, u.Id);
                }
                AutoItem.Add(u.Surname + " " + u.Lastname);              
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

            _queue = new Queue(id, next.ToString(), patientID, userID, roomCbx.Text, clinicCbx.Text, priorityCbx.Text, Convert.ToDateTime(this.openedDate.Text).ToString("yyyy-MM-dd"), DateTime.Now.ToString("dd-MM-yyyy H:mm:ss"),departmentCbx.Text,"","","","","","","","","", Helper.orgID,"IP");

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

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void referralDocTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void button18_Click(object sender, EventArgs e)
        {
            using (ServiceDialog form = new ServiceDialog(PatientID, queueID, queueNo.Text))
            {
                // DentalDialog form1 = new DentalDialog(item.Text, TransactorID);
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    //MessageBox.Show(form.state);
                    _todayList = Queue.ListQueue(Convert.ToDateTime(openedDate.Text).ToString("dd-MM-yyyy")).ToList(); ;
                    LoadServices(queueID);

                }
            }
        }
        Dictionary<string, string> BedDictionary = new Dictionary<string, string>();
        private void roomCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Beds item in Beds.ListBeds(roomCbx.Text)) {
                bedCbx.Items.Add(item.No);
                BedDictionary.Add(item.No,item.Rate);
            }
        }

        private void bedCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            costLbl.Text = BedDictionary[bedCbx.Text];
        }

        private void costLbl_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            using (LabDialog form = new LabDialog(PatientID, queueID, queueNo.Text))
            {
                // DentalDialog form1 = new DentalDialog(item.Text, TransactorID);
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    //MessageBox.Show(form.state);
                    _todayList = Queue.ListQueue(Convert.ToDateTime(openedDate.Text).ToString("dd-MM-yyyy")).ToList(); ;

                    LoadLabs(queueID);

                }
            }
        }

        private void queueNo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string QueueID = Global._queues.First(p => p.No.Contains(queueNo.Text)).Id;
                string patientID = Global._queues.First(d => d.No.Contains(queueNo.Text)).PatientID;
                if (!String.IsNullOrEmpty(QueueID))
                {
                    queueID = QueueID;
                    LoadServices(queueID);
                    LoadLabs(queueID);
                    PatientID = patientID;
                    LoadPatient(patientID);
                }
            }
            catch { }
        }

        private void queueNo_Click(object sender, EventArgs e)
        {
            queueNo.Text = "VHMIS-" + DateTime.Now.ToString("dd-MM-yyyy") + "/ADMIT/";
        }

        private void button4_Click_1(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
