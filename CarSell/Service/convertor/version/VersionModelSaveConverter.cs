using CarSell.DatabaseFake;
using CarSell.ModelView;
using Version = CarSell.DatabaseFake.Version;
namespace CarSell.Service
{
    public class VersionModelSaveConverter : IModelConverter<VersionModel, Version>
    {

        public Version Convert(VersionModel input)
        {
            return new Version()
            {
                ModelId = input.ModelId,
                Type = input.Type,
                Id = input.Id
            };
        }
    }

}