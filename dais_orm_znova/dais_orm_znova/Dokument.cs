using System;

namespace dais_orm_znova {
    public class Dokument {
        private int DokumentId { get; set; }
        private string Nadpis { get; set; }
        private string Obsah{ get; set; }
        private DateTime Datum{ get; set; }
        private string Obrazek{ get; set; }
    }
}