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
using VHMIS.Messaging;
using VHMIS.Model;

namespace VHMIS
{
    public partial class MainForm : Form
    {
        SerialPort srpModemPort = null;
        SerialPort s;
        SpeechRecognitionEngine speechRecognitionEngine = null;
        List<Word> words = new List<Word>();
        public static MainForm _Form1;
        private BackgroundWorker bw_message = new BackgroundWorker();
        private BackgroundWorker bw_upload = new BackgroundWorker();
        private BackgroundWorker bwLite = new BackgroundWorker();
        string start;
        string end;
        public MainForm()
        {
            start = DateTime.Now.ToString("dd-MM-yyyy");
            end = DateTime.Now.ToString("dd-MM-yyyy");
            Helper.orgID = "test";
            InitializeComponent();
            Global.LoadData(start,end);

            LoadVoice();

            _Form1 = this;
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 1 * 60 * 100;
            timer.Elapsed += timer_Elapsed;
            timer.Start();

            bw_message.DoWork += backgroundWorker1_DoWork;
            bw_message.ProgressChanged += backgroundWorker1_ProgressChanged;
            bw_message.WorkerReportsProgress = true;

            bwLite.DoWork += backgroundWorker1_Upload;
            bwLite.ProgressChanged += backgroundWorker1_ProgressChanged;
            bwLite.WorkerReportsProgress = true;


        }
        private void backgroundWorker1_Upload(object sender, System.ComponentModel.DoWorkEventArgs e)
        {

            if (Uploading.CheckServer())
            {

                for (int i = 0; i < 16; i++)
                {
                    FeedBack("PROCESS " + i.ToString());
                    //try
                    //{
                    process(i);
                    //}
                    //catch (Exception c)
                    //{
                    //    FeedBack("PROCESSING ERROR " + i.ToString() + " " + c.Message.ToString());
                    //}

                    bwLite.ReportProgress(i);
                    Thread.Sleep(1500);

                }
            }
            else
            {

                FeedBack("No internet connection ");
                bwLite.Dispose();


            }

        }
        private void process(int count)
        {
            int val = count;
            switch (val)
            {
                case 1:
                    Uploading.Patients();

                    break;
                case 2:
                    Uploading.Users();
                    break;
                case 3:
                    Uploading.Events();
                    break;

                case 14:

                    if (Uploading.CheckServer())
                    {
                        Uploading.updateSyncTime();
                        FeedBack("Uploading and Downloading of information complete");

                        FeedBack("LAST SYNC " + Helper.lastSync);
                        bwLite.Dispose();
                        return;
                    }
                    else
                    {
                        FeedBack("No valid connection ");

                    }
                    break;
                default:
                    FeedBack("Processing");
                    break;
            }

        }

        void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (!bwLite.IsBusy)
            {
                bwLite.RunWorkerAsync();
            }
            if (!bw_message.IsBusy)
            {
                bw_message.RunWorkerAsync();
            }

        }
        public void FeedBack(string text)
        {
            try
            {
                Invoke((MethodInvoker)delegate
                {

                    // onlineLbl.Text = "Last:  " + Helper.lastSync;
                    processLbl.Text = processLbl.Text + text + "\r\n";
                    processLbl.ForeColor = Color.Black;
                });
            }
            catch
            {


            }

        }
        public void GetPort(string comport)
        {
            if (this.s == null)
            {
                this.s = new SerialPort();
                this.s.PortName = comport;
                this.s.Open();
                this.s.BaudRate = 9600;
                this.s.Parity = Parity.None;
                this.s.DataBits = 8;
                this.s.StopBits = StopBits.One;
                //this.s.Handshake = Handshake.RequestToSend;
                this.s.DtrEnable = true;
                this.s.RtsEnable = true;
                //this.s.RtsEnable = true;
                this.s.NewLine = System.Environment.NewLine;
                this.s.WriteLine("AT" + (char)(13));
                string tt = s.ReadLine();
                if (s.ReadLine() != "AT/r/r")
                {
                    Thread.Sleep(2000);
                    this.s.WriteLine("AT+CMGF=1" + (char)(13));
                    Thread.Sleep(3000);
                    this.s.WriteLine("AT+CMGS=\"" + 8050398620 + "\"");
                    Thread.Sleep(5000);
                    this.s.WriteLine(">" + "le" + (char)(26));
                    this.s.Close();
                }
                else
                {
                    MessageBox.Show("Dervice Nt");
                }
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void registrationToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripSplitButton3_ButtonClick(object sender, EventArgs e)
        {

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            InPatient frm = new InPatient(null, null, null);
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            frm.Show();

        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            OutPatient frm = new OutPatient(null, null, null);
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            frm.Show();

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void calendarAndSchedulesToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void queueWaitingListToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {

        }

        private void patientVisitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PatientVisit frm = new PatientVisit(null, null, null);
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void listToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void registerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (PractitionerRegistration form = new PractitionerRegistration())
            {
                // DentalDialog form1 = new DentalDialog(item.Text, TransactorID);
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {


                }
            }
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
           

        }

        private void viewAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewUsers frm = new ViewUsers();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void clinicsToolStripMenuItem_Click(object sender, EventArgs e)
        {
           

        }

        private void wardsToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void departmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void disciplinesToolStripMenuItem_Click(object sender, EventArgs e)
        {
           

        }

        private void testsToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void proceduresToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
        }

        private void operationsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
           
        }

        private void bedsToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void categoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void specimensToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
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


            //words.Add(new Word() { Text = "wordpad", AttachedText = "wordpad.exe", IsShellCommand = true });
            //words.Add(new Word() { Text = "calculator", AttachedText = "calc.exe", IsShellCommand = true });
            words.Add(new Word() { Text = "calendar", AttachedText = "calendar", IsShellCommand = false });
            words.Add(new Word() { Text = "queue", AttachedText = "queue", IsShellCommand = false });
            words.Add(new Word() { Text = "in", AttachedText = "in", IsShellCommand = false });
            words.Add(new Word() { Text = "out", AttachedText = "out", IsShellCommand = false });
            words.Add(new Word() { Text = "patients", AttachedText = "patients", IsShellCommand = false });

            // add the text to the known choices of speechengine
            //texts.Add("wordpad");
            //texts.Add("calculator");
            texts.Add("calendar");
            texts.Add("queue");
            texts.Add("in");
            texts.Add("out");
            texts.Add("patients");

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
            string cmd = getKnownTextOrExecute(e.Result.Text);

            try
            {
                //var said = getKnownTextOrExecute(e.Result.Text);
                //if (said=="calendar") {
                //    CalenderForm frm = new CalenderForm();
                //    frm.MdiParent = this;
                //    frm.Dock = DockStyle.Fill;
                //    frm.Show();

                //}
                //if (said == "queue")
                //{
                //    QueueForm frm = new QueueForm();
                //    frm.MdiParent = this;
                //    frm.Dock = DockStyle.Fill;
                //    frm.Show();
                //}
                //if (said == "in")
                //{
                //    InPatient frm = new InPatient();
                //    frm.MdiParent = this;
                //    frm.Dock = DockStyle.Fill;
                //    frm.Show();
                //}
                //if (said == "out")
                //{
                //    OutPatient frm = new OutPatient();
                //    frm.MdiParent = this;
                //    frm.Dock = DockStyle.Fill;
                //    frm.Show();
                //}
                //if (said == "patients")
                //{
                //    ViewPatient frm = new ViewPatient();
                //    frm.MdiParent = this;
                //    frm.Dock = DockStyle.Fill;
                //    frm.Show();
                //}

            }
            catch
            {

            }

        }

        /// <summary>
        /// Handles the AudioLevelUpdated event of the engine control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Speech.Recognition.AudioLevelUpdatedEventArgs"/> instance containing the event data.</param>
        void engine_AudioLevelUpdated(object sender, AudioLevelUpdatedEventArgs e)
        {
            //  prgLevel.Value = e.AudioLevel;
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

        private void toolStripSplitButton15_ButtonClick(object sender, EventArgs e)
        {
            if (processLbl.Visible == true)
            {
                processLbl.Visible = false;
            }
            else
            {
                processLbl.Visible = true;
            }

        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            //Messenger.connect();
            Messenger.connects();
            if (!Messenger.state)
            {
                FeedBack("Modem not connected.... " + DateTime.Now.ToString());
            }
            else
            {

                foreach (Events c in Global._events.Where(o => o.Notif.Contains("true") && o.Dated.Contains(DateTime.Now.ToString("yyyy-MM-dd"))))
                {
                    FeedBack("PROCESS " + c.Patient + " " + c.Contact);
                    try
                    {
                        string info = Messenger.Send(c.Details, c.Contact.Trim());
                        if (info == "sent")
                        {
                            string SQL = "UPDATE events SET notify = 'false', WHERE id= '" + c.Id + "'";

                            DBConnect.Execute(SQL);

                            FeedBack("Message sent to: " + c.Patient + " Contact: " + c.Contact + "  " + DateTime.Now.ToString());

                        }
                        else
                        {

                            FeedBack("Message not sent : " + c.Patient + " Contact: " + c.Contact + "  " + DateTime.Now.ToString());
                        }
                    }
                    catch (Exception k)
                    {
                        FeedBack("PROCESSING ERROR " + k.Message.ToString());
                    }
                    Thread.Sleep(1500);

                }
            }

        }
        private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            try
            {
                toolStripProgressBar1.Value = e.ProgressPercentage;
            }
            catch { }
        }

        private void toolStripSplitButton9_ButtonClick(object sender, EventArgs e)
        {
            DentalForm frm = new DentalForm(null, null, null);
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void registerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            using (PatientRegistration form = new PatientRegistration())
            {             
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {


                }
            }
        }

        private void viewAllToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ViewPatient frm = new ViewPatient();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            QueueForm frm = new QueueForm();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {

            CalenderForm frm = new CalenderForm();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void cD10DiagnosisToolStripMenuItem_Click(object sender, EventArgs e)
        {
           

        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            PharmacyForm frm = new PharmacyForm();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            frm.Show();

        }

        private void profileToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void referalsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void bokingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (BookingDiag form = new BookingDiag())
            {
                // DentalDialog form1 = new DentalDialog(item.Text, TransactorID);
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    // MessageBox.Show(form.state);

                }
            }
        }
        Roles _role;
        private void MainForm_Load(object sender, EventArgs e)
        {
           
           
            using (LoginForm form = new LoginForm())
            {
                // DentalDialog form1 = new DentalDialog(item.Text, TransactorID);
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    // MessageBox.Show(form.state);
                    LoadProfile();
                }
            }
        }
        private void LoadProfile()
        {
            nameLbl.Text = Helper.Username;
            Image img = Base64ToImage(Helper.Image);
            System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(img);
            imageDropDown.Image = bmp;

        }
        static string base64String = null;
        public System.Drawing.Image Base64ToImage(string bases)
        {
            byte[] imageBytes = Convert.FromBase64String(bases);
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
            ms.Write(imageBytes, 0, imageBytes.Length);
            System.Drawing.Image image = System.Drawing.Image.FromStream(ms, true);
            return image;
        }

        private void roomsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RoomForm frm = new RoomForm();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            AdmissionForm frm = new AdmissionForm();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
          
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {

            QueueForm frm = new QueueForm();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            CalenderForm frm = new CalenderForm();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void processLbl_TextChanged(object sender, EventArgs e)
        {
            processLbl.SelectionStart = processLbl.Text.Length;
            processLbl.ScrollToCaret();
        }

        private void toolStripButton4_Click_1(object sender, EventArgs e)
        {
            using (EventDialog form = new EventDialog())
            {
                // DentalDialog form1 = new DentalDialog(item.Text, TransactorID);
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                   

                }
            }
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            DepartmentForm frm = new DepartmentForm();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void toolStripMenuItem9_Click_1(object sender, EventArgs e)
        {
            RoleForm frm = new RoleForm();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            ClinicForm frm = new ClinicForm();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem13_Click(object sender, EventArgs e)
        {
            WardForm frm = new WardForm();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            RoomForm frm = new RoomForm();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void toolStripMenuItem14_Click(object sender, EventArgs e)
        {
            OperationForm frm = new OperationForm();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void toolStripMenuItem16_Click(object sender, EventArgs e)
        {
            TestForm frm = new TestForm();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void toolStripMenuItem17_Click(object sender, EventArgs e)
        {
            DisciplineForm frm = new DisciplineForm();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton9_Click_1(object sender, EventArgs e)
        {
            DashBoard frm = new DashBoard();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void toolStripMenuItem18_Click(object sender, EventArgs e)
        {
            BedForm frm = new BedForm();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            frm.Show();

        }

        private void toolStripMenuItem19_Click(object sender, EventArgs e)
        {
            CategoryForm frm = new CategoryForm();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void toolStripMenuItem20_Click(object sender, EventArgs e)
        {
            SpecimenForm frm = new SpecimenForm();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void toolStripMenuItem21_Click(object sender, EventArgs e)
        {
            CdForm frm = new CdForm();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void toolStripMenuItem22_Click(object sender, EventArgs e)
        {
            ProfileForm frm = new ProfileForm("");
            frm.MdiParent = this;
            //frm.Dock = DockStyle.Fill;
            frm.Show();
        }
    }
}
