using CosmeticsManagement.Model.CRUD;
using CosmeticsManagement.Model.Entities;

namespace CosmeticsManagement
{
    public class TestForOrder
    {
        public static void Execute()
        {
            Controller<Order> controller = new Controller<Order>();

            var OrderList = controller.Read();

            Console.WriteLine("\nRead realisation:");
            foreach (var order in OrderList)
            {
                Console.WriteLine($"Entity data: {order.OCode}\t{order.PCode}\t{order.OrderDate}\t{order.ProductCountInOrder}\t{order.FCode}\t{order.ExecutionDate}");
            }

            Order orderToCreate = new Order()
            {
                OCode = 553,
                PCode = 334,
                FCode = 198,
                ExecutionDate = DateTime.Now,
                OrderDate = DateTime.Now,
                ProductCountInOrder = 53
            };

            controller.Create(orderToCreate);

            OrderList = controller.Read();

            Console.WriteLine("\nCreate realisation:");
            foreach (var order in OrderList)
            {
                Console.WriteLine($"Entity data: {order.OCode}\t{order.PCode}\t{order.OrderDate}\t{order.ProductCountInOrder}\t{order.FCode}\t{order.ExecutionDate}");
            }

            Order updatedOrder = new Order()
            {
                OCode = 553,
                PCode = 887,
                FCode = 999,
                ExecutionDate = DateTime.Now,
                OrderDate = DateTime.Now,
                ProductCountInOrder = 53
            };

            controller.Update(orderToCreate.PCode, updatedOrder);

            OrderList = controller.Read();

            Console.WriteLine("\nUpdate realisation:");
            foreach (var order in OrderList)
            {
                Console.WriteLine($"Entity data: {order.OCode}\t{order.PCode}\t{order.OrderDate}\t{order.ProductCountInOrder}\t{order.FCode}\t{order.ExecutionDate}");
            }

            controller.Delete(updatedOrder);

            OrderList = controller.Read();

            Console.WriteLine("\nDelete realisation:");
            foreach (var order in OrderList)
            {
                Console.WriteLine($"Entity data: {order.OCode}\t{order.PCode}\t{order.OrderDate}\t{order.ProductCountInOrder}\t{order.FCode}\t{order.ExecutionDate}");
            }
        }
    }
}
