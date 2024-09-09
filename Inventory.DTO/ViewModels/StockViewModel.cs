using Inventory.DTO.DTOs;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Inventory.DTO.ViewModels
{
    public class StockViewModel
    {
        public StockDto stock { get; set; }
        public List<StockProductDto> products { get; set; }
        public SelectList Categories { get; set; }
    }
}
