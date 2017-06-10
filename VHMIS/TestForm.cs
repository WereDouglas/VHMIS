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
    public partial class TestForm : Form
    {
        DataTable t;
        List<Tests> _tests = new List<Tests>();
        Tests _test;
        DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();
        DataGridViewButtonColumn btnEdit = new DataGridViewButtonColumn();
        Dictionary<string, string> departmentDictionary = new Dictionary<string, string>();
        string departmentID;
        public TestForm()
        {
            InitializeComponent();
           
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
            foreach (Category r in Global._categories)
            {
                typeCbx.Items.Add(r.Title);
            }
            foreach (Discipline d in Global._disciplines)
            {
                desciplineCbx.Items.Add(d.Name);
            }
            foreach (Specimens d in Global._specimens)
            {
                specimenCbx.Items.Add(d.Name);
            }
            foreach (Departments d in Global._departments)
            {
                departmentCbx.Items.Add(d.Name);
                departmentDictionary.Add(d.Name,d.Id);
            }
            LoadData();
        }
        bool loaded = false;
        public void LoadData()
        {

            _tests = Global._tests;
            t = new DataTable();
            // create and execute query 
            
            t.Columns.Add(new DataColumn("Select", typeof(bool)));
            t.Columns.Add("id");//1
            t.Columns.Add("Specimen");//2
            t.Columns.Add("Type");//3
            t.Columns.Add("Parameter");//4
            t.Columns.Add("Upper limit");//5
            t.Columns.Add("Lower limit");//6
            t.Columns.Add("Unit of measurement");//7
            t.Columns.Add("Discipline");//8
            t.Columns.Add("Code");//9
            t.Columns.Add("Gender");//10
            t.Columns.Add("Phrase");//11
            t.Columns.Add("Description");//12
            t.Columns.Add("Comment");//13
            t.Columns.Add("Created");//14
            t.Columns.Add("cost");// 15
            t.Columns.Add("departmentID");// 16
            t.Columns.Add("Department");// 17
            t.Columns.Add("Delete");// 18

            foreach (Tests r in Global._tests)
            {
                var value = departmentDictionary.FirstOrDefault(x => x.Value.Contains(r.DepartmentID)).Key;
                t.Rows.Add(new object[] { false, r.Id, r.SpecimenID, r.Type, r.Parameter, r.Upper, r.Lower, r.Unit, r.Disciplineid, r.Code,r.Gender,r.Phrase,r.Description,r.Comment, r.Created,r.Cost,r.DepartmentID, value.ToString(),"Delete" });

            }
            dtGrid.DataSource = t;
            dtGrid.AllowUserToAddRows = false;
            dtGrid.Columns[18].DefaultCellStyle.BackColor = Color.OrangeRed;

            dtGrid.Columns[1].Visible = false;
            dtGrid.Columns[16].Visible = false;
           
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
            _test = new Tests(id,specimenCbx.Text, typeCbx.Text,nameTxt.Text, upperTxt.Text,lowerTxt.Text,unitTxt.Text, desciplineCbx.Text,codeTxt.Text,genderCbx.Text, phraseTxt.Text,descriptionTxt.Text,commentTxt.Text,DateTime.Now.ToString("dd-MM-yyyy H:mm:ss"),costTxt.Text,departmentID, Helper.orgID);

            if (DBConnect.Insert(_test) != "")
            {
                Global._tests.Add(_test);
                nameTxt.Text = "";
                upperTxt.Text = "";
                phraseTxt.Text = "";
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
                if (fileIDs.Contains(dtGrid.Rows[e.RowIndex].Cells[1].Value.ToString()))
                {
                    fileIDs.Remove(dtGrid.Rows[e.RowIndex].Cells[0].Value.ToString());
                    Console.WriteLine("REMOVED this id " + dtGrid.Rows[e.RowIndex].Cells[0].Value.ToString());

                }
                else
                {
                    fileIDs.Add(dtGrid.Rows[e.RowIndex].Cells[1].Value.ToString());
                    Console.WriteLine("ADDED ITEM " + dtGrid.Rows[e.RowIndex].Cells[0].Value.ToString());
                }
            }

            //try
            //{
            if (e.ColumnIndex == 18)
            {
                if (MessageBox.Show("YES or No?", "Are you sure you want to delete this information? ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    DBConnect.Delete("tests", dtGrid.Rows[e.RowIndex].Cells[1].Value.ToString());

                    MessageBox.Show("Information deleted");
                    LoadData();

                }
            }
         

        }
        string updateID;

        private void updateBtn_Click(object sender, EventArgs e)
        {
            if (updateID == "") { return; }
            if (MessageBox.Show("YES or No?", "Are you sure you want to update this information? ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                //string SQL = "UPDATE tests SET name = '" + nameTxt.Text + "',mins='" + minTxt.Text + "',maxs= '" + maxTxt.Text + "' WHERE id= '" + updateID + "'";
                _test = new Tests(updateID, specimenCbx.Text, typeCbx.Text, nameTxt.Text, upperTxt.Text, lowerTxt.Text, unitTxt.Text, desciplineCbx.Text, codeTxt.Text, genderCbx.Text, phraseTxt.Text, descriptionTxt.Text, commentTxt.Text, DateTime.Now.ToString("dd-MM-yyyy H:mm:ss"),costTxt.Text,departmentID, Helper.orgID);

                DBConnect.Update(_test, updateID);
                Global._tests.RemoveAll(x => x.Id == updateID);
                Global._tests.Add(_test);
                // DBConnect.Execute(SQL);
                MessageBox.Show("Information updated");
                saveBtn.Visible = true;
                updateBtn.Visible = false;
                updateID = "";
                nameTxt.Text = "";
                upperTxt.Text = "";
                phraseTxt.Text = "";
                LoadData();
            }

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            nameTxt.Text = "";
            phraseTxt.Text = "";
            upperTxt.Text = "";
            saveBtn.Visible = true;
            updateBtn.Visible = false;
            updateID = "";
        }
        TextBox editBox = null;
        private void dtGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            updateID = dtGrid.Rows[e.RowIndex].Cells[1].Value.ToString();
            _test = new Tests(updateID, dtGrid.Rows[e.RowIndex].Cells[2].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells[3].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells[4].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells[5].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells[6].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells[7].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells[8].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells[9].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells[10].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells[11].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells[12].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells[13].Value.ToString(), DateTime.Now.ToString("dd-MM-yyyy H:mm:ss"), dtGrid.Rows[e.RowIndex].Cells[15].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells[16].Value.ToString(), Helper.orgID);
            //Tests(2, 4, 5,6,7, 8, string created)
            DBConnect.Update(_test, updateID);
            Global._tests.RemoveAll(x => x.Id == updateID);
            Global._tests.Add(_test);

        }

        private void dtGrid_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void departmentCbx_Leave(object sender, EventArgs e)
        {
            try
            {
                departmentID = departmentDictionary[desciplineCbx.Text];
            }
            catch {

            }
        }
    }
}

