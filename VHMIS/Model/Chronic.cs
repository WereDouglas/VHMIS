using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VHMIS.Model
{
   public class Chronic
    {
        private string id;
        private string name;
        private string description;
        private string patientID;
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

        public string Description
        {
            get
            {
                return description;
            }

            set
            {
                description = value;
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

        public Chronic(string id, string name, string description, string patientID, string created)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
            this.PatientID = patientID;
            this.Created = created;
        }

        public static List<Chronic> ListChronic(string PatientID)
        {
            DBConnect.OpenConn();
            List<Chronic> clinics = new List<Chronic>();
            string SQL = "SELECT * FROM chronic WHERE patientID= '"+PatientID+"'";
            NpgsqlCommand command = new NpgsqlCommand(SQL, DBConnect.conn);
            NpgsqlDataReader Reader = command.ExecuteReader();

            while (Reader.Read())
            {
                Chronic p = new Chronic(Reader["id"].ToString(), Reader["name"].ToString(), Reader["description"].ToString(), Reader["patientID"].ToString(), Reader["created"].ToString());
                clinics.Add(p);
            }
            DBConnect.CloseConn();

            return clinics;

        }
    }
}
