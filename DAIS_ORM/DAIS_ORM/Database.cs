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
    public class Uzivatel:Database {
        public void RegistraceUzivatele(string jmeno, string heslo, string hesloZnova, string email, int obecId, DateTime datumNarozeni) {
            SqlCommand reg = _connection.CreateCommand();
            //TODO 
        }

        public DataTable SeznamUzivatelu() {
            SqlCommand list = _connection.CreateCommand();
            list.CommandText = @"SELECT UZIVATEL_ID, NICK, BAN, o.NAZEV FROM SEM_UZIVATEL u 
                                    JOIN SEM_OBEC o ON u.OBEC_OBEC_ID = o.OBEC_ID";
            SqlDataReader reader = list.ExecuteReader();
            var tmp = new DataTable();
            tmp.Load(reader);
            return tmp;
        }

        public DataTable SeznamUzivatelu(int obecId) {
            SqlCommand list = _connection.CreateCommand();
            list.CommandText = @"SELECT UZIVATEL_ID, NICK, BAN, o.NAZEV FROM SEM_UZIVATEL u 
                                    JOIN SEM_OBEC o ON u.OBEC_OBEC_ID = o.OBEC_ID 
                                    WHERE OBEC_ID=obecId";
            SqlDataReader reader = list.ExecuteReader();
            var tmp = new DataTable();
            tmp.Load(reader);
            return tmp;
        }

        public void ZmenaStavuUzivatele(int uzivatelId, int stav) {
            SqlCommand zmena = _connection.CreateCommand();
            zmena.CommandText = @"update SEM_UZIVATEL set ban=@ban where UZIVATEL_ID=uzivatelId";
            zmena.Parameters.AddWithValue("ban", stav);
            zmena.ExecuteNonQuery();
        }

        public void SmazaniUzivatele(int uzivatelId) {
            SqlCommand zmena = _connection.CreateCommand();
            zmena.CommandText = @"update SEM_UZIVATEL set ban=-1 where UZIVATEL_ID = uzivatelId";
            zmena.ExecuteNonQuery();
        }

        public void PrihlaseniUzivatele(string email, string heslo) {
            SqlCommand pickPasswd = _connection.CreateCommand();
            pickPasswd.CommandText = "select HESLO from SEM_UZIVATEL where EMAIL=@mail";
            pickPasswd.Parameters.AddWithValue("mail", email);
            SqlDataReader readPasswd = pickPasswd.ExecuteReader();
            readPasswd.Read();
            string hash = (string)readPasswd["heslo"];
            if (BCrypt.Net.BCrypt.Verify(heslo, hash)) {
                SqlCommand login = _connection.CreateCommand();
                login.CommandText = "select HESLO from SEM_UZIVATEL where EMAIL=@mail";
                login.Parameters.AddWithValue("mail", email);
                SqlDataReader readUsr = pickPasswd.ExecuteReader();
                
            }
        }
    }
    
}