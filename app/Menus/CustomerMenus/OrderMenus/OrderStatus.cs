using System;

namespace Arriba_Eats
{
    /// <summary>
    /// Created for users to check the status of their orders.
    /// </summary>
    class OrderStatusMenu
    {
        public static void OrdersStatus(Customer customer)
        {
            try
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

                foreach (var order in Allorders) // Looping through the orders
                {

                    Console.WriteLine($"Order #{order.Number} from {order.FromRestaurant.Restaurant_Name}: {order.Status}");

                    if (order.Status == OrderStatus.Delivered) // If the order is delivered, show the driver information
                    {
                        Console.WriteLine($"This order was delivered by {order.Driver.Name} (licence plate: {order.Driver.LicencePlate})");
                    }

                    foreach (var item in order.items) // Looping through the items in the order to print them
                    {

                        // Displaying the items in the order
                        Console.WriteLine($"{item.Quantity} x {item.Item.Name}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving orders: {ex.Message}");
            }
        }
    }
}