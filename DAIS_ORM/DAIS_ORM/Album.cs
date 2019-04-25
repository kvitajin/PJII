using System.Data.SqlClient;

namespace DAIS_ORM {
    public class Album:Database {
//        public void VytvorAlbum(string nazev, int obecId) {
//            SqlCommand create = Connection.CreateCommand();
//            create.CommandText = "INSERT INTO SEM_ALBUM(nazev, obec_obec_id) VALUES (@nazev, obecId)";
//            create.Parameters.AddWithValue("nazev", nazev);
//            create.ExecuteNonQuery();
//        }

        public void ZobrazAlbaObce(int obecId) {
            
        }
    }
}