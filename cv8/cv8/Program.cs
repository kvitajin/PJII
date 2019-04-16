using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Transactions;

namespace cv8 {
    class Program {
        static void Main(string[] args) {
            Contact Zake = new Contact("Zake", 22, "asdfg@google.com", 64, false);
            Contact Kris = new Contact("Kris", 22, "asdfg@google.com", 64, true);
            Contact Jirka = new Contact("Jirka", 22, "asdfg@google.com", 70, true);
            Contact[] osoby = {Zake, Kris, Jirka};

            using (FileStream fs = new FileStream("./contatcts.csv", FileMode.Create)) {
                /*using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8, 1024, true)) {
                    foreach (Contact i in osoby) {
                        sw.Write(i.Jmeno);
                        sw.Write(";");
                        sw.Write(i.Vek);
                        sw.Write(";");
                        sw.Write(i.Email);
                        sw.Write(";");
                        sw.Write(i.Vaha);
                        sw.Write(";");
                        sw.Write(i.Zije);
                        sw.WriteLine(";");
                        sw.Flush();
                    }
                }
                //StreamWriter sw =new StreamWriter("./contatcts.csv");        //jde to i takto, ale pak nemam kontrolu nad file streamem
                fs.Seek(0, SeekOrigin.Begin);
                using (StreamReader sr = new StreamReader(fs)) {
                    string line;
                    while ((line = sr.ReadLine()) != null) {
                        string[] tmp = line.Split(new char[]{';'});

                        Contact c = new Contact() {
                            Jmeno = tmp[0],
                            Vaha = byte.Parse(tmp[1]),
                            Email = tmp[2],
                            Vek = byte.Parse(tmp[3]),
                            Zije = bool.Parse(tmp[4])
                        };
                    }
                }*/
                using (BinaryWriter bw =new BinaryWriter(fs, Encoding.UTF8, true)) {
                    bw.Write(((ICollection) osoby).Count);
                    foreach (Contact i in osoby) {
                        bw.Write(i.Jmeno);
                        bw.Write(i.Vek);
                        bw.Write(i.Email);
                        bw.Write(i.Vaha);
                        bw.Write(i.Zije);
                    }
                }

                fs.Seek(0, SeekOrigin.Begin);
                /*using (BinaryReader br =new BinaryReader(fs)) {
                    int count = br.ReadInt32();
                    for (int i = 0; i < count; i++) {
                        Contact c = new Contact() {
                            Jmeno = br.ReadString(),
                            Vek = br.ReadInt32(),
                            Email = br.ReadString(),
                            Vaha = br.ReadInt32(),
                            Zije = br.ReadBoolean()
                        };
                    }*/

                using (BinaryReader br = new BinaryReader(fs)) {
                    br.BaseStream.Seek(9,SeekOrigin.Begin);
                    br.ReadString();
                }
                
                }

        //fs.Dispose();                        //tohle pokud nepouziju using u filestream

        }
    }

    class Contact {

        private string jmeno;
        private int vek;
        private string email;
        private int vaha;
        private bool zije;

        public Contact() {
        }

        public Contact(string jmeno, int vek, string email, int vaha, bool zije) {
            this.jmeno = jmeno;
            this.vek = vek;
            this.email = email;
            this.vaha = vaha;
            this.zije = zije;
        }
        public string Jmeno {
            get => jmeno;
            set => jmeno = value;
        }

        public int Vek {
            get => vek;
            set => vek = value;
        }

        public string Email {
            get => email;
            set => email = value;
        }

        public int Vaha {
            get => vaha;
            set => vaha = value;
        }

        public bool Zije {
            get => zije;
            set => zije = value;
        }


    }
}