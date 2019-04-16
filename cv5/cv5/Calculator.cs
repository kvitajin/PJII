using System;

namespace cv5 {
    public delegate int Operation(int a, int b);
    public delegate void ComputeHandler(int vysledek);

    public class Calculator {
        private int X;
        private int Y;
        public event EventHandler OnSetXY;
        public event ComputeHandler OnCompute;
        

        public void setXY(int x, int y) {
            this.X = x;
            this.Y = y;
            MyEventArgs myEventArgs = new MyEventArgs(x, y);
            
               
            this.OnSetXY(this, myEventArgs);
            

        }

       
        public void Execute(Operation tmp) {
            Console.WriteLine (tmp(X, Y));
        }
    }

    public class MyEventArgs : EventArgs {
        public int a;
        public int b;

        public MyEventArgs(int x, int y) {
            this.a = x;
            this.b = y;
        }
    }

}