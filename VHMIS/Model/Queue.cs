using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VHMIS.Model
{
    public class Queue
    {
        private string id;
        private string follow;
        private string patientID;
        private string userID;
        private string roomID;
        private string clinicID;
        private string department;
        private string status;
        private string dated;
        private string created;
        private string consultation_paid;
        private string investigation_paid;
        private string lab_paid;
        private string pharmacy_paid;
        private string lab_complete;
        private string consultation_complete;
        private string remarks;
        private string other;
        private string no;
        private string orgID;
        private string type;
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

        public string Follow
        {
            get
            {
                return follow;
            }

            set
            {
                follow = value;
            }
        }

        public string PatientID
        {
            get
            {
                return patientID;
            }

            set
            {
                patientID = value;
            }
        }

        public string UserID
        {
            get
            {
                return userID;
            }

            set
            {
                userID = value;
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

        public string RoomID
        {
            get
            {
                return roomID;
            }

            set
            {
                roomID = value;
            }
        }

        public string ClinicID
        {
            get
            {
                return clinicID;
            }

            set
            {
                clinicID = value;
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

        public string Consultation_paid
        {
            get
            {
                return consultation_paid;
            }

            set
            {
                consultation_paid = value;
            }
        }

        public string Investigation_paid
        {
            get
            {
                return investigation_paid;
            }

            set
            {
                investigation_paid = value;
            }
        }

        public string Lab_paid
        {
            get
            {
                return lab_paid;
            }

            set
            {
                lab_paid = value;
            }
        }

        public string Pharmacy_paid
        {
            get
            {
                return pharmacy_paid;
            }

            set
            {
                pharmacy_paid = value;
            }
        }

        public string Lab_complete
        {
            get
            {
                return lab_complete;
            }

            set
            {
                lab_complete = value;
            }
        }

        public string Consultation_complete
        {
            get
            {
                return consultation_complete;
            }

            set
            {
                consultation_complete = value;
            }
        }

        public string Remarks
        {
            get
            {
                return remarks;
            }

            set
            {
                remarks = value;
            }
        }

        public string Other
        {
            get
            {
                return other;
            }

            set
            {
                other = value;
            }
        }

        public string No
        {
            get
            {
                return no;
            }

            set
            {
                no = value;
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

        public string Type
        {
            get
            {
                return type;
            }

            set
            {
                type = value;
            }
        }
        public Queue() { }
        public Queue(string id, string follow, string patientID, string userID, string roomID, string status, string dated, string created, string clinicID, string department, string consultation_paid, string investigation_paid, string lab_paid, string pharmacy_paid, string lab_complete, string consulation_complete, string remarks, string other, string no, string orgID, string type)
        {
            this.Id = id;
            this.Follow = follow;
            this.PatientID = patientID;
            this.UserID = userID;
            this.RoomID = roomID;
            this.ClinicID = clinicID;
            this.Status = status;
            this.Dated = dated;
            this.Created = created;
            this.Department = department;
            this.Consultation_paid = consultation_paid;
            this.Investigation_paid = investigation_paid;
            this.Lab_paid = lab_paid;
            this.Pharmacy_paid = pharmacy_paid;
            this.Lab_complete = lab_complete;
            this.Consultation_complete = consulation_complete;
            this.Remarks = remarks;
            this.Other = other;
            this.No = no;
            this.OrgID = orgID;
            this.Type = type;
        }

        public static List<Queue> ListQueue()
        {
            List<Queue> queue = new List<Queue>();
            string SQL = "SELECT * FROM queue";
            if (Helper.Type != "Lite")
            {
                NpgsqlDataReader Reader = DBConnect.Reading(SQL);
                while (Reader.Read())
                {
                    Queue p = new Queue(Reader["id"].ToString(), Reader["follow"].ToString(), Reader["patientID"].ToString(), Reader["userID"].ToString(), Reader["roomID"].ToString(), Reader["status"].ToString(), Reader["dated"].ToString(), Reader["created"].ToString(), Reader["clinicid"].ToString(), Reader["department"].ToString(), Reader["consultation_paid"].ToString(), Reader["investigation_paid"].ToString(), Reader["lab_paid"].ToString(), Reader["pharmacy_paid"].ToString(), Reader["lab_complete"].ToString(), Reader["consultation_complete"].ToString(), Reader["remarks"].ToString(), Reader["other"].ToString(), Reader["no"].ToString(), Reader["orgid"].ToString(), Reader["type"].ToString());
                    queue.Add(p);
                }
                Reader.Close();
                DBConnect.CloseConn();
            }
            else
            {
                SQLiteDataReader Reader = DBConnect.ReadingLite(SQL);
                while (Reader.Read())
                {
                    Queue p = new Queue(Reader["id"].ToString(), Reader["follow"].ToString(), Reader["patientID"].ToString(), Reader["userID"].ToString(), Reader["roomID"].ToString(), Reader["status"].ToString(), Reader["dated"].ToString(), Reader["created"].ToString(), Reader["clinicid"].ToString(), Reader["department"].ToString(), Reader["consultation_paid"].ToString(), Reader["investigation_paid"].ToString(), Reader["lab_paid"].ToString(), Reader["pharmacy_paid"].ToString(), Reader["lab_complete"].ToString(), Reader["consultation_complete"].ToString(), Reader["remarks"].ToString(), Reader["other"].ToString(), Reader["no"].ToString(), Reader["orgid"].ToString(), Reader["type"].ToString());
                    queue.Add(p);
                }
                Reader.Close();
            }
            return queue;

        }
        public static List<Queue> ListQueue(string Date)
        {           
            List<Queue> queue = new List<Queue>();
           
            if (Helper.Type != "Lite")
            {
                string SQL = "SELECT * FROM queue WHERE dated::date = '" + Date + "'::date ";
                NpgsqlDataReader Reader = DBConnect.Reading(SQL);
                while (Reader.Read())
                {
                    Queue p = new Queue(Reader["id"].ToString(), Reader["follow"].ToString(), Reader["patientID"].ToString(), Reader["userID"].ToString(), Reader["roomID"].ToString(), Reader["status"].ToString(), Reader["dated"].ToString(), Reader["created"].ToString(), Reader["clinicid"].ToString(), Reader["department"].ToString(), Reader["consultation_paid"].ToString(), Reader["investigation_paid"].ToString(), Reader["lab_paid"].ToString(), Reader["pharmacy_paid"].ToString(), Reader["lab_complete"].ToString(), Reader["consultation_complete"].ToString(), Reader["remarks"].ToString(), Reader["other"].ToString(), Reader["no"].ToString(), Reader["orgid"].ToString(), Reader["type"].ToString());
                    queue.Add(p);
                }
                Reader.Close();
                DBConnect.CloseConn();
            }
            else
            {
                string SQL = "SELECT * FROM queue ";
                SQLiteDataReader Reader = DBConnect.ReadingLite(SQL);
                while (Reader.Read())
                {
                    Queue p = new Queue(Reader["id"].ToString(), Reader["follow"].ToString(), Reader["patientID"].ToString(), Reader["userID"].ToString(), Reader["roomID"].ToString(), Reader["status"].ToString(), Reader["dated"].ToString(), Reader["created"].ToString(), Reader["clinicid"].ToString(), Reader["department"].ToString(), Reader["consultation_paid"].ToString(), Reader["investigation_paid"].ToString(), Reader["lab_paid"].ToString(), Reader["pharmacy_paid"].ToString(), Reader["lab_complete"].ToString(), Reader["consultation_complete"].ToString(), Reader["remarks"].ToString(), Reader["other"].ToString(), Reader["no"].ToString(), Reader["orgid"].ToString(), Reader["type"].ToString());
                    queue.Add(p);
                }
                Reader.Close();
            }
            return queue;

        }
    }
}
