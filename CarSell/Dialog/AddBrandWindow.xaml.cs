using CarSell.DatabaseFake;
using CarSell.ModelView;
using CarSell.Service;
using CarSell.Type;
using CarSell.Validation;
using System.Windows;


namespace CarSell.Dialog
{
    public partial class AddBrandWindow : Window
    {
        private readonly IDatabase _database;
        private readonly IModelValidator _validator;
        private readonly IModelConverterFactory _convertor;
        private readonly IMessegeService _messegeService;


        public AddBrandWindow(IServiceFactory serviceFactory)
        {
            InitializeComponent();
            _database = serviceFactory.GetService<IDatabase>();
            _validator = serviceFactory.GetService<IModelValidator>();
            _convertor = serviceFactory.GetService<IModelConverterFactory>();
            _messegeService = serviceFactory.GetService<IMessegeService>();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            BrandModel newBrand = new BrandModel
            {
                Name = BrandFormControl.BrandText,
            };
            var validationErrors = _validator.Validate(newBrand);
            if (validationErrors.Any())
            {
                return;
            }
            newBrand.Id = _database.GenerateNewId(new TypyEntitService().Brand);
            var convertor = _convertor.GetConverter<BrandModel, Brand>();
            _database.AddToDatabase(convertor.Convert(newBrand));

            _messegeService.ShowInfoSucces("Značka byla úspěšně přidána.");
            this.Close();
        }

    }
}