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
    public partial class DisciplineForm : Form
    {
        DataTable t;
        List<Discipline> _disciplines = new List<Discipline>();
        Discipline _discipline;
        DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();
        DataGridViewButtonColumn btnEdit = new DataGridViewButtonColumn();
        public DisciplineForm()
        {
            InitializeComponent();
            LoadData();
          

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

            _disciplines = Global._disciplines;
            t = new DataTable();
            // create and execute query 
            t.Columns.Add("id");//2 
            t.Columns.Add(new DataColumn("Select", typeof(bool)));
            t.Columns.Add("Name");//2
            t.Columns.Add("Code");//
           
            t.Columns.Add("Created");// 

            foreach (Discipline r in Global._disciplines)
            {

                t.Rows.Add(new object[] { r.Id, false, r.Name, r.Code,r.Created });

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

        List<string> fileIDs = new List<string>();

        public object CollectionViewSource { get; private set; }
        public object UserFilter { get; private set; }

  
        string updateID;

      
        TextBox editBox = null;
        private void dtGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            updateID = dtGrid.Rows[e.RowIndex].Cells[2].Value.ToString();
            _discipline = new Discipline(dtGrid.Rows[e.RowIndex].Cells[2].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells[4].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells[5].Value.ToString(), DateTime.Now.ToString("dd-MM-yyyy H:mm:ss"), Helper.orgID);

            DBConnect.Update(_discipline, updateID);
            Global._disciplines.RemoveAll(x => x.Id == updateID);
            Global._disciplines.Add(_discipline);

        }

        private void dtGrid_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (DisciplineDialog form = new DisciplineDialog())
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
