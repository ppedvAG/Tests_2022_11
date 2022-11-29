using Moq;
using PizzaShop.Common;
using PizzaShop.Data;

namespace PizzaShop.Logic.Tests
{
    public class PizzaManagerTests
    {
        [Fact]
        public void GetCheapestPizza_Two_Pizza_Käse_In_Repo()
        {
            var pm = new PizzaManager(new PizzaRepoMock());

            var result = pm.GetCheapestPizza();

            Assert.Equal("Käse", result.Name);
        }

        [Fact]
        public void GetCheapestPizza_Two_Pizza_Käse_In_Repo_moq()
        {
            var mock = new Mock<IPizzaRepository>();
            mock.Setup(x => x.LoadPizzas(It.IsAny<string>())).Returns(() =>
                    new[] { new Pizza() { Name = "Käse",BasisPreis=2.5m },
                            new Pizza() { Name = "Salami",BasisPreis=3.2m } });
            var pm = new PizzaManager(mock.Object);

            var result = pm.GetCheapestPizza();

            Assert.Equal("Käse", result.Name);

        }

        public class PizzaRepoMock : IPizzaRepository
        {
            public IEnumerable<Pizza>? LoadPizzas(string filepath)
            {
                return new[] { new Pizza() { Name = "Käse",BasisPreis=2.5m },
                           new Pizza() { Name = "Salami",BasisPreis=3.2m }};
            }

            public void SavePizzas(IEnumerable<Pizza> pizzas, string filepath)
            {
                throw new NotImplementedException();
            }
        }
    }
}