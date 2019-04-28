using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks.Dataflow;
using Oracle.ManagedDataAccess.Client;

namespace DAIS_ORM {
    public class Album:Database {
        private string nazev;

        public string Nazev {
            get => nazev;
            set => nazev = value;
        }

        public void VytvorAlbum(string nazev, int obecId) {
            using (Connection) {
                using (OracleCommand cmd = new OracleCommand()) {
                    cmd.Connection = Connection;
                    cmd.CommandText = @"INSERT INTO SEM_ALBUM (ALBUM_ID, NAZEV, OBEC_OBEC_ID) 
                    VALUES (SEQ_ALBUM.nextval, :nazev, :obecId)";
                    cmd.Parameters.Add("nazev", nazev);
                    cmd.Parameters.Add("obecId", obecId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Album> ZobrazAlbaObce(int obecId) {
            using (Connection) {
                using (OracleCommand cmd = new OracleCommand()) {
                    cmd.Connection = Connection;
                    cmd.CommandText = "SELECT NAZEV FROM SEM_ALBUM WHERE OBEC_OBEC_ID = :obecId AND VIDIBLE=1";
                    cmd.Parameters.Add("obecId", obecId);
                    OracleDataReader reader = cmd.ExecuteReader();
                    List<Album> vystup = new List<Album>();
                    while (reader.Read()) {
                        Album tmp = new Album();
                        tmp.nazev = (string)reader.GetValue(0);
                        vystup.Add(tmp);
                    }
                    reader.Close();
                    return vystup;
                }
            }
        }

        public void SkryjAlbum(int albumId) {
            using (Connection) {
                using (OracleCommand cmd = new OracleCommand()) {
                    cmd.Connection = Connection;
                    cmd.CommandText = "UPDATE SEM_ALBUM SET VIDIBLE=0 WHERE ALBUM_ID = :albumId";
                    cmd.Parameters.Add("albumId", albumId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}