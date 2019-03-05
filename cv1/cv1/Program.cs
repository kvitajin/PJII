using System;
using System.Globalization;
using static cv1.lcv1;


namespace cv1;
//public class Pepa
//{
//    public void pozdrav(string name)
//    {
//        Console.WriteLine("nazdar "+ name);
//    }
//}




    class Program
    {
        static void Main(string[] args)
        {
//            Console.WriteLine("Hello World!");
//            string num =Console.ReadLine();
//            Console.WriteLine("zadane cislo:" +num);
            
            
//            Console.WriteLine("cislo jedna:");
//            string num = Console.ReadLine();
//            
//            Console.WriteLine("cislo dva:");
//            string num2 = Console.ReadLine();
//            
////            int a =int.Parse(num, CultureInfo.GetCultureInfo("en-us"));
////            int b = int.Parse(num2);
//            double a =double.Parse(num, CultureInfo.GetCultureInfo("en-us"));
//            double b = double.Parse(num2);
//            Console.WriteLine("vysledek: " +(a+b));

            int sum = 0;
            foreach (string tmp in args)
            {
                sum = int.Parse(tmp);
            }
            Console.Write(sum);

            string txt = "jmeno, Prijmeni, vek";
            Console.WriteLine(txt.ToUpper());
            Console.WriteLine(txt.ToLower());
            string[] parts = txt.Split(new char[] {','});
            foreach (string part in parts)
            {
                Console.WriteLine(part);
            }


            char[] a = new char[1];
            a[0] = ',';
            
            //nebo

            char[] b = new[] {',', '$'};
            
            Pepa p =new Pepa();
            p.pozdrav("kokot");
            
        }
    }
}