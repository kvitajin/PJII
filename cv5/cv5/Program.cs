using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace cv5 {
    class Program {
        public static int Sum(int a, int b) {
            
            return a + b;
        }

        public static void vypis(Object a, EventHandler e) {
            Console.WriteLine("jede nandler");
        }

        static void Main(string[] args) {
            
            Calculator cal=new Calculator();
//            cal.OnSetXY += (Object sender, EventArgs argg)=> {
//                MyEventArgs myEventArgs=(MyEventArgs)                                    //todo tpc netusim
//                Console.WriteLine("nastaveno")
//            };
            cal.OnCompute += (int a) => Console.WriteLine(a);
            cal.OnSetXY += (Object sender, EventArgs argg)=>Console.WriteLine("nastaveno2");
            cal.setXY(1, 5);
            
            cal.Execute(Sum);
            cal.Execute((x,y)=>x*y);
        }
        
        
    }

}