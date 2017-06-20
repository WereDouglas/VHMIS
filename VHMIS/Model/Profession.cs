using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VHMIS.Model
{
    public class Profession
    {
        private string id;
        private string title;
        private string userID;
        private string licence;
        private string licenseExp;
        private string boardReg;
        private string boardExp;
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

        public string Title
        {
            get
            {
                return title;
            }

            set
            {
                title = value;
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

        public string Licence
        {
            get
            {
                return licence;
            }

            set
            {
                licence = value;
            }
        }

        public string LicenseExp
        {
            get
            {
                return licenseExp;
            }

            set
            {
                licenseExp = value;
            }
        }

        public string BoardReg
        {
            get
            {
                return boardReg;
            }

            set
            {
                boardReg = value;
            }
        }

        public string BoardExp
        {
            get
            {
                return boardExp;
            }

            set
            {
                boardExp = value;
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
        public Profession() { }
        public Profession(string id, string title, string userID, string licence, string licenseExp, string boardReg, string boardExp, string created, string orgID)
        {
            this.Id = id;
            this.Title = title;
            this.UserID = userID;
            this.Licence = licence;
            this.LicenseExp = licenseExp;
            this.BoardReg = boardReg;
            this.BoardExp = boardExp;
            this.Created = created;
            this.OrgID = orgID;
        }

        public static List<Profession> ListProfession()
        {
            DBConnect.OpenConn();
            List<Profession> lists = new List<Profession>();
            string SQL = "SELECT * FROM profession";
            if (Helper.Type != "Lite")
            {
                NpgsqlDataReader Reader = DBConnect.Reading(SQL);
                while (Reader.Read())
            {
                Profession p = new Profession(Reader["id"].ToString(), Reader["title"].ToString(), Reader["userID"].ToString(), Reader["license"].ToString(), Reader["licenseExp"].ToString(), Reader["boardReg"].ToString(), Reader["boardExp"].ToString(), Reader["created"].ToString(), Reader["orgid"].ToString());
                lists.Add(p);
            }
            DBConnect.CloseConn();
            }
            else
            {
                SQLiteDataReader Reader = DBConnect.ReadingLite(SQL);
                while (Reader.Read())
                {
                    Profession p = new Profession(Reader["id"].ToString(), Reader["title"].ToString(), Reader["userID"].ToString(), Reader["license"].ToString(), Reader["licenseExp"].ToString(), Reader["boardReg"].ToString(), Reader["boardExp"].ToString(), Reader["created"].ToString(), Reader["orgid"].ToString());
                    lists.Add(p);
                }
                Reader.Close();

            }

            return lists;

        }
    }
}
