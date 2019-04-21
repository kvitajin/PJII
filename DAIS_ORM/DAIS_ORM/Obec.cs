using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;

namespace DAIS_ORM {
    public class Obec : Database {
        public void VytvorObec(string nazev) {
            SqlCommand create = _connection.CreateCommand();
            create.CommandText = "INSERT INTO SEM_OBEC(NAZEV) VALUES (@NAZEV)";
            create.Parameters.AddWithValue("NAZEV", nazev);
            create.ExecuteNonQuery();
        }

        public void SkryjObec(int obecId) {
            SqlCommand hide = _connection.CreateCommand();
            hide.CommandText = "UPDATE SEM_OBEC SET VIDIBLE =0 where OBEC_ID=obecId";
            hide.ExecuteNonQuery();
        }

        public IList<Obc> ZobrazObce() {
            SqlCommand show = _connection.CreateCommand();
            show.CommandText = "SELECT NAZEV FROM SEM_OBEC WHERE VIDIBLE=1 ";
            Obc tmp = new Obc();
            IList<Obc> vystup = new List<Obc>();
            SqlDataReader reader = show.ExecuteReader();
            while ((reader.Read())) {
                tmp.Nazev = Convert.ToString(reader["nazev"]);
                vystup.Add(tmp);
            }

            return vystup;
        }
    }

    public class Obc {
        private string nazev;
        private int visibility;

        public string Nazev {
            get => nazev;
            set => nazev = value;
        }

        public int Visibility {
            get => visibility;
            set => visibility = value;
        }
    }
}