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
    public partial class WardForm : Form
    {
        DataTable t;
        List<Wards> _wards = new List<Wards>();
        Wards _ward;
        DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();
        DataGridViewButtonColumn btnEdit = new DataGridViewButtonColumn();
        public WardForm()
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

            _wards = Global._wards;
            t = new DataTable();
            // create and execute query 
            t.Columns.Add("id");//2 
            t.Columns.Add(new DataColumn("Select", typeof(bool)));
            t.Columns.Add("Name");//2
            t.Columns.Add("Code");//
            t.Columns.Add("Capacity");//
            t.Columns.Add("Cost");//
            t.Columns.Add("Deposit");//
            t.Columns.Add("Wing");//
            t.Columns.Add("Period");//
            t.Columns.Add("Created");// 

            foreach (Wards r in Global._wards)
            {

                t.Rows.Add(new object[] { r.Id, false, r.Name, r.Code, r.Capacity,r.Cost,r.Deposit,r.Wing,r.Period, r.Created });

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
            _ward = new Wards(id, nameTxt.Text, codeTxt.Text, capacityTxt.Text,costTxt.Text,depositTxt.Text,wingTxt.Text,periodTxt.Text, DateTime.Now.ToString("dd-MM-yyyy H:mm:ss"), Helper.orgID);

            if (DBConnect.Insert(_ward) != "")
            {
                Global._wards.Add(_ward);
                nameTxt.Text = "";
                codeTxt.Text = "";
                capacityTxt.Text = "";
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
                    DBConnect.Delete("wards", dtGrid.Rows[e.RowIndex].Cells[2].Value.ToString());
                    MessageBox.Show("Information deleted");
                    LoadData();

                }
            }
            //}
            //catch { }
            if (e.ColumnIndex == 0)
            {
                updateID = dtGrid.Rows[e.RowIndex].Cells[2].Value.ToString();

                nameTxt.Text = _wards.First(k => k.Id.Contains(updateID)).Name;
                codeTxt.Text = _wards.First(k => k.Id.Contains(updateID)).Code;
                capacityTxt.Text = _wards.First(k => k.Id.Contains(updateID)).Capacity;
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
                   _ward = new Wards(updateID,nameTxt.Text, codeTxt.Text, capacityTxt.Text, costTxt.Text, depositTxt.Text, wingTxt.Text, periodTxt.Text, DateTime.Now.ToString("dd-MM-yyyy H:mm:ss"), Helper.orgID);

                DBConnect.Update(_ward, updateID);
                Global._wards.RemoveAll(x => x.Id == updateID);
                Global._wards.Add(_ward);
                // DBConnect.Execute(SQL);
                MessageBox.Show("Information updated");
                saveBtn.Visible = true;
                updateBtn.Visible = false;
                updateID = "";
                nameTxt.Text = "";
                codeTxt.Text = "";
                capacityTxt.Text = "";
                LoadData();
            }

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            nameTxt.Text = "";
            capacityTxt.Text = "";
            codeTxt.Text = "";
            saveBtn.Visible = true;
            updateBtn.Visible = false;
            updateID = "";
        }
        TextBox editBox = null;
        private void dtGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            updateID = dtGrid.Rows[e.RowIndex].Cells[2].Value.ToString();
            _ward = new Wards(dtGrid.Rows[e.RowIndex].Cells[2].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells[4].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells[5].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells[6].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells[7].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells[8].Value.ToString(),dtGrid.Rows[e.RowIndex].Cells[9].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells[10].Value.ToString(), DateTime.Now.ToString("dd-MM-yyyy H:mm:ss"), Helper.orgID);

            DBConnect.Update(_ward, updateID);
            Global._wards.RemoveAll(x => x.Id == updateID);
            Global._wards.Add(_ward);
        }

        private void dtGrid_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {

        }
    }
}
