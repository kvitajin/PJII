using System;

namespace dais_orm_znova {
    public class Fotografie {
        private int FotoId { get; set; }
        private string Nazev { get; set; }
        private DateTime Datum { get; set; }
        private string Popis { get; set; }
        private int AlbumId { get; set; }
    }
}