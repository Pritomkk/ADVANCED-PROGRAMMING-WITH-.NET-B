using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOS
{
    public class TokenDTO
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string TokenKey { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        public DateTime? DeletedAt { get; set; }

        public string email { get; set; }
        public int AdminId { get; set; }
    }
}
