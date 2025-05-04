using CarSell.DatabaseFake;
using CarSell.ModelView;

namespace CarSell.Service
{
    public class VATModelSaveConverter : IModelConverter<VATModel, VAT>
    {
        public VAT Convert(VATModel input) => new VAT
        {
            Id = input.Id,
            Tax = input.Tax
        };
    }

}