using System;
using System.Collections.Generic;
using Oracle.ManagedDataAccess.Client;

namespace DAIS_ORM {
    public class Fotografie:Database {
        private string fotka;
        private string popis;
        private DateTime datum;

        public DateTime Datum {
            get => datum;
            set => datum = value;
        }


        public string Fotka {
            get => fotka;
            set => fotka = value;
        }

        public string Popis {
            get => popis;
            set => popis = value;
        }

        public void PridaniFotografie(string nazev, int albumId, string popis= null ) {
            using (Connection) {
                using (OracleCommand cmd = new OracleCommand()) {
                    cmd.Connection = Connection;
                    DateTime now = DateTime.Now;
                    if (popis != null) {
                        cmd.CommandText = @"INSERT INTO SEM_FOTO(foto_id, nazev, datum, popis, album_album_id) 
                VALUES (SEQ_FOTO.nextval, :nazev, :datum, :popis, :albumId)";
                    }
                    else {
                        cmd.CommandText = @"INSERT INTO SEM_FOTO(foto_id, nazev, datum, album_album_id) 
                VALUES (SEQ_FOTO.nextval, :nazev, :datum, :albumId)";
                    }
                    cmd.Parameters.Add("nazev", nazev);
                    cmd.Parameters.Add("datum", now);
                    if (popis != null) {
                        cmd.Parameters.Add("popis", popis);
                    }
                    cmd.Parameters.Add("albumId", albumId);
                    cmd.ExecuteNonQuery();
                    
                }
            }
        }

        public List<Fotografie> ZobrazeniFotografiiAlba(int albumId) {
            using (Connection) {
                using (OracleCommand cmd = new OracleCommand()) {
                    cmd.Connection = Connection;
                    cmd.CommandText = "SELECT NAZEV, DATUM, POPIS FROM SEM_FOTO WHERE ALBUM_ALBUM_ID= :albumId AND VISIBLE=1 ORDER BY DATUM";
                    cmd.Parameters.Add("albumId", albumId);
                    OracleDataReader reader = cmd.ExecuteReader();
                    List<Fotografie> vystup= new List<Fotografie>();
                    while (reader.Read()) {
                        Fotografie tmp = new Fotografie();
                        tmp.Fotka = (string)reader.GetValue(0);
                        tmp.Datum = (DateTime)reader.GetValue(1);
                        tmp.popis = reader.GetValue(2) == null ? null : (string) reader.GetValue(2);
                        vystup.Add(tmp);
                    }
                    reader.Close();
                    return vystup;
                }
            }
        }

        public void SkrytiFotografie(int fotoId) {
            using (Connection) {
                using (OracleCommand cmd = new OracleCommand()) {
                    cmd.Connection = Connection;
                    cmd.CommandText = "UPDATE SEM_FOTO SET VISIBLE = 0 WHERE FOTO_ID = :fotoId ";
                    cmd.Parameters.Add("footId", fotoId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void PridaniKomentare(int fotoId, int uzivatelId, string obsah) {
            using (Connection) {
                using (OracleCommand cmd = new OracleCommand()) {
                    cmd.Connection = Connection;
                    cmd.CommandText = "SELECT ban FROM SEM_UZIVATEL WHERE UZIVATEL_ID=:uzivatelId";
                    cmd.Parameters.Add("uzivatelId", uzivatelId);
                    OracleDataReader reader = cmd.ExecuteReader();
                    reader.Read();
                    decimal ban = (decimal) reader.GetValue(0);
                    Database db = new Database();
                    db.Connect();
                    if (ban != -1 || ban != 3) {
                        using (OracleCommand insert = new OracleCommand()) {
                            insert.Connection = Connection;
                            insert.CommandText= @"INSERT INTO SEM_KOMENTAR(KOMENTAR_ID, OBSAH, FOTO_FOTO_ID, UZIVATEL_UZIVATEL_ID) 
                                  VALUES (SEQ_KOMENTAR.nextval, :obsah,  :fotoId, :uzivatelId)";
                            insert.Parameters.Add("obsah", obsah);
                            insert.Parameters.Add("fotoId", fotoId);
                            insert.Parameters.Add("uzivatelId", uzivatelId);
                            insert.ExecuteNonQuery();
                        }
                    }
//                       
                }
            }
        }
    }
}