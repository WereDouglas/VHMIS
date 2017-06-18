using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VHMIS.Model
{
    public class Patient
    {
        private string id;
        private string patientNo;
        private string contact;
        private string surname;
        private string lastname;
        private string email;
        private string dob;
        private string nationality;
        private string address;
        private string kin;
        private string kincontact;
        private string gender;
        private string image;
        private string created;
        private string religion;
        private string blood;
        private string orgID;
        public Patient() { }
        public Patient(string id, string patientNo, string contact, string surname, string lastname, string email, string dob, string nationality, string address, string kin, string kincontact, string gender, string image, string created, string religion, string blood, string orgID)
        {
            this.Id = id;
            this.PatientNo = patientNo;
            this.Contact = contact;
            this.Surname = surname;
            this.Lastname = lastname;
            this.Email = email;
            this.Dob = dob;
            this.Nationality = nationality;
            this.Address = address;
            this.Kin = kin;
            this.Kincontact = kincontact;
            this.Gender = gender;
            this.Image = image;
            this.Created = created;
            this.Religion = religion;
            this.Blood = blood;
            this.OrgID = orgID;
        }

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

        public string FullName()
        {
            return Surname + " " + Lastname;

        }

        public string PatientNo
        {
            get
            {
                return patientNo;
            }

            set
            {
                patientNo = value;
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

        public string Surname
        {
            get
            {
                return surname;
            }

            set
            {
                surname = value;
            }
        }

        public string Lastname
        {
            get
            {
                return lastname;
            }

            set
            {
                lastname = value;
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

        public string Dob
        {
            get
            {
                return dob;
            }

            set
            {
                dob = value;
            }
        }

        public string Nationality
        {
            get
            {
                return nationality;
            }

            set
            {
                nationality = value;
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

        public string Kin
        {
            get
            {
                return kin;
            }

            set
            {
                kin = value;
            }
        }

        public string Kincontact
        {
            get
            {
                return kincontact;
            }

            set
            {
                kincontact = value;
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

        public string Religion
        {
            get
            {
                return religion;
            }

            set
            {
                religion = value;
            }
        }

        public string Blood
        {
            get
            {
                return blood;
            }

            set
            {
                blood = value;
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

        public static List<Patient> ListPatients()
        {
            List<Patient> patients = new List<Patient>();
            string SQL = "SELECT * FROM patient";

            if (Helper.Type != "Lite")
            {
                NpgsqlDataReader Reader = DBConnect.Reading(SQL);
                while (Reader.Read())
                {
                    Patient p = new Patient(Reader["id"].ToString(), Reader["patientNo"].ToString(), Reader["contact"].ToString(), Reader["surname"].ToString(), Reader["lastname"].ToString(), Reader["email"].ToString(), Reader["dob"].ToString(), Reader["nationality"].ToString(), Reader["address"].ToString(), Reader["kin"].ToString(), Reader["kincontact"].ToString(), Reader["gender"].ToString(), Reader["image"].ToString(), Reader["created"].ToString(), Reader["religion"].ToString(), Reader["blood"].ToString(), Reader["orgid"].ToString());
                    patients.Add(p);

                }
                Reader.Close();
                DBConnect.CloseConn();
            }
            else
            {
                SQLiteDataReader Reader = DBConnect.ReadingLite(SQL);
                while (Reader.Read())
                {
                    Patient p = new Patient(Reader["id"].ToString(), Reader["patientNo"].ToString(), Reader["contact"].ToString(), Reader["surname"].ToString(), Reader["lastname"].ToString(), Reader["email"].ToString(), Reader["dob"].ToString(), Reader["nationality"].ToString(), Reader["address"].ToString(), Reader["kin"].ToString(), Reader["kincontact"].ToString(), Reader["gender"].ToString(), Reader["image"].ToString(), Reader["created"].ToString(), Reader["religion"].ToString(), Reader["blood"].ToString(), Reader["orgid"].ToString());
                    patients.Add(p);
                }
                Reader.Close();

            }
            return patients;

        }
    }
}
