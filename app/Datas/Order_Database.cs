using System;

namespace Arriba_Eats
{

    class Order_Register
    {
        private static List<Order> orders = new List<Order>();

        // Only allowed way to add restaurants
        public static void Register(Order order)
        {
            if (order != null)
                orders.Add(order);
        }

        public static List<Order> GetAllRestaurants()
        {
            return new List<Order>(orders);
        }
        public static List<Order> GetRealRestaurants()
        {
            return orders;
        }


    }



}