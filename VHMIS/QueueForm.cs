using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using VHMIS.Model;

namespace VHMIS
{
    public partial class QueueForm : Form
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

        List<Queue> _queues = new List<Queue>();
        List<Queue> _todayList = new List<Queue>();
        Queue _queue;
        DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();
        DataGridViewButtonColumn btnEdit = new DataGridViewButtonColumn();

        bool loaded = false;
        string today;

        public QueueForm()
        {
            _patientList = Global._patients;
            _userList = Global._users;
            InitializeComponent();
            autocompleteUsers();
            autocompletePatient();
            autocompleteClinics();
            autocompleteWards();
            openedDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            btnDelete.Name = "btnDelete";
            btnDelete.Text = "Complete";
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Width = 60;
            btnDelete.CellTemplate.Style.BackColor = Color.Green;
            btnDelete.UseColumnTextForButtonValue = true;
            btnDelete.HeaderText = "Complete";

            btnEdit.Name = "btnEdit";
            btnEdit.Text = "Visit";
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Width = 60;
            btnEdit.CellTemplate.Style.BackColor = Color.Orange;
            btnEdit.UseColumnTextForButtonValue = true;
            btnEdit.HeaderText = "Edit";
            today = DateTime.Now.ToString("yyyy-MM-dd");
            _queues = Global._queues;
            _todayList = Global._queues;//.Where(r => r.Dated.Contains(today)).ToList();
            LoadData();
            foreach (Clinics d in Global._clinics)
            {
                clinicCbx.Items.Add(d.Name);
            }
            foreach (Wards d in Global._wards)
            {
                roomCbx.Items.Add(d.Name);
            }
            foreach (Departments d in Global._departments)
            {
                departmentCbx.Items.Add(d.Name);
            }


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
            practitionerTxt.AutoCompleteMode = AutoCompleteMode.Suggest;
            practitionerTxt.AutoCompleteSource = AutoCompleteSource.CustomSource;
            practitionerTxt.AutoCompleteCustomSource = AutoItem;

        }
        private void autocompleteClinics()
        {
            AutoCompleteStringCollection AutoItem = new AutoCompleteStringCollection();
            foreach (Clinics u in Global._clinics)
            {
                AutoItem.Add(u.Name);
                clinicDictionary.Add(u.Name, u.Id);
            }
            clinicCbx.AutoCompleteMode = AutoCompleteMode.Suggest;
            clinicCbx.AutoCompleteSource = AutoCompleteSource.CustomSource;
            clinicCbx.AutoCompleteCustomSource = AutoItem;

        }
        private void autocompleteWards()
        {
            AutoCompleteStringCollection AutoItem = new AutoCompleteStringCollection();
            foreach (Wards u in Global._wards)
            {
                AutoItem.Add(u.Name);
                wardDictionary.Add(u.Name, u.Id);
            }
            roomCbx.AutoCompleteMode = AutoCompleteMode.Suggest;
            roomCbx.AutoCompleteSource = AutoCompleteSource.CustomSource;
            roomCbx.AutoCompleteCustomSource = AutoItem;

        }
        private void autocompletePatient()
        {
            AutoCompleteStringCollection AutoItem = new AutoCompleteStringCollection();
            foreach (Patient p in Global._patients)
            {
                AutoItem.Add(p.Surname + " " + p.Lastname);
                patientDictionary.Add(p.Surname + " " + p.Lastname, p.Id);
            }

            patientTxt.AutoCompleteMode = AutoCompleteMode.Suggest;
            patientTxt.AutoCompleteSource = AutoCompleteSource.CustomSource;
            patientTxt.AutoCompleteCustomSource = AutoItem;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void practitionerTxt_Leave(object sender, EventArgs e)
        {
            try
            {
                userID = userDictionary[practitionerTxt.Text];
                _todayList = Global._queues.Where(l => l.UserID.Contains(userID)).ToList();
                LoadData();
            }
            catch { }
           
        }

        private void patientTxt_Leave(object sender, EventArgs e)
        {

            try
            {
                patientID = patientDictionary[patientTxt.Text];
            }
            catch { }
        }
        int follow;

        private void button5_Click(object sender, EventArgs e)
        {
            int next;
            if (_todayList.Count() < 1)
            {
                next = 1;
            }
            else
            {
                follow = _todayList.Max(t => Convert.ToInt32(t.Follow));
                next = follow + 1;
            }

            if (patientID == "" || userID == "")
            {
                MessageBox.Show("Please input the input the patient OR the practitioner  ");
                return;
            }
            string id = Guid.NewGuid().ToString();

            _queue = new Queue(id, next.ToString(), patientID, userID, roomCbx.Text, clinicCbx.Text, priorityCbx.Text, Convert.ToDateTime(this.openedDate.Text).ToString("yyyy-MM-dd"), DateTime.Now.ToString("dd-MM-yyyy H:mm:ss"),departmentCbx.Text);

            if (DBConnect.Insert(_queue) != "")
            {
                Global._queues.Add(_queue);
                patientTxt.Text = "";
                practitionerTxt.Text = "";
                MessageBox.Show("Information Saved");
                LoadData();

            }
            else
            {
                return;

            }

        }
        public void LoadData()
        {

            t = new DataTable();                
            t.Columns.Add("Number");//4
            t.Columns.Add("id");//3     
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
            t.Columns.Add("Deparment");//17      

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
            foreach (Queue q in _todayList)
            {
                t.Rows.Add(new object[] { q.Follow, q.Id, _patientList.First(h => h.Id.Contains(q.PatientID)).Surname + " " + _patientList.First(h => h.Id.Contains(q.PatientID)).Lastname, b, q.RoomID + " \r\n " + q.Department, q.ClinicID, q.Status, _userList.First(h => h.Id.Contains(q.UserID)).Surname + " " + _userList.First(h => h.Id.Contains(q.UserID)).Lastname, b2, "View", "Complete", _patientList.First(h => h.Id.Contains(q.PatientID)).Image, _userList.First(h => h.Id.Contains(q.UserID)).Image, q.PatientID, q.UserID,"Out patient",q.Department });
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
            dtGrid.AllowUserToAddRows = false;
            dtGrid.Columns[9].DefaultCellStyle.BackColor = Color.LightGreen;
            dtGrid.Columns[10].DefaultCellStyle.BackColor = Color.Aquamarine;
            dtGrid.Columns[15].DefaultCellStyle.BackColor = Color.PaleTurquoise;
            dtGrid.RowTemplate.Height = 60;



            dtGrid.Columns[1].Visible = false;

            dtGrid.Columns[11].Visible = false;
            dtGrid.Columns[12].Visible = false;
            dtGrid.Columns[13].Visible = false;
            dtGrid.Columns[14].Visible = false;
            dtGrid.Columns[16].Visible = false;

        }


        public System.Drawing.Image Base64ToImage(string bases)
        {
            byte[] imageBytes = Convert.FromBase64String(bases);
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
            ms.Write(imageBytes, 0, imageBytes.Length);
            System.Drawing.Image image = System.Drawing.Image.FromStream(ms, true);
            return image;
        }

        private void clinicCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                clinicID = clinicDictionary[clinicCbx.Text];
            }
            catch { }
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

        private void dtGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            updateID = dtGrid.Rows[e.RowIndex].Cells[1].Value.ToString();

            if (e.ColumnIndex == 10)
            {
                if (MessageBox.Show("YES or No?", "Is visit complete? ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    //Global._queues.RemoveAll(x => x.Id == updateID);
                    //DBConnect.Delete("queue", dtGrid.Rows[e.RowIndex].Cells[3].Value.ToString());
                    _queue = new Queue(updateID, _queues.First(x => x.Id.Contains(updateID)).Follow, _queues.First(x => x.Id.Contains(updateID)).PatientID, _queues.First(x => x.Id.Contains(updateID)).UserID, _queues.First(x => x.Id.Contains(updateID)).RoomID, _queues.First(x => x.Id.Contains(updateID)).ClinicID, "Complete", _queues.First(x => x.Id.Contains(updateID)).Dated, DateTime.Now.ToString("dd-MM-yyyy H:mm:ss"), _queues.First(x => x.Id.Contains(updateID)).Department);

                    DBConnect.Update(_queue, updateID);
                    Global._queues.RemoveAll(x => x.Id == updateID);
                    Global._queues.Add(_queue);
                    MessageBox.Show("Information updated");
                    LoadData();

                }
            }

            if (e.ColumnIndex == 9)
            {
                string visitID = dtGrid.Rows[e.RowIndex].Cells[1].Value.ToString();
                string patientID = dtGrid.Rows[e.RowIndex].Cells[13].Value.ToString();
                string practitionerID = dtGrid.Rows[e.RowIndex].Cells[14].Value.ToString();
                string department = dtGrid.Rows[e.RowIndex].Cells[16].Value.ToString();


                if(department.Contains("ent")){

                   DentalForm frm = new DentalForm(visitID, patientID, practitionerID);
                    frm.MdiParent = MainForm.ActiveForm;
                    frm.Dock = DockStyle.Fill;
                    frm.Show();

                }
                else {

                    PatientVisit frm = new PatientVisit(visitID, patientID, practitionerID);
                    frm.MdiParent = MainForm.ActiveForm;
                    frm.Dock = DockStyle.Fill;
                    frm.Show();


                }
            }
            if (e.ColumnIndex == 15)
            {
                string visitID = dtGrid.Rows[e.RowIndex].Cells[1].Value.ToString();
                string patientID = dtGrid.Rows[e.RowIndex].Cells[13].Value.ToString();
                string practitionerID = dtGrid.Rows[e.RowIndex].Cells[14].Value.ToString();


                OutPatient frm = new OutPatient(visitID,patientID,practitionerID);
                frm.MdiParent = MainForm.ActiveForm;
                frm.Dock = DockStyle.Fill;
                frm.Show();

            }
        }
    }
}
