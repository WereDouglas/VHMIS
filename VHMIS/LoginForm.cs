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
        Users _users = new Users();
        Billing _bill = new Billing();
        Category _cat = new Category();
        Expense _exp = new Expense();
        Item _item = new Item();
        Organisation _organisation = new Organisation();        
        Roles _roles = new Roles();       
        Stock _stock = new Stock();      
        Transactor _trans = new Transactor();
        private void createSqlliteDB()
        {
            //  string fullFilePath = Path.Combine(appPath, "casesLite.txt");            
            //  string SQL = DBConnect.CreateDBSQL(_users);
            Connection.createSQLLiteDB(DBConnect.CreateDBSQL(_users));
            Connection.createSQLLiteDB(DBConnect.CreateDBSQL(_bill));
            Connection.createSQLLiteDB(DBConnect.CreateDBSQL(_cat));
            Connection.createSQLLiteDB(DBConnect.CreateDBSQL(_exp));
            Connection.createSQLLiteDB(DBConnect.CreateDBSQL(_item));
            Connection.createSQLLiteDB(DBConnect.CreateDBSQL(_organisation));            
            Connection.createSQLLiteDB(DBConnect.CreateDBSQL(_roles));         
            Connection.createSQLLiteDB(DBConnect.CreateDBSQL(_stock));           
            Connection.createSQLLiteDB(DBConnect.CreateDBSQL(_trans));
           


        }

        private void button1_Click(object sender, EventArgs e)
        {
          
           // MessageBox.Show("Information Saved");
            this.DialogResult = DialogResult.OK;
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           /// MessageBox.Show("Information Saved");
            this.DialogResult = DialogResult.OK;
            this.Dispose();
        }
        private void LoadSettings()
        {

            try
            {
                XDocument xmlDoc = XDocument.Load("LocalXMLFile.xml");
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


            }
            catch
            {
                using (SettingDialog form = new SettingDialog())
                {

                    DialogResult dr = form.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        LoadSettings();
                    }
                }
            }

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

        }
    }
}
