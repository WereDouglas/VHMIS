using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VHMIS.Model
{
    public class Discipline
    {
        private string id;
        private string name;
        private string code;
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
        public Discipline() { }
        public Discipline(string id, string name, string code, string created, string orgID)
        {
            this.Id = id;
            this.Name = name;
            this.Code = code;
            this.Created = created;
            this.OrgID = orgID;
        }

        public static List<Discipline> ListDiscipline()
        {
            List<Discipline> patients = new List<Discipline>();
            string SQL = "SELECT * FROM discipline";

            if (Helper.Type != "Lite")
            {
                NpgsqlDataReader Reader = DBConnect.Reading(SQL);
                while (Reader.Read())
                {
                    Discipline p = new Discipline(Reader["id"].ToString(), Reader["name"].ToString(), Reader["code"].ToString(), Reader["created"].ToString(), Reader["orgid"].ToString());
                    patients.Add(p);
                }
                Reader.Close();
                DBConnect.CloseConn();
            }
            else
            {
                SQLiteDataReader Reader = DBConnect.ReadingLite(SQL);
                while (Reader.Read())
                {
                    Discipline p = new Discipline(Reader["id"].ToString(), Reader["name"].ToString(), Reader["code"].ToString(), Reader["created"].ToString(), Reader["orgid"].ToString());
                    patients.Add(p);
                }
                Reader.Close();
            }

            return patients;

        }
    }
}
