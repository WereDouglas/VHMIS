using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VHMIS.Model
{
   public class Clinics
    {
        private string id;
        private string name;
        private string maxs;
        private string mins;
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

        public string Maxs
        {
            get
            {
                return maxs;
            }

            set
            {
                maxs = value;
            }
        }

        public string Mins
        {
            get
            {
                return mins;
            }

            set
            {
                mins = value;
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
        public Clinics() { }
        public Clinics(string id, string name, string maxs, string mins, string created, string orgID)
        {
            this.Id = id;
            this.Name = name;
            this.Maxs = maxs;
            this.Mins = mins;
            this.Created = created;
            this.OrgID = orgID;
        }

        public static List<Clinics> ListClinic()
        {
            List<Clinics> clinics = new List<Clinics>();
            string SQL = "SELECT * FROM clinics";
            if (Helper.Type != "Lite")
            {                      
                NpgsqlDataReader Reader = DBConnect.Reading(SQL);
                while (Reader.Read())
                {
                    Clinics p = new Clinics(Reader["id"].ToString(), Reader["name"].ToString(), Reader["maxs"].ToString(), Reader["mins"].ToString(), Reader["created"].ToString(), Reader["orgid"].ToString());
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
                    Clinics p = new Clinics(Reader["id"].ToString(), Reader["name"].ToString(), Reader["maxs"].ToString(), Reader["mins"].ToString(), Reader["created"].ToString(), Reader["orgid"].ToString());
                    clinics.Add(p);
                }
                Reader.Close();

            }

            return clinics;

        }
    }
}
