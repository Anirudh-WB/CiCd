using CiCd.API.Controllers;

namespace CiCd.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void TestSum()
        {
            var controller = new WeatherForecastController();
            var result = controller.GetSum(2, 3);
            Assert.Equal(5, result);
        }

        [Fact]
        public void TestDiff()
        {
            var controller = new WeatherForecastController();
            var result = controller.GetDiff(3, 2);
            Assert.Equal(1, result);
        }
    }
}