
namespace TddBank.Tests
{
    public class OpeningHoursTests
    {
        [Theory]
        [InlineData(2022, 11, 28, 10, 29, false)]//mo
        [InlineData(2022, 11, 28, 10, 30, true)]//mo
        [InlineData(2022, 11, 28, 10, 31, true)]//mo
        [InlineData(2022, 11, 28, 18, 59, true)]//mo
        [InlineData(2022, 11, 28, 19, 00, false)]//mo
        [InlineData(2022, 11, 28, 19, 01, false)]//mo
        [InlineData(2022, 12, 3, 10, 29, false)]//sa
        [InlineData(2022, 12, 3, 10, 30, true)]//sa
        [InlineData(2022, 12, 3, 13, 59, true)]//sa
        [InlineData(2022, 12, 3, 14, 00, false)]//sa
        [InlineData(2022, 12, 3, 14, 01, false)]//sa
        [InlineData(2022, 12, 4, 12, 00, false)]//so
        public void IsOpen(int y, int M, int d, int h, int m, bool exp)
        {
            var dt = new DateTime(y, M, d, h, m, 0);
            var oh = new OpeningHours();

            Assert.Equal(exp, oh.IsOpen(dt));
        }
    }
}
