using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MyFirstAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ValuesController : MainController
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
                return CustomResponse();

            return CustomResponse(values);
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
        /* use this or the convetion above instead
        [ProducesResponseType(typeof(Product), StatusCodes.Status201Created)] // use this for documentation purpose
        [ProducesResponseType(404)] // use this for documentation purpose
        */
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        public ActionResult Post(Product product)
        {
            if(product.Id == 0) return BadRequest();

            // add database

            //return Ok(product);
            return CreatedAtAction(nameof(Post), product);
        }

        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Put))]
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromForm]Product product) // [FromFrom] is data sent by the client using FormData
        {
            if (!ModelState.IsValid) return BadRequest();

            if (id != product.Id) return NotFound();

            // add database

            //return Ok(product);
            return NoContent();
        }

        [HttpDelete]
        public void Delete([FromQuery]int id) // [FromQuery] when you want to pull a parameter from the query string
        {
        }
    }

    [ApiController]
    public abstract class MainController : ControllerBase
    {
        protected ActionResult CustomResponse(object result = null)
        {
            if(ValidOperations())
            {
                return Ok(new 
                {
                    success = true,
                    data = result
                });
            }

            return BadRequest(new
            {
                success = true,
                errors = ObterErrors()
            });
        }

        public bool ValidOperations() 
        {
            // do validations
            return true;
        }

        protected string ObterErrors()
        {
            return "";
        } 
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    
}