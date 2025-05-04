using CarSell.DatabaseFake;
using CarSell.ModelView;

namespace CarSell.Service
{
    public interface IVATService
    {
        public List<VATModel> GetVATList();
    }
}
