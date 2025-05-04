using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarSell.ModelView
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        [NotMapped]
        public List<SellerCompanyModel> ?Employer { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Musíte vybrat platného zaměstnance.")]
        public int SellerId { get; set; }

        [Required(ErrorMessage = "Jméno je povinné.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Jméno musí být dlouhé 2–50 znaků.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Příjmení je povinné.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Příjmení musí být dlouhá 2–50 znaků.")]
        public string Surname { get; set; }
    }
}
