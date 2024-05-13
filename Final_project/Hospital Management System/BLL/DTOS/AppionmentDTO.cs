using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOS
{
    public class AppionmentDTO
    {
        public int AppointmentID { get; set; }
        [Required]
        [StringLength(20)]
        public string AppointmentDate { get; set; }
        [Required]
        [StringLength(20)]
        public string AppointmentTime { get; set; }
        [Required]
        [StringLength(20)]
        public string AppointmentStatus { get; set; }
        [Required]
        public int PaitentAppointmentSerial { get; set; }
    }

    public class cancelAppionmentDTO
    {
        [Required]
        public string AppointmentStatus { get; set; }

    }
}
