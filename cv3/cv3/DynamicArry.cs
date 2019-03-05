using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace cv3 {
    public class DynamicArry {
        private int size;
        public int?[] data;
        public DynamicArry(int size) {
            this.data = new int?[size];
        }

        public int? this [int myIndex] {
            get { return this.data[myIndex]; }
            set {
                if (this.data.Length<= myIndex) {
                    int?[] tmpArr = new int?[myIndex + 1];
                    Array.Copy(this.data, tmpArr, this.data.Length);
                    this.data = tmpArr;
                }
                this.data[myIndex] = value;
            }
        }

        public override string ToString() {
            StringBuilder tmp = new StringBuilder( );
            foreach (int? i in data) {
                if (i == null) {
                    tmp.Append("x, ");
                }
                else {
                    tmp.Append( i +", ");
                }
            }
            
            //nebo jen return string.Join(", ", data);

            return tmp.ToString();
        }

        public void Sum(ref int sum) {
            foreach (int? i in data) {
                if (i!=null) {
                    sum += i.Value;
                }
            }
        }

        public string StavInfo {
            get
            {
                int flag = 0;
                foreach (int? i in data) {
                    if (i != null) {
                        flag += 1;
                    }
                }

                if (flag == data.Length) {
                    return "Plne";
                }
                else if (flag == 0) {
                    return "Prazdne";
                }
                else {
                    return "neco mezi";
                }
            }
        }
    }
}