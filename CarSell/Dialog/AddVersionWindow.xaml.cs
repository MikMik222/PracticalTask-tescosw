using CarSell.DatabaseFake;
using CarSell.ModelView;
using CarSell.Service;
using CarSell.Type;
using CarSell.Validation;
using System.Windows;


namespace CarSell.Dialog
{
    public partial class AddVersionWindow : Window
    {
        private readonly IDatabase _database;
        private readonly IModelValidator _validator;
        private readonly IModelConverterFactory _convertor;
        private readonly IMessegeService _messegeService;
        private int _VersionId;


        public AddVersionWindow(IServiceFactory serviceFactory, int versionId)
        {
            InitializeComponent();
            _database = serviceFactory.GetService<IDatabase>();
            _validator = serviceFactory.GetService<IModelValidator>();
            _convertor = serviceFactory.GetService<IModelConverterFactory>();
            _VersionId = versionId;
            _messegeService = serviceFactory.GetService<IMessegeService>();
            InitUI();
        }

        private void InitUI()
        {
            var data = _database.GetCarsData();
            var model = data.Models.FirstOrDefault(m => m.Id == _VersionId);
            var znacka = data.Brands.FirstOrDefault(z => z.Id == model?.ZnackaId);

            if (model == null || znacka == null)
            {
                _messegeService.ShowError("Nepodařilo se načíst informace o voze.");
                this.Close();
                return;
            }
            VersionFormControler.ModelTextBlock.Text = $"{model.Name} {znacka.Name}";
        }



        private void BtnAdd_Click(object sender, EventArgs e)
        {

            VersionModel newVersion = new VersionModel()
            {
                Type = VersionFormControler.VersionText,

            };
            var validationErrors = _validator.Validate(newVersion);
            if (validationErrors.Any())
            {
                return;
            }
            newVersion.ModelId = _VersionId;
            newVersion.Id = _database.GenerateNewId(new TypyEntitService().Version);
            var convertor = _convertor.GetConverter<VersionModel, DatabaseFake.Version>();

            _database.AddToDatabase(convertor.Convert(newVersion));
            _messegeService.ShowInfoSucces("Verze byla úspěšně přidána.");
            this.Close();
        }
    }
}