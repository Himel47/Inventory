using Inventory.DTO.DTOs;
using Inventory.DTO.Models;

namespace Inventory.DTO.ViewModels
{
    public class StockViewModel
    {
        public Stock stock { get; set; }
        public List<StockProductDto> products { get; set; }
    }
}
