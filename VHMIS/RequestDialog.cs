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
    public partial class RequestDialog : Form
    {
        DataTable tb;
        string QueueID;
        string PatientID;
        string QueueNo;
        public RequestDialog(string patientID, string queueID, string queueNo)
        {
             QueueID = queueID; ;
            PatientID = patientID;
             QueueNo = queueNo;

            InitializeComponent();
            orderLbl.Text = QueueNo;
            LoadServices(orderLbl.Text);

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
                    myTreeView2.Nodes.Add(treeNode);
                    foreach (Operations d in Global._operations.Where(b => b.DepID.Contains(c.DepID)))
                    {
                        TreeNode child = new TreeNode();
                        child.Name = d.Id;
                        child.Tag = d.Id;
                        child.Text = d.Name;
                        child.ImageIndex = 1;
                        treeNode.Nodes.Add(child);
                    }
                }
                myTreeView2.Nodes[0].TreeView.ImageList = imageList1;
            }
            catch
            {


            }
        }
        string notify;

       
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


        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Dispose();
        }

        private void dtGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void myTreeView2_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (String.IsNullOrEmpty(PatientID))
            {
                MessageBox.Show("Please input the input the patient  ");
                return;
            }

            string paid = "No";
            string status = "Incomplete";


            string OpId = myTreeView2.SelectedNode.Name.ToString();

            string id = Guid.NewGuid().ToString();
            if (!String.IsNullOrEmpty(OpId))
            {
                Services _service = new Services(id, myTreeView2.SelectedNode.Text.ToString(), orderLbl.Text, QueueID, Global._operations.First(s => s.Id.Contains(OpId)).DepID, OpId, PatientID, Helper.userID, Global._operations.First(s => s.Id.Contains(OpId)).Cost, Global._operations.First(s => s.Id.Contains(OpId)).Parameter, "Incomplete", "1", Global._operations.First(s => s.Id.Contains(OpId)).Cost, "No", "", "", DateTime.Now.ToString("dd-MM-yyyy"), DateTime.Now.ToString("dd-MM-yyyy H:mm:ss"), Helper.orgID);
                DBConnect.Insert(_service);
                // Global._services.Add(_service);
                MessageBox.Show("Information added/Saved");
            }
            //}
            //catch { }
            LoadServices(orderLbl.Text);
        }

        private void RequestDialog_Load(object sender, EventArgs e)
        {
            LoadItem();
        }

        private void myTreeView2_Click(object sender, EventArgs e)
        {

            
        }

        private void dtGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dtGrid.Columns["Cancel"].Index && e.RowIndex >= 0)
            {
                if (MessageBox.Show("YES or No?", "Cancel service ? ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    DBConnect.Delete("services", dtGrid.Rows[e.RowIndex].Cells["id"].Value.ToString());
                    MessageBox.Show("Information deleted");
                    LoadServices(orderLbl.Text);

                }

            }
        }
    }
}
