using CarSell.Type;
using System.Windows;


namespace CarSell.Dialog
{
    public partial class ModelSelect : Window
    {
        TypyEntitService _typyEntit = new TypyEntitService();
        public string selectType => comboBoxTypy.SelectedItem as string;
        public ModelSelect()
        {
            InitializeComponent();
            comboBoxTypy.ItemsSource = _typyEntit.ListOptions;
        }

        private void BtnContinueClick(object sender, RoutedEventArgs e)
        {
            if (comboBoxTypy.SelectedItem != null)
            {
                this.DialogResult = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Vyberte, možnost.");
            }
        }
    }
}
