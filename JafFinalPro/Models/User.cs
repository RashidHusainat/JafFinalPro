using JafFinalPro.SharedProp;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JafFinalPro.Models
{
    public class User : CommonProp
    {
        public Guid UserId { get; set; }
        public string FullName { get; set; }
        [Required]
        public string UName { get; set; }
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }
       
    }
}
