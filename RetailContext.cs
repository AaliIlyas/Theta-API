using Microsoft.EntityFrameworkCore;
using Theta.Models.Database;

namespace Bookish.DbModels
{
    public class RetailContext : DbContext
    {
        public RetailContext(DbContextOptions<RetailContext> options) : base(options)
        {
        }

        public DbSet<Customers> Customers { get; set; }
        public DbSet<Products> Members { get; set; }
        public DbSet<Orders> CheckedOutBooks { get; set; }
    }
}
