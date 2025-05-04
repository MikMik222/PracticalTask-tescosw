using CarSell.DatabaseFake;
using CarSell.ModelView;

namespace CarSell.Service
{
    public class ModelSaveConverter : IModelConverter<CarModel, Model>
    {
        public Model Convert(CarModel input)
        {

            return new Model
            {
                Id = input.Id,
                Name = input.Name,
                ZnackaId = input.BrandId, 
            };
        }
    }

}