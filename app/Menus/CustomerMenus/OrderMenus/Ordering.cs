using System;
using System.Collections.Generic;

namespace Arriba_Eats
{
    class OrderingMenus
    {
        public static void OrderMenu2(Customer customer, Restaurant restaurant)
        {
            while (true)
            {
                const int MENU_INDEX = 1;
                const int REVIEWS_INDEX = 2;
                const int BACK_INDEX = 3;

                Console.WriteLine();
                Console.WriteLine($"Placing order from {restaurant.Restaurant_Name}");
                Console.WriteLine("1: See this restaurant's menu and place an order");
                Console.WriteLine("2: See reviews for this restaurant");
                Console.WriteLine("3: Return to main menu");
                Console.Write("Please enter a choice: ");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Invalid input.");
                    continue;
                }

                switch (choice)
                {
                    case MENU_INDEX:
                        List<OrderItem> orderItems = new List<OrderItem>();
                        decimal totalPrice = 0;
                        while (true)
                        {
                            Console.WriteLine($"Current order total: ${totalPrice}");
                            for (int i = 0; i < restaurant.Menu.Count; i++)
                            {
                                var item = restaurant.Menu[i];
                                Console.WriteLine($"{i + 1}: {item.Name}  ${item.Price}");
                            }

                            int completeIndex = restaurant.Menu.Count + 1;
                            int cancelIndex = restaurant.Menu.Count + 2;

                            Console.WriteLine($"{completeIndex}: Complete Order");
                            Console.WriteLine($"{cancelIndex}: Cancel Order");
                            Console.Write("Choose an item number (or complete/cancel): ");

                            if (!int.TryParse(Console.ReadLine(), out int selection) || selection < 1 || selection > cancelIndex)
                            {
                                Console.WriteLine("Invalid choice.");
                                continue;
                            }

                            if (selection == completeIndex)
                            {
                                if (orderItems.Count == 0)
                                {
                                    Console.WriteLine("Cannot complete an empty order.");
                                    continue;
                                }
                                else
                                {
                                    Order newOrder = new Order(customer, restaurant, orderItems);
                                    Console.WriteLine($"Your order has been placed. Your order number is {newOrder.Number}");
                                    newOrder.SetOrderStatus(OrderStatus.Ordered);
                                    Order_List.Register(newOrder);
                                    orderItems.Clear(); 
                                    totalPrice = 0;
                                }
                            }
                            else if (selection == cancelIndex)
                            {
                                Console.WriteLine("Order cancelled.");
                                orderItems.Clear();
                                return;
                            }
                            else
                            {
                                var selectedItem = restaurant.Menu[selection - 1];
                                Console.Write($"Please enter quantity (0 to cancel): ");
                                if (!int.TryParse(Console.ReadLine(), out int quantity) || quantity < 0)
                                {
                                    Console.WriteLine("Invalid quantity.");
                                    continue;
                                }
                                if (quantity == 0)
                                {
                                    return;
                                }


                                orderItems.Add(new OrderItem(selectedItem, quantity));
                                totalPrice += (decimal)selectedItem.Price * quantity;
                                Console.WriteLine($"Added {quantity} x {selectedItem.Name} to order.");
                            }
                        }
                    case REVIEWS_INDEX:
                        var allRatings = Rating_List.GetRealRatings();
                        if (allRatings.Count == 0)
                        {
                            Console.WriteLine("No reviews have been left for this restaurant.");
                            break;
                        }
                        foreach(var rating in allRatings)
                        {
                            Console.WriteLine($"Reviewer: {rating.Customer}");
                            Console.WriteLine($"Rating: {rating.Score}");
                            Console.WriteLine($"Comment: {rating.Comment}");
                        }
                        break;

                    case BACK_INDEX:
                        return;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }
    }
}
