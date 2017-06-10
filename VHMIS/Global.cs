using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VHMIS.Model;

namespace VHMIS
{
  public static class Global
    {
        public static List<Roles> _roles;
        public static List<Patient> _patients;
        public static List<Users> _users;
        public static List<Events> _events;
        public static List<Clinics> _clinics;
        public static List<Queue> _queues;
        public static List<Admission> _admit;
        public static List<Wards> _wards;
        public static List<Departments> _departments;
        public static List<Procedures> _procedures;
        public static List<Operations> _operations;
        public static List<Specimens> _specimens;
        public static List<Tests> _tests;
        public static List<Discipline> _disciplines;
        public static List<Beds> _beds;
        public static List<Category> _categories;
        public static List<Services> _services;
        public static List<Diagnosis> _diagnosis;
        public static List<Cd10> _cds;
        public static List<Transactor> _transactors;
        public static List<Item> _items;
        public static List<Stock> _stocks;
        public static List<Dosage> _dosages;
        public static List<Room> _rooms;
        public static List<Vitals> _vitals;
        public static List<Organisation> _org;

        public static void LoadData() {

            _roles = new List<Roles>(Roles.ListRoles());
            _patients = new List<Patient>(Patient.ListPatients());
            _users = new List<Users>(Users.ListUsers());
            _events = new List<Events>(Events.ListEvents());
            _clinics = new List<Clinics>(Clinics.ListClinic());
            _queues = new List<Queue>(Queue.ListQueue());
            _admit = new List<Admission>(Admission.ListAdmission());
            _wards = new List<Wards>(Wards.ListWards());
            _departments = new List<Departments>(Departments.ListDepartment());
            _procedures = new List<Procedures>(Procedures.ListProcedures());
            _operations = new List<Operations>(Operations.ListOperations());
            _specimens = new List<Specimens>(Specimens.ListSpecimens());
            _tests = new List<Tests>(Tests.ListTests());
            _disciplines = new List<Discipline>(Discipline.ListDiscipline());
            _beds = new List<Beds>(Beds.ListBeds());
            _categories = new List<Category>(Category.ListCategory());
            _cds = new List<Cd10>(Cd10.ListCd10());
            _items = new List<Item>(Item.ListItem());
            _stocks = new List<Stock>(Stock.ListStock());
            _dosages = new List<Dosage>(Dosage.ListDosage());
            _transactors = new List<Transactor>(Transactor.ListTransactors());
            // _services = new List<Services>(Services.ListServices());
            // _diagnosis = new List<Diagnosis>(Diagnosis.ListDiagnosis());
            _rooms = new List<Room>(Room.ListRoom());
            // _vitals = new List<Vitals>(Vitals.ListVitals());
            _org = new List<Organisation>(Organisation.ListOrganisation());

        }
    }
}
