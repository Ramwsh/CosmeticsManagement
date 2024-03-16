using System.Windows;

namespace CosmeticsManagement
{    
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            // Тесты работы БД с каждой сущностью рассматриваемого контекста - Косметическая продукция

            // Тест для таблицы Бренд

            Console.WriteLine("Бренды");
            TestForBrand.Execute();

            // Тест для таблицы Доставки

            Console.WriteLine("Доставки");
            TestForDelivery.Execute();

            // Тест для таблицы Предприятие

            Console.WriteLine("Предприятия");
            TestForFactory.Execute();

            // Тест для таблицы Товары

            Console.WriteLine("Товары");
            TestForProduct.Execute();

            // Тест для таблицы Заказы
            Console.WriteLine("Заказы");
            TestForOrder.Execute();
        }
    }
}
