using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class doctor
    {
        [Key]
        public int DoctorId { get; set; }

        [Required]
        [StringLength(20)]
        public string DoctorName { get; set; }

        [Required]
        [StringLength(20)]
        public string Email { get; set; }
        [Required]
        [StringLength(20)]
        public string Phone { get; set; }

        [Required]
        [StringLength(20)]
        public string Gender { get; set; }

        [Required]
        public int MaxCheckUpPatient { get; set; }

        [ForeignKey("Admin")]
        public int AdminId { get; set; }
        public virtual Admin Admin { get; set; }

        [ForeignKey("Department")]
        public int DepId { get; set; }
        public virtual Department Department { get; set; }


        public virtual ICollection<Appointment> Appointments { get; set; }

        public doctor()
        {
            Appointments = new List<Appointment>();
            Department = new Department();
        }
    }

}
