using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

namespace publisher.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<string>> Index()
        {
            return new string[] { "Value1", "Value2" };
        }

        [HttpPost]
        public IActionResult Post([FromBody]JsonElement body) { 
            string json = System.Text.Json.JsonSerializer.Serialize(body);
             return Ok("{\"success\": \"true\"}");
        }


    }
}