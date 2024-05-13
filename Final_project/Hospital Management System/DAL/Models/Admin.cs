using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }

        [Required]
        [StringLength(20)]
        public string name { get; set; }

        [Required]
        [StringLength(20)]
        public string email { get; set; }

        [Required]
        [StringLength(20)]
        public string password { get; set; }

        [Required]
        [StringLength(20)]
        public string date { get; set; }

        [Required]
        [StringLength(20)]
        public string phone { get; set; }

        [Required]
        [StringLength(20)]
        public string gender { get; set; }

        public virtual ICollection<Token> Tokens { get; set; }

        public virtual ICollection<doctor> Doctors { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual ICollection<Department> Departments { get; set; }

        public virtual ICollection<Patient> Patients { get; set; }

        public virtual ICollection<Inventory> Inventorys { get; set; }

        public Admin()
        {
            Tokens = new List<Token>();
            Doctors = new List<doctor>();
            Appointments = new List<Appointment>();
            Departments = new List<Department>();
            Patients= new List<Patient>();
            Inventorys= new List<Inventory>();
        }
    }
}
