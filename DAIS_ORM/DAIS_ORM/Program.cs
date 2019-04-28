using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
//using Oracle.DataAccess.Client;
//using Oracle.DataAccess.Types;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

namespace DAIS_ORM {
    class Program {
        static void Main(string[] args) {
//            Database db = new Database();
//            db.Connect("rzbi");
//            Console.WriteLine(db.Connection.ToString());
//            Obec obec = new Obec();
//            obec.Connect();
//            obec.VytvorObec("Rybi");

//
//            using (OracleConnection con = new OracleConnection(
//                "User Id=kvi0029;Password=n2HO69fi3w;Data Source=(DESCRIPTION = (ADDRESS_LIST = (ADDRESS = (PROTOCOL = TCP)(HOST = dbsys.cs.vsb.cz)(PORT = 1521)))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = oracle.dbsys.cs.vsb.cz)));")
//            ) {
//                con.Open();
//                Console.WriteLine("ahoj");
//                using (OracleCommand cmd = new OracleCommand()) {
//                    cmd.Connection = con;
//                    cmd.CommandText = "INSERT INTO SEM_OBEC(obec_id, nazev, vidible) VALUES (2,'Závišice',1)";
//                    int tmo = cmd.ExecuteNonQuery();
//                    con.Close();
//                }
//            }

            Database db = new Database();
            db.Connect();
            Obec obec = new Obec();
            Dokument dokument = new Dokument();
            Rubrika rubrika = new Rubrika();
            Uzivatel uzivatel = new Uzivatel();
            Album album = new Album();
            DateTime naroz=  new DateTime(2006, 04, 26 );
                uzivatel.RegistraceUzivatele("Edie", "qwerty123", "qwerty123", "qwerty1@seznam.cz", 1, naroz);
            
/**3.1.**/
//            obec.VytvorObec("Závišice");
/**3.2.**/
//            obec.SkryjObec(2);
//*3.3.**/
//            var tmp= obec.ZobrazVsechnyObce();
//            foreach (var obc in tmp) {
//                Console.WriteLine(obc.Nazev + "\t" + obc.Visibility);
//            }


//            dokument.VytvorDokument(1, "Hovno", "wjfnsflkslskjslkjcscksjcnskjcsnckjscnksjcnskcjsncksjcnskjcnscjksdncksjcnskjcnsdckjsndckjsnckjsdc", 1);
//            dokument.UpravDokument(1, "ajdndlmld");

//            var tmp = dokument.ZobrazDetailDokumentuVRubrice(1);
//            foreach (var doku in tmp) {
//                Console.WriteLine(doku.Nadpis + "\n" + doku.Datum + "\n" + doku.Obsah + "\n");
//            }
/**7.1.**/
//            rubrika.PridejRubriku("PokusnaRubrika");

//            rubrika.UpravRubriku(1, "wtf");
/**7.2.**/
//            db.Connect();
//            var tmp = rubrika.VypisDokumentyVRubrice(1);
//            foreach (var doku in tmp) {
//                Console.WriteLine(doku.Nadpis + "\n" + doku.Datum  + "\n");
//            }
/**4.1.**/
            db.Connect();
            album.VytvorAlbum("pokusneAlbum", 1);
/**4.2.**/
            db.Connect();
            var alba = album.ZobrazAlbaObce(1);
            foreach (var album1 in alba) {
                Console.WriteLine(album1.Nazev);
            }
/**4.3.**/
            db.Connect();
            album.SkryjAlbum(2);
            db.Disconnect();
/**1.1.**/
            db.Connect();
            uzivatel.RegistraceUzivatele("Alfonz", "zxcvbnm321", "zxcvbnm321", "hubert1@seznam.cz", 2, naroz);
/**1.2.**/
            db.Connect();
            var uzivatele = uzivatel.SeznamUzivatelu();
            foreach (var vsichniUzivatele in uzivatele) {
                Console.WriteLine(vsichniUzivatele.Nick + "\t"+ 
                                  vsichniUzivatele.Ban + "\t" + 
                                  vsichniUzivatele.ObecNazev);
            }
/**1.2.**/            
            db.Connect();
            var uzivateleObce = uzivatel.SeznamUzivatelu(1);
            Console.WriteLine("uzivatele obce Rybi:");
            foreach (var uzivatelObce in uzivateleObce) {
                Console.WriteLine(uzivatelObce.Nick + "\t" +
                                  uzivatelObce.Ban + "\t" +
                                  uzivatelObce.ObecNazev);
            }
/**1.3.**/
            db.Connect();
            uzivatel.ZmenaStavuUzivatele(1, "Admin");
/**1.4.**/
            db.Connect();
            uzivatel.ZabanovaniUzivatele(3);
/**1.5.**/            
            db.Connect();
            uzivatel.SmazaniUzivatele(4);
/**1.6.**/            
            db.Connect();
            Uzivatel vypisUzivatel = uzivatel.PrihlaseniUzivatele("qwerty1@seznam.cz","qwerty123");
            if (vypisUzivatel != null) {
                Console.WriteLine(vypisUzivatel.Nick + ", ban: " +vypisUzivatel.Ban + ", Obec Id: " + vypisUzivatel.ObecId);
            }
            
                
            







//            using (OracleConnection con = new OracleConnection("User Id=sku0084;Password=kZtothRHMv;Data Source=(DESCRIPTION = (ADDRESS_LIST = (ADDRESS = (PROTOCOL = TCP)(HOST = dbsys.cs.vsb.cz)(PORT = 1521)))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = oracle.dbsys.cs.vsb.cz)));"))
//            {
//                con.Open();
//                Console.WriteLine("ahoj");
//                using(OracleCommand cmd = new OracleCommand())
//                {
//                    cmd.Connection = con;
//                    cmd.CommandText = "SELECT * FROM Package";
//                    var r = cmd.ExecuteReader();
//                    while (r.Read())
//                    {
//                        Console.WriteLine("|{0,5}|{1,20}|",r.GetValue(0),r.GetValue(1));
//                    }
//                }
//                con.Close();
//            }


        }
    }
}