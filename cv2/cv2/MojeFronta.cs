using System;
using System.ComponentModel.Design;
using System.Net.Sockets;

namespace cv2 {
    public class MojeFronta:IFronta {
        private int[] data;
        private int beginIndex;
        private int endIndex;

        MojeFronta(int len) {
            this.data = new int[len];
            this.beginIndex = 0;
            this.endIndex = 0;
        }
        public bool IsEmpty() {
            if (this.beginIndex == this.endIndex) {
                return true;
            }

            return false;
        }

        public bool IsFull() {
            if (this.endIndex == (this.endIndex + 1) % this.data.Length) {
                return true;
            }

            return false;
           
        }

        public void Clear() {
            this.endIndex = 0;
            this.beginIndex = 0;
        }

        public void Add(int number) {
            if (this.beginIndex == (this.endIndex + 1) % this.data.Length) {
                throw new Exception();
            }
            if (endIndex < data.Length) {
                this.endIndex++;
                this.data[endIndex] = number;
            }
            if (this.endIndex == this.data.Length) {
                this.endIndex = 0;
            }
               
        }

        public int Get() {
            int tmp = this.data[this.beginIndex];
            this.beginIndex++;
            return tmp;
            if (this.beginIndex == this.data.Length) {
                this.beginIndex = 0;
            }
            
        }
    }
}