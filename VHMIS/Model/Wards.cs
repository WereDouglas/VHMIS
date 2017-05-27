using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VHMIS.Model
{
   public class Wards
    {

        private string id;
        private string name;
        private string code;
        private string capacity;
        private string cost;
        private string deposit;
        private string wing;
        private string period;
        private string created;

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

        public string Capacity
        {
            get
            {
                return capacity;
            }

            set
            {
                capacity = value;
            }
        }

        public string Cost
        {
            get
            {
                return cost;
            }

            set
            {
                cost = value;
            }
        }

        public string Deposit
        {
            get
            {
                return deposit;
            }

            set
            {
                deposit = value;
            }
        }

        public string Wing
        {
            get
            {
                return wing;
            }

            set
            {
                wing = value;
            }
        }

        public string Period
        {
            get
            {
                return period;
            }

            set
            {
                period = value;
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

        public Wards(string id, string name, string code, string capacity, string cost, string deposit, string wing, string period, string created)
        {
            this.Id = id;
            this.Name = name;
            this.Code = code;
            this.Capacity = capacity;
            this.Cost = cost;
            this.Deposit = deposit;
            this.Wing = wing;
            this.Period = period;
            this.Created = created;
        }

        public static List<Wards> ListWards()
        {
            DBConnect.OpenConn();

            List<Wards> wards = new List<Wards>();
            string SQL = "SELECT * FROM wards";
            NpgsqlCommand command = new NpgsqlCommand(SQL, DBConnect.conn);
            NpgsqlDataReader Reader = command.ExecuteReader();

            while (Reader.Read())
            {
                Wards p = new Wards(Reader["id"].ToString(), Reader["name"].ToString(), Reader["code"].ToString(), Reader["capacity"].ToString(), Reader["cost"].ToString(), Reader["deposit"].ToString(), Reader["wing"].ToString(), Reader["period"].ToString(), Reader["created"].ToString());
                wards.Add(p);

            }
            DBConnect.CloseConn();

            return wards;

        }
    }
}
