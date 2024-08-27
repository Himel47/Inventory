using Microsoft.AspNetCore.Mvc.Rendering;
using productsDetails.DTOs;
using productsDetails.Models;

namespace productsDetails.ViewModels
{
    public class AddStockViewModel
    {
        public Stock stock { get; set; }
        public List<StockProductDto> products { get; set; }
    }
}
