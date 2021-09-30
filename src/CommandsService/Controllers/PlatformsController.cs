using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CommandsService
{
    [Route("api/c/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        public IActionResult TestInboundConnection()
        {
            Console.WriteLine(" ==> Inbound POST# Commands Service");

            return Ok("Test Inbound Connection Works Fine.");
        }
    }
}