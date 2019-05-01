using System;
using System.Collections.Generic;
using System.Data;
using dais_orm_znova.db_shets;
using dais_orm_znova.proxy_shet;
using Oracle.ManagedDataAccess.Client;

namespace dais_orm_znova {
    class Program {
        static void Main(string[] args) {
            Database db = new Database();
            db.Connect();
//            Obec obec = new Obec();
//            obec.Nazev = "Ova";
//            obec.Visible = 1;
//            ObecTableProxy.Insert(obec);
//            obec.Nazev = "fuck this shit";
//            obec.ObecId = 5;
//            ObecTableProxy.Update(obec);
//            List<Obec> pff;
//            pff= ObecTableProxy.Select();
//            foreach (var hovno in pff) {
//                Console.WriteLine(hovno.ObecId + " " + hovno.Nazev + " " + hovno.Visible);
//            }
//            
//            ObecTableProxy.Delete(obec);
            DateTime naroz=  new DateTime(2006, 04, 26 );

            
            Dokument doc= new Dokument();
            doc.Nadpis="oaksmasokkmsdlcks";
            doc.Obsah="slkdcmdkcmskdmcslskcmslkcmsdlcksmdclskdmcsdlkcmsdlkclmsdkllcmsclkks";
            doc.RubrikaId=1;
            DokumentTableProxy.Insert(doc);
            doc.Obsah = "spaaaaaat";
            DokumentTableProxy.Update(doc);
            doc.RubrikaId = 1;
//            List<Dokument> dopff;
//            dopff = DokumentTableProxy.Select_rubr(doc);
//            foreach (var hovno in dopff) {
//                Console.WriteLine(hovno.DokumentId + " " + hovno.Nadpis + " " + hovno.Obsah+ " " + hovno.RubrikaId );
//            }
//            doc.DokumentId = 1;
//            Dokument tmp = DokumentTableProxy.Select(doc);
//            Console.WriteLine(tmp.DokumentId + " " + tmp.Nadpis + " " + tmp.Obsah+ " " + tmp.RubrikaId );

//            
//            Rubrika rubr =new Rubrika();
//            rubr.Nazev = "hlazeni duhovych jednorozcu";
//            RubrikaTableProxy.Insert(rubr);
//            rubr.Nazev = "vyhlazeni duhovych jednorozcu";
//            rubr.RubrikaId = 13;
//            RubrikaTableProxy.Update(rubr);
//            rubr.RubrikaId = 5;
//            RubrikaTableProxy.Delete(rubr);
//            List<Rubrika> pff;
//            pff= RubrikaTableProxy.Select();
//            foreach (var hovno in pff) {
//                Console.WriteLine(hovno.RubrikaId + " " + hovno.Nazev );
//            }

            Komentar komentar = new Komentar();
            komentar.Obsah = "dsmlsms";
            komentar.DokumentId = 1;
            komentar.UzivatelId = 1;
            KomentarTableProxy.Update(komentar);
            KomentarTableProxy.Select_dokument(1);
            

//            db.Connect();
//            OracleCommand cmd = new OracleCommand();
//            cmd.CommandText = "Registruj";
//            cmd.CommandType = CommandType.StoredProcedure;
//            cmd.Parameters.Add((OracleDbType.Date)naroz.ToString("yyyy-M-d dddd"), OracleDbType.Date).Value=naroz;
//            db.ExecuteNonQuery(cmd);
        }
    }
}