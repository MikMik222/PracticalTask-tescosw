using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSell.ModelView
{
    public class VATModel
    {
        public int Id { get; set; }
        [Range(0, 100, ErrorMessage = "Sazba DPH musí být mezi 0 a 100.")]
        public double Tax { get; set; }
    }
}
