using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOS
{
    public class PaitentDTO
    {
        public int PatientId { get; set; }
        [Required]
        public string PatientName { get; set; }
        [Required]
        public string Email { get; set; }
        public DateTime? AdmissionDate { get; set; }
    
        [Required]
        public string Phone { get; set; }

        [Required]
        [StringLength(10)]
        public string Gender { get; set; }

        [Required]
        public string Status { get; set; }

    }

    public class dischargePaitentDTO
    {
        [Required]
        public string Status { get; set; }
        public DateTime? DischargeDate { get; set; }
    }
}
