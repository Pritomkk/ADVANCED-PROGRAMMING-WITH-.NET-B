using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
     public class Token
    {
          [Key]
            public int Id { get; set; }

            [Required]
            [StringLength(100)]
            public string TokenKey { get; set; }

            [Required]
            public DateTime CreatedAt { get; set; }

            public DateTime? DeletedAt { get; set; }

            public string email { get; set; }

            // Foreign key property
            [ForeignKey("Admin")]
            public int AdminId { get; set; }

            // Navigation property for the associated admin
            public virtual Admin Admin { get; set; }
        }





 }

