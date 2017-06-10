using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using VHMIS.Model;

namespace VHMIS
{
    public partial class ViewPatient : Form
    {
        DataTable t;
        
        List<Patient> _patientList = new List<Patient>();
        Patient _patient;
        bool loaded = false;
        DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();
        DataGridViewButtonColumn btnEdit = new DataGridViewButtonColumn();
        public ViewPatient()
        {

            InitializeComponent();
            searchCbx.Items.Add("Client");
            searchCbx.Items.Add("Name");
            searchCbx.Items.Add("Patient No");
            searchCbx.Items.Add("E-mail");
            searchCbx.Items.Add("Contact");
            searchCbx.Items.Add("Status");
            LoadData();

            btnDelete.Name = "btnDelete";
            btnDelete.Text = "Delete";
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Width = 50;
            btnDelete.CellTemplate.Style.BackColor = Color.Wheat;
            btnDelete.UseColumnTextForButtonValue = true;
            btnDelete.HeaderText = "Delete";

            btnEdit.Name = "btnEdit";
            btnEdit.Text = "View";
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Width = 50;
            btnEdit.CellTemplate.Style.BackColor = Color.Orange;
            btnEdit.UseColumnTextForButtonValue = true;
            btnEdit.HeaderText = "View";
        }
        static string base64String = null;
        public System.Drawing.Image Base64ToImage(string bases)
        {
            byte[] imageBytes = Convert.FromBase64String(bases);
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
            ms.Write(imageBytes, 0, imageBytes.Length);
            System.Drawing.Image image = System.Drawing.Image.FromStream(ms, true);
            return image;
        }
        public void LoadData()
        {
            _patientList = new List<Patient>();
            _patientList = Patient.ListPatients();

            t = new DataTable();           
            t.Columns.Add(new DataColumn("Select", typeof(bool)));
            t.Columns.Add("id");//1
            t.Columns.Add(new DataColumn("Img", typeof(Bitmap)));//
            t.Columns.Add("No");//3
            t.Columns.Add("Surname");//4
            t.Columns.Add("Last name"); //5          
            t.Columns.Add("Contact");//6
            t.Columns.Add("Email");//7
            t.Columns.Add("Date of Birth");//8
            t.Columns.Add("Nationality");//9
            t.Columns.Add("Address");//10 
            t.Columns.Add("KIN");//11
            t.Columns.Add("N.O.K contact");//12
            t.Columns.Add("Gender");//13   
            t.Columns.Add("Created");//14           
            t.Columns.Add("image");//15
            t.Columns.Add("Blood Group");//16
            t.Columns.Add("Religion");//17
            t.Columns.Add("Profile");//18
            t.Columns.Add("Delete");//19



            Bitmap b = new Bitmap(50, 50);

            using (Graphics g = Graphics.FromImage(b))
            {
                g.DrawString("Loading...", this.Font, new SolidBrush(Color.Gray), 00, 00);
            }
            foreach (Patient patient in _patientList)
            {
                              
                t.Rows.Add(new object[] { false, patient.Id,b,patient.PatientNo, patient.Surname, patient.Lastname, patient.Contact,patient.Email, patient.Dob, patient.Nationality, patient.Address, patient.Kin, patient.Kincontact, patient.Gender,patient.Created, patient.Image,patient.Blood,patient.Religion,"View","Delete" });

            }
            dtGrid.DataSource = t;
            ThreadPool.QueueUserWorkItem(delegate
            {
                foreach (DataRow row in t.Rows)
                {
                    try
                    {

                       Image img =  Base64ToImage(row["image"].ToString());                         
                        System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(img);                       
                        Bitmap bps = new Bitmap(bmp, 50, 50);

                        row["Img"] = bps;
                       
                    }
                    catch
                    {

                    }
                }
            });         
            dtGrid.AllowUserToAddRows = false;
            dtGrid.Columns[18].DefaultCellStyle.BackColor = Color.LightGreen;
            dtGrid.Columns[19].DefaultCellStyle.BackColor = Color.Aquamarine;
            dtGrid.RowTemplate.Height = 60;

         
                dtGrid.Columns[1].Visible = false;
             //   dtGrid.Columns[15].Visible = false;
           

        }
        
        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
        string filterField = "Name";
        private void DateTxt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                t.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", filterField, DateTxt.Text);
            }
            catch (Exception c)
            {
                //  Helper.Exceptions(c.ToString(), "Searching users by selection");

            }
        }
        List<string> fileIDs = new List<string>();
        string updateID;
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void dtGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
                   
            updateID = dtGrid.Rows[e.RowIndex].Cells[1].Value.ToString();
            _patient= new Patient(updateID, dtGrid.Rows[e.RowIndex].Cells[3].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells[6].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells[4].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells[5].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells[7].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells[8].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells[9].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells[10].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells[11].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells[12].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells[13].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells[15].Value.ToString(), DateTime.Now.ToString("dd-MM-yyyy H:mm:ss"), dtGrid.Rows[e.RowIndex].Cells[17].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells[16].Value.ToString(), Helper.orgID);

            DBConnect.Update(_patient, updateID);
            Global._patients.RemoveAll(x => x.Id == updateID);
            Global._patients.Add(_patient);

        }

        private void dtGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }

}
