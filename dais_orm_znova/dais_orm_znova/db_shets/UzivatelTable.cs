using System.Collections.Generic;
using dais_orm_znova.proxy_shet;

namespace dais_orm_znova.db_shets {
    public class UzivatelTable:UzivatelTableProxy {
        public static string SELECT = "SELECT uzivatel_id, nick, heslo, email, datum_narozeni, ban, obec_obec_id FROM SEM_UZIVATEL WHERE UZIVATEL_ID = :uzivatelId";
        public static string SELECT_ALL = "SELECT uzivatel_id, nick, heslo, email, datum_narozeni, ban, obec_obec_id FROM SEM_UZIVATEL";
        public static string SELECT_OBEC = "SELECT uzivatel_id, nick, heslo, email, datum_narozeni, ban, obec_obec_id FROM SEM_UZIVATEL WHERE OBEC_OBEC_ID=:obecId";
        public static string INSERT = @"INSERT INTO SEM_UZIVATEL(uzivatel_id, nick, heslo, email, datum_narozeni, ban, obec_obec_id) 
        VALUES (SEQ_OBEC.nextval, :nick, :heslo, :email, :datumNarozeni, 0, :obecId)";
        public static string UPDATE = "UPDATE SEM_UZIVATEL SET NICK=:nick, DATUM_NAROZENI=:datumNarozeni, BAN=:ban, OBEC_OBEC_ID=:obecId where UZIVATEL_ID = :uzivatelId";
        public static string DELETE = "UPDATE SEM_UZIVATEL SET ban = -1 where UZIVATEL_ID = :uzivatelId";

        protected override void insert(Uzivatel uzivatel) {
            throw new System.NotImplementedException();
        }

        protected override void update(Uzivatel uzivatel) {
            throw new System.NotImplementedException();
        }

        protected override void delete(Uzivatel uzivatel) {
            throw new System.NotImplementedException();
        }

        protected override Uzivatel @select(Uzivatel uzivatel) {
            throw new System.NotImplementedException();
        }

        protected override List<Uzivatel> @select() {
            throw new System.NotImplementedException();
        }

        protected override List<Uzivatel> select_obec(int obecId) {
            throw new System.NotImplementedException();
        }
    }
}