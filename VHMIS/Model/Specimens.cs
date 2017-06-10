using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VHMIS.Model
{
    public class Specimens
    {
        private string id;
        private string code;
        private string name;
        private string service;
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

        public Specimens(string id, string code, string name, string service, string created, string orgID)
        {
            this.Id = id;
            this.Code = code;
            this.Name = name;
            this.Service = service;
            this.Created = created;
            this.OrgID = orgID;
        }

        public static List<Specimens> ListSpecimens()
        {           
            DBConnect.OpenConn();

            List<Specimens> spec = new List<Specimens>();
            string SQL = "SELECT * FROM specimens";
            NpgsqlCommand command = new NpgsqlCommand(SQL, DBConnect.conn);
            NpgsqlDataReader Reader = command.ExecuteReader();

            while (Reader.Read())
            {                  
                    Specimens p = new Specimens(Reader["id"].ToString(), Reader["code"].ToString(), Reader["name"].ToString(),Reader["service"].ToString(), Reader["created"].ToString(), Reader["orgid"].ToString());
                spec.Add(p);   
            }
            DBConnect.CloseConn();

            return spec;
            
        }
    }
}
