using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace cv3 {
    public interface ICar {
        
    }
    
    
    public class MujZasobnik<T>:IZasobnik<T> where T:class, new(){
        private static int len = 50;
        private T[] data;
        private int index;
        private int top;

        public MujZasobnik(int size) {
            this.data = new T[size];
            this.index = -1;
        }
       
        public bool IsEmpty() {
            if (this.index == -1) {
                return true;
            }
            return false;
        }

        public bool IsFull() {
            if (this.index==this.data.Length-1) {
                return true;
            }
            return false;
        }

        public void Clear() {
            this.index = -1;
        }


        public void Push(T number) {
            this.index++;
            this.data[this.index] = number;
        }
     

        public T Pop() {
            if (this.IsEmpty())
            {
                throw new StackIsEmptyException();
            }
            T tmp = this.data[this.index];
            this.index--;
            return tmp;
        }

        public T Top {
            get {
                return this.data[this.index];
            }            
        }
    }
}