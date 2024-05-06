using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Department
    {
        [Key]
        public int DepId { get; set; }

        [Required]
        [StringLength(50)]
        public string DepName { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [ForeignKey("Admin")]
        public int AdminId { get; set; }
        public virtual Admin Admin { get; set; }

        public virtual ICollection<doctor> doctors { get; set; }

        public Department()
        {
            doctors = new List<doctor>();
            
        }
    }
}