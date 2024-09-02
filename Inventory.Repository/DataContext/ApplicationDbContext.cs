using Inventory.DTO.Models;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Repository.DataContext
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<StockWithProduct> StockProducts { get; set; }
    }
}
