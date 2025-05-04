namespace CarSell.Service
{
    public interface IModelConverterFactory
    {
        IModelConverter<TInput, TOutput> GetConverter<TInput, TOutput>();
    }

}
