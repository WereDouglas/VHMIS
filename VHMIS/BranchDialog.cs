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
    public partial class BranchDialog : Form
    {
        public BranchDialog()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Dispose();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {

            if (nameTxt.Text == "")
            {
                nameTxt.BackColor = Color.Red;
                return;

            }
            if (addressTxt.Text == "")
            {
                addressTxt.BackColor = Color.Red;
                return;

            }
            
            string id = Guid.NewGuid().ToString();
          Branch  _branch = new Branch(id, nameTxt.Text, locationTxt.Text, addressTxt.Text, contactTxt.Text, DateTime.Now.ToString("dd-MM-yyyy H:mm:ss"), Helper.orgID, codeTxt.Text);

            if (DBConnect.Insert(_branch) != "")
                Global._branch.Add(_branch);
            nameTxt.Text = "";
            addressTxt.Text = "";
            locationTxt.Text = "";
            MessageBox.Show("Information Saved");
            this.DialogResult = DialogResult.OK;
            this.Dispose();

        }
    }
}
