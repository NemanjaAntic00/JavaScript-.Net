using System.Text.Json.Serialization;

namespace WebTemplate.Models
{
    public class Znamenitost
    {
        public int ID { get; set; }
        public required string Naziv { get; set; }
        public required int Cena { get; set; }
        [JsonIgnore]
        public List<Tura>? Ture { get; set; }
    }
}