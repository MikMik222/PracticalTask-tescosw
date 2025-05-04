using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSell.ModelView
{
    public class CarModel
    {
        public int Id { get; set; }
        [NotMapped]
        public List<BrandModel>? Brands { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Musíte vybrat platnou značku.")]
        public int BrandId { get; set; }

        [Required(ErrorMessage = "Název je povinný.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Název musí být v rozmezí 2–50 znaků.")]
        public string Name { get; set; }

    }
}
