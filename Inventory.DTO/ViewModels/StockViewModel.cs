using Inventory.DTO.DTOs;
using Inventory.DTO.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Inventory.DTO.ViewModels
{
    public class StockViewModel
    {
        public Stock stock { get; set; }
        public List<StockProductDto> products { get; set; }
        public SelectList Categories { get; set; }
    }
}
