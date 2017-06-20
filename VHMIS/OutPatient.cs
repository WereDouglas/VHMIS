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
            if (String.IsNullOrEmpty(queueNo.Text))
            {
                MessageBox.Show("Please input the VISIT NO/ID");
                return;
            }
            using (LabDialog form = new LabDialog(PatientID, queueID, queueNo.Text))
            {
                // DentalDialog form1 = new DentalDialog(item.Text, TransactorID);
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    //MessageBox.Show(form.state);
                     
                    LoadLabs(queueID);

                }
            }


        }
        private List<Services> _services;
        private Services _service;
        double serviceTotal = 0;
        private void button18_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(queueNo.Text)){
                MessageBox.Show("Please input the VISIT NO/ID");
                return;
            }
            using (ServiceDialog form = new ServiceDialog(PatientID, queueID, queueNo.Text))
            {
                // DentalDialog form1 = new DentalDialog(item.Text, TransactorID);
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    //MessageBox.Show(form.state);
                  
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
      

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        double procsTotal = 0;
       
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

        private void button4_Click(object sender, EventArgs e)
        {

            using (EventDialog form = new EventDialog())
            {
                // DentalDialog form1 = new DentalDialog(item.Text, TransactorID);
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {


                }
            }
        }
    }
}
