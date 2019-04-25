using System;
using System.Data;
using System.Data.SqlClient;
using Oracle.ManagedDataAccess.Client;

namespace DAIS_ORM {
    public class Database {
        protected static OracleConnection _connection;

        public OracleConnection Connection {
            get => _connection;
            set => _connection = value;
        }

        public void Connect() {

            Connection = new OracleConnection(
                "User Id=kvi0029;Password=n2HO69fi3w;Data Source=(DESCRIPTION = (ADDRESS_LIST = (ADDRESS = (PROTOCOL = TCP)(HOST = dbsys.cs.vsb.cz)(PORT = 1521)))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = oracle.dbsys.cs.vsb.cz)));");
            Connection.Open();
        }

        public void Disconnect() {
            Connection.Dispose();
            Connection.Close();
        }
    }
}

