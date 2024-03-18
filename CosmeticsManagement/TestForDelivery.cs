using CosmeticsManagement.Model.CRUD;
using CosmeticsManagement.Model.Entities;

namespace CosmeticsManagement
{
    public class TestForDelivery
    {
        static public void Execute()
        {
            // 1. Реализация Read (считывания) информации с база данных
            // Объявление и инициализация контроллера при помощи которого осуществляется CRUD (Create, Remove, Update, Delete) функций для работы с базой данной.
            Controller<Delivery> controller = new Controller<Delivery>();

            // Создаем объект List<Brand> DeliveryList и сразу считываем данные таблицы Доставка при помощи метода Controller.Read;
            var DeliveryList = controller.Read();

            // Вывод результата реализации
            Console.WriteLine("\nRead realisation:");
            foreach (var delivery in DeliveryList)
            {
                Console.WriteLine($"Entity data: {delivery.DCode}\t{delivery.OCode}\t{delivery.PCountInDelivery}\t{delivery.RealDeliveryDate}");
            }

            // 2. Реализация Create (создания) объекта Delivery и добавления его в таблицу
            // Объявление и инициализация объекта Delivery с проинициализированными свойствами
            Delivery deliveryToCreate = new Delivery() 
            { 
                DCode = 500, 
                OCode = 400, 
                PCountInDelivery = 123, 
                RealDeliveryDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)
            };

            // Вызываем метод Controller.Create для создания добавления объекта в базу данных.
            controller.Create(deliveryToCreate);

            // Снова реализуем Controller.Read() для созданного ранее списка DeliveryList, чтобы проверить, добавился ли объект
            DeliveryList = controller.Read();

            // Проверка реализации
            Console.WriteLine("\nCreate realisation:");
            foreach (var delivery in DeliveryList)
            {
                Console.WriteLine($"Entity data: {delivery.DCode}\t{delivery.OCode}\t{delivery.PCountInDelivery}\t{delivery.RealDeliveryDate}");
            }

            // 3. Реализация Update (изменения) объекта, который мы добавляли (deliveryToCreate) состоянием нового объекта (updatedDelivery)
            // Создаем новый объект updatedBrand и инициализируем его с другим значениями свойств
            Delivery updatedDelivery = new Delivery()
            {
                DCode = 500,
                OCode = 500,
                PCountInDelivery = 321,
                RealDeliveryDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)
            };

            // Вызывыаем метод Controller.Update для изменения состояния объекта deliveryToCreate в базе данных.
            // Объект для изменения ищется по его ID для замены!
            controller.Update(deliveryToCreate.DCode, updatedDelivery);

            // Снова реализуем controller.Read() для проверки обновленной информации в базе данных Access
            DeliveryList = controller.Read();

            Console.WriteLine("\nUpdate realisation:");
            foreach (var delivery in DeliveryList)
            {
                Console.WriteLine($"Entity data: {delivery.DCode}\t{delivery.OCode}\t{delivery.PCountInDelivery}\t{delivery.RealDeliveryDate}");
            }

            // 4. Реализация Delete (удаления) объекта, который мы добавили (updatedDelivery)
            // Вызов метода Controller.Delete
            controller.Delete(updatedDelivery);

            // Реализуем controller.Read() для проверки обновленной информации в базе данных Access
            DeliveryList = controller.Read();

            Console.WriteLine("\nDelete realisation:");
            foreach (var delivery in DeliveryList)
            {
                Console.WriteLine($"Entity data: {delivery.DCode}\t{delivery.OCode}\t{delivery.PCountInDelivery}\t{delivery.RealDeliveryDate}");
            }
        }
    }
}
