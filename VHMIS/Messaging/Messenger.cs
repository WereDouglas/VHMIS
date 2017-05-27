using GsmComm.GsmCommunication;
using GsmComm.PduConverter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using VHMIS.Model;

namespace VHMIS.Messaging
{
    public class Messenger
    {
        private static GsmCommMain comm;
        private delegate void SetTextCallback(string text);
        private static string cmbCOM;
        private static Message _message;


        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int description, int reservedValue);

        public static bool IsInternetAvailable()
        {
            int description;
            return InternetGetConnectedState(out description, 0);
        }


        public static string Send(string message, string number)
        {
          
            string state;
            try
            {
                SmsSubmitPdu pdu;
                byte dcs = (byte)DataCodingScheme.GeneralCoding.Alpha7BitDefault;
                pdu = new SmsSubmitPdu(message, Convert.ToString(number), dcs);
                int times = 1;
                for (int i = 0; i < times; i++)
                {
                    comm.SendMessage(pdu);
                    _message = new Message();
                   
                }
                state = "sent";

            }
            catch (Exception r)
            {
                state = "not sent " + r;
                MainForm._Form1.FeedBack("Exception " + r.Message.ToString());
            }
            return state;
        }
        public static bool ports = false;
        public static bool state;
        public static bool connect()
        {
            state = false;
            int d = 0;
            do
            {
                d++;
                cmbCOM = "COM" + d.ToString();
                comm = new GsmCommMain(cmbCOM, 9600, 150);
                Console.WriteLine(cmbCOM);
                MainForm._Form1.FeedBack("COMM: " + cmbCOM);

                if (comm.IsConnected())
                {
                    MainForm._Form1.FeedBack("comm is already open");
                    Console.WriteLine("comm is already open");
                    state = true;
                    break;
                }
                else
                {
                    MainForm._Form1.FeedBack("comm is not open");
                    Console.WriteLine("comm is not open");
                    try
                    {
                        comm.Open();
                        state = true;
                    }
                    catch (Exception k)
                    {
                        MainForm._Form1.FeedBack("COMM: " +k.Message.ToString()) ;

                        state = false;
                        continue;

                    }
                }
            }
            while (!comm.IsConnected() && d < 30);

            Console.WriteLine(cmbCOM);
            MainForm._Form1.FeedBack("COMM" + cmbCOM);
            return state;

        }
        public static bool connects()
        {

            cmbCOM = "COM20";
            comm = new GsmCommMain(cmbCOM, 9600, 150);
            Console.WriteLine(cmbCOM);

            if (comm.IsConnected())
            {
                MainForm._Form1.FeedBack("comm is already open");
                state = true;

            }
            else
            {
                Console.WriteLine("comm is not open");
                MainForm._Form1.FeedBack("comm is not open");
                try
                {
                    comm.Open();
                    state = true;
                }
                catch (Exception p)
                {

                    state = false;
                    MainForm._Form1.FeedBack(" Error" + p.Message.ToString());


                }

            }

            Console.WriteLine(cmbCOM);
            return state;

        }

    }
}