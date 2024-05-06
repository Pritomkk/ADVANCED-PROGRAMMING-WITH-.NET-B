using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Appointment
    {
        [Key]
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

        [ForeignKey("Doctor")]
        public int DoctorId { get; set; }
        public virtual doctor Doctor { get; set; }

        [ForeignKey("Admin")]
        public int AdminId { get; set; }
        public virtual Admin Admin { get; set; }

        [ForeignKey("Patient")]
        public int PatientId { get; set; }
        public virtual Patient Patient { get; set; }

    }

}

