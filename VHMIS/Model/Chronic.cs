using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
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
        public Chronic() { }
        public Chronic(string id, string name, string description, string patientID, string created, string orgID)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
            this.PatientID = patientID;
            this.Created = created;
            this.OrgID = orgID;
        }

        public static List<Chronic> ListChronic(string PatientID)
        {
            List<Chronic> clinics = new List<Chronic>();
            string SQL = "SELECT * FROM chronic WHERE patientID= '" + PatientID + "'";
            if (Helper.Type != "Lite")
            {
                DBConnect.OpenConn();
                NpgsqlDataReader Reader = DBConnect.Reading(SQL);
                while (Reader.Read())
                {
                    Chronic p = new Chronic(Reader["id"].ToString(), Reader["name"].ToString(), Reader["description"].ToString(), Reader["patientID"].ToString(), Reader["created"].ToString(), Reader["orgid"].ToString());
                    clinics.Add(p);
                }
                Reader.Close();
                DBConnect.CloseConn();
            }

            else
            {
                SQLiteDataReader Reader = DBConnect.ReadingLite(SQL);
                while (Reader.Read())
                {
                    Chronic p = new Chronic(Reader["id"].ToString(), Reader["name"].ToString(), Reader["description"].ToString(), Reader["patientID"].ToString(), Reader["created"].ToString(), Reader["orgid"].ToString());
                    clinics.Add(p);
                }
                Reader.Close();
            }

            return clinics;

        }
    }
}
