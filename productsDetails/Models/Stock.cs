using productsDetails.DTOs;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace productsDetails.Models
{
    public class Stock
    {
        [Key]
        public Guid skuId { get; set; }
        public string stockStatus { get; set; } = "Received";

        [Display(Name = "Received Time")]
        public DateTime stockReceiveDate { get; set; }
        public int stockTotalCost { get; set; }

        [Display(Name = "Supplier Name")]
        public int? supplierId { get; set; }
    }
}
