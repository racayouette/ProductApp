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
        public async Task<PagedResult<Product>> GetProducts(string parms)
        {
            var splitter = parms.Split(':');
            var pageNumber = int.Parse(splitter[0]);
            var pageSize = int.Parse(splitter[1]);
            var query = context.Set<Product>().AsQueryable();
         
            if (pageSize == 0)
            {
                pageSize = 5;
            }
            var skip = (pageNumber) * pageSize;
            var take = pageSize;

            var products = await query
           .Skip(skip)
           .Take(take)
           .ToListAsync();

            var totalItems = await query.CountAsync();

            var pagedResult = new PagedResult<Product>
            {
                Items = products,
                TotalItems = totalItems,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalPages = (int)Math.Ceiling((double)totalItems / pageSize)
            };

            return pagedResult;
        }

        //public class PagedResult<T>
        //{
        //    public List<T> Items { get; set; }
        //    public int TotalItems { get; set; }
        //    public int PageNumber { get; set; }
        //    public int PageSize { get; set; }
        //    public int TotalPages { get; set; }
        //}

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
