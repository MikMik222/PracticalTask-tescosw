using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSell.Type
{
    public class TypyEntitService
    {
        public string Sale => "Prodej";
        public string Vat => "DPH";
        public string Employee => "Zaměstnanec";
        public string Model => "Model";
        public string Version => "Verze";
        public string Brand => "Značka";
        public string Parametrs => "Parametr";
        public string Seller => "Prodejce";

        public List<string> ListOptions => new List<string> {Sale,  Vat, Employee, Version, Model, Brand, Parametrs , Seller};
    }
}
