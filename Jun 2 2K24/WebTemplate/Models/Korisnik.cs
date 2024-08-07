using System.Text.Json.Serialization;

namespace WebTemplate.Models
{
    public class Korisnik
    {
        public int ID { get; set; }
        public required string Ime { get; set; }
        public required string Prezime { get; set; }
        public int Licna { get; set; }
        [JsonIgnore]
        public List<Tura>? Ture { get; set; }

    }
}