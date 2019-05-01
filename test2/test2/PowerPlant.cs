using System;
using System.Collections.Concurrent;

namespace test2 {

    public delegate void EnergyProducedDelegate(uint amount);
    
    
    public class PowerPlant {
        public string Name { get;}
        public Unit Unit { get; }

        public PowerPlant(string name, Unit unit) {
            this.Name = name;
            this.Unit = unit;
        }

        public void Produce(uint amount) {
            Console.WriteLine("vyrabim "+ amount + " energie");
        }
    }
}