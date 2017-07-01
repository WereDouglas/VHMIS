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
    public partial class QueueDialog : Form
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
        Queue _queue;

        Dictionary<string, string> operationCost = new Dictionary<string, string>();
        Dictionary<string, string> diagnosisCost = new Dictionary<string, string>();

        bool loaded = false;
        string today;
        string QueueID;
        public QueueDialog()
        {
            QueueID  = Guid.NewGuid().ToString();
            _patientList = Global._patients;
            _userList = Global._users;
            InitializeComponent();
            autocompleteUsers();
            autocompletePatient();

            autocompleteWards();
            today = DateTime.Now.ToString("yyyy-MM-dd");
            _queues = Global._queues;
            _todayList = Global._queues.Where(r => r.Dated.Contains(DateTime.Now.ToString("dd-MM-yyyy"))).ToList();

            foreach (Room d in Global._rooms)
            {
                roomCbx.Items.Add(d.Name);
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
                follow = _todayList.Max(d=>Convert.ToInt32(d.Follow));
                next = follow + 1;
            }
            orderLbl.Text = "VHMIS-" + DateTime.Now.ToString("dd-MM-yyyy") + "/" + next;
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

        private void patientTxt_Leave(object sender, EventArgs e)
        {

            try
            {
                patientID = patientDictionary[patientTxt.Text];
            }
            catch { }
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Dispose();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void roomCbx_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        int follow;
       
        int next;

        private void QueueDialog_Load(object sender, EventArgs e)
        {

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
            if (Global._queues.Where(t => t.No.Contains(orderLbl.Text)).Count() < 1)
            {
                MessageBox.Show("Please save /Submit the visit information");
                return;
            }
            if (String.IsNullOrEmpty(userID))
            {
                MessageBox.Show("Please input the input the practitioner  ");
                return;
            }
            string OpId = myTreeView.SelectedNode.Tag.ToString();

            string id = "";
            id = Guid.NewGuid().ToString();
            if (!String.IsNullOrEmpty(OpId))
            {
                Services _service = new Services(id, myTreeView.SelectedNode.Name.ToString(), orderLbl.Text,QueueID, Global._operations.First(s => s.Id.Contains(OpId)).DepID, OpId, patientID, Helper.userID, Global._operations.First(s => s.Id.Contains(OpId)).Cost, Global._operations.First(s => s.Id.Contains(OpId)).Parameter, "Incomplete", "1", Global._operations.First(s => s.Id.Contains(OpId)).Cost, "No", "", "", DateTime.Now.ToString("dd-MM-yyyy"), DateTime.Now.ToString("dd-MM-yyyy H:mm:ss"), Helper.orgID);
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

        private void button2_Click(object sender, EventArgs e)
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
                Queue _q = new Queue(QueueID, next.ToString(), patientID, Helper.UserID, roomCbx.Text, "", Convert.ToDateTime(openedDate.Text).ToString("dd-MM-yyyy"), DateTime.Now.ToString("dd-MM-yyyy H:mm:ss"), "", departmentCbx.Text, "Yes", "Yes", "Yes", "Yes", "Yes", "Yes", "", "", orderLbl.Text, Helper.orgID, departmentCbx.Text);
                DBConnect.Insert(_q);
                Global._queues.Add(_q);
                MessageBox.Show("Information added/Saved");


            }
        }
    }
}
