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
        private Customer orderedOwner;
        private Restaurant fromRestaurant;
        private Deliverer assignedDriver;
        private List<MenuItem> items;
        private OrderStatus status;
        private double totalPrice;


        public Order(Customer customer, Restaurant restaurant, List<MenuItem> items, Deliverer driver)
        {
            this.orderedOwner = customer;
            fromRestaurant = restaurant;
            this.items = items;
            assignedDriver = driver;
            totalPrice = CalculateTotalPrice();
        }

        private double CalculateTotalPrice()
        {
            return items.Sum(item => item.Price);
        }

        public void AssignDeliverer(Deliverer deliverer)
        {
            assignedDriver = deliverer;
            status = OrderStatus.BeingDelivered;
        }

        public void SetOrderStatus(Order order, OrderStatus status)
        {
            order.status = status;
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