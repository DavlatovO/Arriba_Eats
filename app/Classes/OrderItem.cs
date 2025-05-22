namespace Arriba_Eats
{
    public class OrderItem
    {
        public MenuItem Item { get; set; }
        public int Quantity { get; set; }

        public OrderItem(MenuItem item, int quantity)
        {
            Item = item;
            Quantity = quantity;
        }

        public double Subtotal => Item.Price * Quantity;

        public override string ToString()
        {
            return $"{Quantity} x {Item.Name}";
        }
    }
}
