using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using Oracle.ManagedDataAccess.Client;

namespace DAIS_ORM {
    public class Obec : Database {
        public void VytvorObec(string nazev) { 
            using (OracleCommand cmd = new OracleCommand()) {
                    cmd.Connection = Connection;
                    cmd.CommandText = "INSERT INTO SEM_OBEC(obec_id, nazev, vidible) VALUES (SEQ_OBEC.nextval,:obec, 1)";
                    cmd.Parameters.Add("obec", nazev);
                    int tmo = cmd.ExecuteNonQuery();
                }
        }
    
        public void SkryjObec(int obecId) {
            using (OracleCommand cmd = new OracleCommand()) {
                cmd.Connection = Connection;
                cmd.CommandText = "UPDATE SEM_OBEC SET VIDIBLE=0 WHERE OBEC_ID=:obecId";
                cmd.Parameters.Add("obedId", obecId);
                int tmp = cmd.ExecuteNonQuery();
            }
        }


        public List<Obc> ZobrazObce() {
            using (Connection) {
                using (OracleCommand cmd = new OracleCommand()) {
                    cmd.Connection = Connection;
                    cmd.CommandText = "SELECT NAZEV FROM SEM_OBEC WHERE VIDIBLE=1 ";
                    List<Obc> vystup = new List<Obc>();
                    OracleDataReader reader = cmd.ExecuteReader();
                    while (reader.Read()) {
                        Obc tmp = new Obc();
                        tmp.Nazev = (string) reader.GetValue(0);
                        vystup.Add(tmp);
                    }
                    reader.Close();
                    return vystup;
                }
            }
        }

        public List<Obc> ZobrazVsechnyObce() {
            using (Connection) {
                using (OracleCommand cmd = new OracleCommand()) {
                    cmd.Connection = Connection;
                    cmd.CommandText = "SELECT nazev, vidible FROM SEM_OBEC";
                    List<Obc> vystup = new List<Obc>();
                    OracleDataReader reader = cmd.ExecuteReader();
                    while (reader.Read()) {
                        Obc tmp = new Obc();
                        tmp.Nazev = (string) reader.GetValue(0);
                        tmp.Visibility = (Decimal) reader.GetValue(1);
                        
                        vystup.Add(tmp);
                    }
                    reader.Close();
                    return vystup;
                }
                
            }
        }
    }

    public class Obc {
        private string nazev;
        private Decimal? visibility;

        public string Nazev {
            get => nazev;
            set => nazev = value;
        }

        public Decimal? Visibility {
            get => visibility;
            set => visibility = value;
        }
    }
}