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

            Database db = new Database();
            db.Connect();
            Obec obec = new Obec();
            Dokument dokument = new Dokument();
            Rubrika rubrika = new Rubrika();
            Uzivatel uzivatel = new Uzivatel();
            Album album = new Album();
            Fotografie fotografie = new Fotografie();   
            Komentar komentar = new Komentar();
            VerejneOznameni verejneOznameni = new VerejneOznameni();
            DateTime naroz=  new DateTime(2006, 04, 26 );
            
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
            
/**2.1.**/
            db.Connect();
            dokument.VytvorDokument(1, "Hovno", "wjfnsflkslskjslkjcscksjcnskjcsnckjscnksjcnskcjsncksjcnskjcnscjksdncksjcnskjcnsdckjsndckjsnckjsdc", 1);
/**2.2.**/
            db.Connect();
            dokument.UpravDokument(1, "ajdndlmld");
/**2.3.**/
            db.Connect();
            var tmp = dokument.ZobrazDetailDokumentuVRubrice(1);
            foreach (var doku in tmp) {
                Console.WriteLine(doku.Nadpis + "\n" + doku.Datum + "\n" + doku.Obsah + "\n");
            }           
            
/**3.1.**/
            db.Connect();
            obec.VytvorObec("Závišice");
/**3.2.**/
            db.Connect();
            obec.SkryjObec(2);
/*3.3.**/
            db.Connect();
            var obcList= obec.ZobrazVsechnyObce();
            foreach (var obc in obcList) {
                Console.WriteLine(obc.Nazev + "\t" + obc.Visibility);
            }
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
            
/**5.1.**/   
            db.Connect();
            fotografie.PridaniFotografie("asjnskj.jpg", 1, "sksdklds");
/**5.2.**/
            db.Connect();
            var fotky = fotografie.ZobrazeniFotografiiAlba(1);
            foreach (var fotografy in fotky) {
                Console.WriteLine(fotografy.Fotka +" " +fotografy.Datum + "\n" + fotografy.Popis);
            }
/**5.3.**/
            db.Connect();
            fotografie.SkrytiFotografie(2);
/**5.4.**/  
            db.Connect();
            fotografie.PridaniKomentare(1, 2, "bardyo fotka");
/**6.1.**/
            db.Connect();
            komentar.SmazatKomentar(1);
/**6.2.**/
            db.Connect();
            komentar.ZobrazKomentareFotky(1);
            
            db.Connect();
            komentar.ZobrazKomentareDokumentu(1);

/**6.3.**/
            //trigger
            
/**7.1.**/
            db.Connect();
            rubrika.PridejRubriku("PokusnaRubrika");
/**7.1,5**/            
            db.Connect();
            rubrika.UpravRubriku(1, "wtf");
/**7.2.**/
            db.Connect();
            var rubry = rubrika.VypisDokumentyVRubrice(1);
            foreach (var doku in rubry) {
                Console.WriteLine(doku.Nadpis + "\n" + doku.Datum  + "\n");
            }
/**8.0.**/
            db.Connect();
            DateTime from = new DateTime(2019, 4, 27, 12,0,0);
            DateTime to = new DateTime(2019, 4, 29, 12,0,0);
            verejneOznameni.VytvorVerejneOznameni( from, to, 3);
            
/**8.1.**/
            db.Connect();
            verejneOznameni.ZobrazAktualniVerejneOznameni("Rybi");
            
            
            
            db.Disconnect();
            
        }
     
    }
}