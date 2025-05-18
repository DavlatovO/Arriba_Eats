using System;

namespace Arriba_Eats
{

    class RateMenu
    {
        public static void Rate(Customer customer)
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine($"Select a previous order to rate the restaurant it came from:");

                // Step 1: Get all eligible orders for this customer
                var allOrders = Order_Register.GetAllOrders();
                var eligibleOrders = allOrders.Where(o => o.GetOwner == customer && o.Status == OrderStatus.Delivered && o.Ratings == null).ToList();

                if (eligibleOrders.Count == 0)
                {
                    return;
                }

                // Step 2: Show the list
                for (int i = 0; i < eligibleOrders.Count; i++)
                {
                    var order = eligibleOrders[i];
                    Console.WriteLine($"{i + 1}: Order #{order.Number} from {order.FromRestaurant.Restaurant_Name}:");
                }
                Console.WriteLine($"{eligibleOrders.Count + 1}: Return to previous menu");

                // Step 3: Get user choice
                Console.Write($"Please enter a choice (1 - {eligibleOrders.Count + 1}): ");
                if (!int.TryParse(Console.ReadLine(), out int selection) || selection < 1 || selection > eligibleOrders.Count + 1)
                {
                    Console.WriteLine("Invalid choice.");
                    continue;
                }

                // Step 4: Handle return option
                if (selection == eligibleOrders.Count + 1)
                {
                    return;
                }

                // Step 5: Get selected order
                var selectedOrder = eligibleOrders[selection - 1];
                Console.WriteLine($"You are rating order #{selectedOrder.Number} from {selectedOrder.FromRestaurant.Restaurant_Name}:");
                foreach (var items in selectedOrder.Items)
                {
                    Console.WriteLine($"{items.Quantity} x {items.Item.Name}");
                }
                // Step 6: Prompt for rating
                Console.Write("Please enter a rating for this restaurant (1-5, 0 to cancel): ");
                if (!int.TryParse(Console.ReadLine(), out int ratingValue) || ratingValue <= 0 || ratingValue > 5)
                {
                    Console.WriteLine("Invalid rating.");
                    continue;
                }
                Console.WriteLine("Please enter a comment to accompany this rating:");

                string comment = Console.ReadLine() ?? "";

                // Step 7: Create and attach rating
                var rating = new Rating(customer, ratingValue, comment, selectedOrder.FromRestaurant); // or prompt for comment too
                selectedOrder.Ratings = rating;

                Console.WriteLine($"Thank you for rating {selectedOrder.FromRestaurant.Restaurant_Name}.");
                Rating_List.Register(rating);
            }
        }

    }

    //    var rating = new Rating(customer, Ratings.Four);
    //restaurant.AddRating(rating);

    //Console.WriteLine($"Average rating: {restaurant.Restaurant_Rating:F1}");





}