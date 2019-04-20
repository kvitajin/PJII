using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAIS_ORM {
    public class Dokument:Database {
        public void VytvorDokument(int obecId, string nadpis, string text, int rubrikaId, string obrazek=null) {
            SqlCommand create = _connection.CreateCommand();
            DateTime now=DateTime.Today;

            if (obrazek == null) { 
                create.CommandText = @"INSERT INTO SEM_DOKUMENT(nadpis, obsah, datum, rubrika_rubrika_id) 
                values (@nadpis, @text, @text, @rubrikaId)";
            }
            else {
                create.CommandText = @"INSERT INTO SEM_DOKUMENT(nadpis, obsah, datum, obrazek, rubrika_rubrika_id) 
                values (@nadpis, @text, @text, @obrazek, @rubrikaId)";
                create.Parameters.AddWithValue("obrazek", obrazek);
            }
            create.Parameters.AddWithValue("nadpis", nadpis);
            create.Parameters.AddWithValue("obsah", text);
            create.Parameters.AddWithValue("datum", now);
            create.Parameters.AddWithValue("rubrikaId", rubrikaId);
            create.ExecuteNonQuery(); 
        }
    }
}


/*SqlCommand list = _connection.CreateCommand();
            list.CommandText = @"SELECT UZIVATEL_ID, NICK, BAN, o.NAZEV FROM SEM_UZIVATEL u 
                                    JOIN SEM_OBEC o ON u.OBEC_OBEC_ID = o.OBEC_ID";
            SqlDataReader reader = list.ExecuteReader();
            var tmp = new DataTable();
            tmp.Load(reader);
            return tmp;*/