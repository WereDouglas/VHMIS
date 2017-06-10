using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VHMIS.Model
{
   public class Addiction
    {
        private string id;
        private string name;
        private string description;
        private string patientID;
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

        public Addiction(string id, string name, string description, string patientID, string created,string orgID)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
            this.PatientID = patientID;
            this.Created = created;
            this.OrgID = orgID;
        }

        public static List<Addiction> ListAddiction(string PatientID)
        {
            DBConnect.OpenConn();
            List<Addiction> clinics = new List<Addiction>();
            string SQL = "SELECT * FROM addiction WHERE patientID= '"+PatientID+"'";
            NpgsqlCommand command = new NpgsqlCommand(SQL, DBConnect.conn);
            NpgsqlDataReader Reader = command.ExecuteReader();

            while (Reader.Read())
            {
                Addiction p = new Addiction(Reader["id"].ToString(), Reader["name"].ToString(), Reader["description"].ToString(), Reader["patientID"].ToString(), Reader["created"].ToString(), Reader["orgid"].ToString());
                clinics.Add(p);
            }
            DBConnect.CloseConn();

            return clinics;

        }
    }
}
