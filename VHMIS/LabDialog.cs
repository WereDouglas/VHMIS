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
    public partial class LabDialog : Form
    {
        string PatientID;
        string QueueID;
        string QueueNo;
        Dictionary<string, string> testCost = new Dictionary<string, string>();
        private Lab _lab;
        public LabDialog(string patientID, string queueID, string queueNo)
        {
            PatientID = patientID;
            QueueID = queueID;
            QueueNo = queueNo;
            InitializeComponent();

            labCbx.Items.Add("");
            foreach (Tests t in Global._tests)//.Where(i=>i.DepartmentID))
            {
                labCbx.Items.Add(t.Parameter);
                testCost.Add(t.Parameter, t.Cost);
            }
        }
        double LabTotal = 0;
        private void button2_Click(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty(QueueNo))
            {

                MessageBox.Show("Please select the current a number ");
                return;
            }

            string id = "";
            id = Guid.NewGuid().ToString();
            if (!String.IsNullOrEmpty(labCbx.Text))
            {
                _lab = new Lab(id, QueueID, PatientID, labCbx.Text, labCostTxt.Text, DateTime.Now.ToString("dd-MM-yyyy H:mm:ss"), labQty.Text, LabTotal.ToString("n0"), Helper.orgID, QueueNo);
                DBConnect.Insert(_lab);
                this.DialogResult = DialogResult.OK;
                this.Dispose();

            }
        }

        private void labCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                labCostTxt.Text = testCost[labCbx.Text];
                LabTotal = Convert.ToDouble(labCostTxt.Text) * Convert.ToDouble(labQty.Text);
                LabLbl.Text = LabTotal.ToString("n0");
            }
            catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Dispose();
        }
    }
}
