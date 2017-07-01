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
                LoadServices(Global._queues.First(y => y.Id.Contains(queueID)).No);

                PatientID = patientID;
                LoadPatient(patientID);
                queueNo.Text = Global._queues.First(y => y.Id.Contains(queueID)).No;
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
                tb.Rows.Add(new object[] { r.Id, r.Parameter, r.Name, Global._departments.First(e => e.Id.Contains(r.DepartmentID)).Name, r.Price, r.Qty, r.Total, r.Paid, r.Notes, r.Status, r.Results, "Cancel",r.DepartmentID });

            }
            dtServices.DataSource = tb;
            dtServices.AllowUserToAddRows = false;
            dtServices.Columns["Cancel"].DefaultCellStyle.BackColor = Color.OrangeRed;
            dtServices.Columns["id"].Visible = false;
            dtServices.Columns["departmentID"].Visible = false;
            dtServices.Columns["Cancel"].FillWeight = 80;
            totalLbl.Text = _services.Sum(f => Convert.ToDouble(f.Total)).ToString("n0");
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private Lab _lab;
        private List<Lab> _labs;
        private Diagnosis _diag;
        private List<Diagnosis> _diags;

        private List<Services> _services;
        private Services _service;
        double serviceTotal = 0;
        private void button18_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(queueNo.Text))
            {
                MessageBox.Show("Please input the VISIT NO/ID");
                return;
            }
            using (RequestDialog form = new RequestDialog(PatientID, queueID, queueNo.Text))
            {
                // DentalDialog form1 = new DentalDialog(item.Text, TransactorID);
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    //MessageBox.Show(form.state);

                    LoadServices(queueNo.Text);

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
                
                    string QueueID = Global._queues.First(p => p.No.Equals(queueNo.Text)).Id;
                    string patientID = Global._queues.First(d => d.No.Equals(queueNo.Text)).PatientID;
                    if (!String.IsNullOrEmpty(QueueID))
                    {
                        queueID = QueueID;
                        LoadServices(queueNo.Text);
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
            if (e.ColumnIndex == dtServices.Columns["Cancel"].Index && e.RowIndex >= 0)
            {
                if (MessageBox.Show("YES or No?", "Cancel service ? ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    DBConnect.Delete("services", dtServices.Rows[e.RowIndex].Cells["id"].Value.ToString());
                    MessageBox.Show("Information deleted");
                    LoadServices(queueNo.Text);

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

        private void button2_Click_1(object sender, EventArgs e)
        {
            using (StatementDialog form = new StatementDialog(queueID))
            {
                // DentalDialog form1 = new DentalDialog(item.Text, TransactorID);
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {


                }
            }
        }

        private void dtServices_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            if (String.IsNullOrEmpty(dtServices.Rows[e.RowIndex].Cells["Quantity"].Value.ToString()) || String.IsNullOrEmpty(dtServices.Rows[e.RowIndex].Cells["Price"].Value.ToString()))
            {

                MessageBox.Show("Please input a value ");
                return;

            }
            if (e.ColumnIndex == dtServices.Columns["Quantity"].Index || e.ColumnIndex == dtServices.Columns["Price"].Index)
            {
                try
                {
                    dtServices.Rows[e.RowIndex].Cells["Total"].Value = (Convert.ToDouble(dtServices.Rows[e.RowIndex].Cells["Quantity"].Value) * Convert.ToDouble(dtServices.Rows[e.RowIndex].Cells["Price"].Value));
                }
                catch
                {


                }

            }
            Services _c = new Services(dtServices.Rows[e.RowIndex].Cells["id"].Value.ToString(), dtServices.Rows[e.RowIndex].Cells["name"].Value.ToString(), queueNo.Text, queueID, dtServices.Rows[e.RowIndex].Cells["departmentID"].Value.ToString(), dtServices.Rows[e.RowIndex].Cells["name"].Value.ToString(), PatientID, Helper.userID, dtServices.Rows[e.RowIndex].Cells["price"].Value.ToString(), dtServices.Rows[e.RowIndex].Cells["parameter"].Value.ToString(), dtServices.Rows[e.RowIndex].Cells["status"].Value.ToString(), dtServices.Rows[e.RowIndex].Cells["Quantity"].Value.ToString(), dtServices.Rows[e.RowIndex].Cells["Total"].Value.ToString(), dtServices.Rows[e.RowIndex].Cells["Paid"].Value.ToString(), dtServices.Rows[e.RowIndex].Cells["notes"].Value.ToString(), dtServices.Rows[e.RowIndex].Cells["results"].Value.ToString(), DateTime.Now.ToString("dd-MM-yyyy"), DateTime.Now.ToString("dd-MM-yyyy H:mm:ss"), Helper.orgID);
            DBConnect.Update(_c, dtServices.Rows[e.RowIndex].Cells["id"].Value.ToString());
            try
            {
                LoadServices(queueNo.Text);
            }
            catch { }
        }

        private void dtServices_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dtServices.Columns["Paid"].HeaderText.Equals("Paid"))
            {
                TextBox autoText = e.Control as TextBox;
                if (autoText != null)
                {
                    autoText.AutoCompleteMode = AutoCompleteMode.Suggest;
                    autoText.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    AutoCompleteStringCollection DataCollection = new AutoCompleteStringCollection();
                    addPaid(DataCollection);
                    autoText.AutoCompleteCustomSource = DataCollection;
                }
            }

            if (dtServices.Columns["Status"].HeaderText.Equals("Status"))
            {
                TextBox autoText = e.Control as TextBox;
                if (autoText != null)
                {
                    autoText.AutoCompleteMode = AutoCompleteMode.Suggest;
                    autoText.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    AutoCompleteStringCollection DataCollection = new AutoCompleteStringCollection();
                    addStatus(DataCollection);
                    autoText.AutoCompleteCustomSource = DataCollection;
                }
            }
            
        }
        public void addPaid(AutoCompleteStringCollection col)
        {

            col.Add("Yes");
            col.Add("No");

        }
        public void addStatus(AutoCompleteStringCollection col)
        {

            col.Add("Complete");
            col.Add("Incomplete");

        }
    }
}
