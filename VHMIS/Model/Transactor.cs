using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VHMIS.Model
{
    public class Transactor
    {
        private string id;
        private string transactorNo;
        private string contact;
        private string name;
        private string email;
        private string address;
        private string image;
        private string created;
        private string type;//supplier //customer
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

        public string TransactorNo
        {
            get
            {
                return transactorNo;
            }

            set
            {
                transactorNo = value;
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

        public Transactor(string id, string transactorNo, string contact, string name, string email, string address, string image, string created, string type, string orgID)
        {
            this.Id = id;
            this.TransactorNo = transactorNo;
            this.Contact = contact;
            this.Name = name;
            this.Email = email;
            this.Address = address;
            this.Image = image;
            this.Created = created;
            this.Type = type;//supplier //customer
            this.OrgID = orgID;
        }

        public static List<Transactor> ListTransactors()
        {

            DBConnect.OpenConn();

            List<Transactor> transactors = new List<Transactor>();
            string SQL = "SELECT * FROM transactor";
            NpgsqlCommand command = new NpgsqlCommand(SQL, DBConnect.conn);
            NpgsqlDataReader Reader = command.ExecuteReader();

            while (Reader.Read())
            {

                Transactor p = new Transactor(Reader["id"].ToString(), Reader["transactorno"].ToString(), Reader["contact"].ToString(),Reader["name"].ToString(), Reader["email"].ToString(), Reader["address"].ToString(), Reader["image"].ToString(), Reader["created"].ToString(), Reader["type"].ToString(), Reader["orgid"].ToString());
                transactors.Add(p);

            }
            DBConnect.CloseConn();

            return transactors;

        }
    }
}
