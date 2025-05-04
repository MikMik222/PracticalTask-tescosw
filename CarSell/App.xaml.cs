
using System.Windows;
using CarSell.DatabaseFake;
using CarSell.Dialog;
using CarSell.Service;
using CarSell.UserControlComponent;
using CarSell.Validation;
using Microsoft.Extensions.DependencyInjection;

namespace CarSell
{
    public partial class App : Application
    {
        public IServiceProvider ServiceProvider { get; private set; }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var services = new ServiceCollection();
            services.AddSingleton<IServiceFactory, ServiceFactory>();

            var converterRegistrar = new ModelConverterRegistrar();
            converterRegistrar.Register(services);
            services.AddScoped<IModelConverterFactory, ModelConverterFactory>();
            services.AddSingleton<IDatabase, FakeDatabase>();
            services.AddScoped<IErrorDisplayService, ErrorDisplayService>();
            services.AddScoped<IModelValidator, ModelValidator>();
            services.AddScoped<IDateFormatService, DateFormatService>();


            services.AddScoped<IVATService, VATService>();
            services.AddScoped<ISellersService, SellersService>();
            services.AddScoped<ISalesService, SalesService>();
            services.AddScoped<ICarsService, CarService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IBrandService, BrandService>();
            services.AddScoped<IBuyerService, BuyerService>();

            services.AddScoped<IMessegeService, MessegeService>();

            services.AddScoped<MainWindow>();

            ServiceProvider = services.BuildServiceProvider();
            var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }
    }

}
