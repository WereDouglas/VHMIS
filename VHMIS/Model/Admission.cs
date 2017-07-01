using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VHMIS.Model
{
    public class Admission
    {
        private string id;
        private string no;
        private string follow;
        private string patientID;
        private string userID;
        private string departmentID;
        private string ward;       
        private string bed;
        private string status;
        private string remarks;                     
        private string orgID;
        private string dated;
        private string created;
        private string type;
        private string referral;

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

        public string Follow
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

        public string Ward
        {
            get
            {
                return ward;
            }

            set
            {
                ward = value;
            }
        }

        public string Bed
        {
            get
            {
                return bed;
            }

            set
            {
                bed = value;
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

        public string Remarks
        {
            get
            {
                return remarks;
            }

            set
            {
                remarks = value;
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

        public string Type
        {
            get
            {
                return type;
            }

            set
            {
                type = value;
            }
        }

        public string Referral
        {
            get
            {
                return referral;
            }

            set
            {
                referral = value;
            }
        }

        public Admission() { }

        public Admission(string id, string no, string follow, string patientID, string userID, string departmentID, string ward, string bed, string status, string remarks, string orgID, string dated, string created,string type,string referral)
        {
            this.Id = id;
            this.No = no;
            this.Follow = follow;
            this.PatientID = patientID;
            this.UserID = userID;
            this.DepartmentID = departmentID;
            this.Ward = ward;
            this.Bed = bed;
            this.Status = status;
            this.Remarks = remarks;
            this.OrgID = orgID;
            this.Dated = dated;
            this.Created = created;
            this.Type = type;
            this.Referral = referral;
        }

        public static List<Admission> ListAdmission()
        {
            DBConnect.OpenConn();
            List<Admission> queue = new List<Admission>();
            string SQL = "SELECT * FROM admission";
            NpgsqlCommand command = new NpgsqlCommand(SQL, DBConnect.conn);
            NpgsqlDataReader Reader = command.ExecuteReader();

            while (Reader.Read())
            {
                Admission p = new Admission(Reader["id"].ToString(), Reader["no"].ToString(), Reader["follow"].ToString(), Reader["patientID"].ToString(), Reader["userID"].ToString(), Reader["departmentID"].ToString(), Reader["ward"].ToString(), Reader["bed"].ToString(), Reader["status"].ToString(), Reader["remarks"].ToString(), Reader["orgid"].ToString(),Reader["dated"].ToString(), Reader["created"].ToString(), Reader["type"].ToString(), Reader["referral"].ToString());
                queue.Add(p);
            }
            DBConnect.CloseConn();
            return queue;

        }
        public static List<Admission> ListAdmission(string Date)
        {
            DBConnect.OpenConn();

            List<Admission> queue = new List<Admission>();
            string SQL = "SELECT * FROM admission WHERE dated::date = '" + Date + "'::date ";
            NpgsqlCommand command = new NpgsqlCommand(SQL, DBConnect.conn);
            NpgsqlDataReader Reader = command.ExecuteReader();

            while (Reader.Read())
            {
                Admission p = new Admission(Reader["id"].ToString(), Reader["no"].ToString(), Reader["follow"].ToString(), Reader["patientID"].ToString(), Reader["userID"].ToString(), Reader["departmentID"].ToString(), Reader["ward"].ToString(), Reader["bed"].ToString(), Reader["status"].ToString(), Reader["remarks"].ToString(), Reader["orgid"].ToString(), Reader["dated"].ToString(), Reader["created"].ToString(), Reader["type"].ToString(), Reader["referral"].ToString());
                queue.Add(p);
            }
            DBConnect.CloseConn();

            return queue;

        }
    }
}
