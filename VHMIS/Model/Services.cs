using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VHMIS.Model
{
    public class Services
    {
        private string id;
        private string name;
        private string no;
        private string queueID;
        private string departmentID;
        private string operationID;
        private string patientID;
        private string userID;
        private string price;
        private string parameter;
        private string status;
        private string qty;
        private string total;
        private string paid;
        private string notes;
        private string results;      
        private string date;
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

        public string OperationID
        {
            get
            {
                return operationID;
            }

            set
            {
                operationID = value;
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

        public string Notes
        {
            get
            {
                return notes;
            }

            set
            {
                notes = value;
            }
        }

        public string Results
        {
            get
            {
                return results;
            }

            set
            {
                results = value;
            }
        }

        public string Date
        {
            get
            {
                return date;
            }

            set
            {
                date = value;
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

        public Services() { }

        public Services(string id, string name, string no, string queueID, string departmentID, string operationID, string patientID, string userID, string price, string parameter, string status, string qty, string total, string paid, string notes, string results, string date, string created, string orgID)
        {
            this.Id = id;
            this.Name = name;
            this.No = no;
            this.QueueID = queueID;
            this.DepartmentID = departmentID;
            this.OperationID = operationID;
            this.PatientID = patientID;
            this.UserID = userID;
            this.Price = price;
            this.Parameter = parameter;
            this.Status = status;
            this.Qty = qty;
            this.Total = total;
            this.Paid = paid;
            this.Notes = notes;
            this.Results = results;
            this.Date = date;
            this.Created = created;
            this.OrgID = orgID;
        }

        public static List<Services> ListServices(string queueID)
        {
            List<Services> services = new List<Services>();
            string SQL = "SELECT * FROM services WHERE no='" + queueID + "'";
            if (Helper.Type != "Lite")
            {
                NpgsqlDataReader Reader = DBConnect.Reading(SQL);
                while (Reader.Read())
                {
                    Services p = new Services(Reader["id"].ToString(), Reader["name"].ToString(), Reader["no"].ToString(), Reader["queueID"].ToString(), Reader["departmentID"].ToString(), Reader["operationID"].ToString(), Reader["patientID"].ToString(), Reader["userID"].ToString(), Reader["price"].ToString(), Reader["parameter"].ToString(), Reader["status"].ToString(), Reader["qty"].ToString(), Reader["total"].ToString(), Reader["paid"].ToString(), Reader["notes"].ToString(), Reader["results"].ToString(), Reader["date"].ToString(), Reader["created"].ToString(), Reader["orgid"].ToString());
                    services.Add(p);
                }
                DBConnect.CloseConn();
            }
            else
            {
                SQLiteDataReader Reader = DBConnect.ReadingLite(SQL);
                while (Reader.Read())
                {
                    Services p = new Services(Reader["id"].ToString(), Reader["name"].ToString(), Reader["no"].ToString(), Reader["queueID"].ToString(), Reader["departmentID"].ToString(), Reader["operationID"].ToString(), Reader["patientID"].ToString(), Reader["userID"].ToString(), Reader["price"].ToString(), Reader["parameter"].ToString(), Reader["status"].ToString(), Reader["qty"].ToString(), Reader["total"].ToString(), Reader["paid"].ToString(), Reader["notes"].ToString(), Reader["results"].ToString(), Reader["date"].ToString(), Reader["created"].ToString(), Reader["orgid"].ToString());
                    services.Add(p);
                }
                Reader.Close();

            }
            return services;

        }
    }
}
