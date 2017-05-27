using Npgsql;
using System;
using System.Collections.Generic;
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

        public Discipline(string id, string name, string code, string created)
        {
            this.Id = id;
            this.Name = name;
            this.Code = code;
            this.Created = created;
        }

        public static List<Discipline> ListDiscipline()
        {
            DBConnect.OpenConn();

            List<Discipline> patients = new List<Discipline>();
            string SQL = "SELECT * FROM discipline";
            NpgsqlCommand command = new NpgsqlCommand(SQL, DBConnect.conn);
            NpgsqlDataReader Reader = command.ExecuteReader();

            while (Reader.Read())
            {

                Discipline p = new Discipline(Reader["id"].ToString(), Reader["name"].ToString(), Reader["code"].ToString(), Reader["created"].ToString());
                patients.Add(p);

            }
            DBConnect.CloseConn();

            return patients;

        }
    }
}
