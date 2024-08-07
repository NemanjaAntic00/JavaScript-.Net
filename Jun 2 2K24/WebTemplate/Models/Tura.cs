namespace WebTemplate.Models
{
    public class Tura
    {
        public int ID { get; set; }
        public int Cena { get; set; }
        public int PreostaloMesta { get; set; }

        public List<Korisnik>? Korisnici { get; set; }
        public List<Znamenitost>? Znamenitosti { get; set; }
    }
}