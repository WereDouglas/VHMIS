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
    public partial class DentalDialog : Form
    {
        private Lab _lab;
        private List<Lab> _labs;
        private Operations _op;
        private List<Services> _services;
        private Services _service;
        private List<Operations> _ops;
        public string state = "Saved";


        private Diagnosis _diag;
        private List<Diagnosis> _diags;
        string PatientID;
        string PractitionerID;
        string VisitID;
        Dictionary<string, string> operationCost = new Dictionary<string, string>();
        Dictionary<string, string> testCost = new Dictionary<string, string>();
        string No;
        public DentalDialog(string tooth, string patientID, string visitID,string no)
        {
            No = no;
            PatientID = patientID;
            VisitID = visitID;
            InitializeComponent();
            toothTxt.Text = tooth;
            operationCbx.Items.Add("");
            foreach (Operations t in Global._operations)//.Where(i=>i.DepartmentID))
            {
                operationCbx.Items.Add(t.Service);
                operationCost.Add(t.Service, t.Cost);
            }
            labCbx.Items.Add("");
            foreach (Tests t in Global._tests)//.Where(i=>i.DepartmentID))
            {
                labCbx.Items.Add(t.Parameter);
                testCost.Add(t.Parameter, t.Cost);
            }
            autocompleteCD();
        }
        Dictionary<string, string> cdDictionary = new Dictionary<string, string>();
        private void autocompleteCD()
        {
            AutoCompleteStringCollection AutoItem = new AutoCompleteStringCollection();
            foreach (Cd10 p in Global._cds)
            {
                AutoItem.Add(p.Description);
                cdDictionary.Add(p.Code, p.Description);
            }

            diagnosisCbx.AutoCompleteMode = AutoCompleteMode.Suggest;
            diagnosisCbx.AutoCompleteSource = AutoCompleteSource.CustomSource;
            diagnosisCbx.AutoCompleteCustomSource = AutoItem;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label52_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

            this.DialogResult = DialogResult.OK;
            this.Dispose();

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

        private void button17_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(statusCbx.Text))
            {
                MessageBox.Show("Please select the current status of the operation/Service ");
                return;
            }
            string id = "";
            id = Guid.NewGuid().ToString();
            if (!String.IsNullOrEmpty(operationCbx.Text))
            {
                _service = new Services(id, operationCbx.Text, VisitID, "Dental", "procedureID", PatientID, "userID", "code", "userID", opCostTxt.Text, DateTime.Now.ToString("dd-MM-yyyy H:mm:ss"), toothTxt.Text, statusCbx.Text,serviceQty.Text,serviceTotal.ToString("n0"),"No", Helper.orgID,No);
                DBConnect.Insert(_service);
                MessageBox.Show("Information added/Saved");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string id = "";
            id = Guid.NewGuid().ToString();
            if (!String.IsNullOrEmpty(labCbx.Text))
            {
                _lab = new Lab(id, VisitID, PatientID, labCbx.Text, labCostTxt.Text, DateTime.Now.ToString("dd-MM-yyyy H:mm:ss"), labQty.Text, LabTotal.ToString("n0"), Helper.orgID,No);
                DBConnect.Insert(_lab);
                MessageBox.Show("Information added/Saved");
            }
        }
        private void button16_Click(object sender, EventArgs e)
        {
            string id = "";
            id = Guid.NewGuid().ToString();
            if (!String.IsNullOrEmpty(operationCbx.Text))
            {
                _diag = new Diagnosis(id, diagnosisCbx.Text, VisitID, "Dental", "procedureID", PatientID, "userID", codeTxt.Text, "userID", diagCostTxt.Text, noteTxt.Text, DateTime.Now.ToString("dd-MM-yyyy H:mm:ss"), Helper.orgID,No);
                DBConnect.Insert(_diag);
                MessageBox.Show("Information added/Saved");

            }

        }
        double LabTotal = 0;
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

        private void labQty_TextChanged(object sender, EventArgs e)
        {
            try
            {

                LabTotal = Convert.ToDouble(labCostTxt.Text) * Convert.ToDouble(labQty.Text);
                LabLbl.Text = LabTotal.ToString("n0");
            }
            catch { }
        }

        private void serviceQty_TextChanged(object sender, EventArgs e)
        {

        }

        private void diagnosisQty_TextChanged(object sender, EventArgs e)
        {

        }

        private void diagnosisCbx_Leave(object sender, EventArgs e)
        {
            try
            {
                var value = cdDictionary.FirstOrDefault(x => x.Value.Contains(diagnosisCbx.Text)).Key;
                codeTxt.Text = value;// cdDictionary[diagnosisCbx.Text];
            }
            catch
            {

            }
        }

        private void label46_Click(object sender, EventArgs e)
        {

        }
    }
}
