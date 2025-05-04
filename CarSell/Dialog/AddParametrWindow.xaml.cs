using CarSell.DatabaseFake;
using CarSell.ModelView;
using CarSell.Service;
using CarSell.Type;
using CarSell.Validation;
using System.Windows;


namespace CarSell.Dialog
{
    public partial class AddParametrWindow : Window
    {
        private readonly IDatabase _database;
        private readonly IModelValidator _validator;
        private readonly IModelConverterFactory _convertor;
        private readonly int _selectedCar;
        private DatabaseFake.Version _verze;
        private readonly IMessegeService _messegeService;

        public AddParametrWindow(IServiceFactory serviceFactory, int śelectedCar)
        {
            InitializeComponent();
            _database = serviceFactory.GetService<IDatabase>();
            _validator = serviceFactory.GetService<IModelValidator>();
            _convertor = serviceFactory.GetService<IModelConverterFactory>();
            _selectedCar = śelectedCar;
            _messegeService = serviceFactory.GetService<IMessegeService>();
            InitUI();
        }

        private void InitUI()
        {
            var data = _database.GetCarsData();
            var car = data.Parametrs.FirstOrDefault(o => o.Id == _selectedCar);
            var model = data.Models.FirstOrDefault(m => m.Id == car?.ModelId);
            var znacka = data.Brands.FirstOrDefault(z => z.Id == model?.ZnackaId);

            if (model == null || znacka == null)
            {
                _messegeService.ShowError("Nepodařilo se načíst informace o voze.");
                this.Close();
                return;
            }


            _verze = data.Parametrs.FirstOrDefault(v => v.Id == _selectedCar);
            if (_verze == null)
            {
                _messegeService.ShowError("Nepodařilo se načíst informace o voze.");
                this.Close();
            }

            ParametrFormControl.AutoInfoTextBlock.Text = $"Přidání parametru pro: {znacka.Name} {model.Name} {_verze.Type}";

            ExistingParametrControl.ParametryListView.ItemsSource = _verze.Parametrs;
        }

        private void BtnPridat_Click(object sender, RoutedEventArgs e)
        {
            var name = ParametrFormControl.Name;
            var value = ParametrFormControl.Value;
            var unit = ParametrFormControl.Unit;

            ParametrModel novyParametr = new ParametrModel()
            {
                Value = value,
                Unit = unit,
                Name = name,
            };
            var validationErrors = _validator.Validate(novyParametr);
            if (validationErrors.Any())
            {
                return;
            }
            novyParametr.Id = _database.GenerateNewId(new TypyEntitService().Parametrs, _selectedCar);
            var convertor = _convertor.GetConverter<ParametrModel, Parametr>();
            if (_verze.Parametrs == null) _verze.Parametrs = new List<Parametr>();
            _verze.Parametrs.Add(convertor.Convert(novyParametr));
            ExistingParametrControl.ParametryListView.Items.Refresh();
            ParametrFormControl.NameTextBox.Clear();
            ParametrFormControl.ValueTextBox.Clear();
            ParametrFormControl.UnitTextBox.Clear();
        }
    }
}