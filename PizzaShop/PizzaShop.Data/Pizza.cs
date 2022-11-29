namespace PizzaShop.Data
{
    public class Pizza
    {
        public string Name { get; set; } = string.Empty;
        public int Durchmesser { get; set; }
        public ICollection<Belag> Belaege { get; set; } = new List<Belag>();
        public decimal BasisPreis { get; set; }
    }
}