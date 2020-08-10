using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MyFirstAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ValuesController : ControllerBase
    {
        // Get api/values/obter-por-id/5
        [HttpGet("obter-por-id/{id:int}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }
    }
    
}