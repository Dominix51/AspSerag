using System.ComponentModel.DataAnnotations;

namespace AspSerag.Models
{
    public class Pojistka
    {
        public int Id { get; set; }
        public int PojistenyId { get; set; }
        [Required(ErrorMessage = "Vyplňte typ pojištění Ano/Ne")]
        public string Majetek { get; set; } = "";
        [Required(ErrorMessage = "Vyplňte typ pojištění Ano/Ne")]
        public string Osoby { get; set; } = "";
        [Required(ErrorMessage = "Vyplňte typ pojištění Ano/Ne")]
        public string Zivot { get; set; } = "";
        [Required(ErrorMessage = "Vyplňte typ pojištění Ano/Ne")]
        public string Uraz { get; set; } = "";
        [Required(ErrorMessage = "Vyplňte předmět pojištění")]
        public string Predmet { get; set; } = "";
        [Required(ErrorMessage = "Vyplňte počátek pojištění")]
        public DateTime Od { get; set; }
        [Required(ErrorMessage = "Vyplňte konec pojištění")]
        public DateTime Do { get; set; }
    }
}
