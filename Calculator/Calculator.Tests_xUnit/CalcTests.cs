namespace Calculator.Tests_xUnit
{
    public class CalcTests
    {
        [Fact]
        [Trait("Category", "UnitTest")]
        public void Sum_4_and_6_results_10()
        {
            var calc = new Calc();

            var result = calc.Sum(4, 6);

            Assert.Equal(10, result);
        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(2, 3, 5)]
        [InlineData(-2, -3, -5)]
        [InlineData(-2, 3, 1)]
        public void Sum_ok(int a, int b, int exp)
        {
            var calc = new Calc();

            var result = calc.Sum(a, b);

            Assert.Equal(exp, result);
        }

        [Fact]
        public void Sum_MIN_and_n1_throws_OverflowException()
        {
            var calc = new Calc();

            Assert.Throws<OverflowException>(() => calc.Sum(int.MinValue, -1));
        }
    }
}