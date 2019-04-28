using System;
using System.Collections.Generic;
using Oracle.ManagedDataAccess.Client;

namespace DAIS_ORM {
    public class Rubrika:Database {
        public void PridejRubriku(string nazev) {
            using (Connection) {
                using (OracleCommand cmd = new OracleCommand()) {
                    cmd.Connection = Connection;
                    cmd.CommandText = "INSERT INTO SEM_RUBRIKA(rubrika_id, nazev) VALUES (SEQ_RUBRIKA.nextval, :nazev)";
                    cmd.Parameters.Add("nazev", nazev);
                    int tmp = cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpravRubriku(int rubrikaId, string name) {
            using (Connection) {
                using (OracleCommand cmd = new OracleCommand()) {
                    cmd.Connection = Connection;
                    cmd.CommandText = "UPDATE sem_rubrika SET NAZEV=:nazev WHERE RUBRIKA_ID=:id";
                    cmd.Parameters.Add("nazev", name);
                    cmd.Parameters.Add("id", rubrikaId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Dokument> VypisDokumentyVRubrice(int rubrikaId) {
            using (Connection) {
                using (OracleCommand cmd = new OracleCommand()) {
                    cmd.Connection = Connection;
                    cmd.CommandText = "SELECT nadpis, datum FROM SEM_DOKUMENT WHERE RUBRIKA_RUBRIKA_ID = :rubrikaId order by DATUM";
                    cmd.Parameters.Add("rubrikaId", rubrikaId);
                    OracleDataReader reader =cmd.ExecuteReader();
                    List<Dokument> vystup = new List<Dokument>();
                    while (reader.Read()) {
                        Dokument tmp = new Dokument();
                        tmp.Nadpis = (string)reader.GetValue(0);
                        tmp.Datum = (DateTime) reader.GetValue(1);
                        vystup.Add(tmp);
                    }

                    return vystup;
                }
            }
        }
    }
}    