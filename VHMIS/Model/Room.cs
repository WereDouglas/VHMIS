using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VHMIS.Model
{
   public class Room
    {

        private string id;
        private string name;
        private string code;
        private string practitioner;
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

        public string Practitioner
        {
            get
            {
                return practitioner;
            }

            set
            {
                practitioner = value;
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

        public Room(string id, string name, string code, string practitioner, string description, string created, string orgID)
        {
            this.Id = id;
            this.Name = name;
            this.Code = code;
            this.Practitioner = practitioner;
            this.Description = description;
            this.Created = created;
            this.OrgID = orgID;
        }

        public static List<Room> ListRoom()
        {
            DBConnect.OpenConn();

            List<Room> wards = new List<Room>();
            string SQL = "SELECT * FROM room";
            NpgsqlCommand command = new NpgsqlCommand(SQL, DBConnect.conn);
            NpgsqlDataReader Reader = command.ExecuteReader();

            while (Reader.Read())
            {
                Room p = new Room(Reader["id"].ToString(), Reader["name"].ToString(), Reader["code"].ToString(), Reader["practitioner"].ToString(), Reader["description"].ToString(), Reader["created"].ToString(), Reader["orgid"].ToString());
                wards.Add(p);

            }
            DBConnect.CloseConn();

            return wards;

        }
    }
}
