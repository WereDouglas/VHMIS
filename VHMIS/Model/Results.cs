using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VHMIS.Model
{
    public class Results
    {

        private string id;
        private string queueID;
        private string patientID;
        private string labID;
        private string userID;
        private string notes;
        private string examination;
        private string deduction;
        private string image;
        private string created;
        private string orgID;
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

        public string QueueID
        {
            get
            {
                return queueID;
            }

            set
            {
                queueID = value;
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

        public string LabID
        {
            get
            {
                return labID;
            }

            set
            {
                labID = value;
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

        public string Notes
        {
            get
            {
                return notes;
            }

            set
            {
                notes = value;
            }
        }

        public string Examination
        {
            get
            {
                return examination;
            }

            set
            {
                examination = value;
            }
        }

        public string Deduction
        {
            get
            {
                return deduction;
            }

            set
            {
                deduction = value;
            }
        }

        public string Image
        {
            get
            {
                return image;
            }

            set
            {
                image = value;
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
        public Results() { }
        public Results(string id, string queueID, string patientID, string labID, string userID, string notes, string examination, string deduction, string image, string created, string orgID)
        {
            this.Id = id;
            this.QueueID = queueID;
            this.PatientID = patientID;
            this.LabID = labID;
            this.UserID = userID;
            this.Notes = notes;
            this.Examination = examination;
            this.Deduction = deduction;
            this.Image = image;
            this.Created = created;
            this.OrgID = orgID;
        }

        public static List<Results> ListResults(string visitID)
        {
            DBConnect.OpenConn();
            List<Results> clinics = new List<Results>();
            string SQL = "SELECT * FROM results WHERE queueID= '" + visitID + "' ";
            if (Helper.Type != "Lite")
            {
                NpgsqlDataReader Reader = DBConnect.Reading(SQL);
                while (Reader.Read())
                {
                    Results p = new Results(Reader["id"].ToString(), Reader["queueID"].ToString(), Reader["patientID"].ToString(), Reader["labID"].ToString(), Reader["userID"].ToString(), Reader["notes"].ToString(), Reader["examination"].ToString(), Reader["deduction"].ToString(), Reader["image"].ToString(), Reader["created"].ToString(), Reader["orgid"].ToString());
                    clinics.Add(p);
                }
                DBConnect.CloseConn();
            }
            else
            {
                SQLiteDataReader Reader = DBConnect.ReadingLite(SQL);
                while (Reader.Read())
                {
                    Results p = new Results(Reader["id"].ToString(), Reader["queueID"].ToString(), Reader["patientID"].ToString(), Reader["labID"].ToString(), Reader["userID"].ToString(), Reader["notes"].ToString(), Reader["examination"].ToString(), Reader["deduction"].ToString(), Reader["image"].ToString(), Reader["created"].ToString(), Reader["orgid"].ToString());
                    clinics.Add(p);
                }
                Reader.Close();

            }

            return clinics;

        }
    }
}
