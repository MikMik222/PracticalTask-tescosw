using CarSell.DatabaseFake;
using CarSell.ModelView;

namespace CarSell.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IDatabase _database;
        private readonly IModelConverterFactory _converterFactory;
        private readonly IServiceFactory _serviceFactory;

        public EmployeeService(IDatabase database, IModelConverterFactory converterFactory, IServiceFactory serviceFactory)
        {
            _database = database;
            _converterFactory = converterFactory;
            _serviceFactory = serviceFactory;
        }


        public EmployeeModel GetEmployeeModel()
        {
            return new EmployeeModel
            {
                Employer = _serviceFactory.GetService<ISellersService>().GetProdejciList(),
            };
        }
    }
}
