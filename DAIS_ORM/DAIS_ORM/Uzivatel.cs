using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
namespace DAIS_ORM {
       public class Uzivatel:Database {
        public void RegistraceUzivatele(string jmeno, string heslo, string hesloZnova, string email, int obecId, DateTime datumNarozeni) {
            SqlCommand reg = _connection.CreateCommand();
            //TODO 
        }

        public IList<User> SeznamUzivatelu() {
            SqlCommand list = _connection.CreateCommand();
            list.CommandText = @"SELECT UZIVATEL_ID, NICK, BAN, o.NAZEV FROM SEM_UZIVATEL u 
                                    JOIN SEM_OBEC o ON u.OBEC_OBEC_ID = o.OBEC_ID";
            SqlDataReader reader = list.ExecuteReader();
            User tmp = new User();
            IList<User> vystup= new List<User>();
            while (reader.Read()) {
                tmp.UzovatelId = Convert.ToInt32(reader["uzivatel_id"]);
                tmp.Ban = Convert.ToInt32(reader["ban"]);
                tmp.Nick = Convert.ToString(reader["nick"]);
                tmp.ObecNazev = Convert.ToString(reader["nazev"]);
                vystup.Add(tmp);
            }

            return vystup;
        }

        public IList<User> SeznamUzivatelu(int obecId) {
            SqlCommand list = _connection.CreateCommand();
            list.CommandText = @"SELECT UZIVATEL_ID, NICK, BAN, o.NAZEV FROM SEM_UZIVATEL u 
                                    JOIN SEM_OBEC o ON u.OBEC_OBEC_ID = o.OBEC_ID 
                                    WHERE OBEC_ID=obecId";
            SqlDataReader reader = list.ExecuteReader();
            User tmp = new User();
            IList<User> vystup= new List<User>();
            while (reader.Read()) {
                tmp.UzovatelId = Convert.ToInt32(reader["uzivatel_id"]);
                tmp.Ban = Convert.ToInt32(reader["ban"]);
                tmp.Nick = Convert.ToString(reader["nick"]);
                tmp.ObecNazev = Convert.ToString(reader["nazev"]);
                vystup.Add(tmp);
            }

            return vystup;
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
                User usr = new User();
                usr.Nick = (string)readUsr["nick"];
                usr.Ban = (int) readUsr["ban"];
                usr.ObecId = (int) readUsr["obec_id"];
            }
        }

        
    }
       public class User {
           private string nick;
           private int ban;
           private int obecId;
           private string obec_nazev;
           private int uzovatel_id;

           public string ObecNazev {
               get => obec_nazev;
               set => obec_nazev = value;
           }

           public int UzovatelId {
               get => uzovatel_id;
               set => uzovatel_id = value;
           }

           public string Nick {
               get => nick;
               set => nick = value;
           }

           public int Ban {
               get => ban;
               set => ban = value;
           }

           public int ObecId {
               get => obecId;
               set => obecId = value;
           }

       }
}