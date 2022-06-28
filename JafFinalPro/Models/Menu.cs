using JafFinalPro.SharedProp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JafFinalPro.Models
{
    public class Menu : CommonProp
    {
        public int MenuId { get; set; }
        public string MenuTitle { get; set; }
        public string MenuUrl { get; set; }
    }
}
