using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VHMIS.Model
{
   public class Departments
    {

        private string id;
        private string name;
        private string regno;
        private string license;
        private string expiry;
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

        public string Regno
        {
            get
            {
                return regno;
            }

            set
            {
                regno = value;
            }
        }

        public string License
        {
            get
            {
                return license;
            }

            set
            {
                license = value;
            }
        }

        public string Expiry
        {
            get
            {
                return expiry;
            }

            set
            {
                expiry = value;
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

        public Departments(string id, string name, string regno, string license, string expiry, string code, string created, string orgID)
        {
            this.Id = id;
            this.Name = name;
            this.Regno = regno;
            this.License = license;
            this.Expiry = expiry;
            this.Code = code;
            this.Created = created;
            this.OrgID = orgID;
        }

        public static List<Departments> ListDepartment()
        {
            DBConnect.OpenConn();

            List<Departments> departments = new List<Departments>();
            string SQL = "SELECT * FROM departments";
            NpgsqlCommand command = new NpgsqlCommand(SQL, DBConnect.conn);
            NpgsqlDataReader Reader = command.ExecuteReader();

            while (Reader.Read())
            {
                Departments p = new Departments(Reader["id"].ToString(), Reader["name"].ToString(), Reader["regno"].ToString(), Reader["license"].ToString(), Reader["expiry"].ToString(), Reader["code"].ToString(), Reader["created"].ToString(), Reader["orgid"].ToString());
                departments.Add(p);

            }
            DBConnect.CloseConn();

            return departments;

        }
    }
}
