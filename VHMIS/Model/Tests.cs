using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VHMIS.Model
{
    public class Tests
    {
        private string id;
        private string specimenID;
        private string type;
        private string parameter;
        private string upper;
        private string lower;
        private string unit;
        private string disciplineID;
        private string code;
        private string gender;
        private string phrase;
        private string description;
        private string comment;
        private string created;
        private string cost;
        private string departmentID;
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

        public string Disciplineid
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

        public string Comment
        {
            get
            {
                return comment;
            }

            set
            {
                comment = value;
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

        public string DepartmentID
        {
            get
            {
                return departmentID;
            }

            set
            {
                departmentID = value;
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

        public Tests(string id, string specimenID, string type, string parameter, string upper, string lower, string unit, string disciplineid, string code, string gender, string phrase, string description, string comment, string created,string cost,string departmentID, string orgID)
        {
            this.Id = id;
            this.SpecimenID = specimenID;
            this.Type = type;
            this.Parameter = parameter;
            this.Upper = upper;
            this.Lower = lower;
            this.Unit = unit;
            this.Disciplineid = disciplineid;
            this.Code = code;
            this.Gender = gender;
            this.Phrase = phrase;
            this.Description = description;
            this.Comment = comment;
            this.Created = created;
            this.Cost = cost;
            this.DepartmentID = departmentID;
            this.OrgID = orgID;
        }

        public static List<Tests> ListTests()
        {

            DBConnect.OpenConn();
            List<Tests> patients = new List<Tests>();
            string SQL = "SELECT * FROM tests";
            NpgsqlCommand command = new NpgsqlCommand(SQL, DBConnect.conn);
            NpgsqlDataReader Reader = command.ExecuteReader();

            while (Reader.Read())
            {
                Tests p = new Tests(Reader["id"].ToString(), Reader["specimenID"].ToString(), Reader["type"].ToString(), Reader["parameter"].ToString(), Reader["upper"].ToString(), Reader["lower"].ToString(), Reader["unit"].ToString(), Reader["disciplineid"].ToString(), Reader["code"].ToString(), Reader["gender"].ToString(), Reader["phrase"].ToString(), Reader["description"].ToString(), Reader["comment"].ToString(), Reader["created"].ToString(), Reader["cost"].ToString(), Reader["departmentID"].ToString(), Reader["orgid"].ToString());
                patients.Add(p);
            }
            DBConnect.CloseConn();

            return patients;

        }
    }
}
