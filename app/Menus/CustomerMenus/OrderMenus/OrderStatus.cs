using System;

namespace Arriba_Eats
{
    class OrderStatusMenu
    { 
        public static void OrderStatus(Customer customer)
        {
                // Getting all orders from the list
                var Allorders = Order_List.GetAllOrders();
                // Filtering the orders to only show the ones that belong to the customer
                Allorders = Allorders.Where(order => order.GetOwner == customer).OrderBy(order => order.Date).ToList();
                if (Allorders.Count == 0)
                {
                    Console.WriteLine("You have not placed any orders.");
                    return;
                }
                int i = 0;
            foreach (var order in Allorders)
            {
                i++;
                if (order.Status == Arriba_Eats.OrderStatus.Delivered)
                {
                    Console.WriteLine($"This order was delivered by {order.Driver.Name} (licence plate: {order.Driver.Licence_plate})");
                    foreach (var items in order.Items)
                    {
                        Console.WriteLine($"{items.Quantity} x {items.Item.Name}");
                    }
                }

                // Displaying the order number, restaurant name, and status
                Console.WriteLine($"Order #{order.Number} from {order.FromRestaurant.Restaurant_Name}: {order.Status}");
                foreach (var items in order.Items)
                {
                    Console.WriteLine($"{items.Quantity} x {items.Item.Name}");
                }
            }   
        }       
    }
}