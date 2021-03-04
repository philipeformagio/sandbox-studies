using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MinhaAPICore.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : MainController
    {
        [HttpGet]
        public ActionResult<IEnumerable<string>> ObterTodos()
        {
            var valores = new string[] { "value1", "value2" };

            if (valores.Length < 5000)
                return BadRequest();

            return valores;
        }

        [HttpGet("obter-resultado")]
        public ActionResult ObterResultado()
        {
            var valores = new string[] { "value1", "value2" };

            if (valores.Length < 5000)
                return CustomResponde();

            return CustomResponde(valores);
        }

        [HttpGet("obter-valores")]
        public IEnumerable<string> ObterValores()
        {
            var valores = new string[] { "value1", "value2" };

            if (valores.Length < 5000)
                return null;

            return valores;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Product), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public ActionResult Post(Product product)
        {
            if (product.Id == 0) return BadRequest();

            //add no banco

            //return Ok(product);
            return CreatedAtAction(nameof(Post), product);
        }

        [HttpPost("another-post")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        public ActionResult AnotherPost(Product product)
        {
            if (product.Id == 0) return BadRequest();

            //add no banco

            //return Ok(product);
            return CreatedAtAction(nameof(Post), product);
        }

        [HttpPut("{id}")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Put))]
        public ActionResult Put(int id, [FromForm] Product product)
        {
            if (!ModelState.IsValid) return BadRequest();

            if (id != product.Id) return NotFound();

            // update db

            return NoContent();
        }

        [HttpPut("{id}")]
        [Route("another-put")]
        public ActionResult AnotherPut(int id, [FromForm] Product product)
        {
            if (!ModelState.IsValid) return BadRequest();

            if (id != product.Id) return NotFound();

            // update db

            return NoContent();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
    }

    [ApiController]
    public abstract class MainController : ControllerBase
    {
        protected ActionResult CustomResponde(object result = null)
        {
            if (OperacaoValida())
            {
                return Ok(new
                {
                    sucess = true,
                    data = result
                });
            }

            return BadRequest(new
            {
                sucess = false,
                errors = this.GetErrors()
            });
        }

        protected string GetErrors()
        {
            return "error";
        }

        public bool OperacaoValida()
        {
            // validacoes
            return true;
        }
    }
}
