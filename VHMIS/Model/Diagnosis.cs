using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VHMIS.Model
{
    public class Diagnosis
    {
        private string id;
        private string name;
        private string no;
        private string queueID;
        private string patientID;       
        private string code;        
        private string treatment;
        private string notes;
        private string created;
        private string orgID;
        private string userID;

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

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
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

        public string Code
        {
            get
            {
                return code;
            }

            set
            {
                code = value;
            }
        }

        public string Treatment
        {
            get
            {
                return treatment;
            }

            set
            {
                treatment = value;
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

        public Diagnosis() { }

        public Diagnosis(string id, string name, string no, string queueID, string patientID, string code, string treatment, string notes, string created, string orgID, string userID)
        {
            this.Id = id;
            this.Name = name;
            this.No = no;
            this.QueueID = queueID;
            this.PatientID = patientID;
            this.Code = code;
            this.Treatment = treatment;
            this.Notes = notes;
            this.Created = created;
            this.OrgID = orgID;
            this.UserID = userID;
        }

        public static List<Diagnosis> ListDiagnosis(string queueID)
        {
            List<Diagnosis> diagnosis = new List<Diagnosis>();
            string SQL = "SELECT * FROM diagnosis WHERE no ='" + queueID + "'";
            if (Helper.Type != "Lite")
            {              
                NpgsqlDataReader Reader = DBConnect.Reading(SQL);
                while (Reader.Read())
                {
                    Diagnosis p = new Diagnosis(Reader["id"].ToString(), Reader["name"].ToString(), Reader["no"].ToString(), Reader["queueid"].ToString(), Reader["patientid"].ToString(), Reader["code"].ToString(), Reader["treatment"].ToString(), Reader["notes"].ToString(), Reader["created"].ToString(), Reader["orgid"].ToString(), Reader["userid"].ToString());
                    diagnosis.Add(p);
                }
                Reader.Close();
                DBConnect.CloseConn();
            }
            else
            {
                SQLiteDataReader Reader = DBConnect.ReadingLite(SQL);
                while (Reader.Read())
                {
                    Diagnosis p = new Diagnosis(Reader["id"].ToString(), Reader["name"].ToString(), Reader["no"].ToString(), Reader["queueid"].ToString(), Reader["patientid"].ToString(), Reader["code"].ToString(), Reader["treatment"].ToString(), Reader["notes"].ToString(), Reader["created"].ToString(), Reader["orgid"].ToString(), Reader["userid"].ToString());
                    diagnosis.Add(p);
                }
                Reader.Close();

            }

            return diagnosis;

        }
    }
}
