using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VHMIS.Model
{
    public class Queue
    {
        private string id;
        private  string follow;
        private string patientID;
        private string userID;
        private string roomID;
        private string clinicID;
        private string department;
        private string status;
        private string dated;
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

        public String Follow
        {
            get
            {
                return follow;
            }

            set
            {
                follow = value;
            }
        }

        public string PatientID
        {
            get
            {
                return patientID;
            }

            set
            {
                patientID = value;
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

        public string Status
        {
            get
            {
                return status;
            }

            set
            {
                status = value;
            }
        }

        public string Dated
        {
            get
            {
                return dated;
            }

            set
            {
                dated = value;
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

        public string RoomID
        {
            get
            {
                return roomID;
            }

            set
            {
                roomID = value;
            }
        }

        public string ClinicID
        {
            get
            {
                return clinicID;
            }

            set
            {
                clinicID = value;
            }
        }

        public string Department
        {
            get
            {
                return department;
            }

            set
            {
                department = value;
            }
        }

        public Queue(string id, string follow, string patientID, string userID, string roomID, string clinicID, string status, string dated, string created,string department)
        {
            this.Id = id;
            this.Follow = follow;
            this.PatientID = patientID;
            this.UserID = userID;
            this.RoomID = roomID;
            this.ClinicID = clinicID;
            this.Status = status;
            this.Dated = dated;
            this.Created = created;
            this.Department = department;
        }

        public static List<Queue> ListQueue()
        {
            DBConnect.OpenConn();

            List<Queue> queue = new List<Queue>();
            string SQL = "SELECT * FROM queue";
            NpgsqlCommand command = new NpgsqlCommand(SQL, DBConnect.conn);
            NpgsqlDataReader Reader = command.ExecuteReader();

            while (Reader.Read())
            {
                Queue p = new Queue(Reader["id"].ToString(), Reader["follow"].ToString(), Reader["patientID"].ToString(), Reader["userID"].ToString(), Reader["roomID"].ToString(), Reader["clinicID"].ToString(), Reader["status"].ToString(), Reader["dated"].ToString(), Reader["created"].ToString(), Reader["department"].ToString());
                queue.Add(p);
            }
            DBConnect.CloseConn();

            return queue;

        }
    }
}
