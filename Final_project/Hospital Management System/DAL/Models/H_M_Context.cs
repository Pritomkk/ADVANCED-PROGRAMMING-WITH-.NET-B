using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    internal class H_M_Context:DbContext
    {
        public DbSet<Admin>Admins { get; set; }
        public DbSet<doctor> doctors { get; set; }
        public DbSet<Appointment> appointments { get; set; }
        public DbSet<Token>Tokens { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Inventory> Inventories {get;set;}

    }
}
