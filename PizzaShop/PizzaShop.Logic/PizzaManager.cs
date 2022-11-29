using PizzaShop.Common;
using PizzaShop.Data;

namespace PizzaShop.Logic
{
    public class PizzaManager
    {
        public IPizzaRepository Repository { get; }

        public PizzaManager(IPizzaRepository repository)
        {
            Repository = repository;
        }

        public decimal CalcPizzaPreis(Pizza pizza)
        {
            return pizza.BasisPreis + pizza.Belaege.Sum(x => x.Preis);
        }

        public Pizza? GetCheapestPizza()
        {
            var allPizzas = Repository.LoadPizzas("PizzaDb.json");

            return allPizzas.OrderBy(x => CalcPizzaPreis(x)).FirstOrDefault();
        }
    }
}