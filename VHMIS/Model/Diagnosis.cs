using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VHMIS.Model
{
    public class Diagnosis
    {
        private string id;
        private string name;
        private string queueID;
        private string departmentID;
        private string diagnosisID;
        private string patientID;
        private string userID;
        private string code;
        private string doneBy;
        private string price;
        private string note;
        private string created;
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

        public string DiagnosisID
        {
            get
            {
                return diagnosisID;
            }

            set
            {
                diagnosisID = value;
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

        public string DoneBy
        {
            get
            {
                return doneBy;
            }

            set
            {
                doneBy = value;
            }
        }

        public string Price
        {
            get
            {
                return price;
            }

            set
            {
                price = value;
            }
        }

        public string Note
        {
            get
            {
                return note;
            }

            set
            {
                note = value;
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

        public Diagnosis(string id, string name, string queueID, string departmentID, string diagnosisID, string patientID, string userID, string code, string doneBy, string price, string note, string created, string orgID,string no)
        {
            this.id = id;
            this.name = name;
            this.queueID = queueID;
            this.departmentID = departmentID;
            this.diagnosisID = diagnosisID;
            this.patientID = patientID;
            this.userID = userID;
            this.code = code;
            this.doneBy = doneBy;
            this.price = price;
            this.note = note;
            this.created = created;
            this.OrgID = orgID;
            this.No = no;
        }

        public static List<Diagnosis> ListDiagnosis(string queueID)
        {
            DBConnect.OpenConn();

            List<Diagnosis> patients = new List<Diagnosis>();
            string SQL = "SELECT * FROM diagnosis WHERE queueID='" + queueID + "'";
            NpgsqlCommand command = new NpgsqlCommand(SQL, DBConnect.conn);
            NpgsqlDataReader Reader = command.ExecuteReader();

            while (Reader.Read())
            {
                Diagnosis p = new Diagnosis(Reader["id"].ToString(), Reader["name"].ToString(), Reader["queueID"].ToString(), Reader["departmentID"].ToString(), Reader["diagnosisID"].ToString(), Reader["patientID"].ToString(), Reader["userID"].ToString(), Reader["code"].ToString(), Reader["doneby"].ToString(), Reader["price"].ToString(), Reader["note"].ToString(), Reader["created"].ToString(), Reader["orgid"].ToString(), Reader["no"].ToString());
                patients.Add(p);

            }
            DBConnect.CloseConn();

            return patients;

        }
    }
}
