using System;

namespace Arriba_Eats
{

    public enum OrderStatus
    {
        Ordered,
        Cooking,
        Cooked,
        BeingDelivered,
        Delivered

    }


    class Order
    {
        private static int nextOrderNumber = 1; // static counter shared by all instances

        private Customer orderedOwner;
        private Restaurant fromRestaurant;
        private Deliverer assignedDriver;
        private List<OrderItem> Items { get; set; } = new List<OrderItem>();
        private OrderStatus status;
        private int number;
        private Rating rating;
        private DateTime date;



        public Order(Customer customer, Restaurant restaurant)
        {
            this.orderedOwner = customer;
            fromRestaurant = restaurant;
            assignedDriver = null;
            number = nextOrderNumber++;
            date = DateTime.Now;
            rating = null;
        }

        public double TotalPrice => items.Sum(item => item.Subtotal);
        public int Number
        {
            get { return number; }
        }
         public List<OrderItem> items
        {
            get { return Items; }
        }

        public DateTime Date
        {
            get { return date; }
        }

        private double CalculateTotalPrice()
        {
            return items.Sum(item => item.Subtotal);
        }

        public void AssignDeliverer(Deliverer deliverer)
        {
            assignedDriver = deliverer;
        }

        public void SetOrderStatus(OrderStatus Status)
        {
            status = Status;
        }

        
        public OrderStatus Status
        {
            get { return status; }
        }

        public Customer GetOwner
        {
            get { return  orderedOwner; }
        }

        public Restaurant FromRestaurant
        {
            get { return fromRestaurant; }
        }
        public Deliverer Driver
        {
            get { return assignedDriver; }
        }

        public Rating Ratings
        {
                get { return rating; }
            set { rating = value; }
        }
        public void AddItem(MenuItem item, int quantity)
        {
            Items.Add(new OrderItem(item, quantity));
        }

    }








}