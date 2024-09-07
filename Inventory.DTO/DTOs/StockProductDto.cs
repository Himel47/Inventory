using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Inventory.DTO.DTOs
{
    public class StockProductDto
    {
        [Display(Name = "Product Name")]
        public string productName { get; set; }

        [Display(Name = "Product Description")]
        public string productDesc { get; set; } = "";

        [Display(Name = "Unit Price")]
        public int productUnitPrice { get; set; }

        [Display(Name = "Product Amount")]
        public int productQuantity { get; set; }

        [Display(Name = "Product Image")]
        public IFormFile productImageInput { get; set; }

        [Display(Name ="Category")]
        public int categoryId { get; set; }

        public string? ProductViewPicture  { get; set; }

        public string? ProductViewPictureFormat { get; set; }
    }
}
