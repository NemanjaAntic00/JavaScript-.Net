using System.Text.Json.Serialization;

namespace WebTemplate.Models
{
    public class Prodavnica
    {
        [Key]
        public int ID { get; set; }
        [MaxLength(30)]
        public required string Naziv { get; set; }
        [JsonIgnore]
        public List<Zarada>? Zarade { get; set; }

    }
}