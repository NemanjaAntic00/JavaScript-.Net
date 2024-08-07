namespace WebTemplate.Models
{
    public class ZnamenitostTura
    {
        public int ZnamenitostID { get; set; }
        public Znamenitost? Znamenitost { get; set; }
        public int Turaid { get; set; }
        public Tura? Tura { get; set; }
    }
}