using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Oracle.ManagedDataAccess.Client;

namespace DAIS_ORM {
    public class VerejneOznameni:Database {
        public void VytvorVerejneOznameni(DateTime from, DateTime to, int dokumentId) {
            using (Connection) {
                using (OracleCommand cmd = new OracleCommand()) {
                    if (from < to) {
                        cmd.Connection = Connection;
                        cmd.CommandText =
                            "INSERT INTO SEM_VEREJNE_OZNAMENI(datum_vyves, datum_stazeni, dokument_dokument_id) VALUES(:a, :b, :dokumentId)";
                        cmd.Parameters.Add("a", from);
                        cmd.Parameters.Add("b", to);
                        cmd.Parameters.Add("dokumentId", dokumentId);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        public List<Dokument> ZobrazAktualniVerejneOznameni(string jmenoObce) {
            
            DateTime now = DateTime.Now;
            using (Connection) {
                using (OracleCommand cmd = new OracleCommand()) {
                    cmd.Connection = Connection;
                    cmd.CommandText = @"SELECT NADPIS, DATUM, OBSAH  FROM SEM_DOKUMENT d 
                    join SEM_VEREJNE_OZNAMENI vo 
                    on d.DOKUMENT_ID = vo.DOKUMENT_DOKUMENT_ID 
                    join SEM_OBEC_CLANEK oc 
                    on d.DOKUMENT_ID = oc.DOKUMENT_DOKUMENT_ID 
                    join SEM_OBEC o 
                    on oc.OBEC_OBEC_ID = o.OBEC_ID
                    WHERE o.NAZEV=:nazev ANd DATUM_STAZENI> :now AND DATUM_VYVES<:now 
                    ORDER BY DATUM_STAZENI desc" ;
                    cmd.Parameters.Add("nazev", jmenoObce);
                    cmd.Parameters.Add("now", now);
                    List<Dokument> vystup = new List<Dokument>();
                    OracleDataReader reader = cmd.ExecuteReader();
                    while (reader.Read()) {
                        Dokument tmp = new Dokument();
                        tmp.Nadpis = (string)reader.GetValue(0);
                        tmp.Datum = (DateTime) reader.GetValue(1);
                        tmp.Obsah = (string) reader.GetValue(2);
                        vystup.Add(tmp);
                    }
                    return vystup;

                }
            }
        }









    }
}