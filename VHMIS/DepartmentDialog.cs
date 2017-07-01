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
    public partial class DepartmentDialog : Form
    {
        public DepartmentDialog()
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

            string id = Guid.NewGuid().ToString();
         Departments   _department = new Departments(id, nameTxt.Text, regTxt.Text, licenseTxt.Text, Convert.ToDateTime(openedDate.Text).ToString("dd-MM-yyyy"), codeTxt.Text, DateTime.Now.ToString("dd-MM-yyyy H:mm:ss"), Helper.orgID);

            if (DBConnect.Insert(_department) != "")
            {
                Global._departments.Add(_department);
                nameTxt.Text = "";
                regTxt.Text = "";
                licenseTxt.Text = "";
                MessageBox.Show("Information Saved");
                this.DialogResult = DialogResult.OK;
                this.Dispose();

            }
            else
            {
                return;

            }
        }
    }
}
