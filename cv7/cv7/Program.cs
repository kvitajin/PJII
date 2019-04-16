using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace cv7 {
    class Program {
        static void Main(string[] args) {
//            MyStack myStack = new MyStack(20);
//            myStack.Push(5);
//            myStack.Push(20);
//            myStack.Push(-1);
//            myStack.Push(7);
//            myStack.Push(9);
//            myStack.Push(50);
//            myStack.Push(19);
//            myStack.Push(42);
//            
//            /*foreach (int val in myStack) {
//                Console.WriteLine(val);
//            }*/
//            IEnumerator<int> stackEnum = myStack.GetEnumerator();                //dela to to same, co foreach nad tim
//            while (stackEnum.MoveNext()) {
//                Console.WriteLine(stackEnum.Current);
//            }


            int[] num = new int[] {8, 4, 26, 5, 84, 6, 8, 1, 30};
//            Array.Sort(num, new MyComparer());
            User franta =new User();
            foreach (int val in num) {
                Console.WriteLine(val);
            } 
         
            
        }
    }

    class User {
        public int Age { get; set; }
    }
    
//    class MyComparer : IComparer<int> {
//        public int Compare(int x, int y) {
////            return y - x;
//            if (x % 2 == y % 2) {
//                return x - y;
//            }
//            if(x%2==0) {
//                return -1;
//            }
//
//            return 1;
//        }
//    }
    class MyComparer : IComparer<User> {
        public int Compare(User x, User y) {
//            return y - x;
            if (x.Age % 2 == y.Age % 2) {
                return x.Age - y.Age;
            }
            if(x.Age%2==0) {
                return -1;
            }

            return 1;
        }
    }
    
    class MyStack:IEnumerable<int> {
        private int[] data;
        private int top;

        public MyStack(int size) {
            this.data=new int[size];
            this.top = -1;
            
        }

        public void Push(int value) {
            this.top++;
            this.data[this.top] = value;
        }


        public IEnumerator<int> GetEnumerator() {
//            return new MyStackEnumerator(data, top);
/*            for (int i = 0;  i< this.top; i++) {                    //tohle udela to same, co ta clasa pod tilm, jen nema reset
                yield return this.data[i];
            }*/
            Random j= new Random();
            while (true) {
                int i = j.Next(0, 30);
                if (i == 20) {
                    yield break;
                }

                yield return i;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return new MyStackEnumerator(data, top);
        }
    }

    class MyStackEnumerator : IEnumerator<int> {
        private int top=0;
        private int[] data;
        private int index;
        
        public bool MoveNext() {
            this.index += 2;
            if (this.index<=this.top) {
                return true;
            }

            return false;
        }

        public MyStackEnumerator(int[] data, int top) {
            this.data = data;
            this.top = top;
            this.index = -1;
        }

        public void Reset() {
            this.index = -1;
        }

        public int Current {
            get { return this.data[this.index]; }
        }

        object IEnumerator.Current => Current;

        public void Dispose() {
        }
    }
}