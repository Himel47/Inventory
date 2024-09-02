using System.ComponentModel.DataAnnotations;

namespace Inventory.DTO.Models
{
    public class StockWithProduct
    {
        [Key]
        public long Id { get; set; }
        public Guid stockId { get; set; }
        public Guid propductId { get; set; }
    }
}
