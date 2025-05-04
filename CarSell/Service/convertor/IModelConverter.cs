using CarSell.DatabaseFake;

namespace CarSell.Service
{
    public interface IModelConverter<TInput, TOutput>
    {
        TOutput Convert(TInput input);
    }
}
