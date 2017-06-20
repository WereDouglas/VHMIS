using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VHMIS.Model
{
    public class Branch
    {

        private string id;
        private string name;
        private string location;
        private string address;
        private string contact;
        private string created;
        private string orgID;
        private string code;

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

        public string Location
        {
            get
            {
                return location;
            }

            set
            {
                location = value;
            }
        }

        public string Address
        {
            get
            {
                return address;
            }

            set
            {
                address = value;
            }
        }

        public string Contact
        {
            get
            {
                return contact;
            }

            set
            {
                contact = value;
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

        public Branch(string id, string name, string location, string address, string contact, string created, string orgID, string code)
        {
            this.Id = id;
            this.Name = name;
            this.Location = location;
            this.Address = address;
            this.Contact = contact;
            this.Created = created;
            this.OrgID = orgID;
            this.Code = code;
        }
        public Branch() { }

        public static List<Branch> ListBranch()
        {
            string SQL = "SELECT * FROM branch";
            List<Branch> wards = new List<Branch>();
            if (Helper.Type != "Lite")
            {
                DBConnect.OpenConn();

                NpgsqlDataReader Reader = DBConnect.Reading(SQL);
                while (Reader.Read())
                {
                    Branch p = new Branch(Reader["id"].ToString(), Reader["name"].ToString(), Reader["location"].ToString(), Reader["address"].ToString(), Reader["contact"].ToString(), Reader["created"].ToString(), Reader["orgid"].ToString(), Reader["code"].ToString());
                    wards.Add(p);
                }
                DBConnect.CloseConn();
            }
            else
            {
                SQLiteDataReader Reader = DBConnect.ReadingLite(SQL);
                while (Reader.Read())
                {
                    Branch p = new Branch(Reader["id"].ToString(), Reader["name"].ToString(), Reader["location"].ToString(), Reader["address"].ToString(), Reader["contact"].ToString(), Reader["created"].ToString(), Reader["orgID"].ToString(), Reader["code"].ToString());
                    wards.Add(p);
                }
                Reader.Close();
                DBConnect.CloseConn();
            }
            return wards;

        }
          
    }
}
