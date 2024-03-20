using CosmeticsManagement.View;
using System.Windows;
using System.Windows.Input;

namespace CosmeticsManagement.ViewModel
{
    public class MainViewModel
    {
        private Window _currentWindow;

        public MainViewModel(Window window)
        {
            _currentWindow = window;            
        }

        public ICommand OpenBrandViewCommand => new Commands((obj) =>
        {
            Console.WriteLine("test");
            BrandsView brandsView = new BrandsView();
            brandsView.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            brandsView.Show();
            _currentWindow.Close();
        });
    }
}
