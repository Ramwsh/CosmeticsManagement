using System.ComponentModel;
using CosmeticsManagement.Model.Entities;
using CosmeticsManagement.Model.CRUD;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.Windows;
using CosmeticsManagement.View;

namespace CosmeticsManagement.ViewModel
{
    public class BrandViewModel : INotifyPropertyChanged
    {
        private Window currentWindow;

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

        private string? _brandName;
        public string BrandName
        {
            get
            {
                return _brandName;
            }
            set
            {
                _brandName = value;
                OnPropertyChanged(_brandName);
            }
        }
        private string? _brandId;
        public string? BrandId
        {
            get
            {
                return _brandId;
            }
            set
            {
                _brandId = value;
                OnPropertyChanged(nameof(_brandId));
            }
        }

        private Brand selectedBrandItem;

        public Brand SelectedBrandItem
        {
            get
            {
                return selectedBrandItem;
            }
            set
            {                
                selectedBrandItem = value;
                OnPropertyChanged(nameof(selectedBrandItem));
                if (selectedBrandItem != null) 
                {
                    BrandName = selectedBrandItem.BName;                    
                    BrandId = selectedBrandItem.BCode.ToString();
                    OnPropertyChanged(nameof(BrandName));
                    OnPropertyChanged(nameof(BrandId));
                }                                
            }
        }

        public BrandViewModel(Window window)
        {            
            _brands = new ObservableCollection<Brand>(new Controller<Brand>().Read());
            currentWindow = window;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ICommand CreateCommand => new Commands((obj) =>
        {
            if (!string.IsNullOrEmpty(_brandId) && !string.IsNullOrEmpty(_brandName))
            {
                Brand brandToAdd = new Brand() { BCode = Convert.ToInt32(_brandId), BName = _brandName };
                new Controller<Brand>().Create(brandToAdd);
                Brands.Add(brandToAdd);
                Brands = new ObservableCollection<Brand>(new Controller<Brand>().Read());
            }
        });

        public ICommand DeleteCommand => new Commands((obj) =>
        {
            if (selectedBrandItem != null)
            {                
                new Controller<Brand>().Delete(selectedBrandItem);                                
                Brands = new ObservableCollection<Brand>(new Controller<Brand>().Read());
                OnPropertyChanged(nameof(Brands));                
            }
        });

        public ICommand UpdateCommand => new Commands((obj) =>
        {
            if (selectedBrandItem != null)
            {
                Brand updatedBrand = new Brand() {BCode = selectedBrandItem.BCode, BName = BrandName };
                new Controller<Brand>().Update(selectedBrandItem.BCode, updatedBrand);
                Brands = new ObservableCollection<Brand>(new Controller<Brand>().Read());
                OnPropertyChanged(nameof(Brands));
            }
        });

        public ICommand OpenProductsCommand => new Commands((obj) =>
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
