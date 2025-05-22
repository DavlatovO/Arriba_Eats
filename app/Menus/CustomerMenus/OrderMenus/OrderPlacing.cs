using System;
using System.Collections.Generic;

namespace Arriba_Eats
{
    class OrderingMenus
    {
        public static void OrderMenu2(Customer customer, Restaurant restaurant)
        {
            Console.WriteLine($"Placing order from {restaurant.Restaurant_Name}.");
            bool back = false;
            while (!back)
            {
                const int MENU_INDEX = 1;
                const int REVIEWS_INDEX = 2;
                const int BACK_INDEX = 3;

                Console.WriteLine();
                Console.WriteLine("1: See this restaurant's menu and place an order");
                Console.WriteLine("2: See reviews for this restaurant");
                Console.WriteLine("3: Return to main menu");
                Console.WriteLine("Please enter a choice between 1 and 3: ");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Invalid input.");
                    continue;
                }

                switch (choice)
                {
                    case MENU_INDEX:
                        List<(MenuItem item, int quantity)> tempOrderItems = new List<(MenuItem, int)>();
                        double totalPrice = 0;

                        while (true)
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

                            if (selection == completeIndex)
                            {
                                if (tempOrderItems.Count == 0)
                                {
                                    Console.WriteLine("You haven't added any items yet.");
                                    continue;
                                }

                                Order newOrder = new Order(customer, restaurant);
                                foreach (var (item, qty) in tempOrderItems)
                                {
                                    newOrder.AddItem(item, qty); // Use proper method
                                }

                                newOrder.SetOrderStatus(OrderStatus.Ordered);
                                Order_List.Register(newOrder);

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

                                while (true)
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

                                    if (existingIndex != -1)
                                    {
                                        var (existingItem, existingQty) = tempOrderItems[existingIndex];
                                        tempOrderItems[existingIndex] = (existingItem, existingQty + quantity);
                                    }
                                    else
                                    {
                                        tempOrderItems.Add((selectedItem, quantity));
                                    }
                                    totalPrice += selectedItem.Price * quantity;
                                    Console.WriteLine($"Added {quantity} x {selectedItem.Name} to order.");
                                    break; // Return to menu
                                }
                            }
                        }
                        break;




                    case REVIEWS_INDEX:
                        var allRatings = Rating_List.GetRealRatings();
                        if (allRatings.Count == 0)
                        {
                            Console.WriteLine("No reviews have been left for this restaurant.");
                            break;
                        }
                        foreach (var rating in allRatings)
                        {
                            Console.WriteLine($"Reviewer: {rating.Customer}");
                            Console.WriteLine($"Rating: {rating.Score}");
                            Console.WriteLine($"Comment: {rating.Comment}");
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
    }
}
