using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using VHMIS.Model;
using WindowsFormsCalendar;

namespace VHMIS
{
    public partial class CalenderForm : Form
    {
        CalendarItem contextItem = null;
        private List<CalendarItem> _items = new List<CalendarItem>();
        Dictionary<string, string> userDictionary = new Dictionary<string, string>();
        Dictionary<string, string> patientDictionary = new Dictionary<string, string>();
        Dictionary<string, string> contactDictionary = new Dictionary<string, string>();
        Dictionary<string, string> emailDictionary = new Dictionary<string, string>();
        // List<Events> _events = new List<Events>(Global._events);
        Events _event;
        public CalenderForm()
        {
            InitializeComponent();
            startMinTxt.Text = "00";
            endMinTxt.Text = "00";
            autocompleteUsers();
            autocompletePatient();
            startHrTxt.Text = DateTime.Now.ToString("HH");
            endHrTxt.Text = DateTime.Now.AddHours(1).ToString("HH");
            LoadingCalendarLite();

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
                userDictionary.Add(u.Surname + " " + u.Lastname, u.Id);
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

        private void label1_Click(object sender, EventArgs e)
        {

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
            _event = new Events(ID, Helper.CleanString(this.detailsTxt.Text), start, end, practitionerTxt.Text, patientTxt.Text, DateTime.Now.Date.ToString("yyyy-MM-dd"), patientID, "due", userID, Convert.ToDateTime(this.openedDate.Text).ToString("yyyy-MM-dd"), notify, priorityCbx.Text, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "f", contact, email, departmentCbx.Text, clinicCbx.Text, Helper.orgID);

            Global._events.Add(_event);

            string Query2 = "INSERT INTO events (id, details, starts, ends, users, patient, created, patientID, status, userID, dated,notif,priority, sync,cal,contact,email) VALUES ('" + ID + "','" + Helper.CleanString(this.detailsTxt.Text) + "','" + start + "','" + end + "','" + practitionerTxt.Text + "','" + patientTxt.Text + "','" + DateTime.Now.Date.ToString("yyyy-MM-dd") + "','" + patientID + "','due','" + userID + "','" + Convert.ToDateTime(this.openedDate.Text).ToString("yyyy-MM-dd") + "','" + notify + "','" + priorityCbx.Text + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','f','" + contact + "','" + email + "');";
            DBConnect.Execute(Query2);
            MessageBox.Show("Information saved");
            // LoadingCalendarLite();
            string state = "";

            CalendarItem cal = new CalendarItem(calendar1, Convert.ToDateTime(start), Convert.ToDateTime(end), patientTxt.Text + " ATT: " + practitionerTxt.Text + " " + detailsTxt.Text);

            if (state == "Medium") { cal.ApplyColor(Color.LightGreen); }
            if (state == "Low") { cal.ApplyColor(Color.CornflowerBlue); }
            if (state == "High") { cal.ApplyColor(Color.Salmon); }
            if (state == "none") { cal.ApplyColor(Color.LightSeaGreen); }
            _items.Add(cal);

            PlaceItems();

        }
        string patientID;
        string userID;
        public FileInfo ItemsFile
        {
            get
            {
                return new FileInfo(Path.Combine(Application.StartupPath, "items.xml"));
            }
        }

        private void practitionerTxt_Leave(object sender, EventArgs e)
        {
            try
            {
                userID = userDictionary[practitionerTxt.Text];
            }
            catch { }
            LoadingCalendarLite();
        }
        string contact;
        string email;
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

        private void endHrTxt_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToDouble(endHrTxt.Text) < Convert.ToDouble(startHrTxt.Text))
            {
                MessageBox.Show("Schedule end time cannot be less than the start time");
            }
        }

        private void startHrTxt_SelectedIndexChanged(object sender, EventArgs e)
        {
            endHrTxt.Text = (Convert.ToDouble(startHrTxt.Text) + 1).ToString();
        }

        private void detailsTxt_TextChanged(object sender, EventArgs e)
        {

        }
        #region Calendar Methods

        /// <summary>
        /// Handles the LoadItems event of the calendar1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="WindowsFormsCalendar.CalendarLoadEventArgs"/> instance containing the event data.</param>
        private void calendar1_LoadItems(object sender, CalendarLoadEventArgs e)
        {
            PlaceItems();
        }



        private void PlaceItems()
        {
            foreach (CalendarItem item in _items)
            {
                if (calendar1.ViewIntersects(item))
                {
                    calendar1.Items.Add(item);
                }
            }
        }

        private void LoadingCalendarLite()
        {
            _items.Clear();
            List<ItemInfo> lst = new List<ItemInfo>();
            string state = "";
            List<Events> events = new List<Events>(Global._events);

            if (!String.IsNullOrEmpty(departmentCbx.Text)) { events.Clear(); events = Global._events.Where(k => k.Department.Contains(departmentCbx.Text)).ToList(); }
            if (!String.IsNullOrEmpty(clinicCbx.Text)) { events.Clear(); events = Global._events.Where(k => k.Clinic.Contains(clinicCbx.Text)).ToList(); }
            if (!String.IsNullOrEmpty(practitionerTxt.Text)) { events.Clear(); events = Global._events.Where(k => k.Users.Contains(practitionerTxt.Text)).ToList(); }

            foreach (Events e in events)
            {
                CalendarItem cal = new CalendarItem(calendar1, Convert.ToDateTime(e.Starts), Convert.ToDateTime(e.Ends), e.Patient + " ATT: " + e.Users + "\r\n CONTACT " + e.Contact + " EMAIL:" + e.Email + e.Details);

                if (e.Priority == " ")
                {
                    state = "none";
                }
                else
                {
                    state = e.Priority;
                }
                if (state == "Medium") { cal.ApplyColor(Color.LightGreen); }
                if (state == "Low") { cal.ApplyColor(Color.CornflowerBlue); }
                if (state == "High") { cal.ApplyColor(Color.Salmon); }
                if (state == "none") { cal.ApplyColor(Color.LightSeaGreen); }
                _items.Add(cal);
                // t.Rows.Add(new object[] { Reader.GetString(0), Helper.ImageFolder + Reader.GetString(8), b, Reader.GetString(2), Reader.GetString(3), Reader.GetString(7), Reader.GetString(5), Reader.GetString(9), Reader.GetString(14) + "", Reader.GetString(6), "" + Reader.GetString(13) + "" });

            }
            PlaceItems();

        }
        private void calendar1_ItemMouseHover(object sender, CalendarItemEventArgs e)
        {
            Text = e.Item.Text;
        }
        private void calendar1_ItemClick(object sender, CalendarItemEventArgs e)
        {
            MessageBox.Show(e.Item.Text);
        }
        private void calendar1_ItemCreated(object sender, CalendarItemCancelEventArgs e)
        {
            if (e.Item.Text == "")
            {
                MessageBox.Show("No Information");
                return;
            }
            if (patientTxt.Text == "")
            {
                MessageBox.Show("Please select the patient");
                return;
            }
            _items.Add(e.Item);
            string priority = "Medium";
            if (!String.IsNullOrEmpty(priorityCbx.Text))
            {
                priority = priorityCbx.Text;
            }
            string ID = Guid.NewGuid().ToString();
            var start = Convert.ToDateTime(e.Item.Date).ToString("yyyy-MM-dd") + "T" + Convert.ToDateTime(e.Item.Date).ToString("HH:mm:ss");
            var end = Convert.ToDateTime(e.Item.EndDate).ToString("yyyy-MM-dd") + "T" + Convert.ToDateTime(e.Item.EndDate).ToString("HH:mm:ss");
            _event = new Events(ID, Helper.CleanString(e.Item.Text), start, end, practitionerTxt.Text, patientTxt.Text, DateTime.Now.Date.ToString("yyyy-MM-dd"), patientID, "due", userID, Convert.ToDateTime(e.Item.Date).ToString("yyyy-MM-dd"), "false", priority, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "f", contact, email, departmentCbx.Text, clinicCbx.Text, Helper.orgID);

            Global._events.Add(_event);
            string Query2 = "INSERT INTO events (id, details, starts, ends, users, patient, created, patientID, status, userID, dated,notif,priority, sync,cal,contact,email) VALUES ('" + ID + "','" + Helper.CleanString(e.Item.Text) + "','" + start + "','" + end + "','" + practitionerTxt.Text + "','" + patientTxt.Text + "','" + DateTime.Now.Date.ToString("yyyy-MM-dd") + "','" + patientID + "','due','" + userID + "','" + Convert.ToDateTime(e.Item.Date).ToString("yyyy-MM-dd") + "','false','"+priority+"','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','f','" + contact + "','" + email + "');";

            DBConnect.Execute(Query2);
            MessageBox.Show("Information saved" + start + " to" + end);
        }


        #endregion

        #region Month View Methods

        /// <summary>
        /// Handles the SelectionChanged event of the monthView1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void monthView1_SelectionChanged(object sender, EventArgs e)
        {
            this.calendar1.SetViewRange(this.monthView1.SelectionStart.Date, this.monthView1.SelectionEnd.Date);
        }

        #endregion

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            contextItem = calendar1.ItemAt(contextMenuStrip1.Bounds.Location);
        }

        private void CalendarForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            List<ItemInfo> lst = new List<ItemInfo>();

            foreach (CalendarItem item in _items)
            {
                lst.Add(new ItemInfo(item.StartDate, item.EndDate, item.Text, item.BackgroundColor));
            }

            XmlSerializer xmls = new XmlSerializer(lst.GetType());

            if (ItemsFile.Exists)
            {
                ItemsFile.Delete();
            }

            using (Stream s = ItemsFile.OpenWrite())
            {
                xmls.Serialize(s, lst);
                s.Close();
            }
        }

        private void hourToolStripMenuItem_Click(object sender, EventArgs e)
        {
            calendar1.TimeScale = CalendarTimeScale.SixtyMinutes;
        }

        private void minutesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            calendar1.TimeScale = CalendarTimeScale.ThirtyMinutes;
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            calendar1.TimeScale = CalendarTimeScale.FifteenMinutes;
        }

        private void minutesToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            calendar1.TimeScale = CalendarTimeScale.SixMinutes;
        }

        private void minutesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            calendar1.TimeScale = CalendarTimeScale.TenMinutes;
        }

        private void minutesToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            calendar1.TimeScale = CalendarTimeScale.FiveMinutes;
        }


        private void redTagToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (CalendarItem item in calendar1.GetSelectedItems())
            {
                item.ApplyColor(Color.Red);
                calendar1.Invalidate(item);
            }
        }

        private void yellowTagToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (CalendarItem item in calendar1.GetSelectedItems())
            {
                item.ApplyColor(Color.Gold);
                calendar1.Invalidate(item);
            }
        }

        private void greenTagToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (CalendarItem item in calendar1.GetSelectedItems())
            {
                item.ApplyColor(Color.Green);
                calendar1.Invalidate(item);
            }
        }

        private void blueTagToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (CalendarItem item in calendar1.GetSelectedItems())
            {
                item.ApplyColor(Color.DarkBlue);
                calendar1.Invalidate(item);
            }
        }
        private void editItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            calendar1.ActivateEditMode();
        }

        private void otherColorTagToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (ColorDialog dlg = new ColorDialog())
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    foreach (CalendarItem item in calendar1.GetSelectedItems())
                    {
                        item.ApplyColor(dlg.Color);
                        calendar1.Invalidate(item);
                    }
                }
            }
        }

        private void calendar1_ItemDoubleClick(object sender, CalendarItemEventArgs e)
        {
            MessageBox.Show("Double click: " + e.Item.Text);
        }

        private void calendar1_ItemDeleted(object sender, CalendarItemEventArgs e)
        {
            _items.Remove(e.Item);
        }

        private void calendar1_DayHeaderClick(object sender, CalendarDayEventArgs e)
        {
            calendar1.SetViewRange(e.CalendarDay.Date, e.CalendarDay.Date);
        }

        private void diagonalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (CalendarItem item in calendar1.GetSelectedItems())
            {
                item.Pattern = System.Drawing.Drawing2D.HatchStyle.ForwardDiagonal;
                item.PatternColor = Color.Red;
                calendar1.Invalidate(item);
            }
        }

        private void verticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (CalendarItem item in calendar1.GetSelectedItems())
            {
                item.Pattern = System.Drawing.Drawing2D.HatchStyle.Vertical;
                item.PatternColor = Color.Red;
                calendar1.Invalidate(item);
            }
        }

        private void horizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (CalendarItem item in calendar1.GetSelectedItems())
            {
                item.Pattern = System.Drawing.Drawing2D.HatchStyle.Horizontal;
                item.PatternColor = Color.Red;
                calendar1.Invalidate(item);
            }
        }

        private void hatchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (CalendarItem item in calendar1.GetSelectedItems())
            {
                item.Pattern = System.Drawing.Drawing2D.HatchStyle.DiagonalCross;
                item.PatternColor = Color.Red;
                calendar1.Invalidate(item);
            }
        }

        private void noneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (CalendarItem item in calendar1.GetSelectedItems())
            {
                item.Pattern = System.Drawing.Drawing2D.HatchStyle.DiagonalCross;
                item.PatternColor = Color.Empty;
                calendar1.Invalidate(item);
            }
        }


        private void northToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (CalendarItem item in calendar1.GetSelectedItems())
            {
                item.ImageAlign = CalendarItemImageAlign.North;
                calendar1.Invalidate(item);
            }
        }

        private void eastToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (CalendarItem item in calendar1.GetSelectedItems())
            {
                item.ImageAlign = CalendarItemImageAlign.East;
                calendar1.Invalidate(item);
            }
        }

        private void southToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (CalendarItem item in calendar1.GetSelectedItems())
            {
                item.ImageAlign = CalendarItemImageAlign.South;
                calendar1.Invalidate(item);
            }
        }

        private void westToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (CalendarItem item in calendar1.GetSelectedItems())
            {
                item.ImageAlign = CalendarItemImageAlign.West;
                calendar1.Invalidate(item);
            }
        }

        private void selectImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Filter = "*.gif|*.gif|*.png|*.png|*.jpg|*.jpg";

                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    Image img = Image.FromFile(dlg.FileName);

                    foreach (CalendarItem item in calendar1.GetSelectedItems())
                    {
                        item.Image = img;
                        calendar1.Invalidate(item);
                    }
                }
            }


        }

        private void calendar1_ItemsPositioned(object sender, EventArgs e)
        {
            //  MessageBox.Show("");
        }

        private void clinicCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadingCalendarLite();
        }

        private void departmentCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadingCalendarLite();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Close();
        }
    }
}
