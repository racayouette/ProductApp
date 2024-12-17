using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductAPI.Data;
using ProductAPI.Entities;

namespace ProductAPI.Controllers
{
    public class Products2Controller(DataContext context) : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<Product>> GetProductsNoPaging()
        {
            var product = context.Products.ToList();
            return Ok(product);
        }
        public class PagedResult<T>
        {
            public List<T> Items { get; set; }
            public int TotalItems { get; set; }
            public int PageNumber { get; set; }
            public int PageSize { get; set; }
            public int TotalPages { get; set; }
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
