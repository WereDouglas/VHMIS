using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VHMIS.Model;

namespace VHMIS
{
    public class Uploading
    {
        public Uploading()
        {

        }
        public static bool CheckServer()
        {
            string query = "SELECT * FROM users";
            string URL = Helper.genUrl + "api/request";
            NameValueCollection formData = new NameValueCollection();
            formData["query"] = query;
            string resulted = Helper.get(URL, formData);
            if (resulted != "false")
            {
                return true;
            }
            else
            {
                return true;
            }
        }
     
        public static void Users()
        {
            foreach (var h in Global._users.Where(e => Convert.ToDateTime(e.Created) > Convert.ToDateTime(Helper.lastSync)))
            {
                string Query2 = "DELETE from users WHERE id ='" + h.Id + "'";

                MainForm._Form1.FeedBack("Uploading users " + h.Surname + " " + h.Contact);
               Users _user = new Users(h.Id, h.IdNo, h.Contact, h.Contact2, h.Surname, h.Lastname, h.Email, h.Nationality, h.Address,h.Kin,h.Kincontact, h.Passwords,h.Designation,h.Roles, h.Gender,h.Image,h.ClinicID,h.ClinicDesignation, h.InitialPassword, h.Account, h.Status, h.Practice,h.Specialisation,h.Sub, DateTime.Now.ToString("dd-MM-yyyy H:mm:ss"), h.Department,h.OrgID);
                string Query = DBConnect.GenerateQuery(_user);
                // MainForm._Form1.FeedBack("QUERY " + Query);
                string URL = Helper.genUrl + "api/uploading";
                NameValueCollection formData = new NameValueCollection();
                formData["save"] = Query;
                formData["delete"] = Query2;
                string results = Helper.send(URL, formData);
                if (results == "true")
                {
                    MainForm._Form1.FeedBack("Uploading Successful " + h.Surname + " " + h.Contact);
                }
                else
                {
                    MainForm._Form1.FeedBack("Uploading failed " + h.Surname + " " + h.Contact);
                }
            }
            MainForm._Form1.FeedBack("Uploading users complete ");
        }
       
        public static void Patients()
        {
            //.Where(e => Convert.ToDateTime(e.Created) > Convert.ToDateTime(Helper.lastSync))
            foreach (var h in Global._patients)
            {
                string Query2 = "DELETE from patient WHERE id ='" + h.Id + "'";

                MainForm._Form1.FeedBack("Uploading users " + h.Surname + " " + h.Contact);
               Patient _patient = new Patient(h.Id, h.PatientNo, h.Contact, h.Surname, h.Lastname, h.Email,h.Dob ,h.Nationality, h.Address,h.Kin,h.Kincontact, h.Gender,h.Image, DateTime.Now.ToString("dd-MM-yyyy H:mm:ss"), h.Religion,h.Blood,h.OrgID);
                string Query = DBConnect.GenerateQuery(_patient);
                // MainForm._Form1.FeedBack("QUERY " + Query);
                string URL = Helper.genUrl + "api/uploading";
                NameValueCollection formData = new NameValueCollection();
                formData["save"] = Query;
                formData["delete"] = Query2;
                string results = Helper.send(URL, formData);
                if (results == "true")
                {
                    MainForm._Form1.FeedBack("Uploading Successful " + h.Surname + " " + h.Contact);
                }
                else
                {
                    MainForm._Form1.FeedBack("Uploading failed " + h.Surname + " " + h.Contact);
                }
            }
            MainForm._Form1.FeedBack("Uploading patients complete ");
        }
        public static void Events()
        {
            //.Where(e => Convert.ToDateTime(e.Created) > Convert.ToDateTime(Helper.lastSync))
            foreach (var h in Global._events)
            {
                string Query2 = "DELETE from events WHERE id ='" + h.Id + "'";

                MainForm._Form1.FeedBack("Uploading events " + h.Details + " " + h.Contact);
                Events _event = new Events(h.Id,h.Details,h.Starts, h.Ends, h.Users, h.Patient, h.Created, h.Patientid, h.Status, h.Userid, h.Dated, h.Notif, h.Sync, h.Sync, h.Cal, h.Contact+"",h.Email+"",h.Department,h.Clinic,h.OrgID);
                string Query = DBConnect.GenerateQuery(_event);
             
                string URL = Helper.genUrl + "api/uploading";
                NameValueCollection formData = new NameValueCollection();
                formData["save"] = Query;
                formData["delete"] = Query2;
                string results = Helper.send(URL, formData);
                if (results == "true")
                {
                    MainForm._Form1.FeedBack("Uploading Successful " + h.Details + " " + h.Contact);
                }
                else
                {
                    MainForm._Form1.FeedBack("Uploading failed " + h.Details + " " + h.Contact);
                }
            }
            MainForm._Form1.FeedBack("Uploading events complete ");
        }
        public static void updateSyncTime()
        {
            try
            {

                string Query3 = "UPDATE organisation SET sync='" + DateTime.Now.AddMinutes(-10).ToString("dd-MM-yyyy HH:mm:ss") + "'";
                DBConnect.save(Query3);
                Helper.lastSync = DateTime.Now.AddMinutes(-10).ToString("yyyy-MM-dd HH:mm:ss");
            }
            catch
            {
                string Query3 = "UPDATE organisation SET sync='" + DateTime.Now.AddMinutes(-10).ToString("dd-MM-yyyy HH:mm:ss") + "'";
                DBConnect.save(Query3);
                Helper.lastSync = DateTime.Now.AddMinutes(-10).ToString("dd-MM-yyyy HH:mm:ss");
            }
        }
    }
}
