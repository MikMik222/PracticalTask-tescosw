using System.Windows.Controls;
namespace CarSell.UserControlComponent
{
    public partial class ParametrForm : UserControl
    {
        public string Name
        {
            get => NameTextBox.Text;
            set => NameTextBox.Text = value;
        }

        public string Value
        {
            get => ValueTextBox.Text;
            set => ValueTextBox.Text = value;
        }

        public string Unit
        {
            get => UnitTextBox.Text;
            set => UnitTextBox.Text = value;
        }


        public ParametrForm()
        {
            InitializeComponent();
        }

    }
}
