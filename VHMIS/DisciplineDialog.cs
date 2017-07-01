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
    public partial class DisciplineDialog : Form
    {
        public DisciplineDialog()
        {
            InitializeComponent();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (nameTxt.Text == "")
            {
                nameTxt.BackColor = Color.Red;
                return;
            }

            string id = Guid.NewGuid().ToString();
           Discipline _discipline = new Discipline(id, nameTxt.Text, codeTxt.Text, DateTime.Now.ToString("dd-MM-yyyy H:mm:ss"), Helper.orgID);

            if (DBConnect.Insert(_discipline) != "")
            {
                Global._disciplines.Add(_discipline);
                nameTxt.Text = "";
                codeTxt.Text = "";

                MessageBox.Show("Information Saved");
                this.DialogResult = DialogResult.OK;
                this.Dispose();

            }
            else
            {
                return;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Dispose();
        }
    }
}
