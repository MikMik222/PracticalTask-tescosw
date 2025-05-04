using System.ComponentModel.DataAnnotations;


namespace CarSell.ModelView
{
    public class ParametrModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Název je povinný.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Název musí být v rozmezí 2–50 znaků.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Value je povinná.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Value musí být v rozmezí 2–50 znaků.")]
        public string Value { get; set; }

        [StringLength(20, ErrorMessage = "Unit může mít 20 znaků.")]
        public string Unit { get; set; }
    }
}
