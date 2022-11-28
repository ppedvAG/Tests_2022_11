using NUnit.Framework;

namespace Calculator.Tests_NUnit
{
    [TestFixture]
    public class CalcTests
    {
        [Test]
        public void Sum_4_and_6_results_10()
        {
            var calc = new Calc();

            var result = calc.Sum(4, 6);

            //Assert.AreEqual(10, result);
            Assert.That(result, Is.EqualTo(10));
        }

        [Test]
        [TestCase(0, 0, 0)]
        [TestCase(2, 3, 5)]
        [TestCase(-2, -3, -5)]
        [TestCase(-2, 3, 1)]
        public void Sum_ok(int a, int b, int exp)
        {
            var calc = new Calc();

            var result = calc.Sum(a, b);

            Assert.That(result, Is.EqualTo(exp));
        }

        [Test]
        public void Sum_MIN_and_n1_throws_OverflowException()
        {
            var calc = new Calc();

            Assert.Throws<OverflowException>(() => calc.Sum(int.MinValue, -1));
        }
    }
}