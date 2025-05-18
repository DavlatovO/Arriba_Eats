using System;

namespace Arriba_Eats
{
    public static class DelivererMenus
    {
        public static void DelivererMenu(Deliverer deliverer)
        {
            while (true)
            {


                const int DISPLAY_INDEX = 1;
                const int ORDERS_INDEX = 2;
                const int ONTHESPOT_INDEX = 3;
                const int COMPLETE_INDEX = 4;
                const int LOGOUT_INDEX = 5;
                const int NUMBER_OPTIONS = 7;


                Console.WriteLine();
                Console.WriteLine($"1: Display your user information");
                Console.WriteLine($"2: List orders available to deliver");
                Console.WriteLine($"3: Arrived at restaurant to pick up order");
                Console.WriteLine($"4: Mark this delivery as complete");
                Console.WriteLine($"5: Log out");
                Console.WriteLine($"Please enter a choice between 1 and 5:");

                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid choice.");
                    continue;
                }
                if ((choice > 0) && (choice <= NUMBER_OPTIONS))
                {
                    switch (choice)
                    {
                        case DISPLAY_INDEX:
                            deliverer.Details();
                            break;
                        case ORDERS_INDEX:
                            if (deliverer.GetOrder != null)
                            {
                                Console.WriteLine("You have already selected an order for delivery.");
                                break;
                            }

                            Console.WriteLine("Please enter your location (in the form of X,Y):");
                            string input = Console.ReadLine().Trim('(', ')').Replace(" ", "");
                            string[] parts = input.Split(',');

                            if (parts.Length != 2 || !int.TryParse(parts[0], out int x) || !int.TryParse(parts[1], out int y))
                            {
                                Console.WriteLine("Invalid location.");
                                break;
                            }

                            deliverer.location = new Location(x, y);

                            var deliveryOrders = Order_Register.GetRealOrders()
                                .Where(order => (order.Status == OrderStatus.Cooking || order.Status == OrderStatus.Cooked) && order.Driver == null)
                                .ToList();

                            if (!deliveryOrders.Any())
                            {
                                Console.WriteLine("No available orders for delivery at this time.");
                                break;
                            }

                            Console.WriteLine("\nAvailable Orders:");
                            Console.WriteLine("   Order    Restaurant          Loc    Customer Name       Loc    Distance");
                            
                            for (int i = 0; i < deliveryOrders.Count; i++)
                            {
                                var order = deliveryOrders[i];
                                double distance = order.FromRestaurant.Restaurant_Location.DistanceTo(deliverer.location);

                                Console.WriteLine($"{i + 1,3} | {order.Number,-8} | {order.FromRestaurant.Restaurant_Name,-18} | " +
                                                $"({order.FromRestaurant.Restaurant_Location.X},{order.FromRestaurant.Restaurant_Location.Y}) | " +
                                                $"{order.GetOwner.Name,-16} | " +
                                                $"({order.GetOwner.location.X},{order.GetOwner.location.Y}) | {distance,7:F2}");
                            }

                            Console.WriteLine($"{deliveryOrders.Count + 1}: Return to the previous menu");
                            Console.Write($"Please enter a choice between 1 and {deliveryOrders.Count + 1}): ");

                            if (!int.TryParse(Console.ReadLine(), out int selection) || selection < 1 || selection > deliveryOrders.Count + 1)
                            {
                                Console.WriteLine("Invalid choice.");
                                break;
                            }

                            if (selection == deliveryOrders.Count + 1)
                            {
                                break;
                            }

                            var selectedOrder = deliveryOrders[selection - 1];
                            deliverer.GetOrder = selectedOrder;
                            selectedOrder.AssignDeliverer(deliverer);
                            deliverer.Status = DelivererStatus.HeadingToRestaurant;

                            Console.WriteLine($"\nThanks for accepting the order.");
                            Console.WriteLine($"Please head to {selectedOrder.FromRestaurant.Restaurant_Name} " +
                                            $"at ({selectedOrder.FromRestaurant.Restaurant_Location.X},{selectedOrder.FromRestaurant.Restaurant_Location.Y}) to pick it up.");
                            break;

                        case ONTHESPOT_INDEX:
                            if (deliverer.GetOrder == null)
                            {
                                Console.WriteLine("You have not yet accepted an order.");
                                break;
                            }

                            if (deliverer.GetOrder.Status == OrderStatus.BeingDelivered)
                            {
                                Console.WriteLine("You have already picked up this order.");
                                break;
                            }

                            if (deliverer.Status == DelivererStatus.AtRestaurant)
                            {
                                Console.WriteLine("You already indicated that you have arrived at this restaurant.");
                                break;
                            }

                            Console.WriteLine($"Thanks. We have informed {deliverer.GetOrder.FromRestaurant.Restaurant_Name} " +
                                            $"that you have arrived and are ready to pick up order {deliverer.GetOrder.Number}." +
                                            "\nPlease show the staff this screen as confirmation.");
                            deliverer.Status = DelivererStatus.AtRestaurant;

                            var orderStatus = deliverer.GetOrder.Status;
                            if (orderStatus == OrderStatus.Ordered || orderStatus == OrderStatus.Cooking)
                            {
                                Console.WriteLine("The order is still being prepared, so please wait patiently until it is ready.");
                            }
                                Console.WriteLine($"When you have the order, please deliver it to {deliverer.GetOrder.GetOwner.Name} at {deliverer.GetOrder.GetOwner.location.X},{deliverer.GetOrder.GetOwner.location.Y}.");
                            
                            if (orderStatus == OrderStatus.Cooked)
                            {
                                
                                deliverer.Status = DelivererStatus.OnTheWay;

                                Console.WriteLine($"You may now deliver the order to {deliverer.GetOrder.GetOwner.Name} at " +
                                                $"({deliverer.GetOrder.GetOwner.location.X},{deliverer.GetOrder.GetOwner.location.Y}).");
                            }

                            break;
                        case COMPLETE_INDEX:
                            if (deliverer.GetOrder == null)
                            {
                                Console.WriteLine("You have not yet accepted an order.");
                            }
                            else if (deliverer.Status == DelivererStatus.OnTheWay)
                            {
                                Console.WriteLine("Thank you for making the delivery.");
                                deliverer.GetOrder.SetOrderStatus(OrderStatus.Delivered);
                            }
                           else if (deliverer.Status == DelivererStatus.AtRestaurant)
                            {
                                Console.WriteLine("You have not yet picked up the order from the restaurant.");
                            }
                            else
                            {
                                Console.WriteLine("Order cannot be marked as complete in the current state.");
                            }
                            break;
                        case LOGOUT_INDEX:
                            deliverer.Logout();
                            break;
                        default:
                            Console.WriteLine();
                            break;
                    }
                }
            }
        }

    }
}