using System;

namespace Arriba_Eats
{
    /// <summary>
    /// Provides menu operations for deliverers to interact with the Arriba Eats system.
    /// </summary>
    public static class DelivererMenus
    {
        /// <summary>
        /// Displays the deliverer menu and handles all deliverer-related actions.
        /// </summary>
        /// <param name="deliverer">The currently logged-in deliverer.</param>
        public static void DelivererMenu(Deliverer deliverer)
        {
            // Keep the menu running until the user logs out.
            while (true)
            {
                // Menu options for the deliverer.
                const int DISPLAY_INDEX = 1;
                const int ORDERS_INDEX = 2;
                const int ONTHESPOT_INDEX = 3;
                const int COMPLETE_INDEX = 4;
                const int LOGOUT_INDEX = 5;
                const int NUMBER_OPTIONS = 7;

                // Display menu options
                Console.WriteLine("Please make a choice from the menu below:");
                Console.WriteLine($"1: Display your user information");
                Console.WriteLine($"2: List orders available to deliver");
                Console.WriteLine($"3: Arrived at restaurant to pick up order");
                Console.WriteLine($"4: Mark this delivery as complete");
                Console.WriteLine($"5: Log out");
                Console.WriteLine($"Please enter a choice between 1 and 5:");

                // Validate user input
                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid choice.");
                    continue;
                }
                if ((choice >= DISPLAY_INDEX) && (choice <= NUMBER_OPTIONS))
                {
                    switch (choice)
                    {
                        // Display the deliverer information.
                        case DISPLAY_INDEX:
                            Console.WriteLine(deliverer.Details());
                            break;
                        // List the orders available to deliver.
                        case ORDERS_INDEX:
                            try
                            {
                                // Check if deliverer already has an order
                                if (deliverer.CurrentOrder != null)
                                {
                                    Console.WriteLine("You have already selected an order for delivery.");
                                    break; //returns the user to the main menu
                                }
                                // Get the deliverer's current location.
                                Console.WriteLine("Please enter your location (in the form of X,Y):");
                                string input = Console.ReadLine().Trim('(', ')').Replace(" ", "");
                                string[] parts = input.Split(',');

                                if (parts.Length != 2 ||
                                    !int.TryParse(parts[0], out int x) ||
                                    !int.TryParse(parts[1], out int y))
                                {
                                    Console.WriteLine("Invalid location.");
                                    return;
                                }
                                // Create a new location object with the provided coordinates.
                                Location location = new Location(x, y);
                                // Get the list of available orders for delivery.
                                var deliveryOrders = Order_List.GetRealOrders().Where(order => (order.Status == OrderStatus.Ordered || order.Status == OrderStatus.Cooking || order.Status == OrderStatus.Cooked) && order.Driver == null).ToList();
                                // Check if there are any available orders for delivery.
                                if (!deliveryOrders.Any())
                                {
                                    Console.WriteLine("No available orders for delivery at this time.");
                                    break;
                                }

                                Console.WriteLine("The following orders are available for delivery. Select an order to accept it:");
                                Console.WriteLine("   Order  Restaurant Name       Loc    Customer Name    Loc    Dist");

                                // Display the available orders for delivery.
                                for (int i = 0; i < deliveryOrders.Count; i++)
                                {
                                    var order = deliveryOrders[i];
                                    double distanceToRestaurant = order.FromRestaurant.Restaurant_Location.DistanceTo(location);
                                    double distanceToCustomer = order.FromRestaurant.Restaurant_Location.DistanceTo(order.GetOwner.Location);
                                    double distance = distanceToCustomer + distanceToRestaurant;
                                    Console.WriteLine($"{i + 1,3}:  {order.Number,-8}  {order.FromRestaurant.Restaurant_Name,-18}  " +
                                                    $"{order.FromRestaurant.Restaurant_Location.X},{order.FromRestaurant.Restaurant_Location.Y}  " +
                                                    $"{order.GetOwner.Name,-16}  " +
                                                    $"{order.GetOwner.Location.X},{order.GetOwner.Location.Y}  {distance,7}");
                                }

                                Console.WriteLine($"{deliveryOrders.Count + 1}: Return to the previous menu");
                                Console.WriteLine($"Please enter a choice between 1 and {deliveryOrders.Count + 1}: ");

                                // Validate user input for order selection.
                                if (!int.TryParse(Console.ReadLine(), out int selection) || selection < 1 || selection > deliveryOrders.Count + 1)
                                {
                                    Console.WriteLine("Invalid choice.");
                                    break;
                                }

                                if (selection == deliveryOrders.Count + 1)
                                {
                                    break;
                                }
                                // Assign the selected order to the deliverer and change the status.
                                var selectedOrder = deliveryOrders[selection - 1];
                                deliverer.CurrentOrder = selectedOrder;
                                selectedOrder.AssignDeliverer(deliverer);

                                Console.WriteLine($"Thanks for accepting the order. Please head to {selectedOrder.FromRestaurant.Restaurant_Name} at {selectedOrder.FromRestaurant.Restaurant_Location.X},{selectedOrder.FromRestaurant.Restaurant_Location.Y} to pick it up.");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"An error occurred: {ex.Message}");
                            }
                            break;

                        // Mark the deliverer as arrived at the restaurant to pick up the order.
                        case ONTHESPOT_INDEX:
                            try
                            {
                                // Check if deliverer has accepted an order
                                if (deliverer.CurrentOrder == null)
                                {
                                    Console.WriteLine("You have not yet accepted an order.");
                                    break; //returns the user to the main menu
                                }

                                // Check if the deliverer has already picked up the order or is already at the restaurant.
                                if (deliverer.CurrentOrder.Status == OrderStatus.BeingDelivered)
                                {
                                    Console.WriteLine("You have already picked up this order.");
                                    break;
                                }

                                // Check if the deliverer is already at the restaurant.
                                if (deliverer.Status == DelivererStatus.AtRestaurant)
                                {
                                    Console.WriteLine("You already indicated that you have arrived at this restaurant.");
                                    break;
                                }

                                Console.WriteLine($"Thanks. We have informed {deliverer.CurrentOrder.FromRestaurant.Restaurant_Name} " +
                                                $"that you have arrived and are ready to pick up order #{deliverer.CurrentOrder.Number}." +
                                                "\nPlease show the staff this screen as confirmation.");
                                deliverer.Status = DelivererStatus.AtRestaurant;

                                var orderStatus = deliverer.CurrentOrder.Status;
                                if (orderStatus == OrderStatus.Ordered || orderStatus == OrderStatus.Cooking)
                                {
                                    Console.WriteLine("The order is still being prepared, so please wait patiently until it is ready.");
                                }
                                Console.WriteLine($"When you have the order, please deliver it to {deliverer.CurrentOrder.GetOwner.Name} at {deliverer.CurrentOrder.GetOwner.Location.X},{deliverer.CurrentOrder.GetOwner.Location.Y}.");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"An error occurred: {ex.Message}");
                            }
                            break;

                        // Mark the order as complete and update the deliverer's status.
                        case COMPLETE_INDEX:
                            try
                            {
                                // Check whether the deliverer has any order to complete.
                                if (deliverer.CurrentOrder == null)
                                {
                                    Console.WriteLine("You have not yet accepted an order.");
                                    break;
                                }
                                else if (deliverer.Status != DelivererStatus.HeadingToCustomer)
                                {
                                    Console.WriteLine("You have not yet picked up the order.");
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine($"Thank you for making the delivery.");
                                    deliverer.CurrentOrder.SetOrderStatus(OrderStatus.Delivered);
                                    deliverer.CurrentOrder = null;
                                    deliverer.Status = DelivererStatus.Free;
                                }
                            }
                            catch (Exception ex)
                            { 
                                Console.WriteLine($"An error occurred: {ex.Message}");
                            }
                            break;

                        // Log out the deliverer and return to the main menu.
                        case LOGOUT_INDEX:
                            deliverer.Logout();
                            return;
                        default:
                            Console.WriteLine();
                            break;
                    }
                }
            }
        }
    }
}