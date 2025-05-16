using System;

namespace Arriba_Eats
{

    class RateMenu
    {
        public static void Rate(Customer customer)
        {

            while (true)
            {
                const int LASTORDER_INDEX = 1;
                const int BACK_INDEX = 2;
                const int NUMBER_OPTIONS = 2;

                var Allorders = Order_Register.GetAllOrders();


                Console.WriteLine();
                Console.WriteLine($"Select a previous order to rate the restaurant it came from:");

                foreach (var order in Allorders)
                {
                    if (order.GetOwner != customer)
                    {
                        Console.WriteLine();
                        return;
                    }
                    if (order.GetOwner == customer && order.Status == OrderStatus.Delivered && order.)
                    {
                        Console.WriteLine($": Order #{order.Number} from {order.FromRestaurant}: {order.Status}");
                        Console.WriteLine();
                        if (order.Status == Arriba_Eats.OrderStatus.Delivered)
                        {
                            Console.WriteLine($"This order was delivered by {order.Driver.Name} (licence plate: {order.Driver.Licence_plate})");
                            foreach (var items in order.Items)
                            {
                                Console.WriteLine($"{items.Quantity} x {items.Item}");
                            }
                        }
                    }
                }

                    Console.WriteLine($"1: Order #ORDER_NO from RESTAURANT_NAME");
                Console.WriteLine($"2: Return to the previous menu");
                Console.WriteLine($"Please enter a choice between 1 and 2:");

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
                        case LASTORDER_INDEX:
                           
                            break;
                     
                        default:
                            Console.WriteLine("Invalid choice.");
                            break;


                    }
                }
            }
        }
    }

//    var rating = new Rating(customer, Ratings.Four);
//restaurant.AddRating(rating);

//Console.WriteLine($"Average rating: {restaurant.Restaurant_Rating:F1}");





}