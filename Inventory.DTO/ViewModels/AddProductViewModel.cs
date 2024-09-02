using Inventory.DTO.Models;
using System.Web.Mvc;

namespace Inventory.DTO.ViewModels
{
    public class AddProductViewModel
    {
        public Product Product { get; set; }
        public SelectList Categories { get; set; }
    }
}
