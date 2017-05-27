using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VHMIS.Model
{
    public class Theatre
    {
        private string id;
        private string departmentID;
        private string procedure;
        private string surgeonfee;
        private string anaethetist;
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

        public string Procedure
        {
            get
            {
                return procedure;
            }

            set
            {
                procedure = value;
            }
        }

        public string Surgeonfee
        {
            get
            {
                return surgeonfee;
            }

            set
            {
                surgeonfee = value;
            }
        }

        public string Anaethetist
        {
            get
            {
                return anaethetist;
            }

            set
            {
                anaethetist = value;
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

        public Theatre(string id, string departmentID, string procedure, string surgeonfee, string anaethetist, string created)
        {
            this.Id = id;
            this.DepartmentID = departmentID;
            this.Procedure = procedure;
            this.Surgeonfee = surgeonfee;
            this.Anaethetist = anaethetist;
            this.Created = created;
        }

        public static List<Theatre> ListTheatre()
        {
            DBConnect.OpenConn();
            List<Theatre> theatre = new List<Theatre>();
            string SQL = "SELECT * FROM theatre";
            NpgsqlCommand command = new NpgsqlCommand(SQL, DBConnect.conn);
            NpgsqlDataReader Reader = command.ExecuteReader();
            while (Reader.Read())
            {
                Theatre p = new Theatre(Reader["id"].ToString(), Reader["departmentID"].ToString(), Reader["procedure"].ToString(), Reader["surgeonfee"].ToString(), Reader["anaethetist"].ToString(),Reader["created"].ToString());
                theatre.Add(p);
            }
            DBConnect.CloseConn();
            return theatre;

        }
    }
}
