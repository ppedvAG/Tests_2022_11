namespace PizzaShop.Common
{
    public interface IPizzaRepository
    {
        IEnumerable<Pizza>? LoadPizzas(string filepath);
        void SavePizzas(IEnumerable<Pizza> pizzas, string filepath);
    }
}