using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VHMIS
{
    public class Events
    {
        private string id;
        private string details;
        private string starts;
        private string ends;
        private string users;
        private string patient;
        private string created;
        private string patientid;
        private string status;
        private string userid;
        private string dated;
        private string notif;
        private string priority;
        private string sync;
        private string cal;
        private string contact;
        private string email;
        private string department;
        private string clinic;
        private string orgID;
        public Events(string id, string details, string starts, string ends, string users, string patient, string created, string patientid, string status, string userid, string dated, string notif, string priority, string sync, string cal, string contact, string email,string department,string clinic, string orgID)
        {
            this.id = id;
            this.details = details;
            this.starts = starts;
            this.ends = ends;
            this.users = users;
            this.patient = patient;
            this.created = created;
            this.patientid = patientid;
            this.status = status;
            this.userid = userid;
            this.dated = dated;
            this.notif = notif;
            this.priority = priority;
            this.sync = sync;
            this.cal = cal;
            this.email = contact;
            this.department = department;
            this.clinic = clinic;
            this.OrgID = orgID;
        }

        public string Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Details
        {
            get
            {
                return details;
            }

            set
            {
                details = value;
            }
        }

        public string Starts
        {
            get
            {
                return starts;
            }

            set
            {
                starts = value;
            }
        }

        public string Ends
        {
            get
            {
                return ends;
            }

            set
            {
                ends = value;
            }
        }

        public string Users
        {
            get
            {
                return users;
            }

            set
            {
                users = value;
            }
        }

        public string Patient
        {
            get
            {
                return patient;
            }

            set
            {
                patient = value;
            }
        }

        public string Created
        {
            get
            {
                return created;
            }

            set
            {
                created = value;
            }
        }

        public string Patientid
        {
            get
            {
                return patientid;
            }

            set
            {
                patientid = value;
            }
        }

        public string Status
        {
            get
            {
                return status;
            }

            set
            {
                status = value;
            }
        }

        public string Userid
        {
            get
            {
                return userid;
            }

            set
            {
                userid = value;
            }
        }

        public string Dated
        {
            get
            {
                return dated;
            }

            set
            {
                dated = value;
            }
        }

        public string Notif
        {
            get
            {
                return notif;
            }

            set
            {
                notif = value;
            }
        }

        public string Priority
        {
            get
            {
                return priority;
            }

            set
            {
                priority = value;
            }
        }

        public string Sync
        {
            get
            {
                return sync;
            }

            set
            {
                sync = value;
            }
        }

        public string Cal
        {
            get
            {
                return cal;
            }

            set
            {
                cal = value;
            }
        }

        public string Contact
        {
            get
            {
                return contact;
            }

            set
            {
                contact = value;
            }
        }

        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
            }
        }

        public string Department
        {
            get
            {
                return department;
            }

            set
            {
                department = value;
            }
        }

        public string Clinic
        {
            get
            {
                return clinic;
            }

            set
            {
                clinic = value;
            }
        }

        public string OrgID
        {
            get
            {
                return orgID;
            }

            set
            {
                orgID = value;
            }
        }

        public static List<Events> ListEvents()
        {           
            DBConnect.OpenConn();

            List<Events> events = new List<Events>();
            string SQL = "SELECT * FROM events";
            NpgsqlCommand command = new NpgsqlCommand(SQL, DBConnect.conn);
            NpgsqlDataReader Reader = command.ExecuteReader();

            while (Reader.Read())
            {  
               
                    Events p = new Events(Reader["id"].ToString(), Reader["details"].ToString(), Reader["starts"].ToString(), Reader["ends"].ToString(), Reader["users"].ToString(), Reader["patient"].ToString(), Reader["created"].ToString(), Reader["patientid"].ToString(), Reader["status"].ToString(), Reader["userid"].ToString(), Reader["dated"].ToString(), Reader["notif"].ToString(), Reader["priority"].ToString(), Reader["sync"].ToString(), Reader["cal"].ToString(), Reader["contact"].ToString(), Reader["email"].ToString(),Reader["department"].ToString(), Reader["clinic"].ToString(), Reader["orgid"].ToString());
                events.Add(p);                

            }
            DBConnect.CloseConn();

            return events;
            
        }
    }
}
