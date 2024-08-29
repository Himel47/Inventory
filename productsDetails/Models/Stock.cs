using productsDetails.DTOs;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace productsDetails.Models
{
    public class Stock
    {
        [Key]
        public Guid skuId { get; set; }

        [Display(Name ="Stock Status")]
        public string StockStatus { get; set; } = "";

        [Display(Name = "Received Time")]
        [Required]
        public DateTime StockReceiveDate { get; set; }
        public int StockTotalCost { get; set; } = 0;

        [Display(Name = "Supplier Name")]
        public int? SupplierId { get; set; }

        [Display(Name = "Number Of Products")]
        [Required]
        public int ProductNumber { get; set; }
    }
}
