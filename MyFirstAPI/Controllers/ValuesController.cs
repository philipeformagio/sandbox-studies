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

        // When have a typed ActionResult you can either return an actions/results(BadRequest())
        // or its type
        [HttpGet]
        public ActionResult <IEnumerable<string>> GetAll()
        {
            var values = new string[] { "value1", "value2" };

            if(values.Length < 5000)
                return BadRequest();

            return values;
        }

        // When only ActionResult can only return actions/results
        [HttpGet]
        public ActionResult GetResult()
        {
            var values = new string[] { "value1", "value2" };

            if(values.Length < 5000)
                return BadRequest();

            return Ok(values);
        }

        // When typed can only return typed
        [HttpGet]
        public IEnumerable<string> GetValues()
        {
            var values = new string[] { "value1", "value2" };

            if(values.Length < 5000)
                return null;

            return values;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Product), 201)] // use this for documentation purpose
        [ProducesResponseType(404)] // use this for documentation purpose
        public ActionResult Post(Product product)
        {
            if(product.Id == 0) return BadRequest();
             
            // add database

            // return Ok(product);
            return CreatedAtAction(nameof(Post), product);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromForm]Product product) // [FromFrom] is data sent by the client using FormData
        {
        }

        [HttpDelete]
        public void Delete([FromQuery]int id) // [FromQuery] when you want to pull a parameter from the query string
        {
        }
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    
}