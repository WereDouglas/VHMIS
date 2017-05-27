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
    public partial class BedForm : Form
    {
        DataTable t;
        List<Beds> _beds = new List<Beds>();
        Beds _bed;
        DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();
        DataGridViewButtonColumn btnEdit = new DataGridViewButtonColumn();
        public BedForm()
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
            foreach (Wards d in Global._wards)
            {
               wardTxt.Items.Add(d.Name);
            }
        }
        bool loaded = false;
        public void LoadData()
        {

            _beds = Global._beds;
            t = new DataTable();
            // create and execute query 
            t.Columns.Add("id");//2 
            t.Columns.Add(new DataColumn("Select", typeof(bool)));
            t.Columns.Add("Ward");//2
            t.Columns.Add("Bed No.");//
            t.Columns.Add("Account");//
            t.Columns.Add("Rate (per night)");//
            t.Columns.Add("Status");//
            t.Columns.Add("Category");//          
            t.Columns.Add("Created");// 

            foreach (Beds r in Global._beds)
            {

                t.Rows.Add(new object[] { r.Id, false, r.WardID, r.No, r.Acc, r.Rate, r.Status, r.Category, r.Created });

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
            if (wardTxt.Text == "")
            {
                wardTxt.BackColor = Color.Red;
                return;
            }
            //if (Global._beds.Select(l=>l.No.Contains(bedTxt.Text) && l.WardID.Contains(wardTxt.Text)) {

            //    MessageBox.Show("Information already submitted !");
            //    return;
            //}

            string id = Guid.NewGuid().ToString();
            _bed = new Beds(id, wardTxt.Text, bedTxt.Text, accountTxt.Text, rateTxt.Text, statusTxt.Text, categoryTxt.Text, DateTime.Now.ToString("dd-MM-yyyy H:mm:ss"));

            if (DBConnect.Insert(_bed) != "")
            {
                Global._beds.Add(_bed);
                wardTxt.Text = "";
                bedTxt.Text = "";
                accountTxt.Text = "";
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
                    DBConnect.Delete("beds", dtGrid.Rows[e.RowIndex].Cells[2].Value.ToString());
                    MessageBox.Show("Information deleted");
                    LoadData();

                }
            }
            //}
            //catch { }
            if (e.ColumnIndex == 0)
            {
                updateID = dtGrid.Rows[e.RowIndex].Cells[2].Value.ToString();

                wardTxt.Text = _beds.First(k => k.Id.Contains(updateID)).WardID;
                bedTxt.Text = _beds.First(k => k.Id.Contains(updateID)).No;
                accountTxt.Text = _beds.First(k => k.Id.Contains(updateID)).Acc;
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
                _bed = new Beds(updateID, wardTxt.Text, bedTxt.Text, accountTxt.Text, rateTxt.Text, statusTxt.Text, categoryTxt.Text, DateTime.Now.ToString("dd-MM-yyyy H:mm:ss"));

                DBConnect.Update(_bed, updateID);
                Global._beds.RemoveAll(x => x.Id == updateID);
                Global._beds.Add(_bed);
                // DBConnect.Execute(SQL);
                MessageBox.Show("Information updated");
                saveBtn.Visible = true;
                updateBtn.Visible = false;
                updateID = "";
                wardTxt.Text = "";
                bedTxt.Text = "";
                accountTxt.Text = "";
                LoadData();
            }

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            wardTxt.Text = "";
            accountTxt.Text = "";
            bedTxt.Text = "";
            saveBtn.Visible = true;
            updateBtn.Visible = false;
            updateID = "";
        }
        TextBox editBox = null;
        private void dtGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            updateID = dtGrid.Rows[e.RowIndex].Cells[2].Value.ToString();
            _bed = new Beds(dtGrid.Rows[e.RowIndex].Cells[2].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells[4].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells[5].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells[6].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells[7].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells[8].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells[9].Value.ToString(), DateTime.Now.ToString("dd-MM-yyyy H:mm:ss"));

            DBConnect.Update(_bed, updateID);
            Global._beds.RemoveAll(x => x.Id == updateID);
            Global._beds.Add(_bed);
        }

        private void dtGrid_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {

        }
    }
}
