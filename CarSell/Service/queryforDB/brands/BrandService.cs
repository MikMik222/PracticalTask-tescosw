using CarSell.DatabaseFake;
using CarSell.ModelView;

namespace CarSell.Service
{
    public class BrandService : IBrandService
    {
        private readonly IDatabase _database;
        private readonly IModelConverterFactory _converterFactory;

        public BrandService(IDatabase database, IModelConverterFactory converterFactory)
        {
            _database = database;
            _converterFactory = converterFactory;
        }

        public List<BrandModel> GetZnacky()
        {
            var data = _database.GetCarsData();
            return data.Brands.Select(z => new BrandModel
            {
                Id = z.Id,
                Name = z.Name
            }).ToList();
        }
    }
}
