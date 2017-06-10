using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VHMIS.Model
{
    //services bill
    public class Billing
    {

        private string id;
        private string queueID;
        private string details;
        private string qty;
        private string amount;
        private string account;
        private string bypatient;
        private string bycorporate;
        private string patient;
        private string consultant;
        private string discount;
        private string total;
        private string remarks;
        private string method;
        private string created;
        private string balance;
        private string due;
        private string chq;
        private string bank;
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

        public string Details
        {
            get
            {
                return details;
            }

            set
            {
                details = value;
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

        public string Account
        {
            get
            {
                return account;
            }

            set
            {
                account = value;
            }
        }

        public string Bypatient
        {
            get
            {
                return bypatient;
            }

            set
            {
                bypatient = value;
            }
        }

        public string Bycorporate
        {
            get
            {
                return bycorporate;
            }

            set
            {
                bycorporate = value;
            }
        }

        public string Patient
        {
            get
            {
                return patient;
            }

            set
            {
                patient = value;
            }
        }

        public string Consultant
        {
            get
            {
                return consultant;
            }

            set
            {
                consultant = value;
            }
        }

        public string Discount
        {
            get
            {
                return discount;
            }

            set
            {
                discount = value;
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

        public Billing(string id, string queueID, string details, string qty, string amount, string account, string bypatient, string bycorporate, string patient, string consultant, string discount, string total, string remarks, string method, string created, string balance, string due, string chq, string bank, string orgID)
        {
            this.Id = id;
            this.QueueID = queueID;
            this.Details = details;
            this.Qty = qty;
            this.Amount = amount;
            this.Account = account;
            this.Bypatient = bypatient;
            this.Bycorporate = bycorporate;
            this.Patient = patient;
            this.Consultant = consultant;
            this.Discount = discount;
            this.Total = total;
            this.Remarks = remarks;
            this.Method = method;
            this.Created = created;
            this.Balance = balance;
            this.Due = due;
            this.Chq = chq;
            this.Bank = bank;
            this.OrgID = orgID;
        }

        public static List<Billing> ListBilling()
        {
            DBConnect.OpenConn();
            List<Billing> wards = new List<Billing>();
            string SQL = "SELECT * FROM billing";
            NpgsqlCommand command = new NpgsqlCommand(SQL, DBConnect.conn);
            NpgsqlDataReader Reader = command.ExecuteReader();
            while (Reader.Read())
            {
                Billing p = new Billing(Reader["id"].ToString(), Reader["queueid"].ToString(), Reader["details"].ToString(), Reader["qty"].ToString(), Reader["amount"].ToString(), Reader["account"].ToString(), Reader["bypatient"].ToString(),Reader["bycorporate"].ToString(), Reader["patient"].ToString(), Reader["consultant"].ToString(), Reader["discount"].ToString(), Reader["total"].ToString(), Reader["remarks"].ToString(), Reader["method"].ToString(), Reader["created"].ToString(), Reader["balance"].ToString(), Reader["due"].ToString(), Reader["chq"].ToString(), Reader["bank"].ToString(), Reader["orgid"].ToString());
                wards.Add(p);
            }
            DBConnect.CloseConn();
            return wards;

        }
    }
}
