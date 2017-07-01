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
    public partial class SpecimenDialog : Form
    {
        public SpecimenDialog()
        {
            InitializeComponent();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {

            if (serviceTxt.Text == "")
            {
                serviceTxt.BackColor = Color.Red;
                return;
            }

            string id = Guid.NewGuid().ToString();
            Specimens _specimen = new Specimens(id, codeTxt.Text, nameTxt.Text, serviceTxt.Text, DateTime.Now.ToString("dd-MM-yyyy H:mm:ss"), Helper.orgID);

            if (DBConnect.Insert(_specimen) != "")
            {
                Global._specimens.Add(_specimen);
                serviceTxt.Text = "";
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
