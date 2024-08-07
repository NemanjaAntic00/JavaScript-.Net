namespace WebTemplateModels
{
    public class Sala
    {
        public int ID { get; set; }
        public string? Naziv { get; set; }
        public int BrRedova { get; set; }
        public int BrSedista { get; set; }
        public List<Projekcija>? Projekcije { get; set; }
    }
}