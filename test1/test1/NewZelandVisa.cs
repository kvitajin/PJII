namespace test1 {
    public class NewZelandVisa:IVisa {
        public bool? Approved {
            get {
                if (Payment == null) {
                    return null;
                }

                if (Payment > 4000) {
                    return true;
                }

                return false;
            }
        }

        public double? Payment { get; set; }
        public string Name { get; set; }

        public NewZelandVisa(string name, double? payment) {
            this.Payment = payment;
            this.Name = name;
        }
    }

    
}