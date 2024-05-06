using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOS
{
     public class DepartmentDTO
    {
        [Key]
        public int DepId { get; set; }

        [Required]
        [StringLength(50)]
        public string DepName { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public int AdminId { get; set; }
    }
}
