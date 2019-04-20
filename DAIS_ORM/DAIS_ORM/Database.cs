using System;
using System.Data;
using System.Data.SqlClient;
namespace DAIS_ORM {
    public class Database {
        protected SqlConnection _connection;
        public void Connect() {
            this._connection = new SqlConnection();
            _connection.ConnectionString = "data source=dbsys.cs.vsb.cz\\STUDENT; initial catalog=kvi0029; user id=kvi0029; password=F9iwd7GDiu;";
            _connection.Open();
        }
    }
}

