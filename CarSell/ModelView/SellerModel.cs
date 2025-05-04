using System.ComponentModel.DataAnnotations;

namespace CarSell.ModelView
{
    public class SellerModel
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "Jméno společnosti je povinné.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Jméno společnosti musí být mezi 2 a 100.")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Sídlo společnosti je povinné.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Sídlo společnosti musí být mezi 2 a 100.")]
        public string Office { get; set; }


        [Required(ErrorMessage = "Kontakt společnosti je povinné.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Kontakt společnosti musí být mezi 2 a 50.")]
        public string Contact { get; set; }
    }
}