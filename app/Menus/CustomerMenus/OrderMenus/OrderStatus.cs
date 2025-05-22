using System;

namespace Arriba_Eats
{
    class OrderStatusMenu
    { 
        public static void OrdersStatus(Customer customer)
        {
                // Getting all orders from the list
                var Allorders = Order_List.GetAllOrders();
                // Filtering the orders to only show the ones that belong to the customer
                Allorders = Allorders.Where(order => order.GetOwner.Email == customer.Email).OrderBy(order => order.Date).ToList();
                if (!Allorders.Any())
                {
                    Console.WriteLine("You have not placed any orders.");
                    return;
                }
                
                foreach (var order in Allorders)
                {

                    Console.WriteLine($"Order #{order.Number} from {order.FromRestaurant.Restaurant_Name}: {order.Status}");

                    if (order.Status == OrderStatus.Delivered)
                    {
                        Console.WriteLine($"This order was delivered by {order.Driver.Name} (licence plate: {order.Driver.LicencePlate})");
                    }

                    foreach (var item in order.items)
                    {
                        
                        // Displaying the items in the order
                         Console.WriteLine($"{item.Quantity} x {item.Item.Name}");
                    }


                }
        }       
    }
}