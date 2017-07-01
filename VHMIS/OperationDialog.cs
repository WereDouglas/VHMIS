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
    public partial class OperationDialog : Form
    {
        Dictionary<string, string> DepDictionary = new Dictionary<string, string>();
        Dictionary<string, string> DesDictionary = new Dictionary<string, string>();
        Dictionary<string, string> SpeDictionary = new Dictionary<string, string>();
        public OperationDialog()
        {
            InitializeComponent();
            LoadCbx();
        }
        void LoadCbx()
        {

            foreach (Departments d in Global._departments)
            {
                
                if (!DepDictionary.ContainsKey(d.Name))
                {
                    departmentCbx.Items.Add(d.Name);
                    DepDictionary.Add(d.Name, d.Id);
                }
            }
            foreach (Discipline s in Global._disciplines)
            {
               
                if (!DesDictionary.ContainsKey(s.Name))
                {
                    desciplineCbx.Items.Add(s.Name);
                    DesDictionary.Add(s.Name, s.Id);
                }
            }
            foreach (Specimens p in Global._specimens)
            {
                
                if (!SpeDictionary.ContainsKey(p.Name))
                {
                    specimentCbx.Items.Add(p.Name);
                    SpeDictionary.Add(p.Name, p.Id);
                }
            }

        }

        private void saveBtn_Click_1(object sender, EventArgs e)
        {
            if (serviceTxt.Text == "")
            {
                serviceTxt.BackColor = Color.Red;
                return;
            }
            string id = Guid.NewGuid().ToString();
            Operations _operation = new Operations(id, depID, codeTxt.Text, serviceTxt.Text, typeTxt.Text, categoryTxt.Text, costTxt.Text, speID, parameterTxt.Text, upperTxt.Text, lowerTxt.Text, measureTxt.Text, desID, genderCbx.Text, phraseTxt.Text, maxTxt.Text, minTxt.Text, DateTime.Now.ToString("dd-MM-yyyy H:mm:ss"), Helper.orgID);

            if (DBConnect.Insert(_operation) != "")
            {
                Global._operations.Add(_operation);
                MessageBox.Show("Information Saved");
                this.DialogResult = DialogResult.OK;
                this.Dispose();
            }
            else
            {
                return;

            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Dispose();
        }
        string depID;
        private void departmentCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            depID = "";
            try
            {
                depID = DepDictionary[departmentCbx.Text];

            }
            catch { }
        }
        string desID;
        private void desciplineCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            desID = "";
            try
            {
                desID = DesDictionary[desciplineCbx.Text];

            }
            catch { }
        }
        string speID;
        private void specimentCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            speID = "";
            try
            {
                speID = SpeDictionary[specimentCbx.Text];

            }
            catch { }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (DepartmentDialog form = new DepartmentDialog())
            {
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    LoadCbx();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SpecimenDialog form = new SpecimenDialog())
            {
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    LoadCbx();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (DisciplineDialog form = new DisciplineDialog())
            {
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    LoadCbx();
                }
            }
        }
    }
}
