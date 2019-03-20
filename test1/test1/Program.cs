using System;

namespace test1 {
    class Program {
        static void Main(string[] args) {
            VisaList<IVisa> visas =new VisaList<IVisa>();
            visas.Add(new NewZelandVisa("Tomas", 4500));
            visas.Add(new CanadaVisa("Pepa", null));
            visas.Add(new NewZelandVisa("Jan", null));
            visas.Add(new NewZelandVisa("Michala", 2000));
            Console.WriteLine("Cekajicich:" + visas.PendingCount);
            visas.PrintApproved();
            
        }
    }
}