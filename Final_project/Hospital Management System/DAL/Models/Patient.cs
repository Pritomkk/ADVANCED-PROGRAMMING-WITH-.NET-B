using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Patient
    {
        [Key]
        public int PatientId { get; set; }
        [Required]
        [StringLength(50)]
        public string PatientName { get; set; }
        [Required]
        [StringLength(50)]
        public string Email { get; set; }
        public DateTime? AdmissionDate { get; set; }
        public DateTime? DischargeDate { get; set; }
        [Required]
        [StringLength(15)]
        public string Phone { get; set; }

        [Required]
        [StringLength(10)]
        public string Gender { get; set; }

        [Required]
        [StringLength(20)]
        public string Status { get; set; }

        [ForeignKey("Admin")]
        public int AdminId { get; set; }
        public virtual Admin Admin { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
        public Patient()
        {
            Appointments = new List<Appointment>();
        }
    }
}
