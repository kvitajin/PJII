using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace DAIS_ORM {
    public class Dokument:Database {
//        public void VytvorDokument(int obecId, string nadpis, string text, int rubrikaId, string obrazek=null) {
//            SqlCommand create = _connection.CreateCommand();
//            DateTime now=DateTime.Today;
//
//            if (obrazek == null) { 
//                create.CommandText = @"INSERT INTO SEM_DOKUMENT(nadpis, obsah, datum, rubrika_rubrika_id) 
//                values (@nadpis, @text, @text, @rubrikaId)";
//            }
//            else {
//                create.CommandText = @"INSERT INTO SEM_DOKUMENT(nadpis, obsah, datum, obrazek, rubrika_rubrika_id) 
//                values (@nadpis, @text, @datum, @obrazek, @rubrikaId)";
//                create.Parameters.AddWithValue("obrazek", obrazek);
//            }
//            create.Parameters.AddWithValue("nadpis", nadpis);
//            create.Parameters.AddWithValue("obsah", text);
//            create.Parameters.AddWithValue("datum", now);
//            create.Parameters.AddWithValue("rubrikaId", rubrikaId);
//            create.ExecuteNonQuery(); 
//        }
//
//        public void UpravDokument(int dokumentId, string obsah) {
//            SqlCommand edit = _connection.CreateCommand();
//            edit.CommandText = "UPDATE sem_dokument SET OBSAH = @obsah WHERE DOKUMENT_ID= @id";
//            edit.Parameters.AddWithValue("obsah", obsah);
//            edit.Parameters.AddWithValue("id", dokumentId);
//            edit.ExecuteNonQuery();
//        }
//
//        public IList<Doku> ZobrazVRubrice(int rubrikaId) {
//            SqlCommand show = _connection.CreateCommand();
//            show.CommandText = "SELECT NADPIS, OBSAH, DATUM FROM SEM_DOKUMENT WHERE RUBRIKA_RUBRIKA_ID= rubrikaId";
//            SqlDataReader reader =show.ExecuteReader();
//            IList<Doku> vystup= new List<Doku>();
//            Doku tmp = new Doku();
//            while (reader.Read()) {
//                tmp.Nadpis = Convert.ToString(reader["nadpis"]);
//                tmp.Obsah = Convert.ToString(reader["obsah"]);
//                tmp.Datum = Convert.ToDateTime(reader["datum"]);
//                vystup.Add(tmp);
//            }
//            reader.Close();
//            return vystup;
//        }
//
//        public void KomentujDokument(int dokumentId, string text, int uzivatelId) {
//            SqlCommand comment = _connection.CreateCommand();
//            comment.CommandText =
//                "INSERT INTO SEM_KOMENTAR(obsah, dokument_dokument_id, uzivatel_uzivatel_id) VALUES (@obsah, @dokumentId, @uzivatelId)";
//            comment.Parameters.AddWithValue("obsah", text);
//            comment.Parameters.AddWithValue("dokumentId", dokumentId);
//            comment.Parameters.AddWithValue("uzivatelId", uzivatelId);
//            comment.ExecuteNonQuery();
//        }
//
//        public void ZmenRubrikuDokumentu(int dokumentId, int rubrikaId) {
//            SqlCommand change = _connection.CreateCommand();
//            change.CommandText = "UPDATE sem_dokument SET RUBRIKA_RUBRIKA_ID=rubrikaId where DOKUMENT_ID=dokumentId";
//            change.ExecuteNonQuery();
//        }
//        
        
    }

    public class Doku {
        private string nadpis;
        private string obsah;
        private DateTime datum;

        public string Nadpis {
            get => nadpis;
            set => nadpis = value;
        }

        public string Obsah {
            get => obsah;
            set => obsah = value;
        }

        public DateTime Datum {
            get => datum;
            set => datum = value;
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