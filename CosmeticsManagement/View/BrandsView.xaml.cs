using System.Windows;
using System.Windows.Input;
using CosmeticsManagement.ViewModel;

namespace CosmeticsManagement.View
{    
    public partial class BrandsView : Window
    {
        public BrandsView()
        {
            InitializeComponent();
            DataContext = new BrandViewModel();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
    }
}
