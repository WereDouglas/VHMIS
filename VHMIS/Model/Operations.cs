using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VHMIS.Model
{
   public class Operations
    {

        private string id;
        private string departmentID;       
        private string code;
        private string service;
        private string cost;
        private string other;               
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

        public string Service
        {
            get
            {
                return service;
            }

            set
            {
                service = value;
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

        public Operations(string id, string departmentID, string code, string service, string cost, string other, string created)
        {
            this.Id = id;
            this.DepartmentID = departmentID;
            this.Code = code;
            this.Service = service;
            this.Cost = cost;
            this.Other = other;
            this.Created = created;
        }
        public static List<Operations> ListOperations()
        {
            DBConnect.OpenConn();
            List<Operations> wards = new List<Operations>();
            string SQL = "SELECT * FROM operations";
            NpgsqlCommand command = new NpgsqlCommand(SQL, DBConnect.conn);
            NpgsqlDataReader Reader = command.ExecuteReader();
            while (Reader.Read())
            {
                Operations p = new Operations(Reader["id"].ToString(), Reader["departmentID"].ToString(), Reader["code"].ToString(), Reader["service"].ToString(), Reader["cost"].ToString(), Reader["other"].ToString(),Reader["created"].ToString());
                wards.Add(p);
            }
            DBConnect.CloseConn();
            return wards;

        }
    }
}
