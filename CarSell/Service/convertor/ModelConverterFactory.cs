using System;

namespace CarSell.Service
{
    public class ModelConverterFactory : IModelConverterFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public ModelConverterFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IModelConverter<TInput ,TOutput> GetConverter<TInput, TOutput>()
        {
            var converter = _serviceProvider.GetService(typeof(IModelConverter<TInput, TOutput>));
            if (converter is IModelConverter<TInput, TOutput> typedConverter)
            {
                return typedConverter;
            }

            throw new InvalidOperationException($"Konvertor pro {typeof(TOutput).Name} nebyl nalezen.");
        }
    }

}
