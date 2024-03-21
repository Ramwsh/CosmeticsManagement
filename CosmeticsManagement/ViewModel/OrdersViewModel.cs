using CosmeticsManagement.Model.CRUD;
using CosmeticsManagement.Model.Entities;
using CosmeticsManagement.View;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace CosmeticsManagement.ViewModel
{
    public class OrdersViewModel : INotifyPropertyChanged
    {        
        private Order _selectedOrderItem;
        public Order SelectedOrderItem
        {
            get
            {
                return _selectedOrderItem;
            }
            set
            {
                _selectedOrderItem = value;
                OnPropertyChanged(nameof(_selectedOrderItem));
                if (_selectedOrderItem != null)
                {
                    Product selectedProduct = Products.Select(product => product).Where(product => product.PCode == _selectedOrderItem.PCode).FirstOrDefault();
                    if (selectedProduct != null)
                    {
                        SelectedProductItem = selectedProduct;
                        OnPropertyChanged(nameof(SelectedProductItem));
                    }                    

                    Factory selectedFactory = Factories.Select(factory => factory).Where(factory => factory.FCode == _selectedOrderItem.FCode).FirstOrDefault();
                    if (selectedFactory != null)
                    {
                        SelectedFactoryItem = selectedFactory;
                        OnPropertyChanged(nameof(SelectedFactoryItem));
                    }                    

                    OrderId = _selectedOrderItem.OCode.ToString();
                    orderDate = _selectedOrderItem.OrderDate;
                    ExecutionDate = _selectedOrderItem.ExecutionDate;
                    ProductCount = _selectedOrderItem.ProductCountInOrder.ToString();                    
                    OnPropertyChanged(nameof(OrderId));
                    OnPropertyChanged(nameof(orderDate));
                    OnPropertyChanged(nameof(ExecutionDate));
                    OnPropertyChanged(nameof(ProductCount));                                        
                }
            }
        }

        private ObservableCollection<Product> _products;

        public ObservableCollection<Product> Products
        {
            get
            {
                return _products;
            }
            set
            {
                _products = value;
                OnPropertyChanged(nameof(_products));
            }
        }

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

        private ObservableCollection<Order> _orders;

        public ObservableCollection<Order> Orders
        {
            get
            {
                return _orders;
            }
            set
            {
                _orders = value;
                OnPropertyChanged(nameof(_orders));
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
            }
        }

        private Product _selectedProductItem;

        public Product SelectedProductItem
        {
            get
            {
                return _selectedProductItem;
            }
            set
            {
                _selectedProductItem = value;
                OnPropertyChanged(nameof(_selectedProductItem));
            }
        }

        private string? _productCount;

        public string? ProductCount
        {
            get
            {
                return _productCount;
            }
            set
            {
                _productCount = value;
                OnPropertyChanged(nameof(_productCount));
            }
        }

        private DateTime _executionDate;

        public DateTime ExecutionDate
        {
            get
            {
                return _executionDate;
            }
            set
            {
                _executionDate = value;
                OnPropertyChanged(nameof(_executionDate));
            }
        }

        private DateTime _orderDate;

        public DateTime orderDate
        {
            get
            {
                return _orderDate;
            }
            set
            {
                _orderDate = value;
                OnPropertyChanged(nameof(_orderDate));
            }
        }

        private string? _orderId;
        public string? OrderId
        {
            get
            {
                return _orderId;
            }
            set
            {
                _orderId = value;
                OnPropertyChanged(nameof(_orderId));
            }
        }

        private Window currentWindow;

        public OrdersViewModel(Window window)
        {
            currentWindow = window;
            Orders = new ObservableCollection<Order>(new Controller<Order>().Read());
            Factories = new ObservableCollection<Factory>(new Controller<Factory>().Read());
            Products = new ObservableCollection<Product>(new Controller<Product>().Read());
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ICommand CreateCommand => new Commands((obj) =>
        {
            if (!string.IsNullOrEmpty(_orderId) && _orderDate != null && _executionDate != null && !string.IsNullOrEmpty(_productCount) && _selectedProductItem != null && _selectedFactoryItem != null)
            {
                Order orderToAdd = new Order()
                {
                    OCode = Convert.ToInt32(_orderId),
                    OrderDate = _orderDate,
                    ExecutionDate = _executionDate,
                    ProductCountInOrder = Convert.ToInt32(_productCount),
                    PCode = _selectedProductItem.PCode,
                    PName = _selectedProductItem.PName,
                    FCode = _selectedFactoryItem.FCode,
                    FName = _selectedFactoryItem.FName,
                };
                new Controller<Order>().Create(orderToAdd);
                Orders.Add(orderToAdd);
                Orders = new ObservableCollection<Order>(new Controller<Order>().Read());
                OnPropertyChanged(nameof(Orders));
            }
        });

        public ICommand DeleteCommand => new Commands((obj) =>
        {
            if (_selectedOrderItem != null)
            {
                new Controller<Order>().Delete(_selectedOrderItem);
                Orders = new ObservableCollection<Order>(new Controller<Order>().Read());
                OnPropertyChanged(nameof(Orders));
            }
        });

        public ICommand UpdateCommand => new Commands((obj) =>
        {
            if (_selectedOrderItem != null)
            {
                Order updatedOrder = new Order()
                {
                    OCode = _selectedOrderItem.OCode,
                    OrderDate = _orderDate,
                    ExecutionDate = _executionDate,
                    ProductCountInOrder = Convert.ToInt32(_productCount),
                    PCode = _selectedProductItem.PCode,
                    PName = _selectedProductItem.PName,
                    FCode = _selectedFactoryItem.FCode,
                    FName = _selectedFactoryItem.FName,
                };
                new Controller<Order>().Update(_selectedOrderItem.OCode, updatedOrder);
                Orders = new ObservableCollection<Order>(new Controller<Order>().Read());
                OnPropertyChanged(nameof(Orders));
            }
        });

        public ICommand OpenBrandsViewCommand => new Commands((obj) =>
        {
            BrandsView brandsView = new BrandsView();
            brandsView.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            brandsView.Show();
            currentWindow.Close();
        });

        public ICommand OpenProductsViewCommand => new Commands((obj) =>
        {
            ProductsView productsView = new ProductsView();
            productsView.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            productsView.Show();
            currentWindow.Close();
        });

        public ICommand OpenFactoriesViewCommand => new Commands((obj) =>
        {
            FactoriesView factoriesView = new FactoriesView();
            factoriesView.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            factoriesView.Show();
            currentWindow.Close();
        });

        public ICommand OpenDeliveriesViewCommand => new Commands((obj) =>
        {
            DeliveriesView deliveriesView = new DeliveriesView();
            deliveriesView.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            deliveriesView.Show();
            currentWindow.Close();
        });
    }
}
