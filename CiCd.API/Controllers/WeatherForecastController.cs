using Microsoft.AspNetCore.Mvc;

namespace CiCd.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        [HttpGet("sum/{a}/{b}")]
        public int GetSum(int a, int b)
        {
            return a + b;
        }

        [HttpGet("difference/{a}/{b}")]
        public int GetDiff(int a, int b)
        {
            return a - b;
        }
    }
}
