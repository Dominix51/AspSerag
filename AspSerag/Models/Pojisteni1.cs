using System.ComponentModel.DataAnnotations;


namespace AspSerag.Models
{
    public class Pojisteni1
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Vyplňte Jméno")]
        public string Jméno { get; set; } = "";
        [Required(ErrorMessage = "Vyplňte Příjmení")]
        public string Příjmení { get; set; } = "";
        [Required(ErrorMessage = "Vyplňte věk")]
        public int Věk { get; set; }
        [Required(ErrorMessage = "Vyplňte adresu vč. č.p./č.ev.")]
        public string Bydliště { get; set; } = "";
        [Required(ErrorMessage = "Vyplňte Obec trvalého pobytu")]
        public string Obec { get; set; } = "";
        [Required(ErrorMessage = "Vyplňte poštovní směrovací číslo")]
        public int PSČ { get; set; }
        [Required(ErrorMessage = "Vyplňte telefonní číslo")]
        public int Telefon { get; set; }
        [Required(ErrorMessage = "Vyplňte emailovou adresu")]
        public string Email { get; set; } = "";
    }
}
