using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VHMIS.Model
{
    public class Item
    {

        private string id;
        private string name;
        private string code;
        private string description;
        private string manufacturer;
        private string country;
        private string batch;
        private string purchase_price;
        private string sale_price;
        private string composition;
        private string expire;
        private string category;
        private string formulation;
        private string barcode;
        private string image;
        private string created;
        private string department;
        private string date_manufactured;//for age
        private string generic;
        private string strength;

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

        public string Description
        {
            get
            {
                return description;
            }

            set
            {
                description = value;
            }
        }

        public string Manufacturer
        {
            get
            {
                return manufacturer;
            }

            set
            {
                manufacturer = value;
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

        public string Batch
        {
            get
            {
                return batch;
            }

            set
            {
                batch = value;
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

        public string Composition
        {
            get
            {
                return composition;
            }

            set
            {
                composition = value;
            }
        }

        public string Expire
        {
            get
            {
                return expire;
            }

            set
            {
                expire = value;
            }
        }

        public string Category
        {
            get
            {
                return category;
            }

            set
            {
                category = value;
            }
        }

        public string Formulation
        {
            get
            {
                return formulation;
            }

            set
            {
                formulation = value;
            }
        }

        public string Barcode
        {
            get
            {
                return barcode;
            }

            set
            {
                barcode = value;
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

        public string Date_manufactured
        {
            get
            {
                return date_manufactured;
            }

            set
            {
                date_manufactured = value;
            }
        }

        public string Generic
        {
            get
            {
                return generic;
            }

            set
            {
                generic = value;
            }
        }

        public string Strength
        {
            get
            {
                return strength;
            }

            set
            {
                strength = value;
            }
        }

        public Item(string id, string name, string code, string description, string manufacturer, string country, string batch, string purchase_price, string sale_price, string composition, string expire, string category, string formulation, string barcode, string image, string created, string department,string date_manufactured,string generic,string strength)
        {
            this.Id = id;
            this.Name = name;
            this.Code = code;
            this.Description = description;
            this.Manufacturer = manufacturer;
            this.Country = country;
            this.Batch = batch;
            this.Purchase_price = purchase_price;
            this.Sale_price = sale_price;
            this.Composition = composition;
            this.Expire = expire;
            this.Category = category;
            this.Formulation = formulation;
            this.Barcode = barcode;
            this.Image = image;
            this.Created = created;
            this.Department = department;
            this.Date_manufactured = date_manufactured;
            this.Generic = generic;
            this.Strength = strength;
        }

        public static List<Item> ListItem()
        {
            DBConnect.OpenConn();
            List<Item> wards = new List<Item>();
            string SQL = "SELECT * FROM item";
            NpgsqlCommand command = new NpgsqlCommand(SQL, DBConnect.conn);
            NpgsqlDataReader Reader = command.ExecuteReader();
            while (Reader.Read())
            {
                Item p = new Item(Reader["id"].ToString(), Reader["name"].ToString(), Reader["code"].ToString(), Reader["description"].ToString(), Reader["manufacturer"].ToString(), Reader["country"].ToString(), Reader["batch"].ToString(), Reader["purchase_price"].ToString(), Reader["sale_price"].ToString(), Reader["composition"].ToString(), Reader["expire"].ToString(), Reader["category"].ToString(), Reader["formulation"].ToString(), Reader["barcode"].ToString(), Reader["image"].ToString(), Reader["created"].ToString(), Reader["department"].ToString(), Reader["date_manufactured"].ToString(), Reader["generic"].ToString(), Reader["strength"].ToString());
                wards.Add(p);
            }
            DBConnect.CloseConn();
            return wards;

        }
    }
}
