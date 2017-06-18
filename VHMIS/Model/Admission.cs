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
        private  string follow;
        private string patientID;
        private string userID;
        private string ward;
        private string clinicID;
        private string bed;
        private string status;
        private string dated;
        private string created;
        private string consultation_paid;
        private string investigation_paid;
        private string lab_paid;
        private string pharmacy_paid;
        private string lab_complete;
        private string consultation_complete;
        private string remarks;
        private string other;
        private string no;
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

        public string Consultation_paid
        {
            get
            {
                return consultation_paid;
            }

            set
            {
                consultation_paid = value;
            }
        }

        public string Investigation_paid
        {
            get
            {
                return investigation_paid;
            }

            set
            {
                investigation_paid = value;
            }
        }

        public string Lab_paid
        {
            get
            {
                return lab_paid;
            }

            set
            {
                lab_paid = value;
            }
        }

        public string Pharmacy_paid
        {
            get
            {
                return pharmacy_paid;
            }

            set
            {
                pharmacy_paid = value;
            }
        }

        public string Lab_complete
        {
            get
            {
                return lab_complete;
            }

            set
            {
                lab_complete = value;
            }
        }

        public string Consultation_complete
        {
            get
            {
                return consultation_complete;
            }

            set
            {
                consultation_complete = value;
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
        public Admission() { }
        public Admission(string id, string follow, string patientID, string userID, string ward,string status, string dated, string created, string clinicID, string bed,string consultation_paid,string investigation_paid,string lab_paid,string pharmacy_paid,string lab_complete,string consulation_complete,string remarks,string other,string no, string orgID)
        {
            this.Id = id;
            this.Follow = follow;
            this.PatientID = patientID;
            this.UserID = userID;
            this.Ward = ward;
            this.ClinicID = clinicID;
            this.Status = status;
            this.Dated = dated;
            this.Created = created;
            this.Bed = bed;
            this.Consultation_paid = consultation_paid;
            this.Investigation_paid = investigation_paid;
            this.Lab_paid = lab_paid;
            this.Pharmacy_paid = pharmacy_paid;
            this.Lab_complete = lab_complete;
            this.Consultation_complete = consulation_complete;
            this.Remarks = remarks;
            this.Other = other;
            this.No = no;
            this.OrgID = orgID;
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
                Admission p = new Admission(Reader["id"].ToString(), Reader["follow"].ToString(), Reader["patientID"].ToString(), Reader["userID"].ToString(),Reader["ward"].ToString(), Reader["status"].ToString(), Reader["dated"].ToString(), Reader["created"].ToString(), Reader["clinicid"].ToString(),Reader["bed"].ToString(), Reader["consultation_paid"].ToString(), Reader["investigation_paid"].ToString(), Reader["lab_paid"].ToString(), Reader["pharmacy_paid"].ToString(), Reader["lab_complete"].ToString(), Reader["consultation_complete"].ToString(), Reader["remarks"].ToString(), Reader["other"].ToString(), Reader["no"].ToString(), Reader["orgid"].ToString());
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
                Admission p = new Admission(Reader["id"].ToString(), Reader["follow"].ToString(), Reader["patientID"].ToString(), Reader["userID"].ToString(), Reader["ward"].ToString(), Reader["status"].ToString(), Reader["dated"].ToString(), Reader["created"].ToString(), Reader["clinicid"].ToString(), Reader["bed"].ToString(), Reader["consultation_paid"].ToString(), Reader["investigation_paid"].ToString(), Reader["lab_paid"].ToString(), Reader["pharmacy_paid"].ToString(), Reader["lab_complete"].ToString(), Reader["consultation_complete"].ToString(), Reader["remarks"].ToString(), Reader["other"].ToString(), Reader["no"].ToString(), Reader["orgid"].ToString());
                queue.Add(p);
            }
            DBConnect.CloseConn();

            return queue;

        }
    }
}
