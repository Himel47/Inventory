using Inventory.DTO.DTOs;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Inventory.DTO.ViewModels
{
    public class AddProductViewModel
    {
        public StockProductDto Product { get; set; }
        public SelectList Categories { get; set; }
    }
}
