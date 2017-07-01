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
    public partial class DentalDialog : Form
    {
        private Lab _lab;
        private List<Lab> _labs;
        private Operations _op;
        private List<Services> _services;
        private Services _service;
        private List<Operations> _ops;
        public string state = "Saved";


        private Diagnosis _diag;
        private List<Diagnosis> _diags;
        string PatientID;
        string PractitionerID;
        string VisitID;
        Dictionary<string, string> operationCost = new Dictionary<string, string>();
        Dictionary<string, string> testCost = new Dictionary<string, string>();
        string No;
        public DentalDialog(string tooth, string patientID, string visitID,string no)
        {
            No = no;
            PatientID = patientID;
            VisitID = visitID;
            InitializeComponent();
            toothTxt.Text = tooth;
            orderLbl.Text = No;
            autocompleteCD();
            LoadItem();
            LoadServices(No);
        }
        public void LoadItem()
        {
            try
            {
                TreeNode treeNode = new TreeNode("Departments");
                
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
        Dictionary<string, string> cdDictionary = new Dictionary<string, string>();
        private void autocompleteCD()
        {
            AutoCompleteStringCollection AutoItem = new AutoCompleteStringCollection();
            foreach (Cd10 p in Global._cds)
            {
                AutoItem.Add(p.Description);
                cdDictionary.Add(p.Code, p.Description);
            }

            diagnosisCbx.AutoCompleteMode = AutoCompleteMode.Suggest;
            diagnosisCbx.AutoCompleteSource = AutoCompleteSource.CustomSource;
            diagnosisCbx.AutoCompleteCustomSource = AutoItem;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Dispose();
        }

        private void label52_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

            this.DialogResult = DialogResult.OK;
            this.Dispose();

        }
        double serviceTotal = 0;
      


        private void serviceQty_TextChanged(object sender, EventArgs e)
        {

        }

        private void diagnosisQty_TextChanged(object sender, EventArgs e)
        {

        }

        private void diagnosisCbx_Leave(object sender, EventArgs e)
        {
            try
            {
                var value = cdDictionary.FirstOrDefault(x => x.Value.Contains(diagnosisCbx.Text)).Key;
                noteTxt.Text = value;// cdDictionary[diagnosisCbx.Text];
            }
            catch
            {

            }
        }

        private void label46_Click(object sender, EventArgs e)
        {

        }

        private void myTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            
          
            if (String.IsNullOrEmpty(PatientID))
            {
                MessageBox.Show("Please input the input the patient  ");
                return;
            }           
            string OpId = myTreeView.SelectedNode.Tag.ToString();

            
            string id = Guid.NewGuid().ToString();
            if (!String.IsNullOrEmpty(OpId))
            {
                Services _service = new Services(id, myTreeView.SelectedNode.Name.ToString(), orderLbl.Text, VisitID, Global._operations.First(s => s.Id.Contains(OpId)).DepID, OpId, PatientID, Helper.userID, Global._operations.First(s => s.Id.Contains(OpId)).Cost, toothTxt.Text, "Incomplete", "1", Global._operations.First(s => s.Id.Contains(OpId)).Cost, "No", "", "", DateTime.Now.ToString("dd-MM-yyyy"), DateTime.Now.ToString("dd-MM-yyyy H:mm:ss"), Helper.orgID);
                DBConnect.Insert(_service);
                // Global._services.Add(_service);
                MessageBox.Show("Information added/Saved");


            }
            LoadServices(orderLbl.Text);
        }
        DataTable tb;
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
            dtGrid.DataSource = tb;
            dtGrid.AllowUserToAddRows = false;
            dtGrid.Columns["Cancel"].DefaultCellStyle.BackColor = Color.OrangeRed;
            dtGrid.Columns["id"].Visible = false;
            dtGrid.Columns["departmentID"].Visible = false;
            dtGrid.Columns["Cancel"].FillWeight = 80;
            totalLbl.Text = _services.Sum(f => Convert.ToDouble(f.Total)).ToString("n0");
        }

        private void dtGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dtGrid.Columns["Cancel"].Index && e.RowIndex >= 0)
            {
                if (MessageBox.Show("YES or No?", "Cancel service ? ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    DBConnect.Delete("services", dtGrid.Rows[e.RowIndex].Cells["id"].Value.ToString());
                    MessageBox.Show("Information deleted");
                    LoadServices(No);

                }

            }
        }

        private void dtGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (String.IsNullOrEmpty(dtGrid.Rows[e.RowIndex].Cells["Quantity"].Value.ToString()) || String.IsNullOrEmpty(dtGrid.Rows[e.RowIndex].Cells["Price"].Value.ToString()))
            {

                MessageBox.Show("Please input a value ");
                return;

            }
            if (e.ColumnIndex == dtGrid.Columns["Quantity"].Index || e.ColumnIndex == dtGrid.Columns["Price"].Index)
            {
                try
                {
                    dtGrid.Rows[e.RowIndex].Cells["Total"].Value = (Convert.ToDouble(dtGrid.Rows[e.RowIndex].Cells["Quantity"].Value) * Convert.ToDouble(dtGrid.Rows[e.RowIndex].Cells["Price"].Value));
                }
                catch
                {


                }

            }
            Services _c = new Services(dtGrid.Rows[e.RowIndex].Cells["id"].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells["name"].Value.ToString(), No, VisitID, dtGrid.Rows[e.RowIndex].Cells["departmentID"].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells["name"].Value.ToString(), PatientID, Helper.userID, dtGrid.Rows[e.RowIndex].Cells["price"].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells["parameter"].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells["status"].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells["Quantity"].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells["Total"].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells["Paid"].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells["notes"].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells["results"].Value.ToString(), DateTime.Now.ToString("dd-MM-yyyy"), DateTime.Now.ToString("dd-MM-yyyy H:mm:ss"), Helper.orgID);
            DBConnect.Update(_c, dtGrid.Rows[e.RowIndex].Cells["id"].Value.ToString());
            try
            {
                LoadServices(No);
            }
            catch { }
        }
    }
}
