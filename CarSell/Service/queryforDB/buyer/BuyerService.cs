using CarSell.DatabaseFake;
using CarSell.ModelView;
using System.Xml.Linq;

namespace CarSell.Service
{
    public class BuyerService : IBuyerService
    {
        private readonly IDatabase _database;
        private readonly IModelConverterFactory _converterFactory;
        private readonly IServiceFactory _serviceFactory;

        public BuyerService(IDatabase database, IModelConverterFactory converterFactory, IServiceFactory serviceFactory)
        {
            _database = database;
            _converterFactory = converterFactory;
            _serviceFactory = serviceFactory;
        }


        public List<Buyer> GetTenBuyerWithFilter(string name, string surname)
        {
            return _database.GetCarsData().Buyers
                .Where(b =>
                    b.Name.Contains(name, StringComparison.OrdinalIgnoreCase) &&
                    b.Surname.Contains(surname, StringComparison.OrdinalIgnoreCase))
                .Take(10)
                .ToList();
        }
    }
}
