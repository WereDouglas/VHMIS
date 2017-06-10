using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using VHMIS.Model;

namespace VHMIS
{
    public partial class AdmissionForm : Form
    {
        Dictionary<string, string> userDictionary = new Dictionary<string, string>();
        Dictionary<string, string> patientDictionary = new Dictionary<string, string>();
        Dictionary<string, string> clinicDictionary = new Dictionary<string, string>();
        Dictionary<string, string> roomDictionary = new Dictionary<string, string>();
        Dictionary<string, string> wardDictionary = new Dictionary<string, string>();
        Dictionary<string, string> departmentDictionary = new Dictionary<string, string>();
        DataTable t;
        List<Patient> _patientList = new List<Patient>();
        List<Users> _userList = new List<Users>();
        string patientID;
        string userID;
        string wardID;
        string clinicID;

        List<Admission> _admissions = new List<Admission>();
        List<Admission> _todayList = new List<Admission>();
        Admission _admission;
        DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();
        DataGridViewButtonColumn btnEdit = new DataGridViewButtonColumn();
        int follow;
        bool loaded = false;
        string today;
        public AdmissionForm()
        {
            InitializeComponent();
          
            _todayList = Admission.ListAdmission(DateTime.Now.ToString("dd-MM-yyyy")).ToList();
            _patientList = Global._patients;
            _userList = Global._users;
            InitializeComponent();
            LoadData();
            autocompleteUsers();
            autocompleteWards();
            openedDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
          

            today = DateTime.Now.ToString("dd-MM-yyyy");
           // _admissions = Global._admit;
          
        }
        private void autocompleteUsers()
        {
            AutoCompleteStringCollection AutoItem = new AutoCompleteStringCollection();
            foreach (Users u in Global._users)
            {
                AutoItem.Add(u.Surname + " " + u.Lastname);
                userDictionary.Add(u.Surname + " " + u.Lastname, u.Id);
                practitionerCbx.Items.Add(u.Surname + " " + u.Lastname);
            }
            practitionerCbx.AutoCompleteMode = AutoCompleteMode.Suggest;
            practitionerCbx.AutoCompleteSource = AutoCompleteSource.CustomSource;
            practitionerCbx.AutoCompleteCustomSource = AutoItem;

        }

        private void autocompleteWards()
        {
            AutoCompleteStringCollection AutoItem = new AutoCompleteStringCollection();
            foreach (Room u in Global._rooms)
            {
                AutoItem.Add(u.Name);
                roomDictionary.Add(u.Name, u.Id);
                roomCbx.Items.Add(u.Name);
            }
            roomCbx.AutoCompleteMode = AutoCompleteMode.Suggest;
            roomCbx.AutoCompleteSource = AutoCompleteSource.CustomSource;
            roomCbx.AutoCompleteCustomSource = AutoItem;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            using (AdmissionDialog form = new AdmissionDialog())
            {
                // DentalDialog form1 = new DentalDialog(item.Text, TransactorID);
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    //MessageBox.Show(form.state);
                    _todayList = Admission.ListAdmission(Convert.ToDateTime(openedDate.Text).ToString("dd-MM-yyyy")).ToList(); ;
                    LoadData();

                }
            }
        }

        private void practitionerCbx_Leave(object sender, EventArgs e)
        {
            try
            {
                userID = userDictionary[practitionerCbx.Text];
                _todayList = Global._admit.Where(l => l.UserID.Contains(userID) && l.Dated.Contains(Convert.ToDateTime(openedDate.Text).ToString("dd-MM-yyyy"))).ToList();
                LoadData();
            }
            catch { }
        }
        public void LoadData()
        {

            t = new DataTable();
            t.Columns.Add("Number");//4
            t.Columns.Add("id");//3  
            t.Columns.Add("No");//4   
            t.Columns.Add("Patient");//4
            t.Columns.Add(new DataColumn("Img", typeof(Bitmap)));//
            t.Columns.Add("Room");//5
            t.Columns.Add("Clinic"); //6           
            t.Columns.Add("Status");//7
            t.Columns.Add("Practitioner");
            t.Columns.Add(new DataColumn("imgdoc", typeof(Bitmap)));//
            t.Columns.Add("View");//17
            t.Columns.Add("Complete");//17
            t.Columns.Add("image");//17
            t.Columns.Add("docimage");//17  
            t.Columns.Add("patientID");//17  
            t.Columns.Add("practitionerID");//17     
            t.Columns.Add("Out patient");//17 
            t.Columns.Add("Department");//17  
            t.Columns.Add("Paid for consulation");//17
            t.Columns.Add("Paid for Lab");//17 
            t.Columns.Add("Consulation Complete");//17
            t.Columns.Add("Lab Complete");//17 
            t.Columns.Add("Remarks");//17     
            t.Columns.Add("Remove");//23    


            Bitmap b = new Bitmap(50, 50);

            using (Graphics g = Graphics.FromImage(b))
            {
                g.DrawString("Loading...", this.Font, new SolidBrush(Color.Gray), 00, 00);
            }

            Bitmap b2 = new Bitmap(50, 50);

            using (Graphics g2 = Graphics.FromImage(b2))
            {
                g2.DrawString("Loading...", this.Font, new SolidBrush(Color.Gray), 00, 00);
            }
            foreach (Admission q in _todayList)
            {
               t.Rows.Add(new object[] { q.Follow, q.Id, q.No, _patientList.First(h => h.Id.Contains(q.PatientID)).Surname + " " + _patientList.First(h => h.Id.Contains(q.PatientID)).Lastname, b, q.Ward + Environment.NewLine + q.Bed + Environment.NewLine + q.Remarks, q.ClinicID, q.Status, _userList.First(h => h.Id.Contains(q.UserID)).Surname + " " + _userList.First(h => h.Id.Contains(q.UserID)).Lastname, b2, "View", "Complete", _patientList.First(h => h.Id.Contains(q.PatientID)).Image, _userList.First(h => h.Id.Contains(q.UserID)).Image, q.PatientID, q.UserID, "Out patient", q.Bed, q.Consultation_paid, q.Lab_paid, q.Consultation_complete, q.Lab_complete, q.Remarks, "Remove" });
            }
            dtGrid.DataSource = t;
            ThreadPool.QueueUserWorkItem(delegate
            {
                foreach (DataRow row in t.Rows)
                {
                    try
                    {
                        Image img = Base64ToImage(row["image"].ToString());
                        System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(img);
                        Bitmap bps = new Bitmap(bmp, 50, 50);
                        row["Img"] = bps;
                    }
                    catch
                    {

                    }
                    try
                    {
                        Image img = Base64ToImage(row["docimage"].ToString());
                        System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(img);
                        Bitmap bps = new Bitmap(bmp, 50, 50);
                        row["imgdoc"] = bps;
                    }
                    catch
                    {

                    }
                }
            });
            string content = "";
            foreach (DataGridViewRow row in dtGrid.Rows)
            {
                try
                {
                    content = row.Cells["Paid for consulation"].Value.ToString();
                }
                catch { }
                if (content != "Yes")
                {
                    row.DefaultCellStyle.ForeColor = Color.Red;
                    row.DefaultCellStyle.Font = new Font("Calibri", 16.5F, FontStyle.Bold, GraphicsUnit.Pixel);
                }
                else
                {
                    row.DefaultCellStyle.ForeColor = Color.Green;
                    row.DefaultCellStyle.Font = new Font("Calibri", 14.5F, FontStyle.Bold, GraphicsUnit.Pixel);

                }
            }
           
            dtGrid.AllowUserToAddRows = false;
            dtGrid.Columns["View"].DefaultCellStyle.BackColor = Color.LightGreen;
            dtGrid.Columns["Complete"].DefaultCellStyle.BackColor = Color.Aquamarine;
            dtGrid.Columns["Out patient"].DefaultCellStyle.BackColor = Color.PaleTurquoise;
            dtGrid.RowTemplate.Height = 60;
            dtGrid.Columns["Remove"].DefaultCellStyle.BackColor = Color.OrangeRed;

            dtGrid.Columns["id"].Visible = false;
            dtGrid.Columns["imgdoc"].Visible = false;
            dtGrid.Columns["image"].Visible = false;
            dtGrid.Columns["Department"].Visible = false;
            dtGrid.Columns["docimage"].Visible = false;
            dtGrid.Columns["patientID"].Visible = false;
            dtGrid.Columns["practitionerID"].Visible = false;
        }
        public System.Drawing.Image Base64ToImage(string bases)
        {
            byte[] imageBytes = Convert.FromBase64String(bases);
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
            ms.Write(imageBytes, 0, imageBytes.Length);
            System.Drawing.Image image = System.Drawing.Image.FromStream(ms, true);
            return image;
        }

        private void roomCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                wardID = wardDictionary[roomCbx.Text];
            }
            catch { }
        }
        string updateID;

        private void roomCbx_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {

                _todayList = Admission.ListAdmission(Convert.ToDateTime(openedDate.Text).ToString("dd-MM-yyyy")).Where(l => l.Ward.Contains(roomCbx.Text)).ToList();
                LoadData();
            }
            catch { }
        }

        private void openedDate_CloseUp(object sender, EventArgs e)
        {
            _todayList =Admission.ListAdmission(Convert.ToDateTime(openedDate.Text).ToString("dd-MM-yyyy")).ToList();
            LoadData();
        }
    }
}
