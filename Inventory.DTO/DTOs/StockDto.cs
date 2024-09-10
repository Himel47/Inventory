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
        public DateTime StockReceiveDate { get; set; }

        [Display(Name = "Supplier Name")]
        public int? SupplierId { get; set; }

        [Display(Name = "Number Of Products")]
        public int ProductNumber { get; set; }

    }
}
