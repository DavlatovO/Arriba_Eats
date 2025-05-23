
namespace Arriba_Eats
{
    /// <summary>
    /// Creates a menu item with a name and price.
    /// </summary>
    public class MenuItem
    {
        /// <summary>
        /// Menu item name with get and set.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Menu item price with get and set.
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// // Initializes a new instance of the MenuItem class with specified name and price.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="price"></param>
        public MenuItem(string name, double price)
        {
            Name = name;
            Price = price;
        }

        /// <summary>
        /// Returns a string representation of the object, including the name and price formatted as currency.
        /// </summary>
        /// <returns>A string in the format "<c>{Name} - ${Price:F2}</c>", where <c>{Name}</c> is the name of the object and
        /// <c>{Price:F2}</c> is the price formatted to two decimal places.</returns>
        public override string ToString()
        {
            return $"{Name} - ${Price:F2}";
        }
    }
}
