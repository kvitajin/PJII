using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks.Dataflow;
using Oracle.ManagedDataAccess.Client;

namespace DAIS_ORM {
       public class Uzivatel:Database {
           private string nick;
           private Decimal ban;
           private Decimal obecId;
           private string obec_nazev;
           private Decimal uzivatel_id;
           
           public string Nick {
               get => nick;
               set => nick = value;
           }

           public Decimal Ban {
               get => ban;
               set => ban = value;
           }

           public Decimal ObecId {
               get => obecId;
               set => obecId = value;
           }

           public string ObecNazev {
               get => obec_nazev;
               set => obec_nazev = value;
           }

           public Decimal UzivatelId {
               get => uzivatel_id;
               set => uzivatel_id = value;
           }
        public void RegistraceUzivatele(string nick, string heslo, string hesloZnova, string email, int obecId, DateTime datumNarozeni) {        
            using (Connection) {
                using (OracleCommand cmd = new OracleCommand()) {
                    DateTime now = DateTime.Now;  
                    int vek = new DateTime(DateTime.Now.Subtract(datumNarozeni).Ticks).Year - 1;  
                   //Console.WriteLine(vek);
                   if (vek >= 13) {
                       using (OracleCommand mail = new OracleCommand()) {
                           mail.Connection = Connection;
                           mail.CommandText = "SELECT COUNT(*) FROM SEM_UZIVATEL WHERE EMAIL =:mail ";
                           mail.Parameters.Add("mail", email);
                           OracleDataReader reader = mail.ExecuteReader();
                           reader.Read();
                           Console.WriteLine(reader.GetValue(0));
                           decimal pocet = (decimal)reader.GetValue(0);
                           if (pocet!=0) {
                               return;
                           }
                           reader.Close();
                       }

                       if (heslo != hesloZnova) {
                           return;
                       }

                       string hash = BCrypt.Net.BCrypt.HashString(heslo);
                       Database db = new Database();
                       db.Connect();
                       cmd.Connection = Connection;
                       cmd.CommandText =
                           @"INSERT INTO SEM_UZIVATEL (UZIVATEL_ID, NICK, HESLO, EMAIL, DATUM_NAROZENI, BAN, OBEC_OBEC_ID) 
                           VALUES (SEQ_UZIVATEL.nextval, :nick, :hash, :mail, :datum, 0, :obecId)";
                       cmd.Parameters.Add("nick", nick);
                       cmd.Parameters.Add("hash", hash);
                       cmd.Parameters.Add("mail", email);
                       cmd.Parameters.Add("datum", datumNarozeni);
                       cmd.Parameters.Add("obecId", obecId);
                       cmd.ExecuteNonQuery();
                       db.Disconnect();
                   }
                }
            }
        }

       public List<Uzivatel> SeznamUzivatelu() {
            using (Connection) {
                using (OracleCommand cmd = new OracleCommand()) {
                    cmd.Connection = Connection;
                    cmd.CommandText = @"SELECT uzivatel_id, nick, ban, obec_obec_id, o.NAZEV
                          FROM SEM_UZIVATEL u JOIN SEM_OBEC o 
                            ON u.OBEC_OBEC_ID = o.OBEC_ID" ;
                    OracleDataReader reader = cmd.ExecuteReader();
                    List<Uzivatel> vystup= new List<Uzivatel>();
                    while (reader.Read()) {
                        Uzivatel tmp = new Uzivatel();
                        tmp.UzivatelId = (Decimal) reader.GetValue(0); 
                        tmp.Nick = (string)reader.GetValue(1);
                        tmp.Ban = (decimal) reader.GetValue(2);
                        tmp.ObecId = (decimal) reader.GetValue(3);
                        tmp.ObecNazev = (string) reader.GetValue(4);
                        vystup.Add(tmp);
                    }
                    reader.Close();
                    return vystup;
                }
            }
       }
       public List<Uzivatel> SeznamUzivatelu( int obecId) {
           using (Connection) {
               using (OracleCommand cmd = new OracleCommand()) {
                   cmd.Connection = Connection;
                   cmd.CommandText = @"SELECT uzivatel_id, nick, ban, obec_obec_id, o.NAZEV
                          FROM SEM_UZIVATEL u JOIN SEM_OBEC o 
                            ON u.OBEC_OBEC_ID = o.OBEC_ID where OBEC_ID = :obecId AND BAN != -1";
                   cmd.Parameters.Add("obecId", obecId);
                   OracleDataReader reader = cmd.ExecuteReader();
                   List<Uzivatel> vystup= new List<Uzivatel>();
                   while (reader.Read()) {
                       Uzivatel tmp = new Uzivatel();
                       tmp.UzivatelId = (Decimal) reader.GetValue(0); 
                       tmp.Nick = (string)reader.GetValue(1);
                       tmp.Ban = (Decimal) reader.GetValue(2);
                       tmp.ObecId = (Decimal) reader.GetValue(3);
                       tmp.ObecNazev = (string) reader.GetValue(4);
                       vystup.Add(tmp);
                   }
                   reader.Close();
                   return vystup;
               }
           }
       }

       public void ZmenaStavuUzivatele(int uzivatelId, string stav) {
           int iStav;
           if (stav == "admin" || stav == "Admin") {
               iStav = 255;
           }
           else if (stav == "knez" || stav == "Knez") {
               iStav = 127;
           }
           else if (stav == "fotograf" || stav == "Fotograf") {
               iStav = 63;
           }
           else if (stav == "ban" || stav == "Ban") {
               iStav = 3;
           }
           else if (stav == "uzivatel" || stav == "Uzivatel") {
               iStav = 0;
           }
           else {
               Console.WriteLine("neznamy stav uzivatele");
               return;
           }
           using (Connection) {
               using (OracleCommand cmd = new OracleCommand()) {
                   cmd.Connection = Connection;
                   cmd.CommandText = "UPDATE SEM_UZIVATEL SET BAN =:stav WHERE UZIVATEL_ID = :uzivatelId";
                   cmd.Parameters.Add("stav", iStav);
                   cmd.Parameters.Add("uzivatelId", uzivatelId);
                   cmd.ExecuteNonQuery();
               }
           }
       }
       
       public void ZabanovaniUzivatele(int uzivatelId) {
           using (Connection) {
               using (OracleCommand cmd = new OracleCommand()) {
                   cmd.Connection = Connection;
                   cmd.CommandText = "UPDATE SEM_UZIVATEL SET BAN =3 WHERE UZIVATEL_ID = :uzivatelId";
                   cmd.Parameters.Add("uzivatelId", uzivatelId);
                   cmd.ExecuteNonQuery();
               }
           }
       }

       public void SmazaniUzivatele(int uzivatelId) {
           using (Connection) {
               using (OracleCommand cmd = new OracleCommand()) {
                   cmd.Connection = Connection;
                   cmd.CommandText = "UPDATE SEM_UZIVATEL SET BAN =-1 WHERE UZIVATEL_ID = :uzivatelId";
                   cmd.Parameters.Add("uzivatelId", uzivatelId);
                   cmd.ExecuteNonQuery();
               }
           }
       }

       public Uzivatel PrihlaseniUzivatele(string email, string heslo) {
           using (Connection) {
               using (OracleCommand cmd = new OracleCommand()) {
                   cmd.Connection = Connection;
                   cmd.CommandText = "SELECT nick, heslo, ban, obec_obec_id FROM SEM_UZIVATEL WHERE EMAIL = :email";
                   cmd.Parameters.Add("email", email);
                   OracleDataReader reader = cmd.ExecuteReader();
                   reader.Read();
                   if (BCrypt.Net.BCrypt.Verify(heslo, (string) reader.GetValue(1))) {
                       Uzivatel tmp = new Uzivatel();
                       tmp.Nick = (string) reader.GetValue(0);
                       tmp.Ban = (decimal) reader.GetValue(2);
                       tmp.ObecId = (decimal) reader.GetValue(3);
                       reader.Close();
                       return tmp;
                   }
                   reader.Close();
                   Console.WriteLine("Špatné jméno, nebo heslo");
                   return null;  
               }
           }
       }
    }
}