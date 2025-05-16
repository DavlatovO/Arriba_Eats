//using System;
//namespace Arriba_Eats
//{

//    class OrderingMenus
//    {
//        public static void OrderMenu2(Customer customer, Restaurant restaurant)
//        {

//            while (true)
//            {
//                const int MENU_INDEX = 1;
//                const int REVIEWS_INDEX = 2;
//                const int BACK_INDEX = 3;
//                const int NUMBER_OPTIONS = 3;

//                bool FIRST_TIME = false;

//                int OPTIONS = restaurant.Menu.Count;

//                Console.WriteLine();
//                Console.WriteLine($"Placing order from {restaurant.Restaurant_Name}");
//                Console.WriteLine($"1: See this restaurant's menu and place an order");
//                Console.WriteLine($"2: See reviews for this restaurant");
//                Console.WriteLine("3: Return to main menu");
//                Console.WriteLine($"Please enter a choice between 1 and {OPTIONS + 2}:");

//                int choice;
//                if (!int.TryParse(Console.ReadLine(), out choice))
//                {
//                    Console.WriteLine("Invalid choice.");
//                    continue;
//                }
//                if ((choice > 0) && (choice <= NUMBER_OPTIONS))
//                {
//                    switch (choice)
//                    {
//                        case MENU_INDEX:
//                            FIRST_TIME = true;
//                            Console.WriteLine($"Current order total: $TotalPrice");
//                            int i = 0;
//                            foreach (var menu in restaurant.Menu)
//                            {
//                                i++;
//                                Console.WriteLine($"{i}:   ${menu.Price}  {menu.Name}");
//                            }
//                            int COMPLETE_INDEX = i + 1;
//                            int CANCEL_INDEX = i + 2;
//                            Console.WriteLine($"{COMPLETE_INDEX}: Complete order");
//                            Console.WriteLine($"{CANCEL_INDEX}: Cancel order");

//                            if (!int.TryParse(Console.ReadLine(), out int choice2) || choice2 < 1 || choice2 > CANCEL_INDEX)
//                            {
//                                Console.WriteLine("Invalid choice.");
//                                continue;
//                            }

//                            if (choice2 == COMPLETE_INDEX)
//                            {
//                                if (FIRST_TIME)
//                                {
//                                    break;
//                                }
//                                //if (customer.CurrentOrder == null && )
//                                {
                                    
//                                }

//                            }




//                            if (choice2 == OPTIONS + 2)
//                            {
//                                List<Order> OrderList = Order_Register.GetRealRestaurants();
//                                foreach (var orders in OrderList)
//                                {
//                                    if (orders.GetOwner == customer)
//                                    {
//                                        OrderList.Remove(orders);
//                                    }
//                                    else
//                                    {
//                                        break;
//                                    }
//                                }
//                            }
//                            if (choice2 == OPTIONS + 1)
//                            {

//                            }


//                            break;
//                        case REVIEWS_INDEX:
//                            Console.WriteLine();
//                            break;
//                        case BACK_INDEX:
//                            return;
//                        default:
//                            Console.WriteLine("Invalid choice.");
//                            break;


//                    }
//                }
//            }
//        }



//        public static void Ordering(Customer customer, Restaurant restaurant)
//        {

//            while (true)
//            {
//                const int MENU_INDEX = 1;
//                const int NUMBER_OPTIONS = 3;

//                Console.WriteLine($"Placing order from {restaurant.Restaurant_Name}");


               
//            }
//        }

//    }





//}