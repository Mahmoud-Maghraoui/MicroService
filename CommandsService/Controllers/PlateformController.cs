using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CommandsService.Controllers
{
    [Route("api/c/[controller]")]
    [ApiController]
    public class PlateformController : ControllerBase
    {
        [HttpPost]
        public void TestInbound()
        {
            Console.WriteLine("test inbound from Plateform");
        }
    }
}
