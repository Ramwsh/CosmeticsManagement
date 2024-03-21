using CosmeticsManagement.Model.Entities;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using CosmeticsManagement.Model.CRUD;
using System.Windows.Input;
using CosmeticsManagement.View;

namespace CosmeticsManagement.ViewModel
{
    public class DeliveriesViewModel : INotifyPropertyChanged
    {
        private Delivery _selectedDeliveryItem;

        public Delivery SelectedDeliveryItem
        {
            get
            {
                return _selectedDeliveryItem;
            }
            set
            {
                _selectedDeliveryItem = value;
                OnPropertyChanged(nameof(_selectedDeliveryItem));
                if (_selectedDeliveryItem != null)
                {
                    Order selectedOrder = Orders.Select(order => order).Where(order => order.OCode == _selectedDeliveryItem.OCode).FirstOrDefault();
                    SelectedOrderItem = selectedOrder;
                    OnPropertyChanged(nameof(SelectedOrderItem));
                    Product selectedProduct = Products.Select(product => product).Where(product => product.PCode == selectedOrder.PCode).FirstOrDefault();
                    SelectedProductItem = selectedProduct;
                    OnPropertyChanged(nameof(SelectedProductItem));
                    OrderDate = selectedOrder.OrderDate;
                    OnPropertyChanged(nameof(OrderDate));
                    ProductCount = selectedOrder.ProductCountInOrder.ToString();
                    OnPropertyChanged(nameof(ProductCount));
                    DeliveryId = _selectedDeliveryItem.DCode.ToString();
                    OnPropertyChanged(nameof(DeliveryId));
                    DeliveryDate = _selectedDeliveryItem.RealDeliveryDate;
                    OnPropertyChanged(nameof(DeliveryDate));
                }
            }
        }

        private ObservableCollection<Delivery> _deliveries;

        public ObservableCollection<Delivery> Deliveries
        {
            get
            {
                return _deliveries;
            }
            set
            {
                _deliveries = value;
                OnPropertyChanged(nameof(_deliveries));
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
                    Order selectedOrder = Orders.Select(order => order).Where(order => order.OCode == _selectedOrderItem.OCode).FirstOrDefault();
                    Product selectedProduct = Products.Select(product => product).Where(product => product.PCode == selectedOrder.PCode).FirstOrDefault();
                    SelectedProductItem = selectedProduct;
                    OnPropertyChanged(nameof(SelectedProductItem));
                    OrderDate = selectedOrder.OrderDate;
                    OnPropertyChanged(nameof(OrderDate));
                    ProductCount = selectedOrder.ProductCountInOrder.ToString();
                    OnPropertyChanged(nameof(ProductCount));                     
                }
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

        private DateTime _orderDate;

        public DateTime OrderDate
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

        private DateTime _deliveryDate;

        public DateTime DeliveryDate
        {
            get
            {
                return _deliveryDate;
            }
            set
            {
                _deliveryDate = value;
                OnPropertyChanged(nameof(_deliveryDate));
            }
        }

        private string? _deliveryId;        

        public string? DeliveryId
        {
            get
            {
                return _deliveryId;
            }
            set
            {
                _deliveryId = value;
                OnPropertyChanged(nameof(_deliveryId));
            }
        }

        private Window _currentWindow;

        public DeliveriesViewModel(Window window)
        {
            _currentWindow = window;
            Orders = new ObservableCollection<Order>(new Controller<Order>().Read());
            Products = new ObservableCollection<Product>(new Controller<Product>().Read());
            Deliveries = new ObservableCollection<Delivery>(new Controller<Delivery>().Read());
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ICommand CreateCommand => new Commands((obj) =>
        {
            if (!string.IsNullOrEmpty(_deliveryId) && _deliveryDate != null && _selectedOrderItem != null && _selectedProductItem != null && _orderDate != null && !string.IsNullOrEmpty(_productCount))
            {
                Delivery deliveryToAdd = new Delivery()
                {
                    DCode = Convert.ToInt32(_deliveryId),
                    RealDeliveryDate = _deliveryDate,
                    OrderDate = _orderDate,
                    OCode = _selectedOrderItem.OCode,
                    PCountInDelivery = Convert.ToInt32(_productCount)
                };                
                new Controller<Delivery>().Create(deliveryToAdd);
                Deliveries.Add(deliveryToAdd);
                Deliveries = new ObservableCollection<Delivery>(new Controller<Delivery>().Read());
                OnPropertyChanged(nameof(Delivery));
            }
        });

        public ICommand DeleteCommand => new Commands((obj) =>
        {
            if (_selectedDeliveryItem != null)
            {
                new Controller<Delivery>().Delete(_selectedDeliveryItem);
                Deliveries = new ObservableCollection<Delivery>(new Controller<Delivery>().Read());
                OnPropertyChanged(nameof(Deliveries));
            }
        });

        public ICommand UpdateCommand => new Commands((obj) =>
        {
            if (_selectedDeliveryItem != null)
            {
                Delivery updatedDelivery = new Delivery()
                {
                    DCode = _selectedDeliveryItem.DCode,
                    RealDeliveryDate = _deliveryDate,
                    OrderDate = _orderDate,
                    OCode = _selectedOrderItem.OCode,
                    PCountInDelivery = Convert.ToInt32(_productCount)
                };                
                new Controller<Delivery>().Update(_selectedDeliveryItem.DCode, updatedDelivery);
                Deliveries = new ObservableCollection<Delivery>(new Controller<Delivery>().Read());
                OnPropertyChanged(nameof(Deliveries));
            }
        });

        public ICommand OpenBrandsViewCommand => new Commands((obj) =>
        {
            BrandsView brandsView = new BrandsView();
            brandsView.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            brandsView.Show();
            _currentWindow.Close();
        });

        public ICommand OpenProductsViewCommand => new Commands((obj) =>
        {
            ProductsView productsView = new ProductsView();
            productsView.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            productsView.Show();
            _currentWindow.Close();
        });

        public ICommand OpenOrdersViewCommand => new Commands((obj) =>
        {
            OrdersView ordersView = new OrdersView();
            ordersView.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            ordersView.Show();
            _currentWindow.Close();
        });

        public ICommand OpenFactoriesViewCommand => new Commands((obj) =>
        {
            FactoriesView factoriesView = new FactoriesView();
            factoriesView.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            factoriesView.Show();
            _currentWindow.Close();
        });
    }
}
