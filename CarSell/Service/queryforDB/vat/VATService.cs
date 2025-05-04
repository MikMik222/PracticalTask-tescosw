using CarSell.DatabaseFake;
using CarSell.ModelView;

namespace CarSell.Service
{
    public class VATService : IVATService
    {
        private readonly IDatabase _database;
        private readonly IModelConverterFactory _converterFactory;
        private readonly IServiceFactory _serviceFactory;

        public VATService(IDatabase database, IModelConverterFactory converterFactory, IServiceFactory serviceFactory)
        {
            _database = database;
            _converterFactory = converterFactory;
            _serviceFactory = serviceFactory;
        }

        public List<VATModel> GetVATList()
        { 
            return _database.GetCarsData().VAT.Select(v =>
            {
                return new VATModel()
                {
                    Tax = v.Tax,
                    Id = v.Id,
                };
            }
            ).OrderBy(o => o.Tax)
                .ToList();
        }
    }
}
