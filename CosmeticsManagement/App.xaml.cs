using System.Windows;

namespace CosmeticsManagement
{    
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            TestForBrand.Execute();
            TestForDelivery.Execute();
            TestForFactory.Execute();
            TestForOrder.Execute();
            TestForProduct.Execute();
        }
    }
}
