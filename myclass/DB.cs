using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace crud.myclass
{
    internal class DB
    {
        public MySqlConnection con;

        public DB()
        {
            string host = "localhost";
            string database = "studentdb";
            string username = "root";
            string password = "";
            string port = "3306";

            string constring = "datasource=" + host + ";database=" + database + ";port=" + port + ";username=" + username + ";" +
                "password=" + password + ";SslMode =none;";

            con = new MySqlConnection(constring);
        }
    }

    class CRUD : DB
    {
        public string name { get; set; }

        public string age { get; set; }

        public string gender { get; set; }

        public string id { get; set; }

        public DataTable dt = new DataTable();
        public DataSet ds = new DataSet();

        public void Create_data()
        {
            con.Open();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "INSERT INTO student('name', 'age', 'gender') VALUES(name, @age, @gender) ";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;

                cmd.Parameters.Add("name", MySqlDbType.VarChar).Value= name;
                cmd.Parameters.Add("@age", MySqlDbType.VarString).Value = age;
                cmd.Parameters.Add("@gender", MySqlDbType.VarChar).Value = gender;

                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
