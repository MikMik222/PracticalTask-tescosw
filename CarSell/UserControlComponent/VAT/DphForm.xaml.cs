using System.Windows.Controls;


namespace CarSell.UserControlComponent
{
    public partial class DphForm : UserControl
    {

        public DphForm()
        {
            InitializeComponent();
        }

        public string SazbaText
        {
            get { return SazbaTextBox.Text; }
            set { SazbaTextBox.Text = value; }
        }
    }
}
