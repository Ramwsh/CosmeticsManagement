using CosmeticsManagement.JetEFTest.CRUD;
using CosmeticsManagement.JetEFTest.Entities;

namespace CosmeticsManagement
{
    public class TestForBrand
    {
        public static void Execute()
        {
            // 1. Реализация Read (считывания) информации с база данных
            // Объявление и инициализация контроллера при помощи которого осуществляется CRUD (Create, Remove, Update, Delete) функций для работы с базой данной.
            Controller<Brand> controller = new Controller<Brand>();

            // Создаем объект List<Brand> BrandList и сразу считываем данные таблицы Brands при помощи метода Controller.Read;
            var BrandsList = controller.Read();

            // Вывод результата реализации
            Console.WriteLine("\nRead realisation:");
            foreach (var brand in BrandsList)
            {
                Console.WriteLine($"Entity data: {brand.BCode}\t{brand.BName}");
            }

            // 2. Реализация Create (создания) объекта Brand и добавления его в таблицу
            // Объявление и инициализация объекта Brand с проинициализированными полями BCode и BName
            Brand brandToCreate = new Brand() { BCode = 500, BName = "Test brand from JetEFTest application" };

            // Вызываем метод Controller.Create для создания добавления объекта в базу данных.
            controller.Create(brandToCreate);

            // Снова реализуем Controller.Read() для созданного ранее списка BrandList, чтобы проверить, добавился ли объект
            BrandsList = controller.Read();

            // Проверка реализации
            Console.WriteLine("\nCreate realisation:");
            foreach (var brand in BrandsList)
            {
                Console.WriteLine($"Entity data: {brand.BCode}\t{brand.BName}");
            }

            // 3. Реализация Update (изменения) объекта, который мы добавляли (brandToCreate) состоянием нового объекта (updatedBrand)
            // Создаем новый объект updatedBrand и инициализируем его с другим свойством поля BName
            Brand updatedBrand = new Brand() { BCode = 500, BName = "Test brand from JetEFTest application BUT WITHN NEW NAME" };

            // Вызывыаем метод Controller.Update для изменения состояния объекта brandToCreate в базе данных.
            // Объект для изменения ищется по его ID для замены!
            controller.Update(brandToCreate.BCode, updatedBrand);

            // Снова реализуем controller.Read() для проверки обновленной информации в базе данных Access
            BrandsList = controller.Read();

            Console.WriteLine("\nUpdate realisation:");
            foreach (var brand in BrandsList)
            {
                Console.WriteLine($"Entity data: {brand.BCode}\t{brand.BName}");
            }

            // 4. Реализация Delete (удаления) объекта, который мы добавили (updatedBrand)
            // Вызов метода Controller.Delete
            controller.Delete(updatedBrand);

            // Реализуем controller.Read() для проверки обновленной информации в базе данных Access
            BrandsList = controller.Read();

            Console.WriteLine("\nDelete realisation:");
            foreach (var brand in BrandsList)
            {
                Console.WriteLine($"Entity data: {brand.BCode}\t{brand.BName}");
            }
        }
    }
}
