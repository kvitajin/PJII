using System.Collections.Generic;
using System.ComponentModel;
using Oracle.ManagedDataAccess.Client;

namespace DAIS_ORM {
    public class Komentar:Database {
        private string obsah;

        public string Obsah {
            get => obsah;
            set => obsah = value;
        }

        public string Autor {
            get => autor;
            set => autor = value;
        }

        private string autor;
         
        
        public void SmazatKomentar(int komentarId) {
            using (Connection) {
                using (OracleCommand cmd = new OracleCommand()) {
                    cmd.Connection = Connection;
                    cmd.CommandText = "DELETE FROM SEM_KOMENTAR WHERE KOMENTAR_ID=:komentarId";
                    cmd.Parameters.Add("komentarId", komentarId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Komentar> ZobrazKomentareDokumentu(int dokumentId) {
            using (Connection) {
                using (OracleCommand cmd = new OracleCommand()) {
                    cmd.Connection = Connection;
                    cmd.CommandText = "SELECT obsah, nick FROM SEM_KOMENTAR k  JOIN SEM_UZIVATEL u ON k.UZIVATEL_UZIVATEL_ID = u.UZIVATEL_ID WHERE DOKUMENT_DOKUMENT_ID = :dokumentId ORDER BY KOMENTAR_ID" ;
                    cmd.Parameters.Add("dokumentiId", dokumentId);
                    OracleDataReader reader = cmd.ExecuteReader();
                    List<Komentar> vystup= new List<Komentar>();
                    while (reader.Read()) {
                        Komentar tmp = new Komentar();
                        tmp.obsah = (string) reader.GetValue(0);
                        tmp.Autor = (string) reader.GetValue(1);
                        vystup.Add(tmp);
                    }
                    reader.Close();
                    return vystup;
                }
                
            }
        }
        
        public List<Komentar> ZobrazKomentareFotky(int fotoId) {
            using (Connection) {
                using (OracleCommand cmd = new OracleCommand()) {
                    cmd.Connection = Connection;
                    cmd.CommandText = "SELECT obsah, nick FROM SEM_KOMENTAR k  JOIN SEM_UZIVATEL u ON k.UZIVATEL_UZIVATEL_ID = u.UZIVATEL_ID WHERE FOTO_FOTO_ID = :fotoId ORDER BY KOMENTAR_ID" ;
                    cmd.Parameters.Add("fotoId", fotoId);
                    OracleDataReader reader = cmd.ExecuteReader();
                    List<Komentar> vystup= new List<Komentar>();
                    while (reader.Read()) {
                        Komentar tmp = new Komentar();
                        tmp.obsah = (string) reader.GetValue(0);
                        tmp.Autor = (string) reader.GetValue(1);
                        vystup.Add(tmp);
                    }
                    reader.Close();
                    return vystup;
                }
                
            }
        }
        
            
    }
}