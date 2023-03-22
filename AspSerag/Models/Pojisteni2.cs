using System.ComponentModel.DataAnnotations;

namespace AspSerag.Models
{
    public class Pojisteni2
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Vyplňte Jméno")]
        public string Jméno { get; set; } = "";
        [Required(ErrorMessage = "Vyplňte Příjmení")]
        public string Příjmení { get; set; } = "";
        [Required(ErrorMessage = "Vyplňte popis")]
        [StringLength(300, ErrorMessage = "Popisek je příliš dlouhý")]
        public string Popis { get; set; } = "";

    }
}
