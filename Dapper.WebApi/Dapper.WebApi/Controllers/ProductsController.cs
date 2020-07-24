using Dapper.Application.Interfaces;
using Dapper.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Dapper.WebApi.Controllers
{
    /// <summary>
    /// ProductsController returns the product Entity
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        /// <summary>
        /// ProductsController initialize unitOfWork
        /// </summary>
        /// <param name="unitOfWork"></param>
        public ProductsController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Gets all products at once.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await unitOfWork.Products.GetAllAsync();
            return Ok(data);
        }

        /// <summary>
        /// Gets a product by a given Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await unitOfWork.Products.GetByIdAsync(id);
            if (data == null) return NotFound();
            return Ok(data);
        }

        /// <summary>
        /// Adds a product into the database by a given product model.
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(Product product)
        {
            var data = await unitOfWork.Products.AddAsync(product);
            return Ok(data);
        }

        /// <summary>
        /// Deletes a product by a given id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await unitOfWork.Products.DeleteAsync(id);
            return Ok(data);
        }

        /// <summary>
        /// Updates a product by a given id.
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(Product product)
        {
            var data = await unitOfWork.Products.UpdateAsync(product);
            return Ok(data);
        }
    }
}
