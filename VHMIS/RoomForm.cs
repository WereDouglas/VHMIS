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
    public partial class RoomForm : Form
    {
        DataTable t;
        List<Room> _rooms = new List<Room>();
        Room _room;
        Dictionary<string, string> UserDictionary = new Dictionary<string, string>();
        Dictionary<string, string> ContactDictionary = new Dictionary<string, string>();
        public RoomForm()
        {
            InitializeComponent();
            foreach (Users d in Global._users)
            {
                practitionerCbx.Items.Add(d.Surname + " " + d.Lastname);
                UserDictionary.Add(d.Surname + " " + d.Lastname, d.Contact);
                ContactDictionary.Add(d.Contact, d.Id);
            }
            LoadData();
        }
        public void LoadData()
        {

            _rooms = Global._rooms;
            t = new DataTable();
            // create and execute query 
            t.Columns.Add("id");//2 
            t.Columns.Add(new DataColumn("Select", typeof(bool)));
            t.Columns.Add("Name");//2
            t.Columns.Add("Code");//
            t.Columns.Add("Practitioner");//
            t.Columns.Add("Description");//               
            t.Columns.Add("Created");// 
            t.Columns.Add("Delete");// 

            foreach (Room r in Global._rooms)
            {

                t.Rows.Add(new object[] { r.Id, false, r.Name, r.Code, Global._users.First(j=>j.Id.Contains(r.Practitioner)).Surname+" "+  Global._users.First(j => j.Id.Contains(r.Practitioner)).Lastname, r.Description, r.Created, "Delete" });

            }
            dtGrid.DataSource = t;
            dtGrid.AllowUserToAddRows = false;
            dtGrid.Columns[0].Visible = false;

        }
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
        string userID = "";
        private void practitionerCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            contactTxt.Text = "";
            contactTxt.Text = UserDictionary[practitionerCbx.Text];
            userID = ContactDictionary[contactTxt.Text];
            userLbl.Text = userID;
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (roomTxt.Text == "")
            {
                roomTxt.BackColor = Color.Red;
                return;
            }
            if (Global._rooms.Where(l => l.Name.Contains(roomTxt.Text)).Count() > 0) {

                MessageBox.Show("Information already submitted !");
                return;
            }

            string id = Guid.NewGuid().ToString();
            _room = new Room(id,roomTxt.Text, codeTxt.Text, userID, descriptionTxt.Text, DateTime.Now.ToString("dd-MM-yyyy H:mm:ss"), Helper.orgID);

            if (DBConnect.Insert(_room) != "")
            {
                Global._rooms.Add(_room);
                roomTxt.Text = "";
                userID = "";
                descriptionTxt.Text = "";
                MessageBox.Show("Information Saved");
                LoadData();

            }
            else
            {
                return;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
