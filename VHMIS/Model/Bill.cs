using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VHMIS.Model
{
    //medicine and pharmacy bill
    public class Bill
    {

        private string id;
        private string no;
        private string transactorID;
        private string patientID;
        private string remarks;
        private string date;
        private string amount;
        private string balance;
        private string method;
        private string paid;       
        private string created;
        private string department;
        private string due;
        private string chq;
        private string bank;
        private string queueID;
        private string type;//sale or purchase
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

        public string TransactorID
        {
            get
            {
                return transactorID;
            }

            set
            {
                transactorID = value;
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

        public string Amount
        {
            get
            {
                return amount;
            }

            set
            {
                amount = value;
            }
        }

        public string Balance
        {
            get
            {
                return balance;
            }

            set
            {
                balance = value;
            }
        }

        public string Method
        {
            get
            {
                return method;
            }

            set
            {
                method = value;
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

        public string Due
        {
            get
            {
                return due;
            }

            set
            {
                due = value;
            }
        }

        public string Chq
        {
            get
            {
                return chq;
            }

            set
            {
                chq = value;
            }
        }

        public string Bank
        {
            get
            {
                return bank;
            }

            set
            {
                bank = value;
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
        public Bill() { }
        public Bill(string id, string no, string transactorID, string remarks, string date, string amount, string balance, string method, string paid, string created, string department, string due, string chq, string bank, string type,string queueID,string patientID, string orgID)
        {
            this.Id = id;
            this.No = no;
            this.TransactorID = transactorID;
            this.Remarks = remarks;
            this.Date = date;
            this.Amount = amount;
            this.Balance = balance;
            this.Method = method;
            this.Paid = paid;
            this.Created = created;
            this.Department = department;
            this.Due = due;
            this.Chq = chq;
            this.Bank = bank;
            this.Type = type;
            this.QueueID = queueID;
            this.PatientID = patientID;
            this.OrgID = orgID;
        }

        public static List<Bill> ListBill()
        {
           
            List<Bill> wards = new List<Bill>();
            string SQL = "SELECT * FROM bill";

            if (Helper.Type != "Lite")
            {
                DBConnect.OpenConn();
                NpgsqlDataReader Reader = DBConnect.Reading(SQL);
                while (Reader.Read())
                {
                    Bill p = new Bill(Reader["id"].ToString(), Reader["no"].ToString(), Reader["transactionid"].ToString(), Reader["remarks"].ToString(), Reader["date"].ToString(), Reader["amount"].ToString(), Reader["balance"].ToString(), Reader["method"].ToString(), Reader["paid"].ToString(), Reader["created"].ToString(), Reader["department"].ToString(), Reader["due"].ToString(), Reader["chq"].ToString(), Reader["bank"].ToString(), Reader["type"].ToString(), Reader["queueid"].ToString(), Reader["patientid"].ToString(), Reader["orgid"].ToString());
                    wards.Add(p);
                }
                DBConnect.CloseConn();
            }
            else
            {
                SQLiteDataReader Reader = DBConnect.ReadingLite(SQL);
                while (Reader.Read())
                {
                    Bill p = new Bill(Reader["id"].ToString(), Reader["no"].ToString(), Reader["transactionid"].ToString(), Reader["remarks"].ToString(), Reader["date"].ToString(), Reader["amount"].ToString(), Reader["balance"].ToString(), Reader["method"].ToString(), Reader["paid"].ToString(), Reader["created"].ToString(), Reader["department"].ToString(), Reader["due"].ToString(), Reader["chq"].ToString(), Reader["bank"].ToString(), Reader["type"].ToString(), Reader["queueid"].ToString(), Reader["patientid"].ToString(), Reader["orgid"].ToString());
                    wards.Add(p);
                }
                Reader.Close();

            }
            return wards;

        }
    }
}
