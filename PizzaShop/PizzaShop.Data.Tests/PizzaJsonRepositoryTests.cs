using FluentAssertions;

namespace PizzaShop.Data.Tests
{
    public class PizzaJsonRepositoryTests
    {
        [Fact]
        public void LoadPizzas_testfile_with_3_pizzas()
        {
            var fileName = "pizzaTestFile.json";
            var repo = new PizzaJsonRepository();

            var pizzas = repo.LoadPizzas(fileName);

            pizzas.Should().NotBeNull().And.HaveCount(3);
        }

        [Fact]
        public void LoadPizzas_filepath_empty_throws_ArgumentException()
        {
            var repo = new PizzaJsonRepository();

            var act = () => repo.LoadPizzas(string.Empty);

            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void LoadPizzas_filepath_null_throws_ArgumentNullException()
        {
            var repo = new PizzaJsonRepository();

            var act = () => repo.LoadPizzas(null);

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void LoadPizzas_Dir_does_not_exist_throws_DirectoryNotFoundException()
        {
            var repo = new PizzaJsonRepository();

            var act = () => repo.LoadPizzas(@"b:\DER_PFAD_SOLLTE_NICHT_EXISTIEREN\test123.json");

            act.Should().Throw<DirectoryNotFoundException>();
        }

        [Fact]
        public void SavePizza_save_3_pizzas()
        {
            var pizza1 = new Pizza() { Name = "P1", BasisPreis = 4m };
            pizza1.Belaege.Add(new Belag() { Name = "Salami" });
            var pizza2 = new Pizza() { Name = "P2", BasisPreis = 4.2m };
            pizza2.Belaege.Add(new Belag() { Name = "Salami" });
            pizza2.Belaege.Add(new Belag() { Name = "Schinken" });
            var pizza3 = new Pizza() { Name = "P3", BasisPreis = 4.6m };
            var repo = new PizzaJsonRepository();

            var act = () => repo.SavePizzas(new[] { pizza1, pizza2, pizza3 }, "pizza.json");

            act.Should().NotThrow();
        }

        [Fact]
        public void SaveAndLoadPizzas()
        {
            var pizza1 = new Pizza() { Name = "P1", BasisPreis = 4m };
            pizza1.Belaege.Add(new Belag() { Name = "Salami" });
            var pizza2 = new Pizza() { Name = "P2", BasisPreis = 4.2m };
            pizza2.Belaege.Add(new Belag() { Name = "Salami" });
            pizza2.Belaege.Add(new Belag() { Name = "Schinken" });
            var pizza3 = new Pizza() { Name = "P3", BasisPreis = 4.6m };
            var testPizzas = new[] { pizza1, pizza2, pizza3 };
            var fileName = "SaveAndLoadPizzaTest.json";

            var repo = new PizzaJsonRepository();
            repo.SavePizzas(testPizzas, fileName);

            var loaded = repo.LoadPizzas(fileName);

            loaded.Should().BeEquivalentTo(testPizzas);
        }

    }
}