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
    public partial class ViewUsers : Form
    {
        DataTable t;
        Users _users;
        List<Users> _usersList;
        bool loaded = false;
        DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();
        DataGridViewButtonColumn btnEdit = new DataGridViewButtonColumn();
        public ViewUsers()
        {
            InitializeComponent();
            searchCbx.Items.Add("Client");
            searchCbx.Items.Add("Name");
            searchCbx.Items.Add("Users No");
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
            btnEdit.Text = "Edit";
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Width = 50;
            btnEdit.CellTemplate.Style.BackColor = Color.Orange;
            btnEdit.UseColumnTextForButtonValue = true;
            btnEdit.HeaderText = "Edit";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
        
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
            _usersList = new List<Users>();
            _usersList =Global._users;
            t = new DataTable();

            t.Columns.Add(new DataColumn("Select", typeof(bool)));
            t.Columns.Add("id");//3 
            t.Columns.Add(new DataColumn("Img", typeof(Bitmap)));//1
            t.Columns.Add("ID");//5
            t.Columns.Add("Surname");//6
            t.Columns.Add("Last name");//7
            t.Columns.Add("Contact");//8
            t.Columns.Add("Secondary contact");//9
            t.Columns.Add("Email");//10
            t.Columns.Add("Nationality");//11 
            t.Columns.Add("Address");//12        
            t.Columns.Add("KIN");//13
            t.Columns.Add("N.O.K contact");//14
            t.Columns.Add("Gender");//15
            t.Columns.Add("Created");//16          
            t.Columns.Add("image");//17
            t.Columns.Add("Designation");//18
            t.Columns.Add("Title");//19
            t.Columns.Add("Account");//20
            t.Columns.Add("Clinic");//21
            t.Columns.Add("Clinic Designation");//22
            t.Columns.Add("Status");//23
            t.Columns.Add("Practice");//24
            t.Columns.Add("Specialisation");//25
            t.Columns.Add("Sub");//26
            t.Columns.Add("Password");//27
            t.Columns.Add("Role");//28
            t.Columns.Add("Inital");//29
            t.Columns.Add("Sub specialisation");//30
            t.Columns.Add("Department");//31

            Bitmap b = new Bitmap(50, 50);
            using (Graphics g = Graphics.FromImage(b))
            {
                g.DrawString("Loading...", this.Font, new SolidBrush(Color.Gray), 00, 00);
            }
            foreach (Users users in _usersList)
            {
                t.Rows.Add(new object[] { false, users.Id, b,users.IdNo, users.Surname, users.Lastname, users.Contact, users.Contact2, users.Email, users.Nationality, users.Address, users.Kin, users.Kincontact, users.Gender, users.Created, users.Image,users.Designation,users.Roles,users.Account,users.ClinicID,users.ClinicDesignation,users.Status,users.Practice,users.Specialisation,users.Sub,users.Passwords,users.Roles,users.InitialPassword,users.Department });
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
                dtGrid.Columns[15].Visible = false;
                dtGrid.Columns[25].Visible = false;
           }

            loaded = true;

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

        private void dtGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (e.ColumnIndex == dtGrid.Columns[0].Index && e.RowIndex >= 0)
            {
                if (fileIDs.Contains(dtGrid.Rows[e.RowIndex].Cells[14].Value.ToString()))
                {
                    fileIDs.Remove(dtGrid.Rows[e.RowIndex].Cells[14].Value.ToString());
                    Console.WriteLine("REMOVED this id " + dtGrid.Rows[e.RowIndex].Cells[0].Value.ToString());

                }
                else
                {
                    fileIDs.Add(dtGrid.Rows[e.RowIndex].Cells[14].Value.ToString());
                    Console.WriteLine("ADDED ITEM " + dtGrid.Rows[e.RowIndex].Cells[0].Value.ToString());
                }
            }

            //try
            //{
            if (e.ColumnIndex == 1)
            {
                if (MessageBox.Show("YES or No?", "Are you sure you want to delete this information? ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    DBConnect.Delete("users", dtGrid.Rows[e.RowIndex].Cells[3].Value.ToString());

                    MessageBox.Show("Information deleted");
                    LoadData();

                }
            }
            //}
            //catch { }
            if (e.ColumnIndex == 0)
            {
                updateID = dtGrid.Rows[e.RowIndex].Cells[14].Value.ToString();
            }
        }
        string updateID;
       

        private void button2_Click(object sender, EventArgs e)
        {
           
        }
        private void dtGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            updateID = dtGrid.Rows[e.RowIndex].Cells[3].Value.ToString();
            _users = new Users(updateID, dtGrid.Rows[e.RowIndex].Cells[5].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells[8].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells[9].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells[6].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells[7].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells[10].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells[11].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells[12].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells[13].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells[14].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells[27].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells[18].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells[28].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells[15].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells[17].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells[21].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells[22].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells[29].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells[20].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells[23].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells[24].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells[25].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells[26].Value.ToString(), DateTime.Now.ToString("dd-MM-yyyy H:mm:ss"), dtGrid.Rows[e.RowIndex].Cells[31].Value.ToString(), Helper.orgID);

            DBConnect.Update(_users, updateID);
            Global._users.RemoveAll(x => x.Id == updateID);
            Global._users.Add(_users);

        }
    }

}
