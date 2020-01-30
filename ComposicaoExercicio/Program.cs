using System;
using ComposicaoExercicio.Entities;
using ComposicaoExercicio.Entities.Enums;
using System.Globalization;

namespace ComposicaoExercicio
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter client data: ");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Email: ");
            string mail = Console.ReadLine();
            Console.Write("Birth date (DD/MM/YYYY): ");
            DateTime birthDate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("Enter order data: ");
            Console.Write("Status: ");
            OrderStatus status = Enum.Parse<OrderStatus>(Console.ReadLine());

            Client c1 = new Client(name, mail, birthDate);
            Order order = new Order(DateTime.Now, status, c1);

            Console.Write("How many items to this order? ");
            int items = int.Parse(Console.ReadLine());
            Console.WriteLine();            

            for (int i = 1; i <= items; i++)
            {
                Console.WriteLine($"Enter #{i} item data:");
                Console.Write("Product Name: ");
                string prodName = Console.ReadLine();
                Console.Write("Product Price: ");
                double prodPrice = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Quantity: ");
                int prodQntd = int.Parse(Console.ReadLine());
                Product prod = new Product(prodName, prodPrice);
                OrderItem orderItem = new OrderItem(prodQntd, prod.Price, prod);
                order.AddItem(orderItem);
            }

            Console.WriteLine();
            Console.WriteLine(order);
        }
    }
}
