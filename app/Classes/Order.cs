using System;

namespace Arriba_Eats
{
    /// <summary>
    /// Represents the various statuses an order can be in.
    /// </summary>
    public enum OrderStatus
    {
        Ordered,
        Cooking,
        Cooked,
        BeingDelivered,
        Delivered
    }

    /// <summary>
    /// Represents a food order placed by a customer from a restaurant.
    /// </summary>
    class Order
    {
        private static int nextOrderNumber = 1; // Static counter to generate unique order numbers.

        private Customer orderedOwner;
        private Restaurant fromRestaurant;
        private Deliverer assignedDriver;
        private List<OrderItem> Items { get; set; } = new List<OrderItem>();
        private OrderStatus status;
        private int number;
        private Rating rating;
        private DateTime date;

        /// <summary>
        /// Initializes a new order with the specified customer and restaurant.
        /// </summary>
        /// <param name="customer">The customer placing the order.</param>
        /// <param name="restaurant">The restaurant from which the order is placed.</param>
        public Order(Customer customer, Restaurant restaurant)
        {
            this.orderedOwner = customer;
            fromRestaurant = restaurant;
            assignedDriver = null;
            number = nextOrderNumber++;
            date = DateTime.Now;
            rating = null;
        }

        /// <summary>
        /// Calculates the total price of the order by summing item subtotals.
        /// </summary>
        public double TotalPrice => items.Sum(item => item.Subtotal);

        /// <summary>
        /// Gets the unique order number.
        /// </summary>
        public int Number => number;

        /// <summary>
        /// Gets the list of items in the order.
        /// </summary>
        public List<OrderItem> items => Items;

        /// <summary>
        /// Gets the timestamp when the order was created.
        /// </summary>
        public DateTime Date => date;

        /// <summary>
        /// Calculates and returns the total price. (Private method, currently unused externally.)
        /// </summary>
        private double CalculateTotalPrice()
        {
            return items.Sum(item => item.Subtotal);
        }

        /// <summary>
        /// Assigns a deliverer to the order.
        /// </summary>
        /// <param name="deliverer">The deliverer to assign.</param>
        public void AssignDeliverer(Deliverer deliverer)
        {
            assignedDriver = deliverer;
        }

        /// <summary>
        /// Updates the status of the order.
        /// </summary>
        /// <param name="Status">The new status to set.</param>
        public void SetOrderStatus(OrderStatus Status)
        {
            status = Status;
        }

        /// <summary>
        /// Gets the current status of the order.
        /// </summary>
        public OrderStatus Status => status;

        /// <summary>
        /// Gets the customer who placed the order.
        /// </summary>
        public Customer GetOwner => orderedOwner;

        /// <summary>
        /// Gets the restaurant from which the order was placed.
        /// </summary>
        public Restaurant FromRestaurant => fromRestaurant;

        /// <summary>
        /// Gets the deliverer assigned to the order.
        /// </summary>
        public Deliverer Driver => assignedDriver;

        /// <summary>
        /// Gets or sets the rating given for the order.
        /// </summary>
        public Rating Ratings
        {
            get { return rating; }
            set { rating = value; }
        }

        /// <summary>
        /// Adds a menu item and its quantity to the order.
        /// </summary>
        /// <param name="item">The menu item to add.</param>
        /// <param name="quantity">The quantity of the item.</param>
        public void AddItem(MenuItem item, int quantity)
        {
            // Optional: Add null check or quantity validation if needed
            Items.Add(new OrderItem(item, quantity));
        }
    }
}
