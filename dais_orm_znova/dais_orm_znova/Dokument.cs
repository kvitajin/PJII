using System;

namespace dais_orm_znova {
    public class Dokument {
        public int DokumentId { get; set; }
        public string Nadpis { get; set; }
        public string Obsah{ get; set; }
        public DateTime Datum{ get; set; }
        public string Obrazek{ get; set; }
        public int RubrikaId { get; set; }
    }
}