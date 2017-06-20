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
    public partial class EventDialog : Form
    {
        string patientID;
        string userID;
        string contact;
        string email;
        Dictionary<string, string> userDictionary = new Dictionary<string, string>();
        Dictionary<string, string> patientDictionary = new Dictionary<string, string>();
        Dictionary<string, string> contactDictionary = new Dictionary<string, string>();
        Dictionary<string, string> emailDictionary = new Dictionary<string, string>();

        string PatientID;
        
        public EventDialog()
        {
            PatientID = patientID;
            InitializeComponent();
            startMinTxt.Text = "00";
            endMinTxt.Text = "00";
            autocompleteUsers();
            autocompletePatient();
            startHrTxt.Text = DateTime.Now.ToString("HH");
            endHrTxt.Text = DateTime.Now.AddHours(1).ToString("HH");
            foreach (Clinics d in Global._clinics)
            {
                clinicCbx.Items.Add(d.Name);
            }

            foreach (Departments d in Global._departments)
            {
                departmentCbx.Items.Add(d.Name);
            }
        }
        private void autocompleteUsers()
        {
            AutoCompleteStringCollection AutoItem = new AutoCompleteStringCollection();
            foreach (Users u in Global._users)
            {
                AutoItem.Add(u.Surname + " " + u.Lastname);
                if (!userDictionary.ContainsKey(u.Surname + " " + u.Lastname))
                {
                    userDictionary.Add(u.Surname + " " + u.Lastname, u.Id);
                }
            }

            practitionerTxt.AutoCompleteMode = AutoCompleteMode.Suggest;
            practitionerTxt.AutoCompleteSource = AutoCompleteSource.CustomSource;
            practitionerTxt.AutoCompleteCustomSource = AutoItem;

        }
        private void autocompletePatient()
        {
            AutoCompleteStringCollection AutoItem = new AutoCompleteStringCollection();
            foreach (Patient p in Global._patients)
            {
                AutoItem.Add(p.Surname + " " + p.Lastname);
                patientDictionary.Add(p.Surname + " " + p.Lastname, p.Id);
                contactDictionary.Add(p.Id, p.Contact);
                emailDictionary.Add(p.Id, p.Email);
            }

            patientTxt.AutoCompleteMode = AutoCompleteMode.Suggest;
            patientTxt.AutoCompleteSource = AutoCompleteSource.CustomSource;
            patientTxt.AutoCompleteCustomSource = AutoItem;

        }

        string notify;
        private void button5_Click(object sender, EventArgs e)
        {
            if (startHrTxt.Text == "" || endHrTxt.Text == "")
            {
                MessageBox.Show("Please input the start time and end time for the meeting /schedule ");
                return;
            }
            string ID = Guid.NewGuid().ToString();
            var start = Convert.ToDateTime(this.openedDate.Text).ToString("yyyy-MM-dd") + "T" + this.startHrTxt.Text + ":" + startMinTxt.Text + ":00";
            var end = Convert.ToDateTime(this.openedDate.Text).ToString("yyyy-MM-dd") + "T" + this.endHrTxt.Text + ":" + endMinTxt.Text + ":00";

            notify = "false";

            if (notifyChk.Checked)
            {
                notify = "true";
            }
            Events  _event = new Events(ID, Helper.CleanString(this.detailsTxt.Text), start, end, practitionerTxt.Text, patientTxt.Text, DateTime.Now.Date.ToString("yyyy-MM-dd"), patientID, "due", userID, Convert.ToDateTime(this.openedDate.Text).ToString("yyyy-MM-dd"), notify, priorityCbx.Text, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "f", contact, email, departmentCbx.Text, clinicCbx.Text, Helper.orgID);

            Global._events.Add(_event);

            string Query2 = "INSERT INTO events (id, details, starts, ends, users, patient, created, patientID, status, userID, dated,notif,priority, sync,cal,contact,email) VALUES ('" + ID + "','" + Helper.CleanString(this.detailsTxt.Text) + "','" + start + "','" + end + "','" + practitionerTxt.Text + "','" + patientTxt.Text + "','" + DateTime.Now.Date.ToString("yyyy-MM-dd") + "','" + patientID + "','due','" + userID + "','" + Convert.ToDateTime(this.openedDate.Text).ToString("yyyy-MM-dd") + "','" + notify + "','" + priorityCbx.Text + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','f','" + contact + "','" + email + "');";
            DBConnect.Execute(Query2);
        }

        private void practitionerTxt_Leave(object sender, EventArgs e)
        {
            try
            {
                userID = userDictionary[practitionerTxt.Text];
            }
            catch { }
           
        }

        private void patientTxt_Leave(object sender, EventArgs e)
        {

            try
            {
                patientID = patientDictionary[patientTxt.Text];
                contact = contactDictionary[patientID];
                email = emailDictionary[patientID];
            }
            catch { }
        }

        private void startHrTxt_SelectedIndexChanged(object sender, EventArgs e)
        {
            endHrTxt.Text = (Convert.ToDouble(startHrTxt.Text) + 1).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Dispose();
        }
    }
}
