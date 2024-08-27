using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace productsDetails.Models
{
    public class Product
    {
        [Key]
        public Guid productId { get; set; }
        public string productName { get; set; }
        public string productDesc { get; set; } = "";
        public int productUnitPrice { get; set; }
        public int productQuantity { get; set; }
        public string? productImage { get; set; }
        public string productStatus { get; set; } = "";
        public int categoryId { get; set; }
    }
}
