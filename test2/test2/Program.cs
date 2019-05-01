using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

namespace test2 {
    class Program {
        static void Main(string[] args) {
            Unit unit = new Unit(20, "neco");
            PowerPlant pp = new PowerPlant("dukovany", unit);
            House jirka = new House("jirka", 500);
            House kris = new House("Kris", 700);
            House zake = new House( "Zake", 600);
            List<House> tmp = new List<House>();
            
            tmp.Add(jirka);
            tmp.Add(kris);
            tmp.Add(zake);
            tmp.Sort();
            
            StreamWriter sw = new StreamWriter("./Report.txt");
            TextWriter tw = sw;
            tw.WriteLine("Jmeno:"+tmp[0].Name +"Balance: "+ tmp[0].Balance);
            tw.Close();
            sw.Close();
            
        }
    }
}