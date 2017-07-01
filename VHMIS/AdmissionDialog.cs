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

        List<Queue> _queues = new List<Queue>();
        List<Queue> _todayList = new List<Queue>();
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
        string QueueID;
        public AdmissionDialog()
        {
            QueueID = Guid.NewGuid().ToString();
            _patientList = Global._patients;
            _userList = Global._users;
            InitializeComponent();
            autocompleteUsers();
            autocompletePatient();
            autocompleteClinics();
            autocompleteWards();
            today = DateTime.Now.ToString("yyyy-MM-dd");
            _queues = Global._queues;
            _todayList = Global._queues.Where(r => r.Dated.Contains(DateTime.Now.ToString("dd-MM-yyyy"))).ToList();
            foreach (Clinics d in Global._clinics)
            {
                clinicCbx.Items.Add(d.Name);
            }
            foreach (Wards d in Global._wards)
            {
                wardCbx.Items.Add(d.Name);
                wardDictionary.Add(d.Name,d.Id);
            }           
         
            foreach (Departments d in Global._departments)
            {
                departmentCbx.Items.Add(d.Name);
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
            orderLbl.Text = "VHMIS-" + DateTime.Now.ToString("dd-MM-yyyy") + "/ADMIT/" + next;
            LoadItem();
        }
        public void LoadItem()
        {
            try
            {
                TreeNode treeNode = new TreeNode("Departments");
                //  myTreeView.Nodes.Add(treeNode);
                // create and execute query  
                int ct = 1;
                var result = Global._operations.GroupBy(cat => cat.DepID).Select(un => un.First());
                foreach (Operations c in result)
                {
                    treeNode = new TreeNode(ct++ + "." + Global._departments.First(s => s.Id.Contains(c.DepID)).Name);
                    myTreeView.Nodes.Add(treeNode);

                    foreach (Operations d in Global._operations.Where(b => b.DepID.Contains(c.DepID)))
                    {
                        TreeNode child = new TreeNode();

                        child.Name = d.Name;
                        child.Tag = d.Id;
                        child.Text = d.Name;
                        child.ImageIndex = 1;
                        treeNode.Nodes.Add(child);
                    }
                }
                myTreeView.Nodes[0].TreeView.ImageList = imageList1;
            }
            catch
            {


            }
        }
        private void autocompleteUsers()
        {
            AutoCompleteStringCollection AutoItem = new AutoCompleteStringCollection();
            foreach (Users u in Global._users)
            {
                AutoItem.Add(u.Surname + " " + u.Lastname);
                if (!userDictionary.ContainsKey(u.Surname + " " + u.Lastname))
                {
                    userDictionary.Add(u.Surname + " " + u.Lastname, u.Id);
                }

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
        
       

        private void practitionerTxt_Leave(object sender, EventArgs e)
        {
            try
            {
                userID = userDictionary[practitionerTxt.Text];
                _todayList = Global._queues.Where(l => l.UserID.Contains(userID)).ToList();

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

        Dictionary<string, string> BedDictionary = new Dictionary<string, string>();
        private void wardCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            string wardID = wardDictionary[wardCbx.Text];
            foreach (Beds d in Global._beds.Where(f=>f.WardID.Contains(wardCbx.Text)))
            {
                bedCbx.Items.Add(d.No);
                BedDictionary.Add(d.No, d.Rate);
            }
        }

        private void bedCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            costLbl.Text = BedDictionary[bedCbx.Text];
        }

        private void myTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string paid = "No";
            string status = "Incomplete";
            if (paidChk.Checked == true)
            {
                paid = "Yes";
                status = "Complete";
            }
            if (String.IsNullOrEmpty(patientID))
            {
                MessageBox.Show("Please input the input the patient  ");
                return;
            }
            if (String.IsNullOrEmpty(userID))
            {
                MessageBox.Show("Please input the input the practitioner  ");
                return;
            }
            if (Global._queues.Where(t => t.No.Contains(orderLbl.Text)).Count() < 1)
            {
                MessageBox.Show("Please save /Submit the visit information");
                return;
            }
            string OpId = myTreeView.SelectedNode.Tag.ToString();

            string id = "";
            id = Guid.NewGuid().ToString();
            if (!String.IsNullOrEmpty(OpId))
            {
                Services _service = new Services(id, myTreeView.SelectedNode.Name.ToString(), orderLbl.Text, QueueID, Global._operations.First(s => s.Id.Contains(OpId)).DepID, OpId, patientID, Helper.userID, Global._operations.First(s => s.Id.Contains(OpId)).Cost, Global._operations.First(s => s.Id.Contains(OpId)).Parameter, "Incomplete", "1", Global._operations.First(s => s.Id.Contains(OpId)).Cost, "No", "", "", DateTime.Now.ToString("dd-MM-yyyy"), DateTime.Now.ToString("dd-MM-yyyy H:mm:ss"), Helper.orgID);
                DBConnect.Insert(_service);
                // Global._services.Add(_service);
                MessageBox.Show("Information added/Saved");


            }
            LoadServices(orderLbl.Text);
        }
        DataTable tb;
        private void LoadServices(string visitID)
        {

            List<Services> _services = Services.ListServices(visitID);
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
            tb.Columns.Add("Cancel");//

            foreach (Services r in _services)
            {
                tb.Rows.Add(new object[] { r.Id, r.Parameter, r.Name, Global._departments.First(e => e.Id.Contains(r.DepartmentID)).Name, r.Price, r.Qty, r.Total, r.Paid, r.Notes, r.Status, "Cancel" });

            }
            dtGrid.DataSource = tb;
            dtGrid.AllowUserToAddRows = false;
            dtGrid.Columns["Cancel"].DefaultCellStyle.BackColor = Color.OrangeRed;
            dtGrid.Columns["id"].Visible = false;
            dtGrid.Columns["Cancel"].FillWeight = 80;
        }
        private void button18_Click(object sender, EventArgs e)
        {

        }


        private void button2_Click_1(object sender, EventArgs e)
        {
            string paid = "No";
            string status = "Incomplete";
            if (paidChk.Checked == true)
            {
                paid = "Yes";
                status = "Complete";
            }
            if (Global._queues.Where(t => t.No.Contains(orderLbl.Text)).Count() > 0)
            {
                MessageBox.Show("Information already submitted  ");
                return;
            }
            if (patientID == "" || userID == "")
            {
                MessageBox.Show("Please input the input the patient OR the practitioner  ");
                return;
            }

            if (!String.IsNullOrEmpty(departmentCbx.Text))
            {
                Queue _q = new Queue(QueueID, next.ToString(), patientID, Helper.UserID, " ", "", Convert.ToDateTime(openedDate.Text).ToString("dd-MM-yyyy"), DateTime.Now.ToString("dd-MM-yyyy H:mm:ss"), "", departmentCbx.Text, "Yes", "Yes", "Yes", "Yes", "Yes", "Yes", "", "", orderLbl.Text, Helper.orgID, departmentCbx.Text);
                DBConnect.Insert(_q);
                Global._queues.Add(_q);

                Admission _a = new Admission(QueueID, orderLbl.Text, next.ToString(), patientID, Helper.UserID, departmentCbx.Text,wardCbx.Text,bedCbx.Text,priorityCbx.Text,remarksTxt.Text,Helper.orgID, Convert.ToDateTime(openedDate.Text).ToString("dd-MM-yyyy"), DateTime.Now.ToString("dd-MM-yyyy H:mm:ss"),enrollCbx.Text,referralDocTxt.Text);
                DBConnect.Insert(_a);
                Global._admit.Add(_a);

                MessageBox.Show("Information added/Saved");


            }
        }

        private void departmentCbx_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
