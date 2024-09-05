using Inventory.DTO.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Inventory.DTO.ViewModels
{
    public class AddProductViewModel
    {
        public Product Product { get; set; }
        public SelectList Categories { get; set; }
    }
}
