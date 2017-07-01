using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VHMIS.Model;

namespace VHMIS
{
    public partial class DentalForm : Form
    {
        string VisitID;
        string PatientID;
        string PractitionerID;
        private readonly IEnumerable<CheckBox> Chk;
        DataTable tb;
        private Lab _lab;
        private List<Lab> _labs;

        private Diagnosis _diag;
        private List<Diagnosis> _diags;

        private Services _serve;
        private List<Services> _services;

        public DentalForm(string visitID, string patientID, string practitionerID)
        {
            InitializeComponent();
            PatientID = patientID;
            VisitID = visitID;
            PractitionerID = practitionerID;
            this.Chk = this.Controls.OfType<CheckBox>();
            try
            {
                LoadPatient(patientID);
                queueNo.Text = Global._queues.First(p => p.Id.Contains(VisitID)).No;// VisitID;
                LoadServices(queueNo.Text);
            }
            catch
            {

            }
           
        }
        private void LoadPatient(string PatientID)
        {
            string surname = Global._patients.First(k => k.Id.Contains(PatientID)).Surname;
            string lastname = Global._patients.First(k => k.Id.Contains(PatientID)).Lastname;
            nameLbl.Text = surname + " " + lastname;
            noLbl.Text = Global._patients.First(k => k.Id.Contains(PatientID)).PatientNo;

            Image img = Base64ToImage(Global._patients.First(k => k.Id.Contains(PatientID)).Image);
            System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(img);
            //Bitmap bps = new Bitmap(bmp, 50, 50);
            imgCapture.Image = bmp;
            GraphicsPath gp = new GraphicsPath();
            gp.AddEllipse(imgCapture.DisplayRectangle);
            imgCapture.Region = new Region(gp);
            imgCapture.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        public System.Drawing.Image Base64ToImage(string bases)
        {
            byte[] imageBytes = Convert.FromBase64String(bases);
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
            ms.Write(imageBytes, 0, imageBytes.Length);
            System.Drawing.Image image = System.Drawing.Image.FromStream(ms, true);
            return image;
        }
        private void FillChart()
        {
            foreach (Services p in Services.ListServices(queueNo.Text))
            {
                foreach (Control ctrl in panel1.Controls)
                {
                    if (ctrl is CheckBox)
                    {                      
                            if (ctrl.Text== (p.Parameter))
                            {
                            if (p.Status=="Complete") {
                                ctrl.ForeColor = Color.Green;
                            } else {
                                ctrl.ForeColor = Color.Red;
                            }
                              
                                ctrl.Text =p.Parameter +" :"+ p.Name.ToString() +" :"+ p.Notes;
                            // ctrl.Fon = 8;
                            ctrl.Font = new Font("Calibri", 8, FontStyle.Italic);
                        }
                                               
                      
                    }
                }
                //tb.Rows.Add(new object[] { r.Id, r.Parameter, r.Name, r.DepartmentID, r.ProcedureID, r.Price, r.Code, "Cancel" });
            }

        }
        CheckBox myCheckBox;
        private static string[] alphabetArray = { string.Empty, "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (typeCbx.Text == "American")
            {
                foreach (Control ctrl in panel1.Controls)
                {

                    if (ctrl is CheckBox)
                    {
                        for (int r = 1; r < 33; r++)
                        {
                            if (ctrl.Name == ("chk" + r))
                            {
                                ctrl.ForeColor = Color.Orange;
                                ctrl.Text = r.ToString();
                            }
                        }
                        //pchk1
                        for (int r = 0; r < 33; r++)
                        {
                            if (ctrl.Name == ("pchk" + r))
                            {
                                ctrl.Text = alphabetArray[r].ToString();
                                ctrl.ForeColor = Color.Orange;
                            }
                        }
                    }
                }

            }
            else
            {
                foreach (Control ctrl in panel1.Controls)
                {

                    if (ctrl is CheckBox)
                    {
                        ctrl.ForeColor = Color.Green;
                    }
                }
                chk8.Text = "11";
                chk7.Text = "12";
                chk6.Text = "13";
                chk5.Text = "14";
                chk4.Text = "15";
                chk3.Text = "16";
                chk2.Text = "17";
                chk1.Text = "18";


                chk9.Text = "21";
                chk10.Text = "22";
                chk11.Text = "23";
                chk12.Text = "24";
                chk13.Text = "25";
                chk14.Text = "26";
                chk15.Text = "27";
                chk16.Text = "28";

                chk24.Text = "31";
                chk23.Text = "32";
                chk22.Text = "33";
                chk21.Text = "34";
                chk20.Text = "35";
                chk19.Text = "36";
                chk18.Text = "37";
                chk17.Text = "38";

                chk25.Text = "41";
                chk26.Text = "42";
                chk27.Text = "43";
                chk28.Text = "44";
                chk29.Text = "45";
                chk30.Text = "46";
                chk31.Text = "47";
                chk32.Text = "48";

                pchk1.Text = "55";
                pchk2.Text = "54";
                pchk3.Text = "53";
                pchk4.Text = "52";
                pchk5.Text = "51";


                pchk6.Text = "61";
                pchk7.Text = "62";
                pchk8.Text = "63";
                pchk9.Text = "64";
                pchk10.Text = "65";


                pchk11.Text = "75";
                pchk12.Text = "74";
                pchk13.Text = "73";
                pchk14.Text = "72";
                pchk15.Text = "71";


                pchk16.Text = "81";
                pchk17.Text = "82";
                pchk18.Text = "83";
                pchk19.Text = "84";
                pchk20.Text = "85";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void labCostTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void panel1_Enter(object sender, EventArgs e)
        {

        }

        private void chk7_CheckedChanged(object sender, EventArgs e)
        {
            var item = (CheckBox)sender;
            // MessageBox.Show(item.Text);
            if (item.Checked == true)
            {

                using (DentalDialog form = new DentalDialog(item.Text, PatientID, VisitID,queueNo.Text))
                {

                    // DentalDialog form1 = new DentalDialog(item.Text, PatientID);
                    DialogResult dr = form.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        MessageBox.Show(form.state);
                       
                        LoadServices(VisitID);
                    }
                }

            }
            if (item.CheckState.Equals(false))
            {


            }
        }
        private void LoadServices(string visitID)
        {

            List<Services> _services = Services.ListServices(visitID);
            tb = new DataTable();
            // create and execute query 
            tb.Columns.Add("id");//2 
            tb.Columns.Add("Parameter");//2
            tb.Columns.Add("Name");//2
            tb.Columns.Add("Department");//           
            tb.Columns.Add("Price");//
            tb.Columns.Add("Quantity");//
            tb.Columns.Add("Total");//
            tb.Columns.Add("Paid");//
            tb.Columns.Add("Notes");//
            tb.Columns.Add("Status");//    
            tb.Columns.Add("Results");//            
            tb.Columns.Add("Cancel");//

            foreach (Services r in _services)
            {
                tb.Rows.Add(new object[] { r.Id, r.Parameter, r.Name, Global._departments.First(e => e.Id.Contains(r.DepartmentID)).Name, r.Price, r.Qty, r.Total, r.Paid, r.Notes, r.Status,r.Results, "Cancel" });

           }
            dtGrid.DataSource = tb;
            dtGrid.AllowUserToAddRows = false;
            dtGrid.Columns["Cancel"].DefaultCellStyle.BackColor = Color.OrangeRed;
            dtGrid.Columns["id"].Visible = false;
            dtGrid.Columns["Department"].Visible = false;
            dtGrid.Columns["Price"].Visible = false;
            dtGrid.Columns["Quantity"].Visible = false;
            dtGrid.Columns["Total"].Visible = false;
            dtGrid.Columns["Paid"].Visible = false;
            dtGrid.Columns["Cancel"].FillWeight = 80;
        }


        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {

            foreach (Control item in this.Controls)     //this IS YOUR CURRENT FORM
            {
                if ((sender as Control).Equals(item))
                {
                    //Do what you want

                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //try
            //{
                FillChart();
            //}
            //catch { }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (DentalDialog form = new DentalDialog("Other", PatientID, VisitID, queueNo.Text))
            {

                // DentalDialog form1 = new DentalDialog(item.Text, PatientID);
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    MessageBox.Show(form.state);
                   
                    LoadServices(VisitID);
                }
            }
        }

        private void queueNo_Enter(object sender, EventArgs e)
        {

        }

        private void queueNo_Click(object sender, EventArgs e)
        {
            queueNo.Text = "VHMIS-" + DateTime.Now.ToString("dd-MM-yyyy") + "/";
        }

        private void queueNo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                VisitID = Global._queues.First(p => p.No.Equals(queueNo.Text)).Id;
                PatientID = Global._queues.First(d => d.No.Equals(queueNo.Text)).PatientID;
                if (!String.IsNullOrEmpty(VisitID))
                {
                    LoadPatient(PatientID);                   
                    LoadServices(queueNo.Text);
                }
            }
            catch { }
        }

        private void dtServices_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtGrid.Rows[e.RowIndex].Cells["Cancel"].Value.ToString() == "Cancel")
            {
                if (MessageBox.Show("YES or No?", "Cancel this service ? ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    DBConnect.Delete("services", dtGrid.Rows[e.RowIndex].Cells["id"].Value.ToString());
                    MessageBox.Show("Information deleted");
                    LoadServices(queueNo.Text);

                }

            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            using (DentalDialog form = new DentalDialog("Details", PatientID, VisitID, queueNo.Text))
            {

                // DentalDialog form1 = new DentalDialog(item.Text, PatientID);
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                   //// MessageBox.Show(form.state);

                    LoadServices(VisitID);
                }
            }
        }
    }
}
