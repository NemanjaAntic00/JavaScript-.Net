namespace WebTemplate.Models
{
    public class Evidencija
    {
        public int ID { get; set; }
        public required bool Iznajmljena { get; set; }
        public required DateTime Datum { get; set; }
        public required Sala Sala { get; set; }
        public required Korisnik Korisnik { get; set; }

    }
}