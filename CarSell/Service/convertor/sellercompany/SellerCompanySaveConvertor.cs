using CarSell.DatabaseFake;
using CarSell.ModelView;

namespace CarSell.Service
{
    public class SellerCompanySaveConvertor : IModelConverter<SellerModel, SellerCompany>
    {
        public SellerCompany Convert(SellerModel input)
        {
            return new SellerCompany
            {
                Name = input.Name,
                Contact = input.Contact,
                Id = input.Id,
                Office = input.Office
            };
        }
    }

}