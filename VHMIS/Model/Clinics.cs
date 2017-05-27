using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VHMIS.Model
{
   public class Clinics
    {
        private string id;
        private string name;
        private string maxs;
        private string mins;
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

        public string Maxs
        {
            get
            {
                return maxs;
            }

            set
            {
                maxs = value;
            }
        }

        public string Mins
        {
            get
            {
                return mins;
            }

            set
            {
                mins = value;
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

        public Clinics(string id, string name, string maxs, string mins, string created)
        {
            this.Id = id;
            this.Name = name;
            this.Maxs = maxs;
            this.Mins = mins;
            this.Created = created;
        }

        public static List<Clinics> ListClinic()
        {
            DBConnect.OpenConn();

            List<Clinics> clinics = new List<Clinics>();
            string SQL = "SELECT * FROM clinics";
            NpgsqlCommand command = new NpgsqlCommand(SQL, DBConnect.conn);
            NpgsqlDataReader Reader = command.ExecuteReader();

            while (Reader.Read())
            {
                Clinics p = new Clinics(Reader["id"].ToString(), Reader["name"].ToString(), Reader["maxs"].ToString(), Reader["mins"].ToString(), Reader["created"].ToString());
                clinics.Add(p);
            }
            DBConnect.CloseConn();

            return clinics;

        }
    }
}
