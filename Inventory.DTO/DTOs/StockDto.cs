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
        public Guid skuId { get; set; }

        public string StockStatus { get; set; } = "";

        public DateTime StockReceiveDate { get; set; }

        public long StockTotalCost { get; set; } = 0;

        public int? SupplierId { get; set; }

        public int ProductNumber { get; set; }




    }
}
