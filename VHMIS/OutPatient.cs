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
    public partial class OutPatient : Form
    {
        List<Queue> _queues = new List<Queue>();
        List<Queue> _todayList = new List<Queue>();
        Dictionary<string, string> patientDictionary = new Dictionary<string, string>();
        Dictionary<string, string> userDictionary = new Dictionary<string, string>();
        Dictionary<string, string> IdDictionary = new Dictionary<string, string>();
        Dictionary<string, string> numberDictionary = new Dictionary<string, string>();
        Dictionary<string, string> clinicDictionary = new Dictionary<string, string>();
        Dictionary<string, string> roomDictionary = new Dictionary<string, string>();
        Dictionary<string, string> wardDictionary = new Dictionary<string, string>();
        Dictionary<string, string> operationCost = new Dictionary<string, string>();
        Dictionary<string, string> testCost = new Dictionary<string, string>();
        List<Patient> _patientList = new List<Patient>();
        List<Users> _userList = new List<Users>();
        Queue _queue;
        string queueID;
        string PatientID;
        DataTable tb;
        DataTable bb;
        string userID;
        string wardID;
        string clinicID;
        string today;

        public OutPatient(string QueueID, string patientID, string UserID)
        {
            _patientList = Global._patients;
            userID = UserID;
            _userList = Global._users;
            InitializeComponent();

            autocompleteNumber();
            autocompleteID();
            autocompleteUsers();
            autocompletePatient();
            autocompleteClinics();
            autocompleteWards();
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
            labCbx.Items.Add("");
            foreach (Tests t in Global._tests)//.Where(i=>i.DepartmentID))
            {
                labCbx.Items.Add(t.Parameter);
                testCost.Add(t.Parameter, t.Cost);
            }
            operationCbx.Items.Add("");
            foreach (Operations t in Global._operations)//.Where(i=>i.DepartmentID))
            {
                operationCbx.Items.Add(t.Service);
                operationCost.Add(t.Service, t.Cost);
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


        private void button1_Click(object sender, EventArgs e)
        {
            Close();
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private Lab _lab;
        private List<Lab> _labs;
        private Diagnosis _diag;
        private List<Diagnosis> _diags;
        private void button2_Click(object sender, EventArgs e)
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
        private List<Services> _services;
        private Services _service;
        double serviceTotal = 0;
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
        public System.Drawing.Image Base64ToImage(string bases)
        {
            byte[] imageBytes = Convert.FromBase64String(bases);
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
            ms.Write(imageBytes, 0, imageBytes.Length);
            System.Drawing.Image image = System.Drawing.Image.FromStream(ms, true);
            return image;
        }
        int follow;
        private void button3_Click(object sender, EventArgs e)
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

            if (PatientID == "" || userID == "")
            {
                MessageBox.Show("Please input the input the patient OR the practitioner  ");
                return;
            }
            string id = Guid.NewGuid().ToString();

            _queue = new Queue(id, next.ToString(), PatientID, userID, roomCbx.Text, clinicCbx.Text, priorityCbx.Text, Convert.ToDateTime(this.openedDate.Text).ToString("yyyy-MM-dd"), DateTime.Now.ToString("dd-MM-yyyy H:mm:ss"), departmentCbx.Text, "", "", "", "", "", "", "", "", "", Helper.orgID,"OP");

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

        private void operationCbx_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                opCostTxt.Text = operationCost[operationCbx.Text];
                serviceTotal = Convert.ToDouble(opCostTxt.Text) * Convert.ToDouble(serviceQty.Text);
                serviceLbl.Text = serviceTotal.ToString("n0");
            }
            catch { }

        }
        double LabTotal = 0;
        private void labCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                labCostTxt.Text = testCost[labCbx.Text];
                LabTotal = Convert.ToDouble(labCostTxt.Text) * Convert.ToDouble(labQty.Text);
                LabLbl.Text = LabTotal.ToString("n0");
            }
            catch { }
        }

        private void patientTxt_Leave_1(object sender, EventArgs e)
        {
            try
            {
                PatientID = patientDictionary[patientTxt.Text];

                LoadPatient(PatientID);
            }
            catch { }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            PatientProfile frm = new PatientProfile(PatientID);
            frm.MdiParent = MainForm.ActiveForm;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void practitionerTxt_Leave(object sender, EventArgs e)
        {
            try
            {
                userID = userDictionary[practitionerTxt.Text];
            }
            catch { }
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label34_Click(object sender, EventArgs e)
        {

        }

        private void roomCbx_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        string notify;
        Events _event;
        private void button6_Click_1(object sender, EventArgs e)
        {
            if (startHrTxt.Text == "" || endHrTxt.Text == "")
            {
                MessageBox.Show("Please input the start time and end time for the meeting /schedule ");
                return;
            }
            string ID = Guid.NewGuid().ToString();
            var start = Convert.ToDateTime(this.openedDate.Text).ToString("yyyy-MM-dd") + "T" + this.startHrTxt.Text + ":" + startMinTxt.Text + ":00";
            var end = Convert.ToDateTime(this.openedDate.Text).ToString("yyyy-MM-dd") + "T" + this.endHrTxt.Text + ":" + endMinTxt.Text + ":00";

            notify = "false";

            if (notifyChk.Checked)
            {
                notify = "true";
            }
            _event = new Events(ID, Helper.CleanString(this.detailsTxt.Text), start, end, practitionerTxt.Text, patientTxt.Text, DateTime.Now.Date.ToString("yyyy-MM-dd"), PatientID, "due", userID, Convert.ToDateTime(this.openedDate.Text).ToString("yyyy-MM-dd"), notify, priorityCbx.Text, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "f", contactTxt.Text, emailTxt.Text, departmentCbx.Text, clinicCbx.Text, Helper.orgID);

            Global._events.Add(_event);

            string Query2 = "INSERT INTO events (id, details, starts, ends, users, patient, created, patientID, status, userID, dated,notif,priority, sync,cal,contact,email) VALUES ('" + ID + "','" + Helper.CleanString(this.detailsTxt.Text) + "','" + start + "','" + end + "','" + practitionerTxt.Text + "','" + patientTxt.Text + "','" + DateTime.Now.Date.ToString("yyyy-MM-dd") + "','" + PatientID + "','due','" + userID + "','" + Convert.ToDateTime(this.openedDate.Text).ToString("yyyy-MM-dd") + "','" + notify + "','" + priorityCbx.Text + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','f','" + contactTxt.Text + "','" + emailTxt.Text + "');";
            DBConnect.Execute(Query2);
            MessageBox.Show("Information saved");



        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void serviceQty_TextChanged(object sender, EventArgs e)
        {
            try
            {
                serviceTotal = Convert.ToDouble(opCostTxt.Text) * Convert.ToDouble(serviceQty.Text);
                serviceLbl.Text = serviceTotal.ToString("n0");
            }
            catch { }

        }      

        private void button4_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(procTxt.Text))
            {

                MessageBox.Show("Please select the current status of the operation/Service ");
                return;
            }
            string id = "";
            id = Guid.NewGuid().ToString();
            if (!String.IsNullOrEmpty(procTotal.Text))
            {
                _service = new Services(id, procTxt.Text, queueID, "Dental", "procedureID", PatientID, "userID", "code", "userID", procCostTxt.Text, DateTime.Now.ToString("dd-MM-yyyy H:mm:ss"), parameterTxt.Text, statusCbx.Text, procQty.Text, procsTotal.ToString("n0"), "No", Helper.orgID,queueNo.Text);
                DBConnect.Insert(_service);
                MessageBox.Show("Information added/Saved");
                LoadServices(queueID);
            }
        }
        double procsTotal = 0;
        private void procQty_TextChanged(object sender, EventArgs e)
        {
            try
            {
                procsTotal = Convert.ToDouble(procCostTxt.Text) * Convert.ToDouble(procQty.Text);
                procTotal.Text = procsTotal.ToString("n0");
            }
            catch { }

        }

        private void button7_Click(object sender, EventArgs e)
        {

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
            queueNo.Text = "VHMIS-" + DateTime.Now.ToString("dd-MM-yyyy") + "/";
        }

        private void dtServices_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtServices.Rows[e.RowIndex].Cells["Cancel"].Value.ToString() == "Cancel")
            {
                if (MessageBox.Show("YES or No?", "Cancel service ? ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    DBConnect.Delete("services", dtServices.Rows[e.RowIndex].Cells["id"].Value.ToString());
                    MessageBox.Show("Information deleted");
                    LoadServices(queueID);

                }

            }
        }

        private void dtLab_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dtLab.Rows[e.RowIndex].Cells["Cancel"].Value.ToString() == "Cancel")
            {
                if (MessageBox.Show("YES or No?", "Cancel this Lab request ? ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    DBConnect.Delete("lab", dtLab.Rows[e.RowIndex].Cells["id"].Value.ToString());
                    MessageBox.Show("Information deleted");
                    LoadLabs(queueID);

                }

            }
        }
    }
}
