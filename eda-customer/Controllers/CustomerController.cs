using eda_customer.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eda_customer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerDbContext _customerDbContext;
        public CustomerController(CustomerDbContext customerDbContext)
        {
            _customerDbContext = customerDbContext;
        }

        [HttpGet]
        [Route("/customers")]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            return await _customerDbContext.Customers.ToListAsync();
        }

        [HttpGet]
        [Route("/products")]
        public ActionResult<IEnumerable<Product>> GetProduct()
        {
            return _customerDbContext.Products.ToList();
        }

        [HttpPost]
        public async Task PostCustomer(Customer customer)
        {
            _customerDbContext.Customers.Add(customer);
            await _customerDbContext.SaveChangesAsync();
        }



    }
}
