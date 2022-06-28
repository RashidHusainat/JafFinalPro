using JafFinalPro.SharedProp;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JafFinalPro.Models
{
    public class Venu : CommonProp
    {
        public int VenuId { get; set; }
        [Required]
        [Display(Name ="Venu Name")]
        public string VenuName { get; set; }
    }
}
