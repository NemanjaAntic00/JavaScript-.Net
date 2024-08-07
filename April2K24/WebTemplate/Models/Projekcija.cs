namespace WebTemplateModels
{
    public class Projekcija
    {
        public int ID { get; set; }
        public required string Naziv { get; set; }
        public required Sala Sala { get; set; }
        public int Cena { get; set; }
        public int Sifra { get; set; }
        public DateTime Vreme { get; set; }
        public List<Karta>? Karte { get; set; }
    }
}