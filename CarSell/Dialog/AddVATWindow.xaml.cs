using CarSell.DatabaseFake;
using CarSell.ModelView;
using CarSell.Service;
using CarSell.Type;
using CarSell.UserControlComponent;
using CarSell.Validation;
using System.Windows;


namespace CarSell.Dialog
{
    public partial class AddVATWindow : Window
    { 
        private readonly IDatabase _database;
        private readonly IModelValidator _validator;
        private readonly IModelConverterFactory _convertor;
        private readonly IMessegeService _messegeService;


        public AddVATWindow(IServiceFactory serviceFactory)
        {
            InitializeComponent();
            _database = serviceFactory.GetService<IDatabase>();
            _validator = serviceFactory.GetService<IModelValidator>();
            _convertor = serviceFactory.GetService<IModelConverterFactory>();
            _messegeService = serviceFactory.GetService<IMessegeService>();
        }

        private void OnAddDphClick(object sender, RoutedEventArgs e)
        {
            string sazbaText = DphFormControl.SazbaText;

            if (string.IsNullOrWhiteSpace(sazbaText))
            {
                MessageBox.Show("Prosím, zadejte sazbu Vat.", "Chyba", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (double.TryParse(sazbaText, out double sazba))
            {
                VATModel novaDph = new VATModel
                {
                    Tax = sazba,
                };
                var validationErrors = _validator.Validate(novaDph);
                if (validationErrors.Any())
                {
                    return;
                }
                novaDph.Id = _database.GenerateNewId(new TypyEntitService().Vat);
                var convertor = _convertor.GetConverter<VATModel, VAT>();
                _database.AddToDatabase(convertor.Convert(novaDph));
                _messegeService.ShowInfoSucces("DPH bylo úspěšně přidáno.");
                this.Close();
            }
            else
            {
                _messegeService.ShowError("Zadejte platnou hodnotu pro sazbu DPH.");
            }
        }
    }
}