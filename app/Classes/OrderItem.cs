namespace Arriba_Eats
{
    /// <summary>
    /// Represents an item within an order, including the menu item and its quantity.
    /// </summary>
    public class OrderItem
    {
        /// <summary>
        /// Gets or sets the menu item associated with this order item.
        /// </summary>
        public MenuItem Item { get; set; }

        /// <summary>
        /// Gets or sets the quantity of the menu item.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderItem"/> class.
        /// </summary>
        /// <param name="item">The menu item.</param>
        /// <param name="quantity">The quantity ordered.</param>
        public OrderItem(MenuItem item, int quantity)
        {
            // Optional: Add null check or quantity validation if needed
            Item = item;
            Quantity = quantity;
        }

        /// <summary>
        /// Gets the subtotal for this order item (price * quantity).
        /// </summary>
        public double Subtotal => Item.Price * Quantity;

        /// <summary>
        /// Returns a string that represents the current order item.
        /// </summary>
        /// <returns>A string in the format "Quantity x ItemName".</returns>
        public override string ToString()
        {
            return $"{Quantity} x {Item.Name}";
        }
    }
}
