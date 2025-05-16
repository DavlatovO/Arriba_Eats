using System;

namespace Arriba_Eats
{

    class OrderStatusMenu
    { 
        public static void OrderStatus(Customer customer)
        {
                var Allorders = Order_Register.GetAllOrders();
                int i = 0;
                foreach(var order in Allorders)
                {
                    i++;
                    if (order.GetOwner != customer)
                    {
                        Console.WriteLine("You have not placed any orders.");
                        return;
                    }
                    if (order.GetOwner == customer)
                    {
                        Console.WriteLine($"{i}: Order #{order.Number} from {order.FromRestaurant}: {order.Status}");
                        Console.WriteLine();
                        if (order.Status == Arriba_Eats.OrderStatus.Delivered)
                        {
                            Console.WriteLine($"This order was delivered by {order.Driver.Name} (licence plate: {order.Driver.Licence_plate})");
                            foreach (var items in order.Items)
                            {
                                Console.WriteLine($"{items.Quantity} x {items.Item}");
                            }
                        }
                    }
                }   
        }
    }
}