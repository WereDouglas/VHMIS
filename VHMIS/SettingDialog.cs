using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using VHMIS.SQLite;

namespace VHMIS
{
    public partial class SettingDialog : Form
    {
        public SettingDialog()
        {
            InitializeComponent();
            LoadSettings();
        }
        private void LoadSettings()
        {
            // GrantAccess("LocalXMLFile.xml");
            try
            {
                XDocument xmlDoc = XDocument.Load(Connection.XMLFile());
                var servers = from person in xmlDoc.Descendants("Server")
                              select new
                              {
                                  Name = person.Element("Name").Value,
                                  Type = person.Element("Type").Value

                              };
                foreach (var server in servers)
                {
                    serverTxt.Text = server.Name;
                    typeCbx.Text = server.Type;

                    Helper.ServerName = server.Name;
                    Helper.Type = server.Type;

                }
            }
            catch { }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (typeCbx.Text == "")
            {
                typeCbx.BackColor = Color.Red;
                MessageBox.Show("Please select the application type");
                return;
            }

            XElement xml = new XElement("Servers",
              new XElement("Server",
              new XElement("Name", serverTxt.Text),
              new XElement("Type", typeCbx.Text)
           )
           );

            xml.Save(Connection.XMLFile());
            MessageBox.Show("Information Saved");
            this.DialogResult = DialogResult.OK;
            this.Dispose();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (typeCbx.Text == "")
            {
                typeCbx.BackColor = Color.Red;
                MessageBox.Show("Please select the application type");
                return;
            }
            Close();
        }
    }
}
