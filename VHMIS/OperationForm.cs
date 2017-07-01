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

        }
        bool loaded = false;
        public void LoadData()
        {


            t = new DataTable();

            t.Columns.Add("id");//2            
            t.Columns.Add("Department");//4
            t.Columns.Add("depID");//4
            t.Columns.Add("Code");//5            
            t.Columns.Add("Service");//7
            t.Columns.Add("Type");//7
            t.Columns.Add("Category");//7
            t.Columns.Add("Cost");//7
            t.Columns.Add("Specimen");//7
            t.Columns.Add("specimenID");//7
            t.Columns.Add("Parameter");//7
            t.Columns.Add("Upper limit");//7
            t.Columns.Add("Lower limit");//7
            t.Columns.Add("Unit");//7
            t.Columns.Add("Discipline");//7
            t.Columns.Add("disciplineID");//7
            t.Columns.Add("Gender");//7
            t.Columns.Add("Phrase");//7
            t.Columns.Add("Max age");//7
            t.Columns.Add("Min age");//7
            t.Columns.Add("Created");// 9
            t.Columns.Add("Delete");//7
            

            foreach (Operations r in Global._operations)
            {
                t.Rows.Add(new object[] { r.Id, Global._departments.First(y => y.Id.Contains(r.DepID)).Name, r.DepID, r.Code, r.Name, r.Type, r.Category, r.Cost, Global._specimens.First(y => y.Id.Contains(r.SpecimenID)).Name, r.SpecimenID, r.Parameter, r.Upper, r.Lower, r.Unit, Global._disciplines.First(y => y.Id.Contains(r.DisciplineID)).Name, r.DisciplineID, r.Gender, r.Phrase, r.Max, r.Min, r.Created, "Delete" });

            }
            dtGrid.DataSource = t;
            dtGrid.AllowUserToAddRows = false;

            loaded = true;

        }


        private void button1_Click(object sender, EventArgs e)
        {
            Close();
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


        }
        string updateID;

        TextBox editBox = null;
        private void dtGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            updateID = dtGrid.Rows[e.RowIndex].Cells["id"].Value.ToString();
            Operations _operation = new Operations(updateID, dtGrid.Rows[e.RowIndex].Cells["depID"].Value.ToString(),dtGrid.Rows[e.RowIndex].Cells["code"].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells["service"].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells["type"].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells["category"].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells["cost"].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells["specimenID"].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells["parameter"].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells["upper"].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells["lower"].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells["unit"].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells["disciplineID"].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells["gender"].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells["phrase"].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells["max"].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells["min"].Value.ToString(), DateTime.Now.ToString("dd-MM-yyyy H:mm:ss"), Helper.orgID);
            //Operations(2, 4, 5,6,7, 8, string created)
            DBConnect.Update(_operation, updateID);
            Global._operations.RemoveAll(x => x.Id == updateID);
            Global._operations.Add(_operation);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (OperationDialog form = new OperationDialog())
            {
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    LoadData();
                }
            }

        }
    }
}
