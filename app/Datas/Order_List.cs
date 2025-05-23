using System;

namespace Arriba_Eats
{
    /// <summary>
    /// The Rating_List class provides static methods to register and retrieve ratings in the application.
    /// </summary>
    class Order_List
    {
        private static List<Order> orders = new List<Order>();

        // Only allowed way to add restaurants
        public static void Register(Order order)
        {
            if (order != null)
                orders.Add(order);
        }
        /// Method to retrieve all orders where with kind of "read only" status
        public static List<Order> GetAllOrders()
        {
            return new List<Order>(orders);
        }
        ///Method to retrieve all orders where we should be able to modify them
        public static List<Order> GetRealOrders()
        {
            return orders;
        }


    }

}