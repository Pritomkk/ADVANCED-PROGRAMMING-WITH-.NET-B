using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Inventory
    {
       
            [Key]
            public int Id { get; set; }

            [Required]
            [StringLength(50)]
            public string Name { get; set; }

            [Required]
            public int Quantity { get; set; }

            [Required]
          
            public decimal PricePerUnit { get; set; }

            [NotMapped]
            public decimal TotalValue => Quantity * PricePerUnit;

        [ForeignKey("Admin")]
        public int AdminId { get; set; }
        public virtual Admin Admin { get; set; }


    }

    
}
