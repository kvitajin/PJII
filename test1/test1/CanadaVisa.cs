using System.Reflection;

namespace test1 {
    public class CanadaVisa : IVisa {
        public bool? Approved {
            get {
                if (Payment != null) {
                    return true;
                }

                return false;
            }

        }

        public double? Payment { get; set; }
        public string Name { get; set; }

        public CanadaVisa(string name, double? pay) {
            this.Payment = Payment;
            this.Name = name;
        }
    }
}