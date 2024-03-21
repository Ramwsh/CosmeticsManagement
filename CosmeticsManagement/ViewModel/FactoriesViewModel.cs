using CosmeticsManagement.Model.Entities;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using CosmeticsManagement.Model.CRUD;
using CosmeticsManagement.View;
using System.Windows.Input;

namespace CosmeticsManagement.ViewModel
{
    public class FactoriesViewModel : INotifyPropertyChanged
    {
        private Window _currentWindow;

        private ObservableCollection<Factory> _factories;

        public ObservableCollection<Factory> Factories
        {
            get
            {
                return _factories;
            }
            set
            {
                _factories = value;
                OnPropertyChanged(nameof(_factories));
            }
        }

        private Factory _selectedFactoryItem;

        public Factory SelectedFactoryItem
        {
            get
            {
                return _selectedFactoryItem;
            }
            set
            {
                _selectedFactoryItem = value;
                OnPropertyChanged(nameof(_selectedFactoryItem));
                if (_selectedFactoryItem != null)
                {
                    FactoryAddress = _selectedFactoryItem.Address;
                    FactoryId = _selectedFactoryItem.FCode.ToString();
                    FactoryPhone = _selectedFactoryItem.Phone;
                    FactoryName = _selectedFactoryItem.FName;
                    OnPropertyChanged(nameof(FactoryName));
                    OnPropertyChanged(nameof(FactoryPhone));
                    OnPropertyChanged(nameof(FactoryId));
                    OnPropertyChanged(nameof(FactoryAddress));
                }
            }
        }

        private string? _factoryAddress;

        public string? FactoryAddress
        {
            get
            {
                return _factoryAddress;
            }
            set
            {
                _factoryAddress = value;
                OnPropertyChanged(nameof(_factoryAddress));
            }
        }

        private string? _factoryPhone;
        public string? FactoryPhone
        {
            get
            {
                return _factoryPhone;
            }
            set
            {
                _factoryPhone = value;
                OnPropertyChanged(nameof(_factoryPhone));
            }
        }

        private string? _factoryName;
        public string? FactoryName
        {
            get
            {
                return _factoryName;
            }
            set
            {
                _factoryName = value;
                OnPropertyChanged(nameof(_factoryName));
            }
        }

        private string? _factoryId;
        public string? FactoryId
        {
            get
            {
                return _factoryId;
            }
            set
            {
                _factoryId = value;
                OnPropertyChanged(nameof(_factoryId));
            }
        }

        public FactoriesViewModel(Window window)
        {
            Factories = new ObservableCollection<Factory>(new Controller<Factory>().Read());
            _currentWindow = window;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ICommand CreateCommand => new Commands((obj) =>
        {
            if (!string.IsNullOrEmpty(_factoryId) && !string.IsNullOrEmpty(_factoryName) && !string.IsNullOrEmpty(_factoryAddress) && !string.IsNullOrEmpty(_factoryPhone))
            {
                Factory factoryToAdd = new Factory() { FCode = Convert.ToInt32(_factoryId), Address = _factoryAddress, FName = _factoryName, Phone = _factoryPhone };
                new Controller<Factory>().Create(factoryToAdd);
                Factories.Add(factoryToAdd);
                Factories = new ObservableCollection<Factory>(new Controller<Factory>().Read());
            }
        });

        public ICommand DeleteCommand => new Commands((obj) =>
        {
            if (_selectedFactoryItem != null)
            {
                new Controller<Factory>().Delete(_selectedFactoryItem);
                Factories = new ObservableCollection<Factory>(new Controller<Factory>().Read());
                OnPropertyChanged(nameof(Factories));
            }
        });

        public ICommand UpdateCommand => new Commands((obj) =>
        {
            if (_selectedFactoryItem != null)
            {
                Factory updatedFactory = new Factory() { FCode = _selectedFactoryItem.FCode, Address = _factoryAddress, FName = _factoryName, Phone = _factoryPhone };
                new Controller<Factory>().Update(_selectedFactoryItem.FCode, updatedFactory);
                Factories = new ObservableCollection<Factory>(new Controller<Factory>().Read());
                OnPropertyChanged(nameof(Factories));
            }
        });

        public ICommand OpenProductsCommand => new Commands((obj) =>
        {
            ProductsView productsView = new ProductsView();
            productsView.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            productsView.Show();
            _currentWindow.Close();
        });

        public ICommand OpenBrandsCommand => new Commands((obj) =>
        {
            BrandsView brandsView = new BrandsView();
            brandsView.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            brandsView.Show();
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
