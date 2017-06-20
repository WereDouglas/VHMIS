using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VHMIS.Model
{
    public class Procedures
    {
        private string id;
        private string name;
        private string category;
        private string roleID;
        private string cost;
        private string departmentID;
        private string duration;
        private string code;
        private string gender;
        private string description;
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

        public string Category
        {
            get
            {
                return category;
            }

            set
            {
                category = value;
            }
        }

        public string RoleID
        {
            get
            {
                return roleID;
            }

            set
            {
                roleID = value;
            }
        }

        public string Cost
        {
            get
            {
                return cost;
            }

            set
            {
                cost = value;
            }
        }

        public string DepartmentID
        {
            get
            {
                return departmentID;
            }

            set
            {
                departmentID = value;
            }
        }

        public string Duration
        {
            get
            {
                return duration;
            }

            set
            {
                duration = value;
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

        public string Gender
        {
            get
            {
                return gender;
            }

            set
            {
                gender = value;
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
        public Procedures() { }
        public Procedures(string id, string name, string category, string roleID, string cost, string departmentID, string duration, string code, string gender, string description, string created, string orgID)
        {
            this.Id = id;
            this.Name = name;
            this.Category = category;
            this.RoleID = roleID;
            this.Cost = cost;
            this.DepartmentID = departmentID;
            this.Duration = duration;
            this.Code = code;
            this.Gender = gender;
            this.Description = description;
            this.Created = created;
            this.OrgID = orgID;
        }

        public static List<Procedures> ListProcedures()
        {
            List<Procedures> patients = new List<Procedures>();
            string SQL = "SELECT * FROM procedures";
            if (Helper.Type != "Lite")
            {
                NpgsqlDataReader Reader = DBConnect.Reading(SQL);
                while (Reader.Read())
                {
                    Procedures p = new Procedures(Reader["id"].ToString(), Reader["name"].ToString(), Reader["category"].ToString(), Reader["roleID"].ToString(), Reader["cost"].ToString(), Reader["departmentID"].ToString(), Reader["duration"].ToString(), Reader["code"].ToString(), Reader["gender"].ToString(), Reader["description"].ToString(), Reader["created"].ToString(), Reader["orgid"].ToString());
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
                    Procedures p = new Procedures(Reader["id"].ToString(), Reader["name"].ToString(), Reader["category"].ToString(), Reader["roleID"].ToString(), Reader["cost"].ToString(), Reader["departmentID"].ToString(), Reader["duration"].ToString(), Reader["code"].ToString(), Reader["gender"].ToString(), Reader["description"].ToString(), Reader["created"].ToString(), Reader["orgid"].ToString());
                    patients.Add(p);
                }
                Reader.Close();
            }

            return patients;

        }
    }
}
