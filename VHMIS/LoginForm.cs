using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using VHMIS.Model;
using VHMIS.SQLite;

namespace VHMIS
{
    public partial class LoginForm : Form
    {
        Organisation _org;
        List<Organisation> _orgList;
        Roles _role;
        string originalPassword;
        Connection dbobject = new Connection();
        SQLiteConnection SQLconnect = new SQLiteConnection();
        string IP;
        private BackgroundWorker bwLite = new BackgroundWorker();
        public static LoginForm _Form1;
        string start;
        string end;
        public LoginForm()
        {
            start = DateTime.Now.ToString("dd-MM-yyyy");
            end = DateTime.Now.ToString("dd-MM-yyyy");
            createSqlliteDB();
            InitializeComponent();
            LoadSettings();
            _Form1 = this;

            Helper.userName = "Test";
            Helper.userID = "Test";
        }
        
        private void createSqlliteDB()
        {
            
            Connection.createSQLLiteDB(DBConnect.CreateDBSQL(new Addiction()));
            Connection.createSQLLiteDB(DBConnect.CreateDBSQL(new Admission()));
            Connection.createSQLLiteDB(DBConnect.CreateDBSQL(new Billing()));
            Connection.createSQLLiteDB(DBConnect.CreateDBSQL(new Branch()));
            Connection.createSQLLiteDB(DBConnect.CreateDBSQL(new Bill()));           
            Connection.createSQLLiteDB(DBConnect.CreateDBSQL(new Expense()));
            Connection.createSQLLiteDB(DBConnect.CreateDBSQL(new Patient()));
            Connection.createSQLLiteDB(DBConnect.CreateDBSQL( new Category()));
            Connection.createSQLLiteDB(DBConnect.CreateDBSQL(new Beds()));
            Connection.createSQLLiteDB(DBConnect.CreateDBSQL(new Cd10()));
            Connection.createSQLLiteDB(DBConnect.CreateDBSQL(new Chronic()));
            Connection.createSQLLiteDB(DBConnect.CreateDBSQL(new Clinics()));
            Connection.createSQLLiteDB(DBConnect.CreateDBSQL(new Departments()));
            Connection.createSQLLiteDB(DBConnect.CreateDBSQL(new Diagnosis()));
            Connection.createSQLLiteDB(DBConnect.CreateDBSQL(new Discipline()));
            Connection.createSQLLiteDB(DBConnect.CreateDBSQL(new Dosage()));
            Connection.createSQLLiteDB(DBConnect.CreateDBSQL(new Events()));
            Connection.createSQLLiteDB(DBConnect.CreateDBSQL(new Expense()));
            Connection.createSQLLiteDB(DBConnect.CreateDBSQL(new Item()));
            Connection.createSQLLiteDB(DBConnect.CreateDBSQL(new Lab()));
            Connection.createSQLLiteDB(DBConnect.CreateDBSQL(new Notes()));
            Connection.createSQLLiteDB(DBConnect.CreateDBSQL(new Operations()));
            Connection.createSQLLiteDB(DBConnect.CreateDBSQL(new Organisation()));
            Connection.createSQLLiteDB(DBConnect.CreateDBSQL(new Patient()));
            Connection.createSQLLiteDB(DBConnect.CreateDBSQL(new Procedures()));
            Connection.createSQLLiteDB(DBConnect.CreateDBSQL(new Profession()));
            Connection.createSQLLiteDB(DBConnect.CreateDBSQL(new Queue()));
            Connection.createSQLLiteDB(DBConnect.CreateDBSQL(new Results()));
            Connection.createSQLLiteDB(DBConnect.CreateDBSQL(new Roles()));
            Connection.createSQLLiteDB(DBConnect.CreateDBSQL(new Room()));
            Connection.createSQLLiteDB(DBConnect.CreateDBSQL(new Services()));
            Connection.createSQLLiteDB(DBConnect.CreateDBSQL(new Specimens()));
            Connection.createSQLLiteDB(DBConnect.CreateDBSQL(new Stock()));
            Connection.createSQLLiteDB(DBConnect.CreateDBSQL(new Tests()));
            Connection.createSQLLiteDB(DBConnect.CreateDBSQL(new Theatre()));
           // Connection.createSQLLiteDB(DBConnect.CreateDBSQL(new Transaction()));
            Connection.createSQLLiteDB(DBConnect.CreateDBSQL(new Transactor()));
            Connection.createSQLLiteDB(DBConnect.CreateDBSQL(new Users()));
            Connection.createSQLLiteDB(DBConnect.CreateDBSQL(new Vitals()));
            Connection.createSQLLiteDB(DBConnect.CreateDBSQL(new Wards()));
          



        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                _userList = Global._users.Where(j => j.Contact.Contains(contactTxt.Text) && (j.Passwords.Contains(Helper.MD5Hash(passwordTxt.Text)) || j.InitialPassword.Contains(Helper.MD5Hash(passwordTxt.Text)))).ToList();

            }
            catch
            {

                MessageBox.Show("No Users defined");
                return;

            }

            if (_userList.Count() > 0)
            {
                Helper.UserID = _userList.First().Id;
                Helper.Code = Global._org.First().Code;
                Helper.Image = _userList.First().Image;
                Helper.Username = _userList.First().Surname + " " + _userList.First().Lastname;
                Helper.orgID = Global._org.FirstOrDefault().Id;
                Helper.lastSync = Global._org.First().Sync;             
                Helper.BranchID = Global._org.First().BranchID;
                if (String.IsNullOrEmpty(Helper.BranchID))
                {
                    using (ProfileForm form = new ProfileForm(""))
                    {
                        // DentalDialog form1 = new DentalDialog(item.Text, TransactorID);
                        DialogResult dr = form.ShowDialog();
                        if (dr == DialogResult.OK)
                        {
                            // MessageBox.Show(form.state);

                        }
                    }

                }
                this.DialogResult = DialogResult.OK;
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Invalid User Check contact and password !");
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirm or no?", "Are you sure you want to exit the application ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {

                // this.Close(); // you don't need that, it's already closing
                Application.Exit();
            }
        }
        private void LoadSettings()
        {

            //try
            //{
                XDocument xmlDoc = XDocument.Load(Connection.XMLFile());
                var servers = from person in xmlDoc.Descendants("Server")
                              select new
                              {

                                  Name = person.Element("Name").Value,
                                  Type = person.Element("Type").Value
                              };

                foreach (var server in servers)
                {
                    Helper.ServerName = server.Name;
                    Helper.Type = server.Type;
                    if (Helper.Type == "")
                    {
                        using (SettingDialog form = new SettingDialog())
                        {
                            DialogResult dr = form.ShowDialog();
                            if (dr == DialogResult.OK)
                            {
                                LoadSettings();
                            }
                        }
                        return;
                    }
                    if (Helper.Type.Contains("Lite"))
                    {
                        Global.LoadData(start, end);
                        autocomplete();
                        return;
                    }
                    if (Helper.Type.Contains("Enterprise"))
                    {
                        if (IPAddressCheck(server.Name) != "")
                        {
                            Helper.ServerIP = IPAddressCheck(Helper.ServerName);
                            lblStatus.Text += IPAddressCheck(Helper.ServerName);
                            // IP = IPAddressCheck(Helper.serverName);
                            if (TestServerConnection())
                            {
                                lblStatus.Text = lblStatus.Text + " Server connected   you can continue to login";
                                lblStatus.ForeColor = Color.Green;
                                Global.LoadData(start, end);
                                autocomplete();
                            }
                            else
                            {
                                using (SettingDialog form = new SettingDialog())
                                {
                                    DialogResult dr = form.ShowDialog();
                                    if (dr == DialogResult.OK)
                                    {
                                        LoadSettings();
                                    }
                                }

                                lblStatus.Text = ("You are not able to connect to the server contact the administrator for further assistance");
                                lblStatus.ForeColor = Color.Red;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please start the server");
                            return;
                        }
                    }
                }
                // MessageBox.Show(Helper.serverIP);


            //}
            //catch
            //{
            //    using (SettingDialog form = new SettingDialog())
            //    {

            //        DialogResult dr = form.ShowDialog();
            //        if (dr == DialogResult.OK)
            //        {
            //            LoadSettings();
            //        }
            //    }
            //}

        }
        private void autocomplete()
        {
            AutoCompleteStringCollection AutoItem = new AutoCompleteStringCollection();
            foreach (Users r in Users.ListUsers())
            {
                AutoItem.Add(r.Contact);
            }
            contactTxt.AutoCompleteMode = AutoCompleteMode.Suggest;
            contactTxt.AutoCompleteSource = AutoCompleteSource.CustomSource;
            contactTxt.AutoCompleteCustomSource = AutoItem;

            DBConnect.CloseConn();

        }
        List<Users> _userList;
        private String IPAddressCheck(string HostName)
        {
            //var ip = System.Net.Dns.GetHostEntry("JacksLaptop");
            //  string ipStrings = ip.AddressList[0].ToString();
            //var host =;
            var IPAddr = Dns.GetHostEntry(HostName);
            IPAddress ipString = null;

            foreach (var IP in IPAddr.AddressList)
            {
                if (IPAddress.TryParse(IP.ToString(), out ipString) && IP.AddressFamily == AddressFamily.InterNetwork)
                {
                    break;
                }
            }
            // Helper.serverIP = ipString.ToString();
            return ipString.ToString();
        }
        static NpgsqlDataReader Reader = null;
        private bool TestServerConnection()
        {
            //try
            //{

            string SQL = "SELECT * FROM users;";
            Reader = DBConnect.Reading(SQL);
            if (Reader != null)
            {
                lblStatus.Text = lblStatus.Text + ("Local server connection successful");
                lblStatus.ForeColor = Color.Green;
                Reader.Close();
                return true;
            }
            else
            {
                Reader.Close();
                return false;

            }
            // }
            //catch
            //{
            //    lblStatus.Text = ("You are not able to connect to the server contact the administrator for further assistance");
            //    lblStatus.ForeColor = Color.Red;
            //    return false;
            //}
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (SettingDialog form = new SettingDialog())
            {
                // DentalDialog form1 = new DentalDialog(item.Text, ItemID);
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    LoadSettings();
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("YES or No?", "Are you sure you want to delete all database information? ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                
                Connection.createSQLLiteDB(DBConnect.EmptyDBSQL(new Addiction()));
                Connection.createSQLLiteDB(DBConnect.EmptyDBSQL(new Admission()));
                Connection.createSQLLiteDB(DBConnect.EmptyDBSQL(new Billing()));
                Connection.createSQLLiteDB(DBConnect.EmptyDBSQL(new Branch()));
                Connection.createSQLLiteDB(DBConnect.EmptyDBSQL(new Bill()));
                Connection.createSQLLiteDB(DBConnect.EmptyDBSQL(new Expense()));
                Connection.createSQLLiteDB(DBConnect.EmptyDBSQL(new Patient()));
                Connection.createSQLLiteDB(DBConnect.EmptyDBSQL(new Category()));
                Connection.createSQLLiteDB(DBConnect.EmptyDBSQL(new Beds()));
                Connection.createSQLLiteDB(DBConnect.EmptyDBSQL(new Cd10()));
                Connection.createSQLLiteDB(DBConnect.EmptyDBSQL(new Chronic()));
                Connection.createSQLLiteDB(DBConnect.EmptyDBSQL(new Clinics()));
                Connection.createSQLLiteDB(DBConnect.EmptyDBSQL(new Departments()));
                Connection.createSQLLiteDB(DBConnect.EmptyDBSQL(new Diagnosis()));
                Connection.createSQLLiteDB(DBConnect.EmptyDBSQL(new Discipline()));
                Connection.createSQLLiteDB(DBConnect.EmptyDBSQL(new Dosage()));
                Connection.createSQLLiteDB(DBConnect.EmptyDBSQL(new Events()));
                Connection.createSQLLiteDB(DBConnect.EmptyDBSQL(new Expense()));
                Connection.createSQLLiteDB(DBConnect.EmptyDBSQL(new Item()));
                Connection.createSQLLiteDB(DBConnect.EmptyDBSQL(new Lab()));
                Connection.createSQLLiteDB(DBConnect.EmptyDBSQL(new Notes()));
                Connection.createSQLLiteDB(DBConnect.EmptyDBSQL(new Operations()));
                Connection.createSQLLiteDB(DBConnect.EmptyDBSQL(new Organisation()));
                Connection.createSQLLiteDB(DBConnect.EmptyDBSQL(new Patient()));
                Connection.createSQLLiteDB(DBConnect.EmptyDBSQL(new Procedures()));
                Connection.createSQLLiteDB(DBConnect.EmptyDBSQL(new Profession()));
                Connection.createSQLLiteDB(DBConnect.EmptyDBSQL(new Queue()));
                Connection.createSQLLiteDB(DBConnect.EmptyDBSQL(new Results()));
                Connection.createSQLLiteDB(DBConnect.EmptyDBSQL(new Roles()));
                Connection.createSQLLiteDB(DBConnect.EmptyDBSQL(new Room()));
                Connection.createSQLLiteDB(DBConnect.EmptyDBSQL(new Services()));
                Connection.createSQLLiteDB(DBConnect.EmptyDBSQL(new Specimens()));
                Connection.createSQLLiteDB(DBConnect.EmptyDBSQL(new Stock()));
                Connection.createSQLLiteDB(DBConnect.EmptyDBSQL(new Tests()));
                Connection.createSQLLiteDB(DBConnect.EmptyDBSQL(new Theatre()));
                // Connection.createSQLLiteDB(DBConnect.EmptyDBSQL(new Transaction()));
                Connection.createSQLLiteDB(DBConnect.EmptyDBSQL(new Transactor()));
                Connection.createSQLLiteDB(DBConnect.EmptyDBSQL(new Users()));
                Connection.createSQLLiteDB(DBConnect.EmptyDBSQL(new Vitals()));
                Connection.createSQLLiteDB(DBConnect.EmptyDBSQL(new Wards()));
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            using (ProfileForm form = new ProfileForm(""))
            {
                // DentalDialog form1 = new DentalDialog(item.Text, ItemID);
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                  
                    LoadSettings();                  
                    autocomplete();
                }
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void passwordTxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
