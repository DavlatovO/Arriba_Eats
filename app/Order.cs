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
        private List<OrderItem> items;
        private OrderStatus status;
        private double totalPrice;
        private int number;
        private Rating rating;  
        private DateTime date;



        public Order(Customer customer, Restaurant restaurant, List<OrderItem> items)
        {
            this.orderedOwner = customer;
            fromRestaurant = restaurant;
            this.items = items;
            assignedDriver = null;
            totalPrice = CalculateTotalPrice();
            number = nextOrderNumber++;
            date = DateTime.Now;
        }

        public int Number
        {
            get { return number; }
        }
         public List<OrderItem> Items
        {
            get { return items; }
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
            status = OrderStatus.BeingDelivered;
        }

        public void SetOrderStatus(OrderStatus Status)
        {
            status = Status;
        }

        public double TotalPrice
        {
            get { return totalPrice; }
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


    }








}