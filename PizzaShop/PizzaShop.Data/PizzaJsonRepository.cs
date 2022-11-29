using System.Text.Json;

namespace PizzaShop.Data
{
    public class PizzaJsonRepository : IPizzaRepository
    {
        public IEnumerable<Pizza>? LoadPizzas(string filepath)
        {
            if (filepath == null)
                throw new ArgumentNullException(nameof(filepath));
            if (string.IsNullOrWhiteSpace(filepath))
                throw new ArgumentException("", nameof(filepath));

            using var sr = new StreamReader(filepath);
            return JsonSerializer.Deserialize<IEnumerable<Pizza>>(sr.ReadToEnd());
        }

        public void SavePizzas(IEnumerable<Pizza> pizzas, string filepath)
        {
            using var sr = new StreamWriter(filepath);
            sr.Write(JsonSerializer.Serialize(pizzas));
        }
    }
}
