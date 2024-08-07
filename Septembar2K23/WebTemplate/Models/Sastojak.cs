using System.Text.Json.Serialization;

namespace WebTemplate.Models
{
    public class Sastojak
    {
        [Key]
        public int ID { get; set; }
        public required string Naziv { get; set; }
        public required int Kolicina { get; set; }
        public int Cena { get; set; }
        [JsonIgnore]
        public Zarada? Zarade { get; set; }

    }
}