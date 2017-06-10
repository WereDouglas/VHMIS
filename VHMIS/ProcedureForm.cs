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
    public partial class ProcedureForm : Form
    {
        DataTable t;
        List<Procedures> _procedures = new List<Procedures>();
        Procedures _procedure;
        DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();
        DataGridViewButtonColumn btnEdit = new DataGridViewButtonColumn();
        public ProcedureForm()
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
            foreach (Roles r in Global._roles)
            {
                rolesCbx.Items.Add(r.Title);
            }
            foreach (Departments d in Global._departments)
            {
                departmentCbx.Items.Add(d.Name);
            }
            foreach (Category d in Global._categories)
            {
                categoryTxt.Items.Add(d.Title);
            }
        }
        bool loaded = false;
        public void LoadData()
        {

            _procedures = Global._procedures;
            t = new DataTable();
            // create and execute query 
            t.Columns.Add("id");//2 
            t.Columns.Add(new DataColumn("Select", typeof(bool)));
            t.Columns.Add("Name");//4
            t.Columns.Add("Category.");//5
            t.Columns.Add("Role");//6
            t.Columns.Add("Department");//7
            t.Columns.Add("Duration");//7
            t.Columns.Add("Code");//9
            t.Columns.Add("Gender");//7
            t.Columns.Add("Description");//7
            t.Columns.Add("Created");// 9

            foreach (Procedures r in Global._procedures)
            {
                t.Rows.Add(new object[] { r.Id, false, r.Name, r.Category, r.RoleID, r.DepartmentID, r.Duration,r.Code,r.Gender,r.Description, r.Created });

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
            if (nameTxt.Text == "")
            {
                nameTxt.BackColor = Color.Red;
                return;
            }

            string id = Guid.NewGuid().ToString();
            _procedure = new Procedures(id, nameTxt.Text, categoryTxt.Text, rolesCbx.Text,costTxt.Text,departmentCbx.Text,durationTxt.Text,codeTxt.Text,genderCbx.Text,descriptionTxt.Text, DateTime.Now.ToString("dd-MM-yyyy H:mm:ss"), Helper.orgID);

            if (DBConnect.Insert(_procedure) != "")
            {
                Global._procedures.Add(_procedure);
                nameTxt.Text = "";
                costTxt.Text = "";
                durationTxt.Text = "";
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
                    DBConnect.Delete("procedures", dtGrid.Rows[e.RowIndex].Cells[2].Value.ToString());

                    MessageBox.Show("Information deleted");
                    LoadData();

                }
            }
            //}
            //catch { }
            if (e.ColumnIndex == 0)
            {
                updateID = dtGrid.Rows[e.RowIndex].Cells[2].Value.ToString();

                nameTxt.Text = _procedures.First(k => k.Id.Contains(updateID)).Name;
                costTxt.Text = _procedures.First(k => k.Id.Contains(updateID)).Cost;
                durationTxt.Text = _procedures.First(k => k.Id.Contains(updateID)).Duration;
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
                //string SQL = "UPDATE procedures SET name = '" + nameTxt.Text + "',mins='" + minTxt.Text + "',maxs= '" + maxTxt.Text + "' WHERE id= '" + updateID + "'";
                _procedure = new Procedures(updateID, nameTxt.Text, categoryTxt.Text, rolesCbx.Text, costTxt.Text, departmentCbx.Text, durationTxt.Text, codeTxt.Text, genderCbx.Text, descriptionTxt.Text, DateTime.Now.ToString("dd-MM-yyyy H:mm:ss"), Helper.orgID);

                DBConnect.Update(_procedure, updateID);
                Global._procedures.RemoveAll(x => x.Id == updateID);
                Global._procedures.Add(_procedure);
                // DBConnect.Execute(SQL);
                MessageBox.Show("Information updated");
                saveBtn.Visible = true;
                updateBtn.Visible = false;
                updateID = "";
                nameTxt.Text = "";
                costTxt.Text = "";
                durationTxt.Text = "";
                LoadData();
            }

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            nameTxt.Text = "";
            durationTxt.Text = "";
            costTxt.Text = "";
            saveBtn.Visible = true;
            updateBtn.Visible = false;
            updateID = "";
        }
        TextBox editBox = null;
        private void dtGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            updateID = dtGrid.Rows[e.RowIndex].Cells[2].Value.ToString();
            _procedure = new Procedures(updateID, dtGrid.Rows[e.RowIndex].Cells[4].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells[5].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells[6].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells[7].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells[8].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells[9].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells[10].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells[11].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells[12].Value.ToString(), DateTime.Now.ToString("dd-MM-yyyy H:mm:ss"), Helper.orgID);
            //Procedures(2, 4, 5,6,7, 8, string created)
            DBConnect.Update(_procedure, updateID);
            Global._procedures.RemoveAll(x => x.Id == updateID);
            Global._procedures.Add(_procedure);

        }

        private void dtGrid_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {

        }
    }
}
