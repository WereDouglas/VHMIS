using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using VHMIS.SQLite;

namespace VHMIS
{
    public static class DBConnect
    {
        public static NpgsqlConnection conn = new NpgsqlConnection("Server=127.0.0.1;Port=5432;User Id=vhmis;Password=admin;Database=vhmis;");
        static Connection dbobject = new Connection();
        static SQLiteConnection SQLconnect = new SQLiteConnection();
        public static void OpenConn()
        {
            try
            {
                conn.Open();
            }
            catch (Exception exp)
            {
                Console.WriteLine("Error :S");
            }
        }

        public static void CloseConn()
        {
            try
            {
                conn.Close();
            }
            catch (Exception)
            {
                Console.WriteLine("Error :S");
            }
        }
        public static void saveImage(string table, string stream, string id)
        {
            OpenConn();
            NpgsqlCommand command = new NpgsqlCommand("Update " + table + " SET image = '" + stream + "' WHERE id ='" + id + "';", conn);
            //command.Parameters.Add(new NpgsqlParameter("id", id));
            //command.Parameters.Add(new NpgsqlParameter("image", stream));
            Int32 rowsaffected = command.ExecuteNonQuery();
            CloseConn();

        }
        static NpgsqlDataReader Readers = null;
        static NpgsqlCommand cmd = null;
        public static NpgsqlDataReader Reading(string query)
        {
            Readers = null;
            DBConnect.OpenConn();
            cmd = new NpgsqlCommand(query, DBConnect.conn);
            Readers = cmd.ExecuteReader();
            return Readers;

        }
        static SQLiteDataReader Reader;
        public static SQLiteDataReader ReadingLite(string query)
        {
            try
            {
                SQLconnect.ConnectionString = dbobject.datalocation();
                SQLconnect.Open();
            }
            catch
            {

            }
            SQLiteCommand cmd = new SQLiteCommand();
            cmd = SQLconnect.CreateCommand();
            cmd.CommandText = query;
            Reader = cmd.ExecuteReader();
            return Reader;
        }

        public static string save(string query)
        {
            Int32 rowsaffected = 0;
            if (!Helper.Type.Contains("Lite"))
            {
                //try
                //{
                OpenConn();

                NpgsqlCommand command = new NpgsqlCommand(query, conn);
                rowsaffected = command.ExecuteNonQuery();

                CloseConn();
                // return rowsaffected.ToString();
                //}
                //catch (Exception c)
                //{
                //    Console.WriteLine("Errr on insert!" + c.Message);
                //    return "";
                //}
            }
            else
            {
                try
                {
                    SQLconnect.ConnectionString = dbobject.datalocation();
                    SQLconnect.Open();
                }
                catch
                {

                }

                SQLiteCommand cmd = new SQLiteCommand();
                cmd = SQLconnect.CreateCommand();
                cmd.CommandText = query;

                rowsaffected = cmd.ExecuteNonQuery();
                cmd.Dispose();
                SQLconnect.Close();
            }
            return rowsaffected.ToString();
        }
        public static string Insert(Object objGen)
        {
            Int32 rowsaffected = 0;
            //try
            //{


            // Get type and properties (vector)
            Type typeObj = objGen.GetType();
            PropertyInfo[] properties = typeObj.GetProperties();

            // Get table
            string[] type = typeObj.ToString().Split('.');
            string table = type[2].ToLower();

            // Start mounting string to insert
            string SQL = "INSERT INTO " + table + " VALUES (";

            // It goes from second until second to last
            for (int i = 0; i < properties.Length - 1; i++)
            {
                object propValue = properties[i].GetValue(objGen, null);
                string[] typeValue = propValue.GetType().ToString().Split('.');
                if (typeValue[1].Equals("String"))
                {
                    SQL += "'" + propValue.ToString() + "',";
                }
                else if (typeValue[1].Equals("DateTime"))
                {
                    SQL += "'" + Convert.ToDateTime(propValue.ToString()).ToShortDateString() + "',";
                }

                else
                {
                    SQL += propValue.ToString() + ",";
                }
            }

            // get last attribute here
            object lastValue = properties[properties.Length - 1].GetValue(objGen, null);
            string[] lastType = lastValue.GetType().ToString().Split('.');
            if (lastType[1].Equals("String"))
            {
                SQL += "'" + lastValue.ToString() + "'";
            }
            else if (lastType[1].Equals("DateTime"))
            {
                SQL += "'" + Convert.ToDateTime(lastValue.ToString()).ToShortDateString() + "'";
            }

            else
            {
                SQL += lastValue.ToString();
            }

            // Ends string builder
            SQL += ");";

            // Execute command
            if (!Helper.Type.Contains("Lite"))
            {
                OpenConn();
                NpgsqlCommand command = new NpgsqlCommand(SQL, conn);
                rowsaffected = command.ExecuteNonQuery();

                CloseConn();
                return rowsaffected.ToString();
                //}
                //catch (Exception c)
                //{
                //    Console.WriteLine("Errr on insert!" + c.Message);
                //    return "";
                //}
            }
            else
            {
                try
                {
                    SQLconnect.ConnectionString = dbobject.datalocation();
                    SQLconnect.Open();
                }
                catch
                {

                }

                SQLiteCommand cmd = new SQLiteCommand();
                cmd = SQLconnect.CreateCommand();
                cmd.CommandText = SQL;

                rowsaffected = cmd.ExecuteNonQuery();
                cmd.Dispose();
                SQLconnect.Close();
            }
            return rowsaffected.ToString();
        }

        public static string CreateDBSQL(Object objGen)
        {
            //try
            //{
            // OpenConn();

            // Get type and properties (vector)
            Type typeObj = objGen.GetType();
            PropertyInfo[] properties = typeObj.GetProperties();

            // Get table
            string[] type = typeObj.ToString().Split('.');
            string table = type[2].ToLower();

            // Start mounting string to insert           
            string SQL = "CREATE TABLE IF NOT  EXISTS " + table + "  (";

            // It goes from second until second to last
            for (int i = 0; i < properties.Length - 1; i++)
            {
                //object propValue = properties[i].GetValue(objGen, null);
                string[] typeValue = properties[i].ToString().Split(' ');
                SQL += "" + typeValue[1].ToString() + " varchar(255),";

            }

            // get last attribute here           
            string[] lastType = properties[properties.Length - 1].ToString().Split(' ');

            SQL += "" + lastType[1].ToString() + " varchar(255)";


            // Ends string builder
            SQL += ");";


            return SQL;
            //}
            //catch (Exception c)
            //{
            //    Console.WriteLine("Errr on insert!" + c.Message);
            //    return "";
            //}
        }


        public static string EmptyDBSQL(Object objGen)
        {
            //try
            //{
            // OpenConn();

            // Get type and properties (vector)
            Type typeObj = objGen.GetType();
            PropertyInfo[] properties = typeObj.GetProperties();

            // Get table
            string[] type = typeObj.ToString().Split('.');
            string table = type[2].ToLower();

            // Start mounting string to insert           
            string SQL = "DELETE FROM " + table + "";




            return SQL;
            //}
            //catch (Exception c)
            //{
            //    Console.WriteLine("Errr on insert!" + c.Message);
            //    return "";
            //}
        }


        public static string GenerateQuery(Object objGen)
        {
            //try
            //{

            Type typeObj = objGen.GetType();
            PropertyInfo[] properties = typeObj.GetProperties();

            // Get table
            string[] type = typeObj.ToString().Split('.');
            string table = type[2].ToLower();

            // Start mounting string to insert
            string SQL = "INSERT INTO " + table + " VALUES (";

            // It goes from second until second to last
            for (int i = 0; i < properties.Length - 1; i++)
            {
                object propValue = properties[i].GetValue(objGen, null);
                string[] typeValue = propValue.GetType().ToString().Split('.');
                if (typeValue[1].Equals("String"))
                {
                    SQL += "'" + propValue.ToString() + "',";
                }
                else if (typeValue[1].Equals("DateTime"))
                {
                    SQL += "'" + Convert.ToDateTime(propValue.ToString()).ToShortDateString() + "',";
                }

                else
                {
                    SQL += propValue.ToString() + ",";
                }
            }

            // get last attribute here
            object lastValue = properties[properties.Length - 1].GetValue(objGen, null);
            string[] lastType = lastValue.GetType().ToString().Split('.');
            if (lastType[1].Equals("String"))
            {
                SQL += "'" + lastValue.ToString() + "'";
            }
            else if (lastType[1].Equals("DateTime"))
            {
                SQL += "'" + Convert.ToDateTime(lastValue.ToString()).ToShortDateString() + "'";
            }

            else
            {
                SQL += lastValue.ToString();
            }

            // Ends string builder
            SQL += ");";

            return SQL;

        }
        public static void Update(Object objGen, string idValue)
        {
            Int32 rowsaffected = 0;
            //try
            //{


            // Get table
            string[] type = objGen.GetType().ToString().Split('.');
            string table = type[2].ToLower();

            // Start building
            string SQL = "UPDATE " + table + " SET ";

            // Get types and properties
            Type type2 = objGen.GetType();
            PropertyInfo[] properties = type2.GetProperties();

            // Goes until second to last
            for (int i = 0; i < properties.Length - 1; i++)
            {
                object propValue = properties[i].GetValue(objGen, null);
                string[] nameAttribute = properties[i].ToString().Split(' ');
                string[] typeAttribute = propValue.GetType().ToString().Split('.');

                if (typeAttribute[1].Equals("String"))
                {
                    SQL += nameAttribute[1] + " = '" + propValue.ToString() + "',";
                }
                else if (typeAttribute[1].Equals("DateTime"))
                {
                    SQL += nameAttribute[1] + "= '" + Convert.ToDateTime(propValue.ToString()).ToShortDateString() + "',";
                }
                else
                {
                    SQL += nameAttribute[1] + " = " + propValue.ToString() + ",";
                }
            }

            // Process last attribute
            object lastValue = properties[properties.Length - 1].GetValue(objGen, null);
            string[] lastType = lastValue.GetType().ToString().Split('.');
            string[] ultimoCampo = properties[properties.Length - 1].ToString().Split(' ');
            if (lastType[1].Equals("String"))
            {
                SQL += ultimoCampo[1] + " = '" + lastValue.ToString() + "'";
            }
            else if (lastType[1].Equals("DateTime"))
            {
                SQL += ultimoCampo[1] + "= '" + Convert.ToDateTime(lastValue.ToString()).ToShortDateString() + "'";
            }
            else
            {
                SQL += ultimoCampo[1] + " = " + lastValue.ToString();
            }

            // Ends string builder
            SQL += " WHERE id = '" + idValue + "';";


            //}
            //catch (Exception)
            //{
            //    Console.WriteLine("Errr on update!");
            //}

            if (!Helper.Type.Contains("Lite"))
            {
                OpenConn();
                NpgsqlCommand command = new NpgsqlCommand(SQL, conn);
                rowsaffected = command.ExecuteNonQuery();

                CloseConn();

                //}
                //catch (Exception c)
                //{
                //    Console.WriteLine("Errr on insert!" + c.Message);
                //    return "";
                //}
            }
            else
            {
                try
                {
                    SQLconnect.ConnectionString = dbobject.datalocation();
                    SQLconnect.Open();
                }
                catch
                {

                }

                SQLiteCommand cmd = new SQLiteCommand();
                cmd = SQLconnect.CreateCommand();
                cmd.CommandText = SQL;

                rowsaffected = cmd.ExecuteNonQuery();
                cmd.Dispose();
                SQLconnect.Close();
            }

        }
        public static void Execute(string query)
        {
            //try
            //{

            //}
            //catch (Exception c)
            //{
            //    Console.WriteLine("Errr on update!" + c.Message.ToString());
            //}

            if (!Helper.Type.Contains("Lite"))
            {
                OpenConn();
                NpgsqlCommand command = new NpgsqlCommand(query, conn);
                Int32 rowsaffected = command.ExecuteNonQuery();

                CloseConn();

                //}
                //catch (Exception c)
                //{
                //    Console.WriteLine("Errr on insert!" + c.Message);
                //    return "";
                //}
            }
            else
            {
                try
                {
                    SQLconnect.ConnectionString = dbobject.datalocation();
                    SQLconnect.Open();
                }
                catch
                {

                }

                SQLiteCommand cmd = new SQLiteCommand();
                cmd = SQLconnect.CreateCommand();
                cmd.CommandText = query;

                cmd.Dispose();
                SQLconnect.Close();
            }

        }
        public static void Delete(string table, string idValue)
        {
            //try
            //{
            OpenConn();

            string SQL = "DELETE FROM " + table + " WHERE id = '" + idValue + "';";

            NpgsqlCommand command = new NpgsqlCommand(SQL, conn);
            Int32 rowsaffected = command.ExecuteNonQuery();

            CloseConn();
            //}
            //catch (Exception)
            //{
            //    Console.WriteLine("Errr on update!");
            //}
        }
        public static List<Object> QueryTable(string table)
        {
            try
            {
                OpenConn();

                List<Object> lstSelect = new List<Object>();
                string SQL = "SELECT * FROM " + table + ";";

                NpgsqlCommand command = new NpgsqlCommand(SQL, conn);
                NpgsqlDataReader dr = command.ExecuteReader();

                while (dr.Read())
                {
                    for (int i = 0; i < dr.FieldCount; i++)
                    {
                        lstSelect.Add(dr[i]);
                    }
                }

                CloseConn();

                return lstSelect;
            }
            catch (Exception)
            {
                Console.WriteLine("Errr on query!");
                return null;
            }
        }
        //public List<Object> QueryOnTableWithParams(string table, string[] paramName, string[] paramValue)
        //{
        //    try
        //    {
        //        if (paramName.Count != paramValue.Count)
        //        {
        //           Console.WriteLine("Wrong number of params");
        //            return null;
        //        }

        //        this.OpenConn();

        //        List<Object> lstSelect = new List<Object>();
        //        string SQL = "SELECT * FROM " + table + " WHERE ";

        //        // get params
        //        for (int i = 0; i < paramName.Count - 1; i++)
        //        {
        //            SQL += paramName[i] + " = " + paramValue[i] + " AND ";
        //        }

        //        // get last param
        //        SQL += paramName[paramName.Count - 1] + " = " + paramValue[paramValue.Count - 1] + ";";

        //        NpgsqlCommand command = new NpgsqlCommand(SQL, conn);
        //        NpgsqlDataReader dr = command.ExecuteReader();

        //        while (dr.Read())
        //        {
        //            for (int i = 0; i < dr.FieldCount; i++)
        //            {
        //                lstSelect.Add(dr[i]);
        //            }
        //        }

        //        this.CloseConn();

        //        return lstSelect;
        //    }
        //    catch (Exception)
        //    {
        //       Console.WriteLine("Errr on query!");
        //        return null;
        //    }
        //}
    }

}
