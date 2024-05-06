using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace BLL.DTOS
{
    public class AdminDTO
    {
        public int Adminid { get; set; }

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
    }
}
