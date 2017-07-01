using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Speech.Recognition;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using VHMIS.Model;

namespace VHMIS
{
    public partial class PatientVisit : Form
    {

        List<Word> words = new List<Word>();

        private SerialPort port;
        private string scom;
        private object valueGenSync = new object();
        private Random randGen = new Random();

        private int valueGenFrom = 0;
        private int valueGenTo = 100;
        private int valueGenTimerFrom = 100;
        private int valueGenTimerTo = 1000;
        string PatientID;
        string PractitionerID;
        string queueID;
        private Vitals _vital;
        private List<Vitals> _vitals;

        private Lab _lab;
        private List<Lab> _labs;

        private Notes _note;
        private List<Notes> _notes;

        private Results _result;
        private List<Results> _results;
        DataTable tr;
        DataTable tb;
        DataTable ts;
        DataTable td;
        Dictionary<string, string> testCost;
        DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();
        DataGridViewButtonColumn btnLab = new DataGridViewButtonColumn();
        DataGridViewButtonColumn btnLab2 = new DataGridViewButtonColumn();
        DataGridViewButtonColumn btnR = new DataGridViewButtonColumn();
        Dictionary<string, string> operationCost = new Dictionary<string, string>();
        Dictionary<string, string> diagnosisCost = new Dictionary<string, string>();
        Dictionary<string, string> cdDictionary = new Dictionary<string, string>();
        List<Queue> _todayList = new List<Queue>();
        Queue _queue;
        string QueueNo;
        DataTable t;
        List<Users> _userList = new List<Users>();

        bool loaded = false;
        bool loadedLab = false;
        SpeechRecognitionEngine speechRecognitionEngine = null;
        private BackgroundWorker bw_message = new BackgroundWorker();
        public PatientVisit(string visitID, string patientID, string practitionerID)
        {
            testCost = new Dictionary<string, string>();
            _userList = Global._users;
            InitializeComponent();
            // adddevice();
            PatientID = patientID;
            PractitionerID = practitionerID;
            perfChart.TimerInterval = 100;
         
            queueID = visitID;
           
            try
            {
                LoadPatient(patientID);
            }
            catch
            {

            }
            visitLbl.Text = Global._queues.First(e=>e.Id.Contains(queueID)).No;
            QueueNo = Global._queues.First(e => e.Id.Contains(queueID)).No;

          

            btnR.Name = "btnR";
            btnR.Text = "Remove";
            btnR.FlatStyle = FlatStyle.Flat;
            btnR.Width = 20;
            btnR.CellTemplate.Style.BackColor = Color.Green;
            btnR.UseColumnTextForButtonValue = true;
            btnR.HeaderText = "Select";

            LoadServices(visitLbl.Text);

            LoadLab(visitLbl.Text);
            LoadDiagnosis(visitLbl.Text);

            LoadNotes(queueID);
         
           
            //diagnosisCbx.Items.Add("");
            //foreach (Operations t in Global._operations)//.Where(i=>i.DepartmentID))
            //{
            //    diagnosisCbx.Items.Add(t.Name);
            //    diagnosisCost.Add(t.Name, t.Cost);
            //}

            _todayList = Global._queues.Where(j => j.PatientID == patientID).ToList();//.Where(r => r.Dated.Contains(today)).ToList();
          
            LoadVisits();
            LoadVoice();
            bw_message.DoWork += backgroundWorker1_DoWork;

            bw_message.WorkerReportsProgress = true;
            autocompleteCD();
          
        }
        private void LoadServices(string visitID)
        {

            _services = Services.ListServices(visitID);
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
            tb.Columns.Add("departmentID");//

            foreach (Services r in _services)
            {
                tb.Rows.Add(new object[] { r.Id, r.Parameter, r.Name, Global._departments.First(e => e.Id.Contains(r.DepartmentID)).Name, r.Price, r.Qty, r.Total, r.Paid, r.Notes, r.Status, r.Results, "Cancel", r.DepartmentID });

            }
            dtServices.DataSource = tb;
            dtServices.AllowUserToAddRows = false;
            dtServices.Columns["Cancel"].DefaultCellStyle.BackColor = Color.OrangeRed;
            dtServices.Columns["id"].Visible = false;
            dtServices.Columns["departmentID"].Visible = false;
            dtServices.Columns["Cancel"].FillWeight = 80;
            totalLbl.Text = _services.Sum(f => Convert.ToDouble(f.Total)).ToString("n0");
        }
        private void LoadLab(string visitID)
        {

            _services = Services.ListServices(visitID);
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
            tb.Columns.Add("departmentID");//

            foreach (Services r in _services)
            {
                tb.Rows.Add(new object[] { r.Id, r.Parameter, r.Name, Global._departments.First(e => e.Id.Contains(r.DepartmentID)).Name, r.Price, r.Qty, r.Total, r.Paid, r.Notes, r.Status, r.Results, "Cancel", r.DepartmentID });

            }
            dtLab.DataSource = tb;
            dtLab.AllowUserToAddRows = false;
             dtLab.Columns["Cancel"].DefaultCellStyle.BackColor = Color.OrangeRed;
             dtLab.Columns["id"].Visible = false;
             dtLab.Columns["departmentID"].Visible = false;
             dtLab.Columns["Cancel"].FillWeight = 80;
            totalLbl.Text = _services.Sum(f => Convert.ToDouble(f.Total)).ToString("n0");
        }
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

        string line;
        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                
                string path = Environment.CurrentDirectory + "\\icd10.txt";
                const Int32 BufferSize = 1024;
                using (var fileStream = File.OpenRead(path))
                using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
                {                  
                    while ((line = streamReader.ReadLine()) != null)
                    {
                     //  FeedBack(line);
                        Console.WriteLine(line);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void LoadVisits()
        {

            t = new DataTable();
            t.Columns.Add(new DataColumn("Select", typeof(bool)));
            t.Columns.Add("id");//3            
            t.Columns.Add("Number");//4          
            t.Columns.Add("Room");//5
            t.Columns.Add("Clinic"); //6           
            t.Columns.Add("Status");//7
            t.Columns.Add("Practitioner");
            t.Columns.Add(new DataColumn("imgdoc", typeof(Bitmap)));//           
            t.Columns.Add("docimage");//17            
            t.Columns.Add("practitionerID");//17    

            Bitmap b2 = new Bitmap(50, 50);

            using (Graphics g2 = Graphics.FromImage(b2))
            {
                g2.DrawString("Loading...", this.Font, new SolidBrush(Color.Gray), 00, 00);
            }
            foreach (Queue q in _todayList)
            {
                t.Rows.Add(new object[] { false, q.Id, q.Follow, q.RoomID, q.ClinicID, q.Status, _userList.First(h => h.Id.Contains(q.UserID)).Surname + " " + _userList.First(h => h.Id.Contains(q.UserID)).Lastname, b2, _userList.First(h => h.Id.Contains(q.UserID)).Image, q.UserID });
            }
            dtPrevious.DataSource = t;
            ThreadPool.QueueUserWorkItem(delegate
            {
                foreach (DataRow row in t.Rows)
                {

                    try
                    {
                        Image img = Base64ToImage(row["docimage"].ToString());
                        System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(img);
                        Bitmap bps = new Bitmap(bmp, 50, 50);
                        row["imgdoc"] = bps;
                    }
                    catch
                    {

                    }
                }
            });
            dtPrevious.AllowUserToAddRows = false;
            dtPrevious.Columns[1].DefaultCellStyle.BackColor = Color.LightGreen;
            dtPrevious.Columns[2].DefaultCellStyle.BackColor = Color.Aquamarine;
            dtPrevious.RowTemplate.Height = 60;

            dtPrevious.Columns[1].Visible = false;
            dtPrevious.Columns[9].Visible = false;
            dtPrevious.Columns[8].Visible = false;
        }
       
        void LoadVoice()
        {


            try
            {

                // create the engine
                speechRecognitionEngine = createSpeechEngine("en-GB");

                // hook to events
                speechRecognitionEngine.AudioLevelUpdated += new EventHandler<AudioLevelUpdatedEventArgs>(engine_AudioLevelUpdated);
                speechRecognitionEngine.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(engine_SpeechRecognized);

                // load dictionary
                loadGrammarAndCommands();

                // use the system's default microphone
                speechRecognitionEngine.SetInputToDefaultAudioDevice();

                // start listening
                speechRecognitionEngine.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Voice recognition failed");
            }
        }

        private void LoadPatient(string PatientID)
        {
            surnametTxt.Text = Global._patients.First(k => k.Id.Contains(PatientID)).Surname;
            lastnameTxt.Text = Global._patients.First(k => k.Id.Contains(PatientID)).Lastname;
            nameLbl.Text = surnametTxt.Text + " " + lastnameTxt.Text;
            noLbl.Text = Global._patients.First(k => k.Id.Contains(PatientID)).PatientNo;
            contactTxt.Text = Global._patients.First(k => k.Id.Contains(PatientID)).Contact;
            Image img = Base64ToImage(Global._patients.First(k => k.Id.Contains(PatientID)).Image);
            System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(img);
            //Bitmap bps = new Bitmap(bmp, 50, 50);
            imgCapture.Image = bmp;
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

        private void chkBxTimerEnabled_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBxTimerEnabled.Checked && !bgWrkTimer.IsBusy)
            {
                RunTimer();
            }
        }

        private void RunTimer()
        {
            int waitFor = randGen.Next(valueGenTimerFrom, valueGenTimerTo);
            bgWrkTimer.RunWorkerAsync(waitFor);
        }

        private void bgWrkTimer_DoWork(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep(Convert.ToInt32(e.Argument));
        }

        private void bgWrkTimer_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            int genValue = randGen.Next(valueGenFrom, valueGenTo);

            perfChart.AddValue(genValue);

            if (chkBxTimerEnabled.Checked)
            {
                //Simply restart, if still enabled
                RunTimer();
            }
        }
        void adddevice()
        {
            try
            {  //add device n os
                Process p = Process.Start("C:\\Windows\\System32\\DevicePairingWizard.exe");//here write ur own windows drive
                while (true)
                {
                    if (p.HasExited) //determine if process end
                        break;
                }
                //generate busy com ort list
                List<string> tList = new List<string>();

                listBox1.Items.Clear();
                foreach (string s in SerialPort.GetPortNames())
                {
                    tList.Add(s);
                }
                tList.Sort();
                listBox1.Items.Add("NO PORT");
                listBox1.Items.AddRange(tList.ToArray());
                listBox1.SelectedIndex = 0;
                richTextBox1.Text = richTextBox1.Text + Environment.NewLine + "COMPORT GENERATED";
            }
            catch (Exception ee)
            {
                if (DialogResult.Retry == MessageBox.Show("CANT FIND UR ADDED DEVICE..", "Problem occured", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error))
                    adddevice();
            }
        }
        bool connectbluetooth()
        {
            try
            {
                if (listBox1.SelectedIndex != 0)
                {
                    scom = listBox1.SelectedItem.ToString();
                    port = new SerialPort(scom, 9600, Parity.None, 8, StopBits.One);
                    port.Open();
                    richTextBox1.Text = richTextBox1.Text + Environment.NewLine + "CONNECTION OPEN SUCCESSFUL"; ;
                    return true;
                }
                else
                    MessageBox.Show("Please select com port", "Missing port", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            catch (Exception a)
            {
                if (DialogResult.Retry == MessageBox.Show(a.Message, "problem occured", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Warning))
                    connectbluetooth();
                else
                    return false;
                return false;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (testCbx.Text == "Urinalysis")
            {

                UrinalysisTest fmr = new UrinalysisTest();
                fmr.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {

        }
      
       
       
       
        string noteID = "";
        private void LoadNotes(string visitID)
        {
            _notes = Notes.ListNotes(visitID);
            foreach (Notes r in _notes)
            {
                consultTxt.Text = r.Patient;
                consultTxt.Text = r.Consultant;
                treatmentTxt.Text = r.Treatment;
                noteID = r.Id;
            }
        }
      

        private void textBox29_TextChanged(object sender, EventArgs e)
        {

        }
        string testID;
      

        private void button2_Click(object sender, EventArgs e)
        {


        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (!String.IsNullOrEmpty(noteID))
            {
                if (MessageBox.Show("YES or No?", "Would you want to update these notes? ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    _note = new Notes(noteID, queueID, PatientID, PractitionerID, consultTxt.Text, consultTxt.Text, treatmentTxt.Text, DateTime.Now.ToString("dd-MM-yyyy H:mm:ss"), Helper.orgID);
                    DBConnect.Update(_note, noteID);
                    MessageBox.Show("Information updated ");
                }
                return;
            }

            string id = Guid.NewGuid().ToString();
            if (!String.IsNullOrEmpty(consultTxt.Text) && !String.IsNullOrEmpty(consultTxt.Text))
            {
                _note = new Notes(id, queueID, PatientID, PractitionerID, consultTxt.Text, consultTxt.Text, treatmentTxt.Text, DateTime.Now.ToString("dd-MM-yyyy H:mm:ss"), Helper.orgID);
                DBConnect.Insert(_note);
                LoadNotes(queueID);
                MessageBox.Show("Information saved ");
            }

        }
      


        #region internal functions and methods

        /// <summary>
        /// Creates the speech engine.
        /// </summary>
        /// <param name="preferredCulture">The preferred culture.</param>
        /// <returns></returns>
        private SpeechRecognitionEngine createSpeechEngine(string preferredCulture)
        {
            foreach (RecognizerInfo config in SpeechRecognitionEngine.InstalledRecognizers())
            {
                if (config.Culture.ToString() == preferredCulture)
                {
                    speechRecognitionEngine = new SpeechRecognitionEngine(config);
                    break;
                }
            }

            // if the desired culture is not found, then load default
            if (speechRecognitionEngine == null)
            {
                MessageBox.Show("The desired culture is not installed on this machine, the speech-engine will continue using "
                    + SpeechRecognitionEngine.InstalledRecognizers()[1].Culture.ToString() + " as the default culture.",
                    "Culture " + preferredCulture + " not found!");
                speechRecognitionEngine = new SpeechRecognitionEngine(SpeechRecognitionEngine.InstalledRecognizers()[0]);
            }

            return speechRecognitionEngine;
        }

        /// <summary>
        /// Loads the grammar and commands.
        /// </summary>
        private void loadGrammarAndCommands()
        {
            Choices texts = new Choices();
            //try
            //{



            foreach (Tests t in Global._tests)
            {


                // add commandItem to the list for later lookup or execution
                words.Add(new Word() { Text = t.Parameter, AttachedText = t.Id, IsShellCommand = false });

                // add the text to the known choices of speechengine
                texts.Add(t.Parameter);
            }
            //words.Add(new Word() { Text = "wordpad", AttachedText = "wordpad.exe", IsShellCommand = true });
            //words.Add(new Word() { Text = "calculator", AttachedText = "calc.exe", IsShellCommand = true });

            //// add the text to the known choices of speechengine
            //texts.Add("wordpad");
            //texts.Add("calculator");

            Grammar wordsList = new Grammar(new GrammarBuilder(texts));
            speechRecognitionEngine.LoadGrammar(wordsList);
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        }

        /// <summary>
        /// Gets the known command.
        /// </summary>
        /// <param name="command">The order.</param>
        /// <returns></returns>
        private string getKnownTextOrExecute(string command)
        {
            try
            {
                var cmd = words.Where(c => c.Text == command).First();

                if (cmd.IsShellCommand)
                {
                    Process proc = new Process();
                    proc.EnableRaisingEvents = false;
                    proc.StartInfo.FileName = cmd.AttachedText;
                    proc.Start();
                    return "you just started : " + cmd.AttachedText;
                }
                else
                {
                    return cmd.AttachedText;
                }
            }
            catch (Exception)
            {
                return command;
            }
        }

        #endregion

        #region speechEngine events

        /// <summary>
        /// Handles the SpeechRecognized event of the engine control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Speech.Recognition.SpeechRecognizedEventArgs"/> instance containing the event data.</param>
        void engine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            //txtSpoken.Text += "\r" + getKnownTextOrExecute(e.Result.Text);
            /////scvText.ScrollToEnd();
            //Console.WriteLine("SEE" + e.Result.Text);
            //try
            //{
            //    testsTxt.Text = e.Result.Text;

            //    var testID = getKnownTextOrExecute(e.Result.Text);

            //    testsTxt.Text = testsTxt.Text + " Specimen:" + Global._tests.First(w => w.Id.Contains(testID)).SpecimenID + "\r\nType:" + Global._tests.First(w => w.Id.Contains(testID)).Type + "\r\nLower Limit:" + Global._tests.First(w => w.Id.Contains(testID)).Lower + "\r\nUpper Limit:" + Global._tests.First(w => w.Id.Contains(testID)).Upper + "\r\n" + Global._tests.First(w => w.Id.Contains(testID)).Description + "\r\nGender:" + Global._tests.First(w => w.Id.Contains(testID)).Gender;

            //}
            //catch
            //{

            //    testsTxt.Text = "Cant find the test";
            //}

        }

        /// <summary>
        /// Handles the AudioLevelUpdated event of the engine control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Speech.Recognition.AudioLevelUpdatedEventArgs"/> instance containing the event data.</param>
        void engine_AudioLevelUpdated(object sender, AudioLevelUpdatedEventArgs e)
        {
           // prgLevel.Value = e.AudioLevel;
        }

        #endregion

        #region window closing

        /// <summary>
        /// Handles the Closing event of the Window control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.ComponentModel.CancelEventArgs"/> instance containing the event data.</param>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // unhook events
            speechRecognitionEngine.RecognizeAsyncStop();
            // clean references
            speechRecognitionEngine.Dispose();
        }

        #endregion

        #region GUI events


        #endregion

        private void LoadDiagnosis(string visitID)
        {
            _diags = Diagnosis.ListDiagnosis(visitID);
            tb = new DataTable();
            // create and execute query 
            tb.Columns.Add("id");//2 
            tb.Columns.Add("Diagnosis");//2
            tb.Columns.Add("Code");//2
            tb.Columns.Add("Notes");//
            tb.Columns.Add("Treatment");//
            tb.Columns.Add("Cancel");//
            foreach (Diagnosis r in _diags)
            {
                tb.Rows.Add(new object[] { r.Id, r.Name,r.Code, r.Notes, r.Treatment, "Cancel" });
            }
            dtDiag.DataSource = tb;
            dtDiag.AllowUserToAddRows = false;
            dtDiag.Columns["Cancel"].DefaultCellStyle.BackColor = Color.OrangeRed;
            dtDiag.Columns["id"].Visible = false;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }
        private Diagnosis _diag;
        private List<Diagnosis> _diags;
       
      
        private void y(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

       
        private List<Services> _services;
        private Services _service;
        private void button18_Click_1(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(QueueNo))
            {
                MessageBox.Show("Please input the VISIT NO/ID");
                return;
            }
            using (RequestDialog form = new RequestDialog(PatientID, queueID, QueueNo))
            {
                // DentalDialog form1 = new DentalDialog(item.Text, TransactorID);
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    //MessageBox.Show(form.state);
                 
                    LoadServices(visitLbl.Text);

                }
            }
        }

        double diagTotal = 0;
        
        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void diagnosisCbx_Leave(object sender, EventArgs e)
        {
            try
            {
                var value = cdDictionary.FirstOrDefault(x => x.Value.Contains(diagnosisCbx.Text)).Key;
                codeTxt.Text = value;// cdDictionary[diagnosisCbx.Text];
            }
            catch {

            }
        }

        private void codeTxt_Leave(object sender, EventArgs e)
        {
            try
            {
               
                diagnosisCbx.Text = cdDictionary[codeTxt.Text];
            }
            catch
            {

            }

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void txtSpoken_TextChanged(object sender, EventArgs e)
        {

        }


        private void button2_Click_3(object sender, EventArgs e)
        {
            string id = "";
            id = Guid.NewGuid().ToString();
            if (!String.IsNullOrEmpty(diagnosisCbx.Text))
            {
                Diagnosis _diag = new Diagnosis(id, diagnosisCbx.Text,visitLbl.Text, queueID, PatientID, codeTxt.Text,treatmentTxt.Text,consultTxt.Text, DateTime.Now.ToString("dd-MM-yyyy H:mm:ss"), Helper.orgID, Helper.UserID);
                DBConnect.Insert(_diag);
                MessageBox.Show("Information added/Saved");
                LoadDiagnosis(visitLbl.Text);
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(QueueNo))
            {
                MessageBox.Show("Please input the VISIT NO/ID");
                return;
            }
            using (ReferDialog form = new ReferDialog(PatientID, queueID, QueueNo))
            {
                // DentalDialog form1 = new DentalDialog(item.Text, TransactorID);
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                   
                   // LoadServices(queueID);

                }
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {

        }
    }
}
