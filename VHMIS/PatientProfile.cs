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
    public partial class PatientProfile : Form
    {
        string PatientID;
        string PractitionerID;
        string queueID;
        private Vitals _vital;
        private List<Vitals> _vitals;
        DataTable t;
        List<Patient> _patientList = new List<Patient>();
        List<Users> _userList = new List<Users>();
        private Lab _lab;
        private List<Lab> _labs;
        private Results _result;
        private List<Results> _results;

        private Chronic _chronic;
        private List<Chronic> _chronics;

        private Allergy _allergy;
        private List<Allergy> _allergies;
        List<Queue> _queues = new List<Queue>();
        List<Queue> _todayList = new List<Queue>();
        Queue _queue;
        private Addiction _addiction;
        private List<Addiction> _addictions;
        DataTable tr;
        DataTable tb;
        DataTable ts;
        Dictionary<string, string> testCost;
        DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();
        DataGridViewButtonColumn btnLab = new DataGridViewButtonColumn();
        DataGridViewButtonColumn btnLab2 = new DataGridViewButtonColumn();
        DataGridViewButtonColumn btnR = new DataGridViewButtonColumn();
        DataGridViewButtonColumn btnEdit = new DataGridViewButtonColumn();
        bool loaded = false;
        string today;
        public PatientProfile(string patientID)
        {
            _patientList = Global._patients;
            _userList = Global._users;
            PatientID = patientID;
            InitializeComponent();
            if (patientID != "")
            {

                surnameTxt.Text = Global._patients.First(k => k.Id.Contains(patientID)).Surname;
                lastnameTxt.Text = Global._patients.First(k => k.Id.Contains(patientID)).Lastname;

                Image img = Base64ToImage(Global._patients.First(k => k.Id.Contains(patientID)).Image);
                System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(img);
                //Bitmap bps = new Bitmap(bmp, 50, 50);
                imgCapture.Image = bmp;
                imgCapture.SizeMode = PictureBoxSizeMode.StretchImage;


            }
            LoadAddiction(PatientID);
            LoadAllergy(PatientID);
            LoadChronic(PatientID);

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
            _todayList = Global._queues.Where(j=>j.PatientID==patientID).ToList();//.Where(r => r.Dated.Contains(today)).ToList();
            LoadData();
        }
        public void LoadData()
        {

            t = new DataTable();

            t.Columns.Add(new DataColumn("Select", typeof(bool)));
            t.Columns.Add("id");//3            
            t.Columns.Add("Number");//4
            t.Columns.Add("Patient");//4
            t.Columns.Add(new DataColumn("Img", typeof(Bitmap)));//
            t.Columns.Add("Room");//5
            t.Columns.Add("Clinic"); //6           
            t.Columns.Add("Status");//7
            t.Columns.Add("Practitioner");
            t.Columns.Add(new DataColumn("imgdoc", typeof(Bitmap)));//
            t.Columns.Add("image");//17
            t.Columns.Add("docimage");//17  
            t.Columns.Add("patientID");//17  
            t.Columns.Add("practitionerID");//17           

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
                t.Rows.Add(new object[] { false, q.Id, q.Follow, _patientList.First(h => h.Id.Contains(q.PatientID)).Surname + " " + _patientList.First(h => h.Id.Contains(q.PatientID)).Lastname, b, q.RoomID, q.ClinicID, q.Status, _userList.First(h => h.Id.Contains(q.UserID)).Surname + " " + _userList.First(h => h.Id.Contains(q.UserID)).Lastname, b2, _patientList.First(h => h.Id.Contains(q.PatientID)).Image, _userList.First(h => h.Id.Contains(q.UserID)).Image, q.PatientID, q.UserID });
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
            dtGrid.Columns[1].DefaultCellStyle.BackColor = Color.LightGreen;
            dtGrid.Columns[2].DefaultCellStyle.BackColor = Color.Aquamarine;
            dtGrid.RowTemplate.Height = 60;

            if (!loaded)
            {
                dtGrid.Columns.Add(btnEdit);
                dtGrid.Columns.Add(btnDelete);
                dtGrid.Columns[1].Visible = false;
                dtGrid.Columns[10].Visible = false;
                dtGrid.Columns[11].Visible = false;
                dtGrid.Columns[12].Visible = false;
                dtGrid.Columns[13].Visible = false;
            }

            loaded = true;

        }
        string updateID;
        private void dtGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            updateID = dtGrid.Rows[e.RowIndex].Cells[3].Value.ToString();

            if (e.ColumnIndex == 1)
            {
                if (MessageBox.Show("YES or No?", "Is visit complete? ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    //Global._queues.RemoveAll(x => x.Id == updateID);
                    //DBConnect.Delete("queue", dtGrid.Rows[e.RowIndex].Cells[3].Value.ToString());
                    _queue = new Queue(updateID, _queues.First(x => x.Id.Contains(updateID)).Follow, _queues.First(x => x.Id.Contains(updateID)).PatientID, _queues.First(x => x.Id.Contains(updateID)).UserID, _queues.First(x => x.Id.Contains(updateID)).RoomID, _queues.First(x => x.Id.Contains(updateID)).ClinicID, "Complete", _queues.First(x => x.Id.Contains(updateID)).Dated, DateTime.Now.ToString("dd-MM-yyyy H:mm:ss"),_queues.First(x => x.Id.Contains(updateID)).Department, "", "", "", "", "", "", "", "", "", Helper.orgID);

                    DBConnect.Update(_queue, updateID);
                    Global._queues.RemoveAll(x => x.Id == updateID);
                    Global._queues.Add(_queue);
                    MessageBox.Show("Information updated");
                    LoadData();

                }
            }

            if (e.ColumnIndex == 0)
            {
                string visitID = dtGrid.Rows[e.RowIndex].Cells[3].Value.ToString();
                string patientID = dtGrid.Rows[e.RowIndex].Cells[14].Value.ToString();
                string practitionerID = dtGrid.Rows[e.RowIndex].Cells[15].Value.ToString();

                PatientVisit frm = new PatientVisit(visitID, patientID, practitionerID);
                frm.MdiParent = MainForm.ActiveForm;
                frm.Dock = DockStyle.Fill;
                frm.Show();



            }
        }

        private void LoadAddiction(string patID)
        {

            _addictions = Addiction.ListAddiction(patID);
            tr = new DataTable();
            // create and execute query 
            tr.Columns.Add("id");//2 
            tr.Columns.Add("Name");//2
            tr.Columns.Add("Description");//
            tr.Columns.Add("Created");//
            tr.Columns.Add("Delete");//
            foreach (Addiction r in _addictions)
            {

                tr.Rows.Add(new object[] { r.Id, r.Name, r.Description, r.Created, "Delete" });

            }
            dtAddict.DataSource = tr;
            dtAddict.AllowUserToAddRows = false;


            dtAddict.Columns[0].Visible = false;
            dtAddict.Columns[4].DefaultCellStyle.BackColor = Color.Aquamarine;

        }
        private void LoadAllergy(string patID)
        {

            _allergies = Allergy.ListAllergy(patID);
            tr = new DataTable();
            // create and execute query 
            tr.Columns.Add("id");//2 

            tr.Columns.Add("Name");//2
            tr.Columns.Add("Description");//
            tr.Columns.Add("Created");//
            tr.Columns.Add("Delete");//
            foreach (Allergy r in _allergies)
            {
                tr.Rows.Add(new object[] { r.Id, r.Name, r.Description, r.Created, "Delete" });
            }
            dtAllergy.DataSource = tr;
            dtAllergy.AllowUserToAddRows = false;
            dtAllergy.Columns[4].DefaultCellStyle.BackColor = Color.Aquamarine;
            dtAllergy.Columns[0].Visible = false;


        }

        private void LoadChronic(string patientID)
        {

            _chronics = Chronic.ListChronic(patientID);
            tb = new DataTable();
            // create and execute query 
            tb.Columns.Add("id");//0
            tb.Columns.Add("Name");//1
            tb.Columns.Add("Description");//2
            tb.Columns.Add("Created");//4
            tb.Columns.Add("Delete");//
            foreach (Chronic r in _chronics)
            {
                tb.Rows.Add(new object[] { r.Id, r.Name, r.Description, r.Created, "Delete" });
            }
            dtChronic.DataSource = tb;
            dtChronic.DataSource = tb;
            dtChronic.AllowUserToAddRows = false;
            dtChronic.Columns[0].Visible = false;
            dtChronic.Columns[4].DefaultCellStyle.BackColor = Color.Aquamarine;

        }
        public System.Drawing.Image Base64ToImage(string bases)
        {
            byte[] imageBytes = Convert.FromBase64String(bases);
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
            ms.Write(imageBytes, 0, imageBytes.Length);
            System.Drawing.Image image = System.Drawing.Image.FromStream(ms, true);
            return image;
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
            if (chronicBtn.Checked == true)
            {
                _chronic = new Chronic(id, nameTxt.Text, descriptionTxt.Text, PatientID, DateTime.Now.ToString("dd-MM-yyyy H:mm:ss"),Helper.orgID);
                DBConnect.Insert(_chronic);
            }
            if (allergyBtn.Checked == true)
            {
                _allergy = new Allergy(id, nameTxt.Text, descriptionTxt.Text, PatientID, DateTime.Now.ToString("dd-MM-yyyy H:mm:ss"), Helper.orgID);
                DBConnect.Insert(_allergy);
            }
            if (additBtn.Checked == true)
            {
                _addiction = new Addiction(id, nameTxt.Text, descriptionTxt.Text, PatientID, DateTime.Now.ToString("dd-MM-yyyy H:mm:ss"), Helper.orgID);
                DBConnect.Insert(_addiction);
            }
            nameTxt.Text = "";
            descriptionTxt.Text = "";

            MessageBox.Show("Information Saved");
            LoadAddiction(PatientID);
            LoadAllergy(PatientID);
            LoadChronic(PatientID);


        }

        private void dtChronic_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string updateID = dtChronic.Rows[e.RowIndex].Cells[0].Value.ToString();
            _chronic = new Chronic(updateID, dtChronic.Rows[e.RowIndex].Cells[1].Value.ToString(), dtChronic.Rows[e.RowIndex].Cells[2].Value.ToString(), PatientID, DateTime.Now.ToString("dd-MM-yyyy H:mm:ss"), Helper.orgID);
            DBConnect.Update(_chronic, updateID);
        }

        private void dtChronic_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                if (MessageBox.Show("YES or No?", "Are you sure you want to delete this information? ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    DBConnect.Delete("chronic", dtChronic.Rows[e.RowIndex].Cells[0].Value.ToString());
                    MessageBox.Show("Information deleted");
                    LoadChronic(PatientID);
                }
            }

        }

        private void dtAllergy_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                if (MessageBox.Show("YES or No?", "Are you sure you want to delete this information? ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    DBConnect.Delete("allergy", dtAllergy.Rows[e.RowIndex].Cells[0].Value.ToString());
                    MessageBox.Show("Information deleted");
                    LoadAllergy(PatientID);
                }
            }

        }

        private void dtAllergy_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string updateID = dtAllergy.Rows[e.RowIndex].Cells[0].Value.ToString();
            _allergy = new Allergy(updateID, dtAllergy.Rows[e.RowIndex].Cells[1].Value.ToString(), dtAllergy.Rows[e.RowIndex].Cells[2].Value.ToString(), PatientID, DateTime.Now.ToString("dd-MM-yyyy H:mm:ss"), Helper.orgID);
            DBConnect.Update(_allergy, updateID);


        }

        private void dtAddict_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                if (MessageBox.Show("YES or No?", "Are you sure you want to delete this information? ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    DBConnect.Delete("addiction", dtAddict.Rows[e.RowIndex].Cells[0].Value.ToString());
                    MessageBox.Show("Information deleted");
                    LoadAddiction(PatientID);
                }
            }

        }

        private void dtAddict_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string updateID = dtAddict.Rows[e.RowIndex].Cells[0].Value.ToString();
            _addiction = new Addiction(updateID, dtAddict.Rows[e.RowIndex].Cells[1].Value.ToString(), dtAddict.Rows[e.RowIndex].Cells[2].Value.ToString(), PatientID, DateTime.Now.ToString("dd-MM-yyyy H:mm:ss"), Helper.orgID);
            DBConnect.Update(_addiction, updateID);


        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
