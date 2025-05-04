using System.ComponentModel.DataAnnotations;

namespace CarSell.ModelView
{
    public class VersionModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Verze je povinná.")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Verze musí být dlouhá 1–50 znaků.")]
        public string Type {  get; set; }

        public int ModelId { get; set; }
    }
}