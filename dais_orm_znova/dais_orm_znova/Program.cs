using System;
using System.Collections.Generic;
using dais_orm_znova.db_shets;
using dais_orm_znova.proxy_shet;

namespace dais_orm_znova {
    class Program {
        static void Main(string[] args) {
            Database db = new Database();
            db.Connect();
            Obec obec = new Obec();
            obec.Nazev = "Ova";
            obec.Visible = 1;
            ObecTableProxy.Insert(obec);
            obec.Nazev = "fuck this shit";
            obec.ObecId = 5;
            ObecTableProxy.Update(obec);
            List<Obec> pff;
            pff= ObecTableProxy.Select();
            foreach (var hovno in pff) {
                Console.WriteLine(hovno.ObecId + " " + hovno.Nazev + " " + hovno.Visible);
            }
            
            ObecTableProxy.Delete(obec);
            
        }
    }
}