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
    public partial class OperationForm : Form
    {
        DataTable t;
        List<Operations> _operations = new List<Operations>();
        Operations _operation;
        DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();
        DataGridViewButtonColumn btnEdit = new DataGridViewButtonColumn();
        public OperationForm()
        {
            InitializeComponent();
            LoadData();
            updateBtn.Visible = false;

            btnDelete.Name = "btnDelete";
            btnDelete.Text = "Delete";
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Width = 30;
            btnDelete.CellTemplate.Style.BackColor = Color.Wheat;
            btnDelete.UseColumnTextForButtonValue = true;
            btnDelete.HeaderText = "Delete";

            btnEdit.Name = "btnEdit";
            btnEdit.Text = "Edit";
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Width = 30;
            btnEdit.CellTemplate.Style.BackColor = Color.Orange;
            btnEdit.UseColumnTextForButtonValue = true;
            btnEdit.HeaderText = "Edit";

            foreach (Departments d in Global._departments)
            {
                departmentCbx.Items.Add(d.Name);
            }
        }
        bool loaded = false;
        public void LoadData()
        {

            _operations = Global._operations;
            t = new DataTable();
            // create and execute query 
            t.Columns.Add("id");//2 
            t.Columns.Add(new DataColumn("Select", typeof(bool)));
            t.Columns.Add("Department");//4
            t.Columns.Add("Code");//5            
            t.Columns.Add("Service");//7
            t.Columns.Add("Cost");//7
            t.Columns.Add("Other");//9
            t.Columns.Add("Created");// 9

            foreach (Operations r in Global._operations)
            {
                t.Rows.Add(new object[] { r.Id, false, r.DepartmentID, r.Code, r.Service, r.Cost, r.Other, r.Created });

            }
            dtGrid.DataSource = t;
            dtGrid.AllowUserToAddRows = false;

            if (!loaded)
            {
                dtGrid.Columns.Add(btnEdit);
                dtGrid.Columns.Add(btnDelete);
                dtGrid.Columns[0].Visible = false;
            }

            loaded = true;
            // btnDelete.DisplayIndex = 1;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (serviceTxt.Text == "")
            {
                serviceTxt.BackColor = Color.Red;
                return;
            }

            string id = Guid.NewGuid().ToString();
            _operation = new Operations(id, departmentCbx.Text, codeTxt.Text, serviceTxt.Text, costTxt.Text, otherTxt.Text, DateTime.Now.ToString("dd-MM-yyyy H:mm:ss"));

            if (DBConnect.Insert(_operation) != "")
            {
                Global._operations.Add(_operation);
                serviceTxt.Text = "";
                costTxt.Text = "";
                otherTxt.Text = "";
                MessageBox.Show("Information Saved");
                LoadData();

            }
            else
            {
                return;

            }
        }
        List<string> fileIDs = new List<string>();

        public object CollectionViewSource { get; private set; }
        public object UserFilter { get; private set; }

        private void dtGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (e.ColumnIndex == dtGrid.Columns[0].Index && e.RowIndex >= 0)
            {
                if (fileIDs.Contains(dtGrid.Rows[e.RowIndex].Cells[0].Value.ToString()))
                {
                    fileIDs.Remove(dtGrid.Rows[e.RowIndex].Cells[0].Value.ToString());
                    Console.WriteLine("REMOVED this id " + dtGrid.Rows[e.RowIndex].Cells[0].Value.ToString());

                }
                else
                {
                    fileIDs.Add(dtGrid.Rows[e.RowIndex].Cells[0].Value.ToString());
                    Console.WriteLine("ADDED ITEM " + dtGrid.Rows[e.RowIndex].Cells[0].Value.ToString());
                }
            }

            //try
            //{
            if (e.ColumnIndex == 1)
            {
                if (MessageBox.Show("YES or No?", "Are you sure you want to delete this information? ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    DBConnect.Delete("operations", dtGrid.Rows[e.RowIndex].Cells[2].Value.ToString());

                    MessageBox.Show("Information deleted");
                    LoadData();

                }
            }
            //}
            //catch { }
            if (e.ColumnIndex == 0)
            {
                updateID = dtGrid.Rows[e.RowIndex].Cells[2].Value.ToString();

                serviceTxt.Text = _operations.First(k => k.Id.Contains(updateID)).Service;
                costTxt.Text = _operations.First(k => k.Id.Contains(updateID)).Cost;
                otherTxt.Text = _operations.First(k => k.Id.Contains(updateID)).Other;
                saveBtn.Visible = false;
                updateBtn.Visible = true;

            }

        }
        string updateID;

        private void updateBtn_Click(object sender, EventArgs e)
        {
            if (updateID == "") { return; }
            if (MessageBox.Show("YES or No?", "Are you sure you want to update this information? ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                _operation = new Operations(updateID, departmentCbx.Text, codeTxt.Text, serviceTxt.Text, costTxt.Text, otherTxt.Text, DateTime.Now.ToString("dd-MM-yyyy H:mm:ss"));

                DBConnect.Update(_operation, updateID);
                Global._operations.RemoveAll(x => x.Id == updateID);
                Global._operations.Add(_operation);
                // DBConnect.Execute(SQL);
                MessageBox.Show("Information updated");
                saveBtn.Visible = true;
                updateBtn.Visible = false;
                updateID = "";
                serviceTxt.Text = "";
                costTxt.Text = "";
                otherTxt.Text = "";
                LoadData();
            }

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            serviceTxt.Text = "";
            otherTxt.Text = "";
            costTxt.Text = "";
            saveBtn.Visible = true;
            updateBtn.Visible = false;
            updateID = "";
        }
        TextBox editBox = null;
        private void dtGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            updateID = dtGrid.Rows[e.RowIndex].Cells[2].Value.ToString();
            _operation = new Operations(updateID, dtGrid.Rows[e.RowIndex].Cells[4].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells[5].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells[6].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells[7].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells[8].Value.ToString(), DateTime.Now.ToString("dd-MM-yyyy H:mm:ss"));
            //Operations(2, 4, 5,6,7, 8, string created)
            DBConnect.Update(_operation, updateID);
            Global._operations.RemoveAll(x => x.Id == updateID);
            Global._operations.Add(_operation);

        }

        private void dtGrid_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {

        }
    }
}
