namespace WebTemplate.Models
{
    public class Zarada
    {
        public int ID { get; set; }
        public required int Mesta { get; set; }
        public required int Pazar { get; set; }
        public required Prodavnica Prodavnica { get; set; }
        public required List<Sastojak> Sastojci { get; set; }

    }
}