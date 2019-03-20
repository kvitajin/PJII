using System;
using System.Collections.Generic;
using System.Linq;
namespace test1 {
    public class VisaList<T>:IVisa {
        private List<T> data=new List<T>();
        public void Add(T tmp) {
            this.data.Append(tmp);
        }

        public bool? Approved { get; }
        public double? Payment { get; set; }
        public string Name { get; set; }

        public int PendingCount {
            get {
                int i = 0;
                for (int j = 0; j < data.Count; j++) {
                    if (Approved == null) {
                        ++i;
                    }
                }
                return i;
              
            }
        }

        public void PrintApproved() {
            for (int i = 0; i < data.Count; i++) {
                if (Approved == true) {
                    Console.WriteLine(Name);
                }
            }
        }

    }
}