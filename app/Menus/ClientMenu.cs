using System;

namespace Arriba_Eats
{
    public static class ClientMenus
    {
    public static void ClientMenu(Client client)
    {
        Restaurant restaurant = client.GetRestaurant;
        while (true)
        {
        

            const int DISPLAY_INDEX = 1;
            const int ADDITEM_INDEX = 2;
            const int CURRENTORDER_INDEX = 3;
            const int STARTCOOKING_INDEX = 4;
            const int FINISHCOOKING_INDEX = 5;
            const int HANDLEDELIVERERS_INDEX = 6;
            const int LOGOUT_INDEX = 7;
            const int NUMBER_OPTIONS = 7;


            Console.WriteLine();
            Console.WriteLine($"1: Display your user information");
            Console.WriteLine($"2: Add items to restaurant menu");
            Console.WriteLine($"3: See current orders");
            Console.WriteLine($"4: Start cooking order");
            Console.WriteLine($"5: Finish cooking order");
            Console.WriteLine($"6: Handle deliverers who have arrived");
            Console.WriteLine($"7: Log out");
            Console.WriteLine($"Please enter a choice between 1 and 7:");

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
                            Console.WriteLine(client.Details());
                            break;
                        case ADDITEM_INDEX:
                            Console.WriteLine($"This is your restaurant's current menu:");
                            foreach (var items in restaurant.Menu)
                            {
                                Console.WriteLine($"${items.Price}   {items.Name}");
                            }
                            Console.WriteLine("Please enter the name of the new item (blank to cancel):");
                            string item = Console.ReadLine();
                            Console.WriteLine("Please enter the price of the new item (without the $):");
                            double price1 = Double.Parse(Console.ReadLine());
                            MenuItem item1 = new MenuItem(item, price1);
                            if (item1 != null)
                            {
                                Console.WriteLine($"Successfully added {item1.Name} ({item1.Price}) to menu.");
                                restaurant.Menu.Add(item1);
                            }
                            break;
                        case CURRENTORDER_INDEX:
                            var Allorders = Order_List.GetRealOrders();
                            Allorders = Allorders.Where(order => order.FromRestaurant.Owner == client && order.Status == OrderStatus.Ordered).ToList();
                            if (Allorders.Count != 0)
                            {
                                foreach (var order in Allorders)
                                {

                                    Console.WriteLine($"Order #{order.Number} for {order.GetOwner.Name}: {order.Status}");
                                    foreach (var items in order.Items)
                                    {
                                        Console.WriteLine($"{items.Quantity} x {items.Item.Name}");
                                    }
                                    Console.WriteLine();
                                }
                            }
                            else
                            {
                                Console.WriteLine("Your restaurant has no current orders.");
                            }
                            
                            break;
                        case STARTCOOKING_INDEX:
                            var allorders = Order_List.GetAllOrders();
                            allorders = allorders.Where(order => order.FromRestaurant.Owner == client && order.Status == OrderStatus.Ordered).ToList();
                            if (allorders.Count > 0)
                            {
                                Console.WriteLine($"Select an order once you are ready to start cooking:");
                                int i = 0;
                                foreach (var order in allorders)
                                {
                                    i++;
                                    Console.WriteLine($"#{order.Number} for {order.GetOwner.Name}: {order.Status}");
                                    Console.WriteLine();
                                }
                                Console.WriteLine($"{i + 1}: Return to the previous menu");
                                Console.WriteLine($"Please enter a choice between 1 and {i + 1}:");
                                int input;
                                if (int.TryParse(Console.ReadLine(), out input))
                                {
                                    if (input >= 1 && input <= allorders.Count)
                                    {
                                        var selectedOrder = allorders[input - 1];
                                        selectedOrder.SetOrderStatus(OrderStatus.Cooking);
                                        Console.WriteLine($"Order #{selectedOrder.Number} is now marked as cooking.Please prepare the order, then mark it as finished cooking:");
                                        foreach (var items in selectedOrder.Items)
                                        {
                                            Console.WriteLine($"{items.Quantity} x {items.Item.Name}");
                                        }
                                    }
                                    else if (input == allorders.Count + 1)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid choice.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Invalid input.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Your restaurant has no current orders.");
                            }

                            break;
                        case FINISHCOOKING_INDEX:
                            var AllOrders = Order_List.GetAllOrders();
                            AllOrders = AllOrders.Where(order => order.FromRestaurant.Owner == client && order.Status == OrderStatus.Cooking).ToList();
                            if (AllOrders.Count > 0)
                            {
                                Console.WriteLine("Select an order once you have finished preparing it:");
                                int i = 0;
                                foreach (var order in AllOrders)
                                {
                                    i++;
                                    Console.WriteLine($"{i}: Order #{order.Number} for {order.GetOwner.Name}");
                                }
                                Console.WriteLine($"{i + 1}: Return to the previous menu");
                                Console.WriteLine($"Please enter a choice between 1 and {i + 1}:");

                                int input2;
                                if (int.TryParse(Console.ReadLine(), out input2))
                                {
                                    if (input2 >= 1 && input2 <= AllOrders.Count)
                                    {
                                        var selectedOrder = AllOrders[input2 - 1];
                                        selectedOrder.SetOrderStatus(OrderStatus.Cooked);
                                        Console.WriteLine($"Order #{selectedOrder.Number} is now ready for collection.");
                                        if (selectedOrder.Driver == null)
                                        {
                                            Console.WriteLine($"No deliverer has been assigned yet.");
                                        }
                                        else if (selectedOrder.Driver.Status == DelivererStatus.AtRestaurant)
                                        {
                                            Console.WriteLine($"Please take it to the deliverer with licence plate {selectedOrder.Driver.Licence_plate}, who is waiting to collect it.");
                                        }
                                        else
                                        {
                                            Console.WriteLine($"The deliverer with licence plate {selectedOrder.Driver.Licence_plate} will be arriving soon to collect it.");
                                        }
                                    }
                                    else if (input2 == AllOrders.Count + 1)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid choice.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Invalid choice.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Your restaurant has no current orders.");
                            }

                            break;
                        case HANDLEDELIVERERS_INDEX:
                            var orders = Order_List.GetAllOrders();
                            orders = orders.Where(order => order.FromRestaurant.Owner == client &&
                                                    (order.Status == OrderStatus.Cooked ||
                                                    order.Status == OrderStatus.Cooking) &&
                                                    order.Driver != null &&
                                                    order.Driver.Status == DelivererStatus.AtRestaurant).ToList();
                            Console.WriteLine("These deliverers have arrived and are waiting to collect orders.");
                            Console.WriteLine("Select an order to indicate that the deliverer has collected it:");
                            int c = 0;
                            foreach (var order in orders)
                            {
                                c++;
                                Console.WriteLine($"{c}: Order #{order.Number} for {order.GetOwner.Name} (Deliverer licence plate: {order.Driver.Name}) (Order status: {order.Status})");
                            }
                            Console.WriteLine($"{c + 1}: Return to the previous menu");
                            Console.WriteLine($"Please enter a choice between 1 and {c + 1}:");
                            int input3;
                            if (int.TryParse(Console.ReadLine(), out input3))
                            {
                                if (input3 >= 1 && input3 <= orders.Count)
                                {
                                    var SelectedOrder = orders[input3 - 1];
                                    if (SelectedOrder.Status != OrderStatus.Cooked)
                                    {
                                        Console.WriteLine("This order has not yet been cooked.");
                                    }
                                    else
                                    {
                                        SelectedOrder.SetOrderStatus(OrderStatus.BeingDelivered);
                                        Console.WriteLine($"Order {SelectedOrder.Number} is now marked as being delivered.");
                                    }

                                }
                                else if (input3 == orders.Count + 1)
                                {
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Invalid choice.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid input.");
                            }


                            break;
                        case LOGOUT_INDEX:
                            client.Logout();
                            return;
                        default:
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid choice.");
                }
            }
    }

    }
    

}