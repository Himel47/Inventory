using System.ComponentModel.DataAnnotations;

namespace Inventory.AggregateRoot.Models
{
    public class Category
    {
        [Key]
        public int categoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
