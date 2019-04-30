namespace dais_orm_znova {
    public class Komentar {
        private int KomentarId { get; set; }
        private string obsah { get; set; }
        private int? DokumentId { get; set; }
        private int? FotoId { get; set; }
        private int UzivatelId { get; set; }
    }
}