using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace productsDetails.DTOs
{
    public class StockProductDto
    {
        public string productName { get; set; }
        public string productDesc { get; set; } = "";
        public int productUnitPrice { get; set; }
        public int productQuantity { get; set; }
        public string productImage { get; set; }
        public int categoryId { get; set; }
    }
}
