using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VHMIS.Model
{
   public class Beds
    {

        private string id;
        private string wardID;
        private string no;
        private string acc;
        private string rate;
        private string status;
        private string category;       
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

        public string WardID
        {
            get
            {
                return wardID;
            }

            set
            {
                wardID = value;
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

        public string Acc
        {
            get
            {
                return acc;
            }

            set
            {
                acc = value;
            }
        }

        public string Rate
        {
            get
            {
                return rate;
            }

            set
            {
                rate = value;
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

        public Beds(string id, string wardID, string no, string acc, string rate, string status, string category, string created, string orgID)
        {
            this.Id = id;
            this.WardID = wardID;
            this.No = no;
            this.Acc = acc;
            this.Rate = rate;
            this.Status = status;
            this.Category = category;
            this.Created = created;
            this.OrgID = orgID;
        }

        public static List<Beds> ListBeds()
        {
            DBConnect.OpenConn();
            List<Beds> wards = new List<Beds>();
            string SQL = "SELECT * FROM beds";
            NpgsqlCommand command = new NpgsqlCommand(SQL, DBConnect.conn);
            NpgsqlDataReader Reader = command.ExecuteReader();
            while (Reader.Read())
            {
                Beds p = new Beds(Reader["id"].ToString(), Reader["wardID"].ToString(), Reader["no"].ToString(), Reader["acc"].ToString(), Reader["rate"].ToString(), Reader["status"].ToString(), Reader["category"].ToString(),Reader["created"].ToString(), Reader["orgid"].ToString());
                wards.Add(p);
            }
            DBConnect.CloseConn();
            return wards;

        }
        public static List<Beds> ListBeds(string ward)
        {
            DBConnect.OpenConn();
            List<Beds> wards = new List<Beds>();
            string SQL = "SELECT * FROM beds WHERE wardid='" + ward + "'";
            NpgsqlCommand command = new NpgsqlCommand(SQL, DBConnect.conn);
            NpgsqlDataReader Reader = command.ExecuteReader();
            while (Reader.Read())
            {
                Beds p = new Beds(Reader["id"].ToString(), Reader["wardID"].ToString(), Reader["no"].ToString(), Reader["acc"].ToString(), Reader["rate"].ToString(), Reader["status"].ToString(), Reader["category"].ToString(), Reader["created"].ToString(), Reader["orgid"].ToString());
                wards.Add(p);
            }
            DBConnect.CloseConn();
            return wards;

        }
    }
}
