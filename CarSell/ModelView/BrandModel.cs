using System.ComponentModel.DataAnnotations;

namespace CarSell.ModelView
{
    public class BrandModel
    {
        [Required(ErrorMessage = "Značka je povinná.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Značka musí být dlouhá 2–50 znaků.")]
        public string Name {  get; set; }
        public int Id { get; set; }
    }
}