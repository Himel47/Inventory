using Microsoft.AspNetCore.Http;

namespace Inventory.DTO.DTOs
{
    public class StockProductDto
    {
        public string productName { get; set; }
        
        public string productDesc { get; set; } = "";
        
        public int productUnitPrice { get; set; }
        
        public int productQuantity { get; set; }
        
        public IFormFile productImage { get; set; }

        public int categoryId { get; set; }
    }
}
