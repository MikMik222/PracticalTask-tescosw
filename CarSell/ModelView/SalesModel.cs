using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSell.ModelView
{
    public class SalesModel
    {
        public int Id { get; set; }
        public string Seller { get; set; }
        public string NameOfModel { get; set; }
        public string DateOfSale { get; set; }
        [Range(0, Double.MaxValue, ErrorMessage = "Neplatná cena.")]
        public double Cost { get; set; }
        public double Vat { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Zvolte platné dph")]
        public int dphId {  get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Zvolte kupujícího")]
        public int kupujiciId { get; set; }

        public DateTime DateSale { get; set; }
        public int EmployeeId {  get; set; }
        public int VersionId {  get; set; } 
    }
}
