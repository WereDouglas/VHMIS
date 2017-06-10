using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VHMIS.Model;

namespace VHMIS
{
    public partial class AdmissionDialog : Form
    {
        Dictionary<string, string> userDictionary = new Dictionary<string, string>();
        Dictionary<string, string> patientDictionary = new Dictionary<string, string>();
        Dictionary<string, string> clinicDictionary = new Dictionary<string, string>();
        Dictionary<string, string> roomDictionary = new Dictionary<string, string>();
        Dictionary<string, string> wardDictionary = new Dictionary<string, string>();
        Dictionary<string, string> departmentDictionary = new Dictionary<string, string>();
        DataTable t;
        List<Patient> _patientList = new List<Patient>();
        List<Users> _userList = new List<Users>();
        string patientID;
        string userID;
        string wardID;
        string clinicID;

        List<Admission> _admission = new List<Admission>();
        List<Admission> _todayList = new List<Admission>();
        Admission _admit;
        DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();
        DataGridViewButtonColumn btnEdit = new DataGridViewButtonColumn();
        Dictionary<string, string> operationCost = new Dictionary<string, string>();
        Dictionary<string, string> diagnosisCost = new Dictionary<string, string>();

        bool loaded = false;
        string today;
        int follow;
        Services _service;
        int next;
        public AdmissionDialog()
        {

            _patientList = Global._patients;
            _userList = Global._users;
            InitializeComponent();
            autocompleteUsers();
            autocompletePatient();
            autocompleteClinics();
            autocompleteWards();
            today = DateTime.Now.ToString("yyyy-MM-dd");
            _admission = Global._admit;
            _todayList = Global._admit.Where(r => r.Dated.Contains(DateTime.Now.ToString("dd-MM-yyyy"))).ToList();
            foreach (Clinics d in Global._clinics)
            {
                clinicCbx.Items.Add(d.Name);
            }
            foreach (Wards d in Global._wards)
            {
                wardCbx.Items.Add(d.Name);
                wardDictionary.Add(d.Name,d.Id);
            }
           
            operationCbx.Items.Add("");
            foreach (Operations t in Global._operations)//.Where(i=>i.DepartmentID))
            {
                operationCbx.Items.Add(t.Service);
                operationCost.Add(t.Service, t.Cost);
            }

            if (_todayList.Count() < 1)
            {
                next = 1;
            }
            else
            {
                follow = _todayList.Max(t => Convert.ToInt32(t.Follow));
                next = follow + 1;
            }
            orderLbl.Text = "VHMIS-" + DateTime.Now.ToString("dd-MM-yyyy") + "ADMIT/" + next;
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
        private void autocompleteWards()
        {
            AutoCompleteStringCollection AutoItem = new AutoCompleteStringCollection();
            foreach (Room u in Global._rooms)
            {
                AutoItem.Add(u.Name);
                wardDictionary.Add(u.Name, u.Id);
            }
            wardCbx.AutoCompleteMode = AutoCompleteMode.Suggest;
            wardCbx.AutoCompleteSource = AutoCompleteSource.CustomSource;
            wardCbx.AutoCompleteCustomSource = AutoItem;

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

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (patientID == "" || userID == "")
            {
                MessageBox.Show("Please input the input the patient OR the practitioner  ");
                return;
            }
            string id = Guid.NewGuid().ToString();
            string paid = "No";
            string status = "Incomplete";
            if (paidChk.Checked == true)
            {
                paid = "Yes";
                status = "Complete";
            }
            Helper.orgID = "test";
            _admit = new Admission(id, next.ToString(), patientID, userID, wardCbx.Text, priorityCbx.Text, Convert.ToDateTime(this.openedDate.Text).ToString("yyyy-MM-dd"), DateTime.Now.ToString("dd-MM-yyyy H:mm:ss"), clinicCbx.Text, bedCbx.Text, paid, "", "", "", "", "", remarksTxt.Text, "", orderLbl.Text, Helper.orgID);
            Global._admit.Add(_admit);
            if (DBConnect.Insert(_admit) != "")
            {
                patientTxt.Text = "";
                practitionerTxt.Text = "";
                string ids = Guid.NewGuid().ToString();
                if (!String.IsNullOrEmpty(operationCbx.Text))
                {

                    _service = new Services(ids, operationCbx.Text, id, "Dental", "procedureID", patientID, "userID", "code", "userID", opCostTxt.Text, DateTime.Now.ToString("dd-MM-yyyy H:mm:ss"), operationCbx.Text, status, "1", opCostTxt.Text, paid, Helper.orgID);
                    DBConnect.Insert(_service);
                    MessageBox.Show("Information added/Saved");
                    this.DialogResult = DialogResult.OK;
                    this.Dispose();
                }

                MessageBox.Show("Information Saved");


            }
            else
            {
                return;

            }
        }

        private void practitionerTxt_Leave(object sender, EventArgs e)
        {
            try
            {
                userID = userDictionary[practitionerTxt.Text];
                _todayList = Global._admit.Where(l => l.UserID.Contains(userID)).ToList();

            }
            catch { }
        }

        private void patientTxt_Leave(object sender, EventArgs e)
        {
            try
            {
                patientID = patientDictionary[patientTxt.Text];
            }
            catch { }
        }

        private void operationCbx_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                opCostTxt.Text = operationCost[operationCbx.Text];
                //serviceTotal = Convert.ToDouble(opCostTxt.Text) * Convert.ToDouble(opCostTxt.Text);
                //serviceLbl.Text = serviceTotal.ToString("n0");
            }
            catch { }
        }

        private void wardCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            string wardID = wardDictionary[wardCbx.Text];
            foreach (Beds d in Global._beds.Where(f=>f.WardID.Contains(wardCbx.Text)))
            {
                bedCbx.Items.Add(d.No);
            }
        }
    }
}
