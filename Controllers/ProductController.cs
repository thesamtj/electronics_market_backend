using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Electronics_market_backend.Data;
using Electronics_market_backend.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Electronics_market_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly ApplicationDbContext _db;

        public ProductController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET: api/<ProductController>
        [HttpGet("[action]")]
        public IActionResult GetProducts()
        {
            return Ok(_db.Products.ToList());
        }

        
        // POST api/<ProductController>
        [HttpPost("[action]")]
        public async Task<IActionResult> AddProduct([FromBody] ProductViewModel formData)
        {
            var newproduct = new ProductViewModel
            {
                Name = formData.Name,
                ImageUrl = formData.ImageUrl,
                Description = formData.Description,
                OutOfStock = formData.OutOfStock,
                Price = formData.Price
            };

            await _db.Products.AddAsync(newproduct);

            await _db.SaveChangesAsync();

            return Ok();
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
