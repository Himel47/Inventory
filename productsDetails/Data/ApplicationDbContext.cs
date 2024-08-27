using Microsoft.EntityFrameworkCore;
using productsDetails.Models;

namespace productsDetails.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
