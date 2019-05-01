using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using Oracle.ManagedDataAccess.Client;

namespace DAIS_ORM {
    public class Dokument:Database {
        private string nadpis;
        private string obsah;
        private DateTime datum;
        private string obrazek;

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
    
        public void VytvorDokument(int obecId, string nadpis, string text, int rubrikaId, string obrazek = null) {
            using (Connection) {
                using (OracleCommand cmd = new OracleCommand()) {
                    cmd.Connection = Connection;
                    if (obrazek == null) {
                        cmd.CommandText = @"INSERT ALL into SEM_DOKUMENT(dokument_id, nadpis, obsah, datum, rubrika_rubrika_id) 
                                              values (SEQ_DOKUMENT.nextval, :nadpis, :text, :datum, :rubrikaId) 
                                              into SEM_OBEC_CLANEK(obec_obec_id, dokument_dokument_id) values (:obecId, SEQ_DOKUMENT.currval)
                                              select * from dual";

                    }
                    else {
                        cmd.CommandText = @"INSERT all INTO SEM_DOKUMENT(dokument_id, nadpis, obsah, datum, obrazek, rubrika_rubrika_id) 
                                              values (SEQ_DOKUMENT.nextval, :nadpis, :text, :datum, :obrazek, :rubrikaId) 
                                              into SEM_OBEC_CLANEK(obec_obec_id, dokument_dokument_id) values (:obecId, SEQ_DOKUMENT.currval)
                                              select * from dual";
                        cmd.Parameters.Add("obrazek", obrazek);
 
                    }

                    DateTime now = DateTime.Today;
                    cmd.Parameters.Add("nadpis", nadpis);
                    cmd.Parameters.Add("text", text);
                    cmd.Parameters.Add("datum", now);
                    cmd.Parameters.Add("rubrikaId", rubrikaId);
                    cmd.Parameters.Add("obecId", obecId);
                    int tmp = cmd.ExecuteNonQuery();
//                    Database db = new Database();
//                    db.Connect();
////                    using (OracleCommand link = new OracleCommand()) {
//                        cmd.Connection = Connection;
//                        cmd.CommandText =
//                            "INSERT INTO SEM_OBEC_CLANEK (OBEC_OBEC_ID, DOKUMENT_DOKUMENT_ID) VALUES (:obecId, SEQ_DOKUMENT.currval)";
//                        cmd.Parameters.Add("obecId", obecId);
//                        cmd.ExecuteNonQuery();
////                    }
                }
            }
        }

        public void UpravDokument(int dokumentId, string obsah) {           
            using (Connection) {
                using (OracleCommand cmd = new OracleCommand()) {
                    cmd.Connection = Connection;
                    cmd.CommandText = "UPDATE sem_dokument SET OBSAH = :obsah WHERE DOKUMENT_ID= :id";
                    cmd.Parameters.Add("obsah", obsah);
                    cmd.Parameters.Add("id", dokumentId);
                    cmd.ExecuteNonQuery();
                }
            }
            
        }

        public List<Dokument> ZobrazDetailDokumentuVRubrice(int dokumentId) {
            using (Connection) {
                using (OracleCommand cmd = new OracleCommand()) {
                    cmd.Connection = Connection;
                    cmd.CommandText = "SELECT  nadpis, obsah, datum, obrazek FROM SEM_DOKUMENT WHERE DOKUMENT_ID=:dokumentId";
                    cmd.Parameters.Add("dokumentId", dokumentId);
                    OracleDataReader reader = cmd.ExecuteReader();
                    List<Dokument> vystup = new List<Dokument>();
                    while (reader.Read()) {
                        Dokument tmp = new Dokument();
                        tmp.nadpis = (string)reader.GetValue(0);
                        tmp.obsah = (string)reader.GetValue(1);
                        tmp.datum = (DateTime) reader.GetValue(2);
                        tmp.obrazek =  reader.GetValue(3)==DBNull.Value? null: (string)reader.GetValue(3);
                        vystup.Add(tmp);
                    }        
                    reader.Close();
                    return vystup;
                }
            }
        }

        public void KomentujDokument(int dokumentId, string text, int uzivatelId) {
            using (Connection) {
                using (OracleCommand cmd = new OracleCommand()) {
                    cmd.Connection = Connection;
                    cmd.CommandText = @"INSERT INTO SEM_KOMENTAR (
                          KOMENTAR_ID, OBSAH, DOKUMENT_DOKUMENT_ID, UZIVATEL_UZIVATEL_ID) 
                          VALUES (seq_komentar.nextval, :text, :dokumentId, :uzivatelId)";
                    cmd.Parameters.Add("text", text);
                    cmd.Parameters.Add("dokumentId", dokumentId);
                    cmd.Parameters.Add("uzivatelId", uzivatelId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void ZmenRubrikuDokumentu(int dokumentId, int rubrikaId) {
            using (Connection) {
                using (OracleCommand cmd = new OracleCommand()) {
                    cmd.Connection = Connection;
                    cmd.CommandText =
                        "UPDATE sem_dokument SET RUBRIKA_RUBRIKA_ID=:rubrikaId WHERE DOKUMENT_ID=:dokumentId";
                    cmd.Parameters.Add("rubrikaId", rubrikaId);
                    cmd.Parameters.Add("dokumentId", dokumentId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}