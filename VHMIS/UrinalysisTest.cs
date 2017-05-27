using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VHMIS
{

    public partial class UrinalysisTest : Form
    {
        private object valueGenSync = new object();
        private Random randGen = new Random();

        private int valueGenFrom = 0;
        private int valueGenTo = 100;
        private int valueGenTimerFrom = 100;
        private int valueGenTimerTo = 1000;


        string InputData = String.Empty;
        delegate void SetTextCallback(string text);
        private SerialPort serialPort1;
        public UrinalysisTest()
        {
            InitializeComponent();
            perfChart.TimerInterval = 100;
            openPort();

        }
        private void chkBxTimerEnabled_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBxTimerEnabled.Checked && !bgWrkTimer.IsBusy)
            {
                RunTimer();
            }
        }
        private void openPort()
        {
            serialPort1 = new SerialPort();

            try
            {
          
            serialPort1.BaudRate = 9600;
            serialPort1.PortName = "COM8"; //incoming port
            serialPort1.DataBits = 8;
            serialPort1.DataReceived += new SerialDataReceivedEventHandler(DataReceive);
            serialPort1.Open();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                serialPort1.Close();
            }

        }
        string ph;
        string phValue;
        public void DataReceive(object obj, SerialDataReceivedEventArgs e)
        {
            InputData = serialPort1.ReadLine();
            if (InputData != String.Empty)
            {
                SetText(InputData);
                Console.Write(InputData);
                //LIGHT:233-MOISTURE:247-DEPTH:243-SMELL:240-Voltage:1.11-pH value: 3.89
                string[] words = InputData.Split('-');
                foreach (string word in words)
                {
                    Console.WriteLine(word);
                    if (word.ToLower().Contains("touch"))
                    {
                        string[] phs = word.Split(':');
                        phValue = phs[1];
                        SetText(phValue);
                        phValue = phValue.Replace("\r\n", "").Replace("\r", "").Replace("\n", "").Replace(" ", "");
                        SetGraph(Convert.ToInt32(Convert.ToDouble(phValue)));
                        Console.WriteLine("" + phValue);
                    }

                }
            }
        }

        private void SetText(string text)
        {

            if (this.textBox2.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });

                //int genValue = randGen.Next(valueGenFrom, valueGenTo);

                //perfChart.AddValue(genValue);

                //if (chkBxTimerEnabled.Checked)
                //{
                //    //Simply restart, if still enabled
                //    RunTimer();
                //}
            }
            else
            {
                textBox2.Text += text.Trim();
            }

        }
        private void SetGraph(int text)
        {

            int genValue = Convert.ToInt32(text);

            perfChart.AddValue(genValue);

            if (chkBxTimerEnabled.Checked)
            {
                //Simply restart, if still enabled
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
    }
}
