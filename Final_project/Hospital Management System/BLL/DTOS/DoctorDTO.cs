using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOS
{
     public class DoctorDTO
    {
        public int DoctorId { get; set; }

        [Required]
        public string DoctorName { get; set; }

        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }

        public string Gender { get; set; }

        public int MaxCheckUpPatient { get; set; }

        public int Adminid { get; set; }
    }
}
