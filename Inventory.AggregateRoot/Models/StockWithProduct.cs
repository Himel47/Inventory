using System.ComponentModel.DataAnnotations;

namespace Inventory.AggregateRoot.Models
{
    public class StockWithProduct
    {
        [Key]
        public long Id { get; set; }
        public Guid stockId { get; set; }
        public Guid propductId { get; set; }
        public int productStockPrice { get; set; }
        public int productStockQuantity { get; set; }
    }
}
