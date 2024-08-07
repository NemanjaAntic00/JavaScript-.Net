namespace WebTemplate.Models
{
    public class KorisnikTura
    {
        public int KorisnikID { get; set; }
        public Korisnik? Korisnik { get; set; }
        public int TuraID { get; set; }
        public Tura? Tura { get; set; }

    }
}