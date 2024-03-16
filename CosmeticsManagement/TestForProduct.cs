
using CosmeticsManagement.JetEFTest.CRUD;
using CosmeticsManagement.JetEFTest.Entities;

namespace CosmeticsManagement
{
    public class TestForProduct
    {
        public static void Execute()
        {
            Controller<Product> controller = new Controller<Product>();

            var ProductList = controller.Read();

            Console.WriteLine("\nRead realisation:");
            foreach (var product in ProductList)
            {
                Console.WriteLine($"Entity data: {product.PCode}\t{product.Price}\t{product.Measure}\t{product.PName}");
            }

            Product productToCreate = new Product()
            {
                PCode = 986,
                PName = "Some product",
                Measure = "Kilos",
                Price = 2000
            };

            controller.Create(productToCreate);

            ProductList = controller.Read();

            Console.WriteLine("\nCreate realisation:");
            foreach (var product in ProductList)
            {
                Console.WriteLine($"Entity data: {product.PCode}\t{product.Price}\t{product.Measure}\t{product.PName}");
            }

            Product updatedProduct = new Product()
            {
                PCode = 986,
                PName = "New product",
                Measure = "Tons",
                Price = 5000
            };

            controller.Update(productToCreate.PCode, updatedProduct);

            ProductList = controller.Read();

            Console.WriteLine("\nUpdate realisation:");
            foreach (var product in ProductList)
            {
                Console.WriteLine($"Entity data: {product.PCode}\t{product.Price}\t{product.Measure}\t{product.PName}");
            }

            controller.Delete(updatedProduct);

            ProductList = controller.Read();

            Console.WriteLine("\nDelete realisation:");
            foreach (var product in ProductList)
            {
                Console.WriteLine($"Entity data: {product.PCode}\t{product.Price}\t{product.Measure}\t{product.PName}");
            }
        }
    }
}
