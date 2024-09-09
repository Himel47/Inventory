using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.DTO.DTOs
{
    public class StockDto
    {
        [Key]
        public Guid skuId { get; set; }

        [Display(Name = "Stock Status")]
        public string StockStatus { get; set; } = "";

        [Display(Name = "Received Time")]
        [Required]
        public DateTime StockReceiveDate { get; set; }
        public long StockTotalCost { get; set; } = 0;

        [Display(Name = "Supplier Name")]
        public int? SupplierId { get; set; }

        [Display(Name = "Number Of Products")]
        [Required]
        public int ProductNumber { get; set; }

    }
}
