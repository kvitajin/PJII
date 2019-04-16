using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Lesson8
{
    static class SqlDataReaderExtensions
    {
        public static byte? GetByteOrNull(this SqlDataReader reader, string colName)
        {
            return reader.IsDBNull(reader.GetOrdinal(colName)) ? null : (byte?)reader.GetByte(reader.GetOrdinal(colName));
        }

    }
    class Program
    {
        
        static void Main(string[] args)
        {
            Users u = new Users()
            {
                Age = 12,
                Firstname = "AAAA",
                Lastname = "Uuu",
                IsDeleted = false
            };
            /*
        String SqlConnectionStirng ="Server = 'dbsys.cs.vsb.cz\\STUDENT', Database = 'kvi0029', User Id = 'kvi0029', password = 'F9iwd7GDiu'";
            using (SqlConnection conn = new SqlConnection(ConnectString))
            {

                conn.Open();
                string insertQuery = @"insert into Users (firstname, lastname, age, isDeleted) values (@FN, @LN, @A, @ID);";
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = insertQuery;
                    cmd.Connection = conn;

                    cmd.Parameters.Add(new SqlParameter() {
                        ParameterName = "FN",
                        Value = u.Firstname
                    });

                    cmd.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "LN",
                        Value = u.Lastname
                    });

                    cmd.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "A",
                        Value = u.Age == null? DBNull.Value : (object)u.Age
                    });

                    cmd.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "ID",
                        Value = u.IsDeleted
                    });

                    cmd.ExecuteNonQuery();
                  
                }
                conn.Close();*/

            String ConnectString="Server = 'dbsys.cs.vsb.cz\\STUDENT', Database = 'kvi0029', User Id = 'kvi0029', password = 'F9iwd7GDiu'";
            using (SqlConnection conn = new SqlConnection(ConnectString))
            {

                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();
                
                string selectCountQuer = "Select count (*) from Users;";
                using (SqlCommand cmd = new SqlCommand(selectCountQuer, conn))
                {
                    int count = (int)cmd.ExecuteScalar();
                    //Console.Write(count);
                }

                Users u2;

                string selectQuer = "Select * from Users;";
                using (SqlCommand cmd = new SqlCommand(selectQuer, conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        u2 = new Users()
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("id")),
                            Age = reader.GetInt32(reader.GetOrdinal("age")),
                            Firstname = reader.GetString(reader.GetOrdinal("Firstname")),
                            Lastname = reader.GetString(reader.GetOrdinal("Lastname")),
                            IsDeleted = reader.GetBoolean(reader.GetOrdinal("isDeleted"))
                        };
                        //Console.WriteLine(u2.Firstname);
                    }
                    reader.Close();
                }
                
                string deleteQuer = @"Delete from Users where id= @Iden;";
                using (SqlCommand cmd = new SqlCommand(deleteQuer, conn))
                {
                    cmd.Transaction = tran;
                    cmd.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "Iden",
                        Value = 1                        
                    });

                    cmd.ExecuteNonQuery();

                }

                tran.Commit();
                conn.Close();
                Console.Read();
            }
        }
    }

    class Users
    {
        string firstname;
        private string lastname;
        int age;
        bool isDeleted;
        public int Id;

        public string Firstname {
            get { return firstname; }
            set { firstname = value; } }
        public string Lastname  {
            get { return lastname; }
            set { lastname = value; } }
        public int? Age {
            get { return age; }
            set { age = value.Value; }
        }
        public bool IsDeleted
        {
            get { return isDeleted; }
            set { isDeleted = value; }
        }
    }
}
