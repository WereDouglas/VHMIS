using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VHMIS.Model
{
   public class Cd10
    {

        private string id;
        private string code;
        private string description;
        private string other;
        private string department;
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
        public Cd10() { }
        public Cd10(string id, string code, string description, string other, string department, string created, string orgID)
        {
            this.Id = id;
            this.Code = code;
            this.Description = description;
            this.Other = other;
            this.Department = department;
            this.Created = created;
            this.OrgID = orgID;
        }

        public static List<Cd10> ListCd10()
        {
            List<Cd10> wards = new List<Cd10>();
            string SQL = "SELECT * FROM cd10";
            if (Helper.Type != "Lite")
            {
                DBConnect.OpenConn();
                NpgsqlDataReader Reader = DBConnect.Reading(SQL);
                while (Reader.Read())
                {
                    Cd10 p = new Cd10(Reader["id"].ToString(), Reader["code"].ToString(), Reader["description"].ToString(), Reader["other"].ToString(), Reader["department"].ToString(), Reader["created"].ToString(), Reader["orgid"].ToString());
                    wards.Add(p);
                }
                Reader.Close();
                DBConnect.CloseConn();
            }
            else
            {
                SQLiteDataReader Reader = DBConnect.ReadingLite(SQL);
                while (Reader.Read())
                {
                    Cd10 p = new Cd10(Reader["id"].ToString(), Reader["code"].ToString(), Reader["description"].ToString(), Reader["other"].ToString(), Reader["department"].ToString(), Reader["created"].ToString(), Reader["orgid"].ToString());
                    wards.Add(p);
                }
                Reader.Close();

            }
            return wards;

        }
    }
}
