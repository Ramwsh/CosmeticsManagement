using CosmeticsManagement.Model.CRUD;
using CosmeticsManagement.Model.Entities;
using CosmeticsManagement.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows;
using CosmeticsManagement.View;

namespace CosmeticsManagement.ViewModel
{    

    public class ProductsViewModel : INotifyPropertyChanged
    {
        private Window currentWindow;

        private string? _price;
        public string? Price
        {
            get
            {
                return _price;
            }
            set
            {
                _price = value;
                OnPropertyChanged(nameof(_price));
            }
        }

        private Brand _selectedBrandItem;

        public Brand SelectedBrandItem
        {
            get
            {
                return _selectedBrandItem;
            }
            set
            {
                _selectedBrandItem = value;
                OnPropertyChanged(nameof(_selectedBrandItem));
            }
        }

        private string? _selectedMeasureItem;

        public string? SelectedMeasureItem
        {
            get
            {
                return _selectedMeasureItem;
            }
            set
            {
                _selectedMeasureItem = value;
                OnPropertyChanged(nameof(_selectedMeasureItem));
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
                if (_selectedProductItem != null)
                {
                    ProductId = _selectedProductItem.PCode.ToString();
                    ProductName = _selectedProductItem.PName;
                    Price = _selectedProductItem.Price.ToString();

                    string selectedMeasure = MeasuresHelper.Measures.Select(measure => measure).Where(measure => measure == _selectedProductItem.Measure).FirstOrDefault();
                    if (selectedMeasure != null)
                    {
                        SelectedMeasureItem = selectedMeasure;
                        OnPropertyChanged(nameof(SelectedMeasureItem));
                    }

                    Brand selectedBrand = Brands.Select(brand => brand).Where(brand => brand.BCode == _selectedProductItem.BCode).FirstOrDefault();
                    if (selectedBrand != null)
                    {
                        SelectedBrandItem = selectedBrand;
                        OnPropertyChanged(nameof(SelectedBrandItem));
                    }                    

                    OnPropertyChanged(nameof(Price));
                    OnPropertyChanged(nameof(ProductName));
                    OnPropertyChanged(nameof(ProductId));                    
                }
            }
        }

        private ObservableCollection<string> _measures;

        public ObservableCollection<string> Measures
        {
            get
            {
                return _measures;
            }
            set
            {
                _measures = value;
                OnPropertyChanged(nameof(_measures));
            }
        }

        private string? _productName;

        public string? ProductName
        {
            get
            {
                return _productName;
            }
            set
            {
                _productName = value;
                OnPropertyChanged(nameof(_productName));
            }
        }

        private string? _productId;
        public string? ProductId
        {
            get
            {
                return _productId;
            }
            set
            {
                _productId = value;
                OnPropertyChanged(nameof(_productId));
            }
        }

        private ObservableCollection<Brand> _brands;

        public ObservableCollection<Brand> Brands
        {
            get
            {
                return _brands;
            }
            set
            {
                _brands = value;
                OnPropertyChanged(nameof(_brands));
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

        public ProductsViewModel(Window window)
        {
            Products = new ObservableCollection<Product>(new Controller<Product>().Read());
            Measures = new ObservableCollection<string>(MeasuresHelper.Measures);            
            Brands = new ObservableCollection<Brand>(new Controller<Brand>().Read());       
            currentWindow = window;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ICommand CreateProductCommand => new Commands((obj) =>
        {
            if (!string.IsNullOrEmpty(_productName) && !string.IsNullOrEmpty(_productId) && !string.IsNullOrEmpty(_selectedMeasureItem) && _selectedBrandItem != null)
            {
                Product productToAdd = new Product()
                {
                    BCode = _selectedBrandItem.BCode,
                    BName = _selectedBrandItem.BName,
                    PCode = Convert.ToInt32(_productId),
                    PName = _productName,
                    Measure = _selectedMeasureItem,
                    Price = Convert.ToInt32(_price)
                };
                new Controller<Product>().Create(productToAdd);
                Products = new ObservableCollection<Product>(new Controller<Product>().Read());
                OnPropertyChanged(nameof(Products));
            }
        });

        public ICommand UpdateProductCommand => new Commands((obj) =>
        {
            if (_selectedProductItem != null)
            {
                Product updatedProduct = new Product()
                {
                    BCode = _selectedBrandItem.BCode,
                    BName = _selectedBrandItem.BName,
                    PCode = _selectedProductItem.PCode,
                    PName = _productName,
                    Measure = _selectedMeasureItem,
                    Price = Convert.ToInt32(_price)
                };
                new Controller<Product>().Update(_selectedProductItem.PCode, updatedProduct);
                Products = new ObservableCollection<Product>(new Controller<Product>().Read());
                OnPropertyChanged(nameof(Products));
            }
        });

        public ICommand RemoveProductCommand => new Commands((obj) =>
        {
            if (_selectedProductItem != null)
            {
                new Controller<Product>().Delete(_selectedProductItem);
                Products = new ObservableCollection<Product>(new Controller<Product>().Read());
                OnPropertyChanged(nameof(Products));
            }
        });

        public ICommand OpenBrandsViewCommand => new Commands((obj) =>
        {
            BrandsView brandsView = new BrandsView();
            brandsView.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            brandsView.Show();
            currentWindow.Close();
        });

        public ICommand OpenFactoriesViewCommand => new Commands((obj) =>
        {
            FactoriesView factoriesView = new FactoriesView();
            factoriesView.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            factoriesView.Show();
            currentWindow.Close();
        });

        public ICommand OpenOrdersViewCommand => new Commands((obj) =>
        {
            OrdersView ordersView = new OrdersView();
            ordersView.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            ordersView.Show();
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
