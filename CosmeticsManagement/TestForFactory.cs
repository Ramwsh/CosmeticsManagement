using CosmeticsManagement.JetEFTest.CRUD;
using CosmeticsManagement.JetEFTest.Entities;

namespace CosmeticsManagement
{
    public class TestForFactory
    {
        public static void Execute()
        {            
            Controller<Factory> controller = new Controller<Factory>();
            
            var FactoryList = controller.Read();
            
            Console.WriteLine("\nRead realisation:");
            foreach (var factory in FactoryList)
            {
                Console.WriteLine($"Entity data: {factory.FCode}\t{factory.FName}\t{factory.Address}\t{factory.Phone}");
            }
            
            Factory factoryToCreate = new Factory()
            {
                FCode = 500,
                FName = "Factory Created from programm",
                Address = "Some address",
                Phone = "1234567890"
            };
            
            controller.Create(factoryToCreate);

            FactoryList = controller.Read();
            
            Console.WriteLine("\nCreate realisation:");
            foreach (var factory in FactoryList)
            {
                Console.WriteLine($"Entity data: {factory.FCode}\t{factory.FName}\t{factory.Address}\t{factory.Phone}");
            }

            Factory updatedFactory = new Factory()
            {
                FCode = 500,
                FName = "New factory Name",
                Address = "New address",
                Phone = "0987654321"
            };
            
            controller.Update(factoryToCreate.FCode, updatedFactory);

            FactoryList = controller.Read();

            Console.WriteLine("\nUpdate realisation:");
            foreach (var factory in FactoryList)
            {
                Console.WriteLine($"Entity data: {factory.FCode}\t{factory.FName}\t{factory.Address}\t{factory.Phone}");
            }

            controller.Delete(updatedFactory);

            FactoryList = controller.Read();

            Console.WriteLine("\nDelete realisation:");
            foreach (var factory in FactoryList)
            {
                Console.WriteLine($"Entity data: {factory.FCode}\t{factory.FName}\t{factory.Address}\t{factory.Phone}");
            }
        }
    }
}
