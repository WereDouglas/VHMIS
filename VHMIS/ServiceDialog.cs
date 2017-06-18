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
    public partial class ServiceDialog : Form
    {
        string PatientID;
        string QueueID;
        string QueueNo;
        Dictionary<string, string> operationCost = new Dictionary<string, string>();
        public ServiceDialog(string patientID,string queueID,string queueNo)
        {
            PatientID = patientID;
            QueueID = queueID;
            QueueNo = queueNo;

            InitializeComponent();
            operationCbx.Items.Add("");
            foreach (Operations t in Global._operations)//.Where(i=>i.DepartmentID))
            {
                operationCbx.Items.Add(t.Service);
                operationCost.Add(t.Service, t.Cost);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Dispose();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(statusCbx.Text))
            {

                MessageBox.Show("Please select the current status of the operation/Service ");
                return;
            }
            if (String.IsNullOrEmpty(QueueNo))
            {

                MessageBox.Show("Please select the current a number ");
                return;
            }
            string id = "";
            id = Guid.NewGuid().ToString();
            if (!String.IsNullOrEmpty(operationCbx.Text))
            {
              Services  _service = new Services(id, operationCbx.Text, QueueID, "Dental", "procedureID", PatientID, "userID", "code", "userID", opCostTxt.Text, DateTime.Now.ToString("dd-MM-yyyy H:mm:ss"), parameterTxt.Text, statusCbx.Text, serviceQty.Text, serviceTotal.ToString("n0"), "No", Helper.orgID, QueueNo);
                DBConnect.Insert(_service);
                MessageBox.Show("Information added/Saved");
                this.DialogResult = DialogResult.OK;
                this.Dispose();

            }
        }
        double serviceTotal = 0;
        private void operationCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            try
            {
                opCostTxt.Text = operationCost[operationCbx.Text];
                serviceTotal = Convert.ToDouble(opCostTxt.Text) * Convert.ToDouble(serviceQty.Text);
                serviceLbl.Text = serviceTotal.ToString("n0");
            }
            catch { }
        }
    }
}
