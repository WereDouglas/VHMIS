using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VHMIS.Model
{
    public class Organisation
    {
        private string id;
        private string name;
        private string code;
        private string registration;
        private string contact;
        private string address;
        private string tin;
        private string vat;
        private string email;
        private string country;
        private string initialpassword;
        private string account;
        private string status;
        private string expires;
        private string image;
        private string created;
        private string sync;
        private string counts;
        private string company;
        private string branchID;

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

        public string Registration
        {
            get
            {
                return registration;
            }

            set
            {
                registration = value;
            }
        }

        public string Contact
        {
            get
            {
                return contact;
            }

            set
            {
                contact = value;
            }
        }

        public string Address
        {
            get
            {
                return address;
            }

            set
            {
                address = value;
            }
        }

        public string Tin
        {
            get
            {
                return tin;
            }

            set
            {
                tin = value;
            }
        }

        public string Vat
        {
            get
            {
                return vat;
            }

            set
            {
                vat = value;
            }
        }

        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
            }
        }

        public string Country
        {
            get
            {
                return country;
            }

            set
            {
                country = value;
            }
        }

        public string Initialpassword
        {
            get
            {
                return initialpassword;
            }

            set
            {
                initialpassword = value;
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

        public string Expires
        {
            get
            {
                return expires;
            }

            set
            {
                expires = value;
            }
        }

        public string Image
        {
            get
            {
                return image;
            }

            set
            {
                image = value;
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

        public string Sync
        {
            get
            {
                return sync;
            }

            set
            {
                sync = value;
            }
        }

        public string Counts
        {
            get
            {
                return counts;
            }

            set
            {
                counts = value;
            }
        }

        public string Company
        {
            get
            {
                return company;
            }

            set
            {
                company = value;
            }
        }

        public string BranchID
        {
            get
            {
                return branchID;
            }

            set
            {
                branchID = value;
            }
        }

        public Organisation() { }
        public Organisation(string id, string name, string code, string registration, string contact, string address, string tin, string vat, string email, string country, string initialpassword, string account, string status, string expires, string image, string created, string sync, string counts, string company,string branchID)
        {
            this.Id = id;
            this.Name = name;
            this.Code = code;
            this.Registration = registration;
            this.Contact = contact;
            this.Address = address;
            this.Tin = tin;
            this.Vat = vat;
            this.Email = email;
            this.Country = country;
            this.Initialpassword = initialpassword;
            this.Account = account;
            this.Status = status;
            this.Expires = expires;
            this.Image = image;
            this.Created = created;
            this.Sync = sync;
            this.Counts = counts;
            this.Company = company;
            this.BranchID = branchID;
        }

        public static List<Organisation> ListOrganisation()
        {
            
            List<Organisation> wards = new List<Organisation>();
            string SQL = "SELECT * FROM organisation LIMIT 1";
            if (Helper.Type != "Lite")
            {
                NpgsqlDataReader Reader = DBConnect.Reading(SQL);
                while (Reader.Read())
                {
                    Organisation p = new Organisation(Reader["id"].ToString(), Reader["name"].ToString(), Reader["code"].ToString(), Reader["registration"].ToString(), Reader["contact"].ToString(), Reader["address"].ToString(), Reader["tin"].ToString(), Reader["vat"].ToString(), Reader["email"].ToString(), Reader["country"].ToString(), Reader["initialpassword"].ToString(), Reader["account"].ToString(), Reader["status"].ToString(), Reader["expires"].ToString(), Reader["image"].ToString(), Reader["created"].ToString(), Reader["sync"].ToString(), Reader["counts"].ToString(), Reader["company"].ToString(), Reader["branchid"].ToString());
                    wards.Add(p);
                }
                DBConnect.CloseConn();
            }
            else
            {
                SQLiteDataReader Reader = DBConnect.ReadingLite(SQL);
                while (Reader.Read())
                {
                    Organisation p = new Organisation(Reader["id"].ToString(), Reader["name"].ToString(), Reader["code"].ToString(), Reader["registration"].ToString(), Reader["contact"].ToString(), Reader["address"].ToString(), Reader["tin"].ToString(), Reader["vat"].ToString(), Reader["email"].ToString(), Reader["country"].ToString(), Reader["initialpassword"].ToString(), Reader["account"].ToString(), Reader["status"].ToString(), Reader["expires"].ToString(), Reader["image"].ToString(), Reader["created"].ToString(), Reader["sync"].ToString(), Reader["counts"].ToString(), Reader["company"].ToString(), Reader["branchid"].ToString());
                    wards.Add(p);
                }
                Reader.Close();

            }
            return wards;

        }
    }
}