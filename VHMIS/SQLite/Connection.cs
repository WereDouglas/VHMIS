using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VHMIS.SQLite
{
    public class Connection
    {
        static Connection dbobject = new Connection();
        static SQLiteConnection SQLconnect = new SQLiteConnection();
        public string datalocation()
        {
            string path = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string appPath = Path.GetDirectoryName(Application.ExecutablePath);
            //   string fullFilePath = Path.Combine(appPath, "casesLite.txt");
            string dir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            return "Data Source=" + dir + "\\vhmis.bbs;";
            /// 
            // Helper.GrantAccess(appPath + "\\pos.bbs;");
            // return "Data Source=" + appPath + "\\pos.bbs;";
        }
        public static string XMLFile()
        {
            string path = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string appPath = Path.GetDirectoryName(Application.ExecutablePath);
            string dir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            return dir + "\\DBHMIS.xml";

        }
        public static void createSQLLiteDB(String SQL)
        {


            // string fullFilePath = Path.Combine(appPath, "casesLite.txt");

            //try
            //{
            SQLconnect.ConnectionString = dbobject.datalocation();
            SQLconnect.Open();

            SQLiteCommand SQLcommand = new SQLiteCommand();
            SQLcommand = SQLconnect.CreateCommand();
            //CreateDBSQL(Object objGen)

            SQLcommand.CommandText = SQL;
            //  SQLcommand.CommandText = "CREATE TABLE IF NOT EXISTS business ( Username TEXT, Password TEXT);";
            ///////
            SQLcommand.ExecuteNonQuery();
            SQLcommand.Dispose();
            SQLconnect.Close();
            //}
            //catch (Exception p)
            //{
            //    MessageBox.Show(p.Message.ToString());

            //}


        }


    }
}