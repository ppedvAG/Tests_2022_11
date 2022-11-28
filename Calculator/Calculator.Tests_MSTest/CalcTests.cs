using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Calculator.Tests_MSTest
{
    [TestClass]
    public class CalcTests
    {
        [TestMethod]
        [TestCategory("UnitTest")]
        public void Sum_2_and_3_results_5()
        {
            //Arrange
            var calc = new Calc();

            //Act
            var result = calc.Sum(2, 3);

            //Assert
            Assert.AreEqual(5, result);
        }

        [TestMethod]
        [TestCategory("UnitTest")]
        public void Sum_1240_and_500_results_1740()
        {
            //Arrange
            var calc = new Calc();

            //Act
            var result = calc.Sum(1240, 500);

            //Assert.Fail("Schade");

            //Assert
            Assert.AreEqual(1740, result);
        }

        [TestMethod]
        [DataRow(2, 3, 5)]
        [DataRow(0, 0, 0)]
        [DataRow(-5, -2, -7)]
        [DataRow(-5, 12, 7)]
        public void Sum_ok(int a, int b, int expected)
        {
            //Arrange
            var calc = new Calc();

            //Act
            var result = calc.Sum(a, b);

            //Assert
            Assert.AreEqual(expected, result);
        }


        [TestMethod]
        public void Sum_MAX_and_1_throws_OverflowException()
        {
            var calc = new Calc();

            Assert.ThrowsException<OverflowException>(() => calc.Sum(int.MaxValue, 1));
        }
    }
}