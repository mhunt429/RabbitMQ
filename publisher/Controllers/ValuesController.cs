using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;
using publisher.interfaces;

namespace publisher.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public ValuesController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Index()
        {
            return new string[] { "Value1", "Value2" };
        }

        [HttpPost]
        public IActionResult Post([FromBody]string body) { 
            string json = System.Text.Json.JsonSerializer.Serialize(body);
            Console.WriteLine("Received a Post:" + body);
            _messageService.Enqueue(body);
            return Ok(true);
        }


    }
}