namespace WebTemplateModels
{
    public class Karta
    {
        public int ID { get; set; }
        public int Cena { get; set; }
        public int Red { get; set; }
        public int Sediste { get; set; }
        public Projekcija? Projekcija { get; set; }
    }
}