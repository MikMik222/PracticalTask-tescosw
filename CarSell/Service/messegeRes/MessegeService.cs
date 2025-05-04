using System.Windows;

namespace CarSell.Service
{
    public class MessegeService : IMessegeService
    {
        public void ShowError(string errorMsg)
        {
            MessageBox.Show(errorMsg, "Chyba", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public void ShowInfoSucces(string successMsg)
        {
            MessageBox.Show(successMsg, "Úspěch", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
