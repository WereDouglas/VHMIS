﻿using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VHMIS.Model
{
   public class Transaction
    {

        private string id;
        private string no;
        private string itemID;
        private string quantity;
        private string date;
        private string price;
        private string type;//Purchase or Sale
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

        public string ItemID
        {
            get
            {
                return itemID;
            }

            set
            {
                itemID = value;
            }
        }

        public string Quantity
        {
            get
            {
                return quantity;
            }

            set
            {
                quantity = value;
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

        public Transaction(string id, string no, string itemID, string quantity, string date, string price, string type,string created)
        {
            this.Id = id;
            this.No = no;
            this.ItemID = itemID;
            this.Quantity = quantity;
            this.Date = date;
            this.Price = price;
            this.Type = type;//Purchase or Sale
            this.Created = created;
        }

        public static List<Transaction> ListTransaction()
        {
            DBConnect.OpenConn();
            List<Transaction> wards = new List<Transaction>();
            string SQL = "SELECT * FROM transaction";
            NpgsqlCommand command = new NpgsqlCommand(SQL, DBConnect.conn);
            NpgsqlDataReader Reader = command.ExecuteReader();
            while (Reader.Read())
            {
                Transaction p = new Transaction(Reader["id"].ToString(), Reader["no"].ToString(), Reader["itemid"].ToString(), Reader["quantity"].ToString(), Reader["date"].ToString(), Reader["price"].ToString(), Reader["type"].ToString(), Reader["created"].ToString());
                wards.Add(p);
            }
            DBConnect.CloseConn();
            return wards;

        }
    }
}
