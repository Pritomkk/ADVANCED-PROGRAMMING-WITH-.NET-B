using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOS
{
    public class InventoryDTO
    {
        
        public int Id { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }

        public decimal PricePerUnit { get; set; }

        public decimal TotalValue => Quantity * PricePerUnit;

        public int AdminId { get; set; }
   
    }


}
