using CarSell.DatabaseFake;
using CarSell.ModelView;

namespace CarSell.Service
{
    public class ParametrSaveConvertor : IModelConverter<ParametrModel, Parametr>
    {
        public Parametr Convert(ParametrModel input)
        {
            return new Parametr
            {
                Id = input.Id,
                Hodnota = input.Value,
                Nazev = input.Name,
                Jednotka = input.Unit,
            };
        }
    }

}