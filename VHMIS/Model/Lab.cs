using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VHMIS.Model
{
   public class Lab
    {
        private string id;
        private string queueID;
        private string patientID;
        private string test;
        private string cost;
        private string created;
        private string qty;
        private string total;
        private string orgID;
        private string no;
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
        public string QueueID
        {
            get
            {
                return queueID;
            }

            set
            {
                queueID = value;
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

        public string Test
        {
            get
            {
                return test;
            }

            set
            {
                test = value;
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

        public string Qty
        {
            get
            {
                return qty;
            }

            set
            {
                qty = value;
            }
        }

        public string Total
        {
            get
            {
                return total;
            }

            set
            {
                total = value;
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

        public string No
        {
            get
            {
                return no;
            }

            set
            {
                no = value;
            }
        }

        public Lab(string id, string queueID, string patientID, string test, string cost, string created, string qty, string total, string orgID,string no)
        {
            this.Id = id;
            this.QueueID = queueID;
            this.PatientID = patientID;
            this.Test = test;
            this.Cost = cost;
            this.Created = created;
            this.Qty = qty;
            this.Total = total;
            this.OrgID = orgID;
            this.No = no;
        }

        public static List<Lab> ListLab(string visitID)
        {
            DBConnect.OpenConn();
            List<Lab> clinics = new List<Lab>();
            string SQL = "SELECT * FROM lab WHERE queueID= '" + visitID + "' ";
            NpgsqlCommand command = new NpgsqlCommand(SQL, DBConnect.conn);
            NpgsqlDataReader Reader = command.ExecuteReader();
            while (Reader.Read())
            {
                Lab p = new Lab(Reader["id"].ToString(), Reader["queueID"].ToString(), Reader["patientID"].ToString(), Reader["test"].ToString(),Reader["cost"].ToString(), Reader["created"].ToString(), Reader["qty"].ToString(), Reader["total"].ToString(), Reader["orgid"].ToString(), Reader["no"].ToString());
                clinics.Add(p);
            }
            DBConnect.CloseConn();

            return clinics;

        }
    }
}
