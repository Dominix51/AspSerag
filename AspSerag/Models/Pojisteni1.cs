namespace AspSerag.Models
{
    public class Pojisteni1
    {
        public int Id { get; set; }
        public string Jméno { get; set; } = "";
        public string Příjmení { get; set; } = "";
        public int Věk { get; set; }
        public string Bydliště { get; set; } = "";
        public string Obec { get; set; } = "";
        public int PSČ { get; set; }
        public int Telefon { get; set; }
        public string Email { get; set; } = "";
    }
}
