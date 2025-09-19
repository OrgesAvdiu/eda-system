using eda_inventory.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace eda_inventory.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ProductDbContext _productDbContext;
        public ProductController(ProductDbContext productDbContext)
        {
            _productDbContext = productDbContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Products>> GetProducts()
        {
            return _productDbContext.Products.ToList();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateProduct(Products products)
        {
            _productDbContext.Products.Update(products);
            await _productDbContext.SaveChangesAsync();
            var product = JsonSerializer.Serialize(new
            {
                products.Id,
                NewName = products.Name,
                products.Quantity
            });
            return CreatedAtAction("GetProducts", new { products.Id }, products);
        }


        [HttpPost]
        public async Task<ActionResult<Products>> PostProduct(Products products)
        {
            _productDbContext.Products.Add(products);
            await _productDbContext.SaveChangesAsync();
            var product = JsonSerializer.Serialize(new
            {
                products.Id,
                products.ProductId,
                products.Name,
                products.Quantity
            });
            return CreatedAtAction("GetProducts", new { products.Id }, products);
        }

    }
}