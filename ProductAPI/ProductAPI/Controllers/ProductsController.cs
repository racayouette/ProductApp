using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductAPI.Data;
using ProductAPI.Entities;

namespace ProductAPI.Controllers
{
    public class ProductsController(DataContext context) : BaseApiController
    {
        // /api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var product = await context.Products.ToListAsync();
            return Ok(product);

        }

        // /api/products/1
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await context.Products.FindAsync(id);
            return product == null ?
                (ActionResult<Product>)NotFound() :
                (ActionResult<Product>)Ok(product);
        }
    }
}
