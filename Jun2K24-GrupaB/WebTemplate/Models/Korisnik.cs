namespace WebTemplate.Models
{
    public class Korisnik
    {
        public int ID { get; set; }
        public required string Ime { get; set; }
        public required string Prezime { get; set; }

        public required int JMBG { get; set; }
        public List<Evidencija>? Evidencije { get; set; }
    }
}