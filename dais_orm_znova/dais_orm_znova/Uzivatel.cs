using System;

namespace dais_orm_znova {
    public class Uzivatel {
        private int UzivatelId { get; set; }
        private string Nick { get; set; }
        private string Heslo { get; set; }
        private string Email { get; set; }
        private DateTime DatumNarozeni { get; set; }
        private int Ban { get; set; }
    }
}