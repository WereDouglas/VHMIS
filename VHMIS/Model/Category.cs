using Npgsql;
using System;
using System.Collections.Generic;
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

        public Category(string id, string title, string docfee, string hosfee, string created)
        {
            this.Id = id;
            this.Title = title;
            this.Docfee = docfee;
            this.Hosfee = hosfee;
            this.Created = created;
        }

        public static List<Category> ListCategory()
        {
            DBConnect.OpenConn();

            List<Category> lists = new List<Category>();
            string SQL = "SELECT * FROM category";
            NpgsqlCommand command = new NpgsqlCommand(SQL, DBConnect.conn);
            NpgsqlDataReader Reader = command.ExecuteReader();

            while (Reader.Read())
            {
                Category p = new Category(Reader["id"].ToString(), Reader["title"].ToString(), Reader["docfee"].ToString(), Reader["hosfee"].ToString(), Reader["created"].ToString());
                lists.Add(p);

            }
            DBConnect.CloseConn();

            return lists;

        }
    }
}
