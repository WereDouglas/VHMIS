using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VHMIS.Model
{
   public class Vitals
    {
        private string id;
        private string queueID;
        private string patientID;
        private string parameter;
        private string reading;
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

        public string Parameter
        {
            get
            {
                return parameter;
            }

            set
            {
                parameter = value;
            }
        }

        public string Reading
        {
            get
            {
                return reading;
            }

            set
            {
                reading = value;
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

        public Vitals(string id, string queueID, string patientID, string parameter, string reading, string created)
        {
            this.Id = id;
            this.QueueID = queueID;
            this.PatientID = patientID;
            this.Parameter = parameter;
            this.Reading = reading;
            this.Created = created;
        }

        public static List<Vitals> ListVitals(string visitID)
        {
            DBConnect.OpenConn();

            List<Vitals> clinics = new List<Vitals>();
            string SQL = "SELECT * FROM vitals WHERE queueID= '" + visitID + "' ";
            NpgsqlCommand command = new NpgsqlCommand(SQL, DBConnect.conn);
            NpgsqlDataReader Reader = command.ExecuteReader();
            while (Reader.Read())
            {
                Vitals p = new Vitals(Reader["id"].ToString(), Reader["queueID"].ToString(), Reader["patientID"].ToString(), Reader["parameter"].ToString(),Reader["reading"].ToString(), Reader["created"].ToString());
                clinics.Add(p);
            }
            DBConnect.CloseConn();

            return clinics;

        }
    }
}
