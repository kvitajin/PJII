using System;

namespace cv3 {
    class Program {
        static void Main(string[] args) {
            MujZasobnik<int?> ciselnik =new MujZasobnik<int?>(5);        //nejde, protoze int neni soucasti ICar
            
            ciselnik.Push(2);
            ciselnik.Push(5);
            
            MujZasobnik<string> reteznik = new MujZasobnik<string>(5);
            
            reteznik.Push("asdf");
            reteznik.Push("qwerty");
            
//            Nullable t = new Nullable<int>(58);
//            
//            int? j =58;
//            
//            Console.WriteLine(t.HasValue);
//            
//            Console.WriteLine("Hello World!");

            int?[] arr = new int?[10];
            
        }
    }
}