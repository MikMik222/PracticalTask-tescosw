using System.Windows;

namespace CarSell.Service
{
    public class ErrorDisplayService : IErrorDisplayService
    {
        public void ShowErrors(IEnumerable<string> errors)
        {
            var errorMessage = string.Join(Environment.NewLine, errors);
            MessageBox.Show(errorMessage, "Chyby při validaci", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
