using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VHMIS.Model
{
    public class Operations
    {
        private string id;
        private string depID;
        private string code;
        private string name;
        private string type;//treatment  or investigation //test diagnosis
        private string category;//Operation ,surgery, other
        private string cost;       
        private string specimenID; 
        private string parameter;
        private string upper;
        private string lower;
        private string unit;
        private string disciplineID;       
        private string gender;
        private string phrase;
        private string max;
        private string min;
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

        public string DepID
        {
            get
            {
                return depID;
            }

            set
            {
                depID = value;
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

        public string SpecimenID
        {
            get
            {
                return specimenID;
            }

            set
            {
                specimenID = value;
            }
        }

        public string Parameter
        {
            get
            {
                return parameter;
            }

            set
            {
                parameter = value;
            }
        }

        public string Upper
        {
            get
            {
                return upper;
            }

            set
            {
                upper = value;
            }
        }

        public string Lower
        {
            get
            {
                return lower;
            }

            set
            {
                lower = value;
            }
        }

        public string Unit
        {
            get
            {
                return unit;
            }

            set
            {
                unit = value;
            }
        }

        public string DisciplineID
        {
            get
            {
                return disciplineID;
            }

            set
            {
                disciplineID = value;
            }
        }

        public string Gender
        {
            get
            {
                return gender;
            }

            set
            {
                gender = value;
            }
        }

        public string Phrase
        {
            get
            {
                return phrase;
            }

            set
            {
                phrase = value;
            }
        }

        public string Max
        {
            get
            {
                return max;
            }

            set
            {
                max = value;
            }
        }

        public string Min
        {
            get
            {
                return min;
            }

            set
            {
                min = value;
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
        public Operations() { }
        public Operations(string id, string depID, string code, string name, string type, string category, string cost, string specimenID, string parameter, string upper, string lower, string unit, string disciplineID, string gender, string phrase, string max, string min, string created, string orgID)
        {
            this.Id = id;
            this.DepID = depID;
            this.Code = code;
            this.Name = name;
            this.Type = type;
            this.Category = category;
            this.Cost = cost;
            this.SpecimenID = specimenID;
            this.Parameter = parameter;
            this.Upper = upper;
            this.Lower = lower;
            this.Unit = unit;
            this.DisciplineID = disciplineID;
            this.Gender = gender;
            this.Phrase = phrase;
            this.Max = max;
            this.Min = min;
            this.Created = created;
            this.OrgID = orgID;
        }

        public static List<Operations> ListOperations()
        {
            List<Operations> operations = new List<Operations>();
            string SQL = "SELECT * FROM operations";
            if (Helper.Type != "Lite")
            {
                NpgsqlDataReader Reader = DBConnect.Reading(SQL);
                while (Reader.Read())
                {
                    Operations p = new Operations(Reader["id"].ToString(), Reader["depID"].ToString(), Reader["code"].ToString(), Reader["name"].ToString(), Reader["type"].ToString(), Reader["category"].ToString(), Reader["cost"].ToString(), Reader["specimenID"].ToString(), Reader["parameter"].ToString(), Reader["upper"].ToString(), Reader["lower"].ToString(), Reader["unit"].ToString(), Reader["disciplineID"].ToString(), Reader["gender"].ToString(), Reader["phrase"].ToString(), Reader["max"].ToString(), Reader["min"].ToString(), Reader["created"].ToString(), Reader["orgID"].ToString());
                    operations.Add(p);
                }
                Reader.Close();
                DBConnect.CloseConn();
            }
            else
            {
                SQLiteDataReader Reader = DBConnect.ReadingLite(SQL);
                while (Reader.Read())
                {
                    Operations p = new Operations(Reader["id"].ToString(), Reader["depID"].ToString(), Reader["code"].ToString(), Reader["name"].ToString(), Reader["type"].ToString(), Reader["category"].ToString(), Reader["cost"].ToString(), Reader["specimenID"].ToString(), Reader["parameter"].ToString(), Reader["upper"].ToString(), Reader["lower"].ToString(), Reader["unit"].ToString(), Reader["discipineID"].ToString(), Reader["gender"].ToString(), Reader["phrase"].ToString(), Reader["max"].ToString(), Reader["min"].ToString(), Reader["created"].ToString(), Reader["orgID"].ToString());
                    operations.Add(p);
                }
                Reader.Close();
            }
            return operations;

        }
    }
}
