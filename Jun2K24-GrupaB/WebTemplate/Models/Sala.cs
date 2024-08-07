namespace WebTemplate.Models
{
    public class Sala
    {
        [Key]
        public int ID { get; set; }
        public int Kapacitet { get; set; }
        [MaxLength(50)]
        public required string Adresa { get; set; }
        public int Cena { get; set; }
        public List<Evidencija>? Evidencije { get; set; }

    }
}