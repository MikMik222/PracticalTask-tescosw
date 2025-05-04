using CarSell.DatabaseFake;
using CarSell.ModelView;
using System.Text;

namespace CarSell.Service
{
    public class SalesService : ISalesService
    {
        IDatabase _database;
        IDateFormatService _dateFormatService;

        public SalesService(IDatabase database, IDateFormatService dateFormatService)
        {
            _database = database;
            _dateFormatService = dateFormatService;
        }

        public List<SalesModel> GetListSales()
        {
            var data = _database.GetCarsData();
            return data.Sales.Select(p =>
            {
                var type = data.Parametrs.FirstOrDefault(m => m.Id == p.VersionId);
                var model = data.Models.FirstOrDefault(m => m.Id == type?.ModelId);
                var brand = data.Brands.FirstOrDefault(z => z.Id == model?.ZnackaId);
                var seller = data.Employees.FirstOrDefault(pro => pro.Id == p.EmployeeId);
                var employer = data.Sellers.FirstOrDefault(zam => zam.Id == seller?.ProdejceId);
                return new SalesModel
                {
                    Seller = $"{seller?.Name} {seller?.Surname} - {employer?.Name}",
                    NameOfModel = $"{brand?.Name} {model?.Name} {type?.Type}",
                    DateOfSale = _dateFormatService.Format(p.DateSale),
                    Cost = p.Cost,
                    Vat = data.VAT.FirstOrDefault(s => s.Id == p.VATId)?.Tax ?? 0
                };
            }).ToList();
        }

        public int GetRandomIdForSales()
        {
            var data = _database.GetCarsData();
            int countRow = data.Employees.Count;
            Random random = new Random();
            return data.Employees[random.Next(countRow)].Id;
        }

        public string GetSalesSummary(DateTime from, DateTime to, bool weekendsOnly)
        {
            var data = _database.GetCarsData();
            if (data == null) return string.Empty;

            var summaries = data.Sales
                .Where(p => p.DateSale >= from && p.DateSale <= to)
                .Where(p => !weekendsOnly || (p.DateSale.DayOfWeek == DayOfWeek.Saturday || p.DateSale.DayOfWeek == DayOfWeek.Sunday))
                .GroupBy(p => p.VersionId)
                .Select(g =>
                {
                    var type = data.Parametrs.FirstOrDefault(m => m.Id == g.Key);
                    var model = data.Models.FirstOrDefault(m => m.Id == type?.ModelId);
                    var brand = data.Brands.FirstOrDefault(z => z.Id == model?.ZnackaId);
                    var modelName = $"{brand?.Name} {model?.Name} {type?.Type}";
                    var sumCena = g.Sum(p => p.Cost);
                    var sumCenaSDph = g.Sum(p =>
                    {
                        var dph = data.VAT.FirstOrDefault(d => d.Id == p.VATId)?.Tax ?? 0;
                        return p.Cost * (1 + dph / 100);
                    });

                    return new
                    {
                        NazevModelu = modelName,
                        CenaBezDPH = sumCena,
                        CenaSDPH = sumCenaSDph
                    };
                })
                .Where(s => s.NazevModelu != null)
                .ToList();

            var sb = new StringBuilder();
            foreach (var s in summaries)
            {
                sb.AppendLine($"{s.NazevModelu}");
                sb.AppendLine($"Cena bez DPH: {s.CenaBezDPH:N2} Kč");
                sb.AppendLine($"Cena s DPH:   {s.CenaSDPH:N2} Kč");
                sb.AppendLine();
            }
            return sb.ToString();
        }
    }
}
