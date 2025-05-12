// MenuItem.cs
namespace Arriba_Eats
{
    public class MenuItem
    {
        public string Name { get; set; }
        public double Price { get; set; }

        public MenuItem(string name, double price)
        {
            Name = name;
            Price = price;
        }

        public override string ToString()
        {
            return $"{Name} - ${Price:F2}";
        }
    }
}
