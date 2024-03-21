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
            BrandsView brandsView = new BrandsView();
            brandsView.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            brandsView.Show();
            _currentWindow.Close();
        });

        public ICommand OpenProductViewCommand => new Commands((obj) =>
        {
            ProductsView productsView = new ProductsView();
            productsView.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            productsView.Show();
            _currentWindow.Close();
        });

        public ICommand OpenFactoriesViewCommand => new Commands((obj) =>
        {
            FactoriesView factoriesView = new FactoriesView();
            factoriesView.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            factoriesView.Show();
            _currentWindow.Close();
        });

        public ICommand OpenOrdersViewCommand => new Commands((obj) =>
        {
            OrdersView ordersView = new OrdersView();
            ordersView.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            ordersView.Show();
            _currentWindow.Close();
        });

        public ICommand OpenDeliveriesViewCommand => new Commands((obj) =>
        {
            DeliveriesView deliveriesView = new DeliveriesView();
            deliveriesView.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            deliveriesView.Show();
            _currentWindow.Close();
        });
    }
}
