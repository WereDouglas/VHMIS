using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VHMIS.Model
{
    public class Services
    {
        private string id;
        private string name;
        private string queueID;
        private string departmentID;
        private string procedureID;
        private string patientID;
        private string userID;
        private string code;
        private string doneBy;
        private string price;
        private string created;        
        private string parameter;
        private string status;
        private string qty;
        private string total;
        private string paid;
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

        public string ProcedureID
        {
            get
            {
                return procedureID;
            }

            set
            {
                procedureID = value;
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

        public string Parameter
        {
            get
            {
                return parameter;
            }

            set
            {
                parameter = value;
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

        public string Paid
        {
            get
            {
                return paid;
            }

            set
            {
                paid = value;
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

        public Services(string id, string name, string queueID, string departmentID, string procedureID, string patientID, string userID, string code, string doneBy, string price, string created,string parameter,string status,string qty,string total,string paid, string orgID,string no)
        {
            this.Id = id;
            this.Name = name;
            this.QueueID = queueID;
            this.DepartmentID = departmentID;
            this.ProcedureID = procedureID;
            this.PatientID = patientID;
            this.UserID = userID;
            this.Code = code;
            this.DoneBy = doneBy;
            this.Price = price;
            this.Created = created;
            this.Parameter = parameter;
            this.Status = status;
            this.Qty = qty;
            this.Total = total;
            this.Paid = paid;
            this.OrgID = orgID;
            this.No = no;
        }

        public static List<Services> ListServices(string queueID)
        {
            DBConnect.OpenConn();

            List<Services> patients = new List<Services>();
            string SQL = "SELECT * FROM services WHERE queueID='"+queueID+"'";
            NpgsqlCommand command = new NpgsqlCommand(SQL, DBConnect.conn);
            NpgsqlDataReader Reader = command.ExecuteReader();

            while (Reader.Read())
            {
                Services p = new Services(Reader["id"].ToString(), Reader["name"].ToString(), Reader["queueID"].ToString(), Reader["departmentID"].ToString(), Reader["procedureID"].ToString(), Reader["patientID"].ToString(), Reader["userID"].ToString(), Reader["code"].ToString(), Reader["doneby"].ToString(), Reader["price"].ToString(),Reader["created"].ToString(), Reader["parameter"].ToString(), Reader["status"].ToString(),Reader["qty"].ToString(),Reader["total"].ToString(), Reader["paid"].ToString(), Reader["orgid"].ToString(), Reader["no"].ToString());
                patients.Add(p);

            }
            DBConnect.CloseConn();

            return patients;

        }
    }
}
