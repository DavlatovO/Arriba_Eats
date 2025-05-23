using System;

namespace Arriba_Eats
{
    class RateMenu
    {
        public static void Rate(Customer customer)
        {
            while (true)
            {
                Console.WriteLine($"Select a previous order to rate the restaurant it came from:");

                // Step 1: Get all eligible orders for this customer (delivered and not yet rated)
                List<Order> allOrders;
                try
                {
                    allOrders = Order_List.GetAllOrders();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error retrieving orders: {ex.Message}");
                    return;
                }

                List<Order> eligibleOrders;
                try
                {
                    eligibleOrders = allOrders
                        .Where(o => o.GetOwner == customer && o.Status == OrderStatus.Delivered && o.Ratings == null)
                        .ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error filtering orders: {ex.Message}");
                    return;
                }

                // Step 2: Show the list of eligible orders
                for (int i = 0; i < eligibleOrders.Count; i++)
                {
                    var order = eligibleOrders[i];
                    Console.WriteLine($"{i + 1}: Order #{order.Number} from {order.FromRestaurant.Restaurant_Name}");
                }
                Console.WriteLine($"{eligibleOrders.Count + 1}: Return to the previous menu");

                // Step 3: Get user input for order selection
                Console.WriteLine($"Please enter a choice between 1 and {eligibleOrders.Count + 1}:");
                if (!int.TryParse(Console.ReadLine(), out int selection) || selection < 1 || selection > eligibleOrders.Count + 1)
                {
                    Console.WriteLine("Invalid choice.");
                    continue;
                }

                // Step 4: Handle return to previous menu
                if (selection == eligibleOrders.Count + 1)
                {
                    return;
                }

                // Step 5: Show order details for confirmation
                Order selectedOrder;
                try
                {
                    selectedOrder = eligibleOrders[selection - 1];
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error retrieving selected order: {ex.Message}");
                    continue;
                }

                Console.WriteLine($"You are rating order #{selectedOrder.Number} from {selectedOrder.FromRestaurant.Restaurant_Name}:");
                foreach (var items in selectedOrder.items)
                {
                    Console.WriteLine($"{items.Quantity} x {items.Item.Name}");
                }

                // Step 6: Prompt for rating (1-5) or cancel (0)
                Console.WriteLine("Please enter a rating for this restaurant (1-5, 0 to cancel): ");
                if (!int.TryParse(Console.ReadLine(), out int ratingValue) || ratingValue < 0 || ratingValue > 5)
                {
                    Console.WriteLine("Invalid rating.");
                    continue;
                }
                if (ratingValue == 0)
                {
                    return;
                }

                // Step 7: Prompt for optional comment
                Console.WriteLine("Please enter a comment to accompany this rating:");
                string comment = Console.ReadLine() ?? "";

                // Step 8: Create and attach the rating to the order
                try
                {
                    var rating = new Rating(customer, ratingValue, comment, selectedOrder.FromRestaurant);
                    selectedOrder.Ratings = rating;
                    Rating_List.Register(rating);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error saving rating: {ex.Message}");
                    continue;
                }

                Console.WriteLine($"Thank you for rating {selectedOrder.FromRestaurant.Restaurant_Name}.");
                return;
            }
        }
    }
}
