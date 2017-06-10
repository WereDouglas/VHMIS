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
    public partial class RoleForm : Form
    {
        DataTable t;
        List<Roles> _roles = new List<Roles>();
        Roles _role;
        DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();
        DataGridViewButtonColumn btnEdit = new DataGridViewButtonColumn();

        public RoleForm()
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
        }
        bool loaded= false;
        public void LoadData()
        {            
            //dtGrid.Refresh();
            _roles.Clear();
            _roles = Roles.ListRoles();
            t = new DataTable();
            // create and execute query 
            t.Columns.Add("id");//2 
            t.Columns.Add(new DataColumn("Select", typeof(bool)));
            t.Columns.Add("Title");//2
            t.Columns.Add("Views");//
            t.Columns.Add("Actions");// 
            t.Columns.Add("created");// 

            foreach (Roles r in _roles)
            {
                byte[] MyData = new byte[0];

                t.Rows.Add(new object[] { r.Id, false, r.Title, r.Views, r.Actions,r.Created });

            }
            dtGrid.DataSource = t;
            dtGrid.AllowUserToAddRows = false;
            
            if (!loaded) {
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

        private void button2_Click(object sender, EventArgs e)
        {
            if (viewTxt.Text == "")
            {

                viewTxt.BackColor = Color.Red;
                return;

            }
            if (actionTxt.Text == "")
            {
                actionTxt.BackColor = Color.Red;
                return;

            }
            string id = Guid.NewGuid().ToString();
            _role = new Roles(id, titleTxt.Text, viewTxt.Text, actionTxt.Text, DateTime.Now.ToString("dd-MM-yyyy H:mm:ss"), Helper.orgID);


            if (DBConnect.Insert(_role) != "")
            {
                titleTxt.Text = "";
                actionTxt.Text = "";
                viewTxt.Text = "";
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
                    DBConnect.Delete("roles", dtGrid.Rows[e.RowIndex].Cells[2].Value.ToString());

                    MessageBox.Show("Information deleted");
                    LoadData();

                }
            }
            //}
            //catch { }
            if (e.ColumnIndex == 0)
            {
                updateID = dtGrid.Rows[e.RowIndex].Cells[2].Value.ToString();

                titleTxt.Text = _roles.First(k => k.Id.Contains(updateID)).Title;
                viewTxt.Text = _roles.First(k => k.Id.Contains(updateID)).Views;
                actionTxt.Text = _roles.First(k => k.Id.Contains(updateID)).Actions;
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
                string SQL = "UPDATE roles SET views = '" + viewTxt.Text + "',actions='" + actionTxt.Text + "',title= '" + titleTxt.Text + "' WHERE id= '" + updateID + "'";

                DBConnect.Execute(SQL);

                MessageBox.Show("Information updated");
                saveBtn.Visible = true;
                updateBtn.Visible = false;
                updateID = "";
                titleTxt.Text = "";
                actionTxt.Text = "";
                viewTxt.Text = "";
                LoadData();
            }

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            titleTxt.Text = "";
            actionTxt.Text = "";
            viewTxt.Text = "";
            saveBtn.Visible = true;
            updateBtn.Visible = false;
            updateID = "";
        }
        private void dtGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            updateID = dtGrid.Rows[e.RowIndex].Cells[2].Value.ToString();
            _role = new Roles(dtGrid.Rows[e.RowIndex].Cells[2].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells[4].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells[5].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells[6].Value.ToString(), DateTime.Now.ToString("dd-MM-yyyy H:mm:ss"), Helper.orgID);

            DBConnect.Update(_role, updateID);
            Global._roles.RemoveAll(x => x.Id == updateID);
            Global._roles.Add(_role);

        }
    }
}
