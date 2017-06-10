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
    public partial class ClinicForm : Form
    {
        DataTable t;
        List<Clinics> _clinics = new List<Clinics>();
        Clinics _clinic;
        DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();
        DataGridViewButtonColumn btnEdit = new DataGridViewButtonColumn();
        public ClinicForm()
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
        bool loaded = false;
        public void LoadData()
        {

            _clinics = Global._clinics;
            t = new DataTable();
            // create and execute query 
            t.Columns.Add("id");//2 
            t.Columns.Add(new DataColumn("Select", typeof(bool)));
            t.Columns.Add("Name");//2
            t.Columns.Add("Max No");//
            t.Columns.Add("Min No");//
            t.Columns.Add("Created");// 

            foreach (Clinics r in Global._clinics)
            {

                t.Rows.Add(new object[] { r.Id, false, r.Name, r.Maxs, r.Mins, r.Created });

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
            _clinic = new Clinics(id, nameTxt.Text, maxTxt.Text, minTxt.Text, DateTime.Now.ToString("dd-MM-yyyy H:mm:ss"), Helper.orgID);

            if (DBConnect.Insert(_clinic) != "")
            {
                Global._clinics.Add(_clinic);
                nameTxt.Text = "";
                maxTxt.Text = "";
                minTxt.Text = "";
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
                    DBConnect.Delete("clinics", dtGrid.Rows[e.RowIndex].Cells[2].Value.ToString());

                    MessageBox.Show("Information deleted");
                    LoadData();

                }
            }
            //}
            //catch { }
            if (e.ColumnIndex == 0)
            {
                updateID = dtGrid.Rows[e.RowIndex].Cells[2].Value.ToString();

                nameTxt.Text = _clinics.First(k => k.Id.Contains(updateID)).Name;
                maxTxt.Text = _clinics.First(k => k.Id.Contains(updateID)).Maxs;
                minTxt.Text = _clinics.First(k => k.Id.Contains(updateID)).Mins;
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
                //string SQL = "UPDATE clinics SET name = '" + nameTxt.Text + "',mins='" + minTxt.Text + "',maxs= '" + maxTxt.Text + "' WHERE id= '" + updateID + "'";
                _clinic = new Clinics(updateID, nameTxt.Text, maxTxt.Text, minTxt.Text, DateTime.Now.ToString("dd-MM-yyyy H:mm:ss"), Helper.orgID);

                DBConnect.Update(_clinic, updateID);
                Global._clinics.RemoveAll(x => x.Id == updateID);
                Global._clinics.Add(_clinic);
                // DBConnect.Execute(SQL);
                MessageBox.Show("Information updated");
                saveBtn.Visible = true;
                updateBtn.Visible = false;
                updateID = "";
                nameTxt.Text = "";
                maxTxt.Text = "";
                minTxt.Text = "";
                LoadData();
            }

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            nameTxt.Text = "";
            minTxt.Text = "";
            maxTxt.Text = "";
            saveBtn.Visible = true;
            updateBtn.Visible = false;
            updateID = "";
        }
        TextBox editBox = null;
        private void dtGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            updateID = dtGrid.Rows[e.RowIndex].Cells[2].Value.ToString();
            _clinic = new Clinics(dtGrid.Rows[e.RowIndex].Cells[2].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells[4].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells[5].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells[6].Value.ToString(), DateTime.Now.ToString("dd-MM-yyyy H:mm:ss"), Helper.orgID);

            DBConnect.Update(_clinic, updateID);
            Global._clinics.RemoveAll(x => x.Id == updateID);
            Global._clinics.Add(_clinic);

        }

        private void dtGrid_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {

        }
    }
}
