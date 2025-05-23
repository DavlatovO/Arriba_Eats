using System;
using System.Collections.Generic;

namespace Arriba_Eats
{
    /// <summary>
    /// Created for users to place orders from restaurants.
    /// </summary>
    class OrderingMenus
    {
        public static void OrderMenu2(Customer customer, Restaurant restaurant)
        {
            try
            {


                Console.WriteLine($"Placing order from {restaurant.Restaurant_Name}.");
                bool back = false; // Flag to control the loop
                while (!back)
                {
                    // Constants for menu options
                    const int MENU_INDEX = 1;
                    const int REVIEWS_INDEX = 2;
                    const int BACK_INDEX = 3;

                    Console.WriteLine();
                    Console.WriteLine("1: See this restaurant's menu and place an order");
                    Console.WriteLine("2: See reviews for this restaurant");
                    Console.WriteLine("3: Return to main menu");
                    Console.WriteLine("Please enter a choice between 1 and 3: ");

                    if (!int.TryParse(Console.ReadLine(), out int choice)) // Read the user input and do error checking
                    {
                        Console.WriteLine("Invalid input.");
                        continue;
                    }

                    switch (choice)
                    {
                        // Show the restaurant's menu and allow the customer to place an order
                        case MENU_INDEX:
                            try
                            {
                                List<(MenuItem item, int quantity)> tempOrderItems = new List<(MenuItem, int)>(); // Temporary list to hold items and quantities
                                                                                                                  // Initialize total price
                                double totalPrice = 0;

                                while (true) // Loop until the order is complete or canceled
                                {
                                    Console.WriteLine($"\nCurrent order total: ${totalPrice:F2}");

                                    // Display menu
                                    for (int i = 0; i < restaurant.Menu.Count; i++)
                                    {
                                        var item = restaurant.Menu[i];
                                        Console.WriteLine($"{i + 1}:   {item.Price,7:C2}  {item.Name}");
                                    }

                                    int completeIndex = restaurant.Menu.Count + 1;
                                    int cancelIndex = restaurant.Menu.Count + 2;

                                    Console.WriteLine($"{completeIndex}: Complete order");
                                    Console.WriteLine($"{cancelIndex}: Cancel order");
                                    Console.WriteLine($"Please enter a choice between 1 and {cancelIndex}:");

                                    if (!int.TryParse(Console.ReadLine(), out int selection) || selection < 1 || selection > cancelIndex)
                                    {
                                        Console.WriteLine("Invalid choice.");
                                        continue;
                                    }

                                    if (selection == completeIndex) // Complete order
                                    {
                                        if (tempOrderItems.Count == 0) // Check if any items were added
                                        {
                                            Console.WriteLine("You haven't added any items yet.");
                                            continue;
                                        }

                                        Order newOrder = new Order(customer, restaurant); // Create a new order
                                        foreach (var (item, qty) in tempOrderItems)
                                        {
                                            newOrder.AddItem(item, qty); // Use proper method
                                        }

                                        newOrder.SetOrderStatus(OrderStatus.Ordered); // Set order status to Ordered
                                        Order_List.Register(newOrder); // Register the order

                                        Console.WriteLine($"Your order has been placed. Your order number is #{newOrder.Number}.");

                                        break; // Exit to previous menu
                                    }
                                    else if (selection == cancelIndex)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        var selectedItem = restaurant.Menu[selection - 1];
                                        Console.WriteLine($"Adding {selectedItem.Name} to order.");

                                        while (true) // Loop until quantity is confirmed or canceled
                                        {
                                            Console.WriteLine("Please enter quantity (0 to cancel):");
                                            if (!int.TryParse(Console.ReadLine(), out int quantity) || quantity < 0)
                                            {
                                                Console.WriteLine("Invalid quantity.");
                                                continue;
                                            }

                                            if (quantity == 0)
                                            {
                                                break; // Back to item selection
                                            }

                                            // Check if item already exists in tempOrderItems
                                            int existingIndex = tempOrderItems.FindIndex(t => t.item.Name == selectedItem.Name);

                                            if (existingIndex != -1) // If item already exists new quantity should be added to the existing one
                                            {
                                                var (existingItem, existingQty) = tempOrderItems[existingIndex];
                                                tempOrderItems[existingIndex] = (existingItem, existingQty + quantity);
                                            }
                                            else
                                            {
                                                tempOrderItems.Add((selectedItem, quantity)); // Add new item and quantity
                                            }
                                            totalPrice += selectedItem.Price * quantity;
                                            Console.WriteLine($"Added {quantity} x {selectedItem.Name} to order.");
                                            break; // Return to menu
                                        }
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"An error occurred while placing the order: {ex.Message}");
                            }
                            break;
                        // Show reviews for the restaurant
                        case REVIEWS_INDEX:
                            try
                            {
                                var allRatings = Rating_List.GetRealRatings(); // Get all ratings
                                if (allRatings.Count == 0)
                                {
                                    Console.WriteLine("No reviews have been left for this restaurant.");
                                    break;
                                }
                                foreach (var rating in allRatings)
                                {
                                    Console.WriteLine($"Reviewer: {rating.Customer.Name}");
                                    // Convert double score to int (round down or cast)
                                    int scoreInt = (int)rating.Score;

                                    // Create stars string
                                    string stars = new string('*', scoreInt);
                                    Console.WriteLine($"Rating: {stars}");
                                    Console.WriteLine($"Comment: {rating.Comment}");
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"An error occurred while displaying reviews: {ex.Message}");
                            }
                            break;

                        case BACK_INDEX:
                            back = true; // Set back to true to exit the loop

                            break;
                        // Exit the method after returning to the customer menu

                        default:
                            Console.WriteLine("Invalid choice.");
                            break;
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
