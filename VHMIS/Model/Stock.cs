using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VHMIS.Model
{
    public class Stock
    {

        private string id;
        private string itemID;
        private string quantity;
        private string remarks;
        private string created;
        private string sale_price;
        private string purchase_price;
        private string new_price;
        private string previous_price;
        private string total_qty;
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

        public string Sale_price
        {
            get
            {
                return sale_price;
            }

            set
            {
                sale_price = value;
            }
        }

        public string Purchase_price
        {
            get
            {
                return purchase_price;
            }

            set
            {
                purchase_price = value;
            }
        }

        public string New_price
        {
            get
            {
                return new_price;
            }

            set
            {
                new_price = value;
            }
        }

        public string Previous_price
        {
            get
            {
                return previous_price;
            }

            set
            {
                previous_price = value;
            }
        }

        public string Total_qty
        {
            get
            {
                return total_qty;
            }

            set
            {
                total_qty = value;
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
        public Stock() { }
        public Stock(string id, string itemID, string quantity, string remarks, string created, string sale_price, string purchase_price, string new_price, string previous_price, string total_qty, string orgID)
        {
            this.Id = id;
            this.ItemID = itemID;
            this.Quantity = quantity;
            this.Remarks = remarks;
            this.Created = created;
            this.Sale_price = sale_price;
            this.Purchase_price = purchase_price;
            this.New_price = new_price;
            this.Previous_price = previous_price;
            this.Total_qty = total_qty;
            this.OrgID = orgID;
        }

        public static List<Stock> ListStock()
        {

            List<Stock> wards = new List<Stock>();
            string SQL = "SELECT * FROM stock";
            if (Helper.Type != "Lite")
            {
                NpgsqlDataReader Reader = DBConnect.Reading(SQL);
                while (Reader.Read())
                {
                    Stock p = new Stock(Reader["id"].ToString(), Reader["itemid"].ToString(), Reader["quantity"].ToString(), Reader["remarks"].ToString(), Reader["created"].ToString(), Reader["sale_price"].ToString(), Reader["purchase_price"].ToString(), Reader["new_price"].ToString(), Reader["previous_price"].ToString(), Reader["total_qty"].ToString(), Reader["orgid"].ToString());
                    wards.Add(p);
                }
                Reader.Close();
                DBConnect.CloseConn();
            }
            else
            {
                SQLiteDataReader Reader = DBConnect.ReadingLite(SQL);
                while (Reader.Read())
                {
                    Stock p = new Stock(Reader["id"].ToString(), Reader["itemid"].ToString(), Reader["quantity"].ToString(), Reader["remarks"].ToString(), Reader["created"].ToString(), Reader["sale_price"].ToString(), Reader["purchase_price"].ToString(), Reader["new_price"].ToString(), Reader["previous_price"].ToString(), Reader["total_qty"].ToString(), Reader["orgid"].ToString());
                    wards.Add(p);
                }
                Reader.Close();

            }
            return wards;

        }
    }
}
