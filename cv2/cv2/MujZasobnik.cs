using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace cv2 {
    public class MujZasobnik:IZasobnik{
        private static int len = 50;
        private int[] data;
        private int index;
        
        public MujZasobnik(int size) {
            this.data = new int[size];
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


        public void Push(int number) {
            this.index++;
            this.data[this.index] = number;
        }

        public int Pop() {
            if (this.IsEmpty())
            {
                throw new StackIsEmptyException();
            }
            int tmp = this.data[this.index];
            this.index--;
            return tmp;
        }

        public int Top {
            get {
                 return this.data[this.index];
            }            
        }
    }
}