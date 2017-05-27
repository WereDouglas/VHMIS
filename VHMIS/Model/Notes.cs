using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VHMIS.Model
{
   public class Notes
    {

        private string id;
        private string queueID;
        private string patientID;
        private string userID;
        private string patient;
        private string consultant;
        private string treatment;
        private string created;

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

        public string Consultant
        {
            get
            {
                return consultant;
            }

            set
            {
                consultant = value;
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

        public Notes(string id, string queueID, string patientID, string userID, string patient, string consultant, string treatment, string created)
        {
            this.Id = id;
            this.QueueID = queueID;
            this.PatientID = patientID;
            this.UserID = userID;
            this.Patient = patient;
            this.Consultant = consultant;
            this.Treatment = treatment;
            this.Created = created;
        }

        public static List<Notes> ListNotes(string visitID)
        {
            DBConnect.OpenConn();
            List<Notes> clinics = new List<Notes>();
            string SQL = "SELECT * FROM notes WHERE queueID= '"+visitID+"' ";
            NpgsqlCommand command = new NpgsqlCommand(SQL, DBConnect.conn);
            NpgsqlDataReader Reader = command.ExecuteReader();

            while (Reader.Read())
            {
                Notes p = new Notes(Reader["id"].ToString(), Reader["queueID"].ToString(), Reader["patientID"].ToString(), Reader["userID"].ToString(), Reader["patient"].ToString(), Reader["consultant"].ToString(), Reader["treatment"].ToString(), Reader["created"].ToString());
                clinics.Add(p);
            }
            DBConnect.CloseConn();

            return clinics;

        }
    }
}
