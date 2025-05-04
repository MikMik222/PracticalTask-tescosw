using CarSell.DatabaseFake;
using CarSell.ModelView;
using Microsoft.Extensions.DependencyInjection;

namespace CarSell.Service
{
    public class ModelConverterRegistrar
    {
        public void Register(IServiceCollection services)
        {
            services.AddScoped<IModelConverter<SalesModel, Sale>, SaleModelSaveConverter>();
            services.AddScoped<IModelConverter<VATModel, VAT>, VATModelSaveConverter>();
            services.AddScoped<IModelConverter<EmployeeModel, Employee>, EmployeeSaveConvertor>();
            services.AddScoped<IModelConverter<CarModel, Model>, ModelSaveConverter>();
            services.AddScoped<IModelConverter<BrandModel, Brand>, BrandSaveConverter>();
            services.AddScoped<IModelConverter<ParametrModel, Parametr>, ParametrSaveConvertor>();
            services.AddScoped<IModelConverter<SellerModel, SellerCompany>, SellerCompanySaveConvertor>();
            services.AddScoped<IModelConverter<VersionModel, DatabaseFake.Version>, VersionModelSaveConverter>();
        }
    }
}