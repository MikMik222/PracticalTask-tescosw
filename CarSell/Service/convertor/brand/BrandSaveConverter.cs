using CarSell.DatabaseFake;
using CarSell.ModelView;

namespace CarSell.Service
{
    public class BrandSaveConverter : IModelConverter<BrandModel, Brand>
    {
        public Brand Convert(BrandModel input)
        {

            return new Brand
            {
                Id = input.Id,
                Name = input.Name
            };
        }
    }

}