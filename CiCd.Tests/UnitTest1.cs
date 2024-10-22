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
    }
}