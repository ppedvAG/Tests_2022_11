using FluentAssertions;
using Moq;
using PizzaShop.Api.Controllers;
using PizzaShop.Common;

namespace PizzaShop.Api.Tests
{
    public class PizzaControllerTests
    {
        [Fact]
        public void Get()
        {
            var mock = new Mock<IPizzaRepository>();
            mock.Setup(x => x.LoadPizzas(It.IsAny<string>()))
                .Returns(() =>
                    new[] { new Pizza() { Name = "Käse", BasisPreis=2.5m },
                            new Pizza() { Name = "Salami", BasisPreis=3.2m } });

            var pc = new PizzaController(mock.Object);

            var result = pc.Get();

            result.Should().HaveCount(2);

            mock.Verify(x => x.SavePizzas(It.IsAny<IEnumerable<Pizza>>(),It.IsAny<string>()), Times.Never);
        }
    }
}