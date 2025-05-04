using CarSell.DatabaseFake;
using CarSell.ModelView;
using CarSell.Service;
using CarSell.Type;
using CarSell.Validation;
using System.Windows;


namespace CarSell.Dialog
{
    public partial class AddModelWindow : Window
    {
        private readonly IDatabase _database;
        private readonly IModelValidator _validator;
        private readonly IModelConverterFactory _convertor;
        private readonly ICarsService _vozidloService;
        private readonly IMessegeService _messegeService;

        public AddModelWindow(IServiceFactory serviceFactory)
        {
            InitializeComponent();
            _database = serviceFactory.GetService<IDatabase>();
            _validator = serviceFactory.GetService<IModelValidator>();
            _convertor = serviceFactory.GetService<IModelConverterFactory>();
            _vozidloService = serviceFactory.GetService<ICarsService>();
            _messegeService = serviceFactory.GetService<IMessegeService>();
            FillComboBox();
        }

        private void FillComboBox()
        {
            var zamestnanec = _vozidloService.GetCarModel();
            if (zamestnanec == null || zamestnanec.Brands == null) return;
            ModelFormControl.BrandComboBox.ItemsSource = zamestnanec.Brands;
        }
        private void BtnPridat_Click(object sender, RoutedEventArgs e)
        {
            CarModel novyModel = new CarModel
            {
                BrandId = Convert.ToInt32(ModelFormControl.SelectedZnackaId),
                Name = ModelFormControl.ModelNazev,
            };
            var validationErrors = _validator.Validate(novyModel);
            if (validationErrors.Any())
            {
                return;
            }
            novyModel.Id = _database.GenerateNewId(new TypyEntitService().Model);
            var convertor = _convertor.GetConverter<CarModel, Model>();
            _database.AddToDatabase(convertor.Convert(novyModel));
            _messegeService.ShowInfoSucces("Model auta byl byl úspěšně přidán.");
            this.Close();
        }
    }
}