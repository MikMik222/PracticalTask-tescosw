using CarSell.DatabaseFake;
using CarSell.ModelView;

namespace CarSell.Service
{
    public class CarService : ICarsService
    {
        private readonly IDatabase _database;
        private readonly IModelConverterFactory _converterFactory;
        private readonly IServiceFactory   _serviceFactory;

        public CarService(IDatabase database, IModelConverterFactory converterFactory, IServiceFactory serviceFactory)
        {
            _database = database;
            _converterFactory = converterFactory;
            _serviceFactory = serviceFactory;
        }

        public List<BrandModel> GetBrands()
        {
            return _serviceFactory.GetService<IBrandService>().GetZnacky();
        }

        public List<Model> GetModelsByBrandId(int znackaId)
        {
            return _database.GetCarsData()?.Models
                .Where(m => m.ZnackaId == znackaId)
                .ToList() ?? new List<Model>();
        }

        public List<DatabaseFake.Version> GetVersionByModelId(int modelId)
        {
            return _database.GetCarsData()?.Parametrs
                .Where(v => v.ModelId == modelId)
                .ToList() ?? new List<DatabaseFake.Version>();
        }

        public CarModel GetCarModel()
        {
            List<BrandModel> znacky = (this as ICarsService).GetBrands();
            
            return new CarModel
            {
                Brands = znacky
            };
        }
    }
}
