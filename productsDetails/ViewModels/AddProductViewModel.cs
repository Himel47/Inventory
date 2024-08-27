using Microsoft.AspNetCore.Mvc.Rendering;
using productsDetails.Models;

namespace productsDetails.ViewModels
{
    public class AddProductViewModel
    {
        public Product Product { get; set; }
        public SelectList Categories { get; set; }
    }
}
