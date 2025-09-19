using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace eda_customer.Data
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext()
        {

        }
        public CustomerDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}

