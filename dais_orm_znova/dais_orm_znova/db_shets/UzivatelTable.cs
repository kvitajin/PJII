using System;
using System.Collections.Generic;
using dais_orm_znova.proxy_shet;
using Oracle.ManagedDataAccess.Client;

namespace dais_orm_znova.db_shets {
    public class UzivatelTable:UzivatelTableProxy {
        public static string SELECT = "SELECT uzivatel_id, nick, heslo, email, datum_narozeni, ban, obec_obec_id FROM SEM_UZIVATEL WHERE UZIVATEL_ID = :uzivatelId";
        public static string SELECT_ALL = "SELECT uzivatel_id, nick, heslo, email, datum_narozeni, ban, obec_obec_id FROM SEM_UZIVATEL";
        public static string SELECT_OBEC = "SELECT uzivatel_id, nick, heslo, email, datum_narozeni, ban, obec_obec_id FROM SEM_UZIVATEL WHERE OBEC_OBEC_ID=:obecId";
        public static string INSERT = @"INSERT INTO SEM_UZIVATEL(uzivatel_id, nick, heslo, email, datum_narozeni, ban, obec_obec_id) 
        VALUES (SEQ_OBEC.nextval, :nick, :heslo, :email, :datumNarozeni, 0, :obecId)";
        public static string UPDATE = "UPDATE SEM_UZIVATEL SET NICK=:nick, DATUM_NAROZENI=:datumNarozeni, BAN=:ban, OBEC_OBEC_ID=:obecId where UZIVATEL_ID = :uzivatelId";
        public static string DELETE = "UPDATE SEM_UZIVATEL SET ban = -1 where UZIVATEL_ID = :uzivatelId";
        public static string ZMENA_PRAV = "UPDATE SEM_UZIVATEL SET BAN= :ban WHERE UZIVATEL_ID = :uzivatelId";

        protected override void insert(Uzivatel uzivatel) {
//            Database db = new Database();
//            db.Connect();
//            OracleCommand cmd = new OracleCommand("Registruj");
//            cmd.Parameters.Add("p_datumNarozeni", OracleDbType.Date).Value = uzivatel.DatumNarozeni;
//            cmd.ExecuteNonQuery();
            throw new NotImplementedException();
        }

        protected override void update(Uzivatel uzivatel) {
            Database db = new Database();
            db.Connect();
            OracleCommand cmd = db.CreateCommand(UPDATE);
            cmd.Parameters.Add("nick", uzivatel.Nick);
            cmd.Parameters.Add("datumNarozeni", uzivatel.DatumNarozeni);
            cmd.Parameters.Add("ban", uzivatel.Ban);
            cmd.Parameters.Add("uzivatelId", uzivatel.UzivatelId);
            db.ExecuteNonQuery(cmd);   
            db.Close();
        }

        protected override void delete(Uzivatel uzivatel) {
            Database db = new Database();
            db.Connect();
            OracleCommand cmd = db.CreateCommand(DELETE);
            cmd.Parameters.Add("uzivatelId", uzivatel.UzivatelId);
            db.ExecuteNonQuery(cmd);  
            db.Close();        
        }

        protected override Uzivatel select(Uzivatel uzivatel) {        //login
            Database db = new Database();
            db.Connect();
            OracleCommand cmd = db.CreateCommand(SELECT);
            cmd.Parameters.Add("uzivatelId", uzivatel.UzivatelId);
            
            OracleDataReader readshit = db.Select(cmd);
            readshit.Read();
            Uzivatel tmp = new Uzivatel();
            tmp.Heslo = readshit.GetString(2);
            if (BCrypt.Net.BCrypt.Verify(uzivatel.Heslo, tmp.Heslo)) {
                tmp.UzivatelId = readshit.GetInt32(0);
                tmp.Nick = readshit.GetString(1);
                tmp.Email = readshit.GetString(3);
                tmp.DatumNarozeni = readshit.GetDateTime(4);
                tmp.Ban = readshit.GetInt32(5);
                tmp.ObecId = readshit.GetInt32(6);
            }
            else {
                readshit.Close();
                db.Close();
                return null;
            }
            
            readshit.Close();
            db.Close();
            return tmp;
        }

        protected override List<Uzivatel> select() {
            Database db = new Database();
            db.Connect();
            OracleCommand cmd = db.CreateCommand(SELECT_ALL);
            List<Uzivatel> vystup = new List<Uzivatel>();
            OracleDataReader readshit = db.Select(cmd);
            while (readshit.Read()) {
                Uzivatel tmp = new Uzivatel();
                tmp.Heslo = readshit.GetString(2);
                tmp.UzivatelId = readshit.GetInt32(0);
                tmp.Nick = readshit.GetString(1);
                tmp.Email = readshit.GetString(3);
                tmp.DatumNarozeni = readshit.GetDateTime(4);
                tmp.Ban = readshit.GetInt32(5);
                tmp.ObecId = readshit.GetInt32(6);
                vystup.Add(tmp);
            }

            readshit.Close();
            db.Close();
            return vystup;
        }

        protected override List<Uzivatel> select_obec(int obecId) {
            Database db = new Database();
            db.Connect();
            OracleCommand cmd = db.CreateCommand(SELECT_OBEC);
            cmd.Parameters.Add("obecId", obecId);
            List<Uzivatel> vystup = new List<Uzivatel>();
            OracleDataReader readshit = db.Select(cmd);
            while (readshit.Read()) {
                Uzivatel tmp = new Uzivatel();
                tmp.Heslo = readshit.GetString(2);
                tmp.UzivatelId = readshit.GetInt32(0);
                tmp.Nick = readshit.GetString(1);
                tmp.Email = readshit.GetString(3);
                tmp.DatumNarozeni = readshit.GetDateTime(4);
                tmp.Ban = readshit.GetInt32(5);
                tmp.ObecId = readshit.GetInt32(6);
                vystup.Add(tmp);
            }

            readshit.Close();
            db.Close();
            return vystup;
        }

        protected override void zmena_prav(Uzivatel uzivatel, string prava) {
            int iStav;
            if (prava == "admin" || prava == "Admin") {
                iStav = 255;
            }
            else if (prava == "knez" || prava == "Knez") {
                iStav = 127;
            }
            else if (prava == "fotograf" || prava == "Fotograf") {
                iStav = 63;
            }
            else if (prava == "ban" || prava == "Ban") {
                iStav = 3;
            }
            else if (prava == "uzivatel" || prava == "Uzivatel") {
                iStav = 0;
            }
            else {
                Console.WriteLine("neznamy stav uzivatele");
                return;
            }
            Database db = new Database();
            db.Connect();
            OracleCommand cmd = db.CreateCommand(ZMENA_PRAV);
            cmd.Parameters.Add("ban", iStav);
            cmd.Parameters.Add("uzivatelId", uzivatel.UzivatelId);
            db.ExecuteNonQuery(cmd);   
            db.Close(); 
        }
    }
}