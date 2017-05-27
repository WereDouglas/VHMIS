﻿using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VHMIS.Model
{
   public class Dosage
    {
        private string id;
        private string itemID;
        private string dose;
        private string prescription;
        private string qty;
        private string min_age;
        private string max_age;
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

        public string Dose
        {
            get
            {
                return dose;
            }

            set
            {
                dose = value;
            }
        }

        public string Prescription
        {
            get
            {
                return prescription;
            }

            set
            {
                prescription = value;
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

        public string Min_age
        {
            get
            {
                return min_age;
            }

            set
            {
                min_age = value;
            }
        }

        public string Max_age
        {
            get
            {
                return max_age;
            }

            set
            {
                max_age = value;
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

        public Dosage(string id, string itemID, string dose, string prescription, string qty, string min_age, string max_age, string created)
        {
            this.Id = id;
            this.ItemID = itemID;
            this.Dose = dose;
            this.Prescription = prescription;
            this.Qty = qty;
            this.Min_age = min_age;
            this.Max_age = max_age;
            this.Created = created;
        }

        public static List<Dosage> ListDosage()
        {
            DBConnect.OpenConn();
            List<Dosage> clinics = new List<Dosage>();
            string SQL = "SELECT * FROM dosage";
            NpgsqlCommand command = new NpgsqlCommand(SQL, DBConnect.conn);
            NpgsqlDataReader Reader = command.ExecuteReader();

            while (Reader.Read())
            {
                Dosage p = new Dosage(Reader["id"].ToString(), Reader["itemid"].ToString(), Reader["dose"].ToString(), Reader["prescription"].ToString(), Reader["qty"].ToString(), Reader["min_age"].ToString(), Reader["max_age"].ToString(), Reader["created"].ToString());
                clinics.Add(p);
            }
            DBConnect.CloseConn();

            return clinics;

        }
    }
}