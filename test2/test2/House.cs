using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace test2 {
    public class House:IConsumer, IComparer<House> {
        public double Balance { get; set; }
        public List<uint> History { get; set; }
        public string Name { get; set; }

        public PowerPlant PowerPlant {
            get { return PowerPlant; }
            set {
                if (Balance >= PowerPlant.Unit.Price) {
                    this.PowerPlant = PowerPlant;
                    EnergyProducedDelegate en = ConsumeEnergy;
                }
            }
        }

        public int Compare(House x, House y) {
            if (x.Balance > y.Balance) {
                return 1;
            }
            return  -1;
        }

        public int CompareTo( House y) {
            return Compare(this, y);
        }

        private void ConsumeEnergy(uint amount) {
            uint spotreba = amount * (uint)PowerPlant.Unit.Price;
            Balance -=spotreba;
            Console.WriteLine( "spotreba je " + spotreba);
            History.Add(spotreba);
            if (Balance < 0) {
                throw new NotEnoughMoneyExeption(Balance);
            }
        }

        public House(string name, double balance) {
            this.Name = name;
            this.Balance = balance;
        }
    }
}