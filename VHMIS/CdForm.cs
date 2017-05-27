using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VHMIS.Model;

namespace VHMIS
{
    public partial class CdForm : Form
    {
        private BackgroundWorker bw_message = new BackgroundWorker();
        DataTable t;
        List<Cd10> _cds = new List<Cd10>();
        Cd10 _cd10;
        public CdForm()
        {
            InitializeComponent();
            bw_message.DoWork += backgroundWorker1_DoWork;
            bw_message.WorkerReportsProgress = true;
            LoadData();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (!bw_message.IsBusy)
            {
                bw_message.RunWorkerAsync();
            }
        }
        string line;
        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {

                string path = Environment.CurrentDirectory + "\\icd10.txt";
                const Int32 BufferSize = 1024;
                using (var fileStream = File.OpenRead(path))
                using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
                {
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        //  FeedBack(line);
                        Console.WriteLine(line);
                        string[] sections = line.Split(' ');
                        string descriptions="";
                        for (int i = 1; i < sections.Count(); i++) {

                            descriptions = descriptions +" "+ sections[i];
                        }
                        string id = Guid.NewGuid().ToString();
                        _cd10 = new Cd10(id, sections[0],Helper.CleanString(descriptions)," "," ", DateTime.Now.ToString("dd-MM-yyyy H:mm:ss"));
                        if (Global._cds.Where(h => h.Code.Contains(sections[0])).Count() < 1)
                        {
                            DBConnect.Insert(_cd10);
                        }
                        else {

                            Console.WriteLine("Already saved "+ line);
                        }
                    }
                        
                        
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void LoadData()
        {

          
            t = new DataTable();
            // create and execute query 
          
            t.Columns.Add(new DataColumn("Select", typeof(bool)));
            t.Columns.Add("id");//2 
            t.Columns.Add("Code");//2
            t.Columns.Add("Description");//
            t.Columns.Add("Other");//
            t.Columns.Add("Department");//                   
            t.Columns.Add("Created");// 
            t.Columns.Add("Action");//7

            foreach (Cd10 r in Global._cds)
            {

                t.Rows.Add(new object[] { false, r.Id, r.Code, r.Description, r.Other, r.Description,r.Created,"Remove" });

            }
            dtGrid.DataSource = t;
            dtGrid.AllowUserToAddRows = false;            
            dtGrid.Columns[1].Visible = false;
            dtGrid.Columns[7].DefaultCellStyle.BackColor = Color.OrangeRed;
            // btnDelete.DisplayIndex = 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
        List<string> fileIDs = new List<string>();
        private void dtGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (e.ColumnIndex == dtGrid.Columns[0].Index && e.RowIndex >= 0)
            {
                if (fileIDs.Contains(dtGrid.Rows[e.RowIndex].Cells[1].Value.ToString()))
                {
                    fileIDs.Remove(dtGrid.Rows[e.RowIndex].Cells[1].Value.ToString());
                    Console.WriteLine("REMOVED this id " + dtGrid.Rows[e.RowIndex].Cells[0].Value.ToString());

                }
                else
                {
                    fileIDs.Add(dtGrid.Rows[e.RowIndex].Cells[1].Value.ToString());
                    Console.WriteLine("ADDED ITEM " + dtGrid.Rows[e.RowIndex].Cells[1].Value.ToString());
                }
            }

           
            if (e.ColumnIndex == 7)
            {
                if (MessageBox.Show("YES or No?", "Are you sure you want to delete this information? ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    DBConnect.Delete("cd10", dtGrid.Rows[e.RowIndex].Cells[1].Value.ToString());
                    MessageBox.Show("Information deleted");
                    LoadData();

                }
            } 
        }
        string updateID;
        private void dtGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            updateID = dtGrid.Rows[e.RowIndex].Cells[1].Value.ToString();
            _cd10 = new Cd10(dtGrid.Rows[e.RowIndex].Cells[1].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells[2].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells[3].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells[4].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells[5].Value.ToString(), DateTime.Now.ToString("dd-MM-yyyy H:mm:ss"));

            DBConnect.Update(_cd10, updateID);
            Global._cds.RemoveAll(x => x.Id == updateID);
            Global._cds.Add(_cd10);
        }
    }
}
