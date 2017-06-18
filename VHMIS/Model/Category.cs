using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VHMIS.Model
{
    public class Category
    {
        private string id;
        private string title;
        private string docfee;
        private string hosfee;
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

        public string Title
        {
            get
            {
                return title;
            }

            set
            {
                title = value;
            }
        }

        public string Docfee
        {
            get
            {
                return docfee;
            }

            set
            {
                docfee = value;
            }
        }

        public string Hosfee
        {
            get
            {
                return hosfee;
            }

            set
            {
                hosfee = value;
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
        public Category() { }
        public Category(string id, string title, string docfee, string hosfee, string created, string orgID)
        {
            this.Id = id;
            this.Title = title;
            this.Docfee = docfee;
            this.Hosfee = hosfee;
            this.Created = created;
            this.OrgID = orgID;
        }

        public static List<Category> ListCategory()
        {
            List<Category> lists = new List<Category>();
            string SQL = "SELECT * FROM category";
            if (Helper.Type != "Lite")
            {
                DBConnect.OpenConn();
                NpgsqlDataReader Reader = DBConnect.Reading(SQL);
                while (Reader.Read())
                {
                    Category p = new Category(Reader["id"].ToString(), Reader["title"].ToString(), Reader["docfee"].ToString(), Reader["hosfee"].ToString(), Reader["created"].ToString(), Reader["orgid"].ToString());
                    lists.Add(p);
                }
                Reader.Close();
                DBConnect.CloseConn();
            }
            else
            {
                SQLiteDataReader Reader = DBConnect.ReadingLite(SQL);
                while (Reader.Read())
                {
                    Category p = new Category(Reader["id"].ToString(), Reader["title"].ToString(), Reader["docfee"].ToString(), Reader["hosfee"].ToString(), Reader["created"].ToString(), Reader["orgid"].ToString());
                    lists.Add(p);
                }
                Reader.Close();
            }

            return lists;

        }
    }
}
