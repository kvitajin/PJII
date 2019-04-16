using System;
using System.Data.SqlClient;

namespace dais1 {
    class Program {
        static void Main(string[] args) {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "data source=dbsys.cs.vsb.cz\\STUDENT; initial catalog=kvi0029; user id=kvi0029; password=F9iwd7GDiu;";
            connection.Open();
            //SqlCommand cmd1 = connection.CreateCommand();
            //cmd1.CommandText = "INSERT INTO Student(login, fname, lname, email) values ('luk012', 'petr', 'vydra', 'petr.vydra@vsb.cz')";    //spatne, kvuli bezpecnosti (sql injection)
            
            //cmd1.ExecuteNonQuery();

//            SqlCommand cmd2 = connection.CreateCommand();
//            cmd2.CommandText =
//                "INSERT INTO Student(login, fname, lname, email) VALUES (@login, @fname, @lname, @email)";
//            cmd2.Parameters.AddWithValue("login", "luk123");
//            cmd2.Parameters.AddWithValue("fname", "Lukas");
//            cmd2.Parameters.AddWithValue("lname", "Pesek");
//            cmd2.Parameters.AddWithValue("email", "likas.pesek@vsb.cz");
//            cmd2.ExecuteNonQuery();
//            
            SqlCommand cmd1 = connection.CreateCommand();
            cmd1.CommandText = "select fname, lname FROM Student";
            SqlDataReader reader = cmd1.ExecuteReader();
            while (reader.Read()) {
                if (reader["fname"] != DBNull.Value) {
                    //neco
                }
                string fname = Convert.ToString(reader["fname"]);
                string lname = Convert.ToString(reader["lname"]);
                Console.WriteLine("{0} {1}", fname, lname);
            }
            reader.Close();
            connection.Close();
        }
    }
}