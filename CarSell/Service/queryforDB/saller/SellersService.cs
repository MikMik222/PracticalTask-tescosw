using CarSell.DatabaseFake;
using CarSell.ModelView;

namespace CarSell.Service
{
    public class SellersService : ISellersService
    {
        private readonly IDatabase _database;
        private readonly IModelConverterFactory _converterFactory;
        private readonly IServiceFactory _serviceFactory;

        public SellersService(IDatabase database, IModelConverterFactory converterFactory, IServiceFactory serviceFactory)
        {
            _database = database;
            _converterFactory = converterFactory;
            _serviceFactory = serviceFactory;
        }

        public List<SellerCompanyModel> GetProdejciList()
        {
            return _database.GetCarsData().Sellers.Select(p =>
            {
                return new SellerCompanyModel
                {
                    Id = p.Id,
                    Name = p.Name,
                };
            }).ToList();
        }
    }
}
