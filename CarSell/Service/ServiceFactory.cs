using Microsoft.Extensions.DependencyInjection;


namespace CarSell.Service
{
    public class ServiceFactory : IServiceFactory
    {
        private readonly IServiceProvider _provider;

        public ServiceFactory(IServiceProvider provider)
        {
            _provider = provider;
        }

        public T GetService<T>() where T : class
        {
            return _provider.GetRequiredService<T>();
        }
    }
}
