using CarSell.DatabaseFake;
using CarSell.Service;
using System.Windows;
using System.Windows.Controls;


namespace CarSell.Dialog
{

    public partial class SelectBuyerDialog : Window
    {
        public Buyer? SelectBuyer { get; private set; }
        private IBuyerService _buyerService;

        public SelectBuyerDialog(IBuyerService buyerService)
        {
            InitializeComponent();
            _buyerService = buyerService;
        }


        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            string jmeno = NameTextBox.Text;
            string prijmeni = PrijmeniTextBox.Text;
            var tenbuyer = _buyerService.GetTenBuyerWithFilter(jmeno, prijmeni);
            ResultBuyerList.ItemsSource = tenbuyer;
        }

        private void BtnVybrat_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.DataContext is Buyer z)
            {
                SelectBuyer = z;
                DialogResult = true;
            }
        }
    }

}