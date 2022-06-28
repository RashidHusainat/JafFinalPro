using JafFinalPro.SharedProp;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JafFinalPro.Models
{
    public class Slider: CommonProp
    {
        public int SliderId { get; set; }
        [Required]
        public string SliderTitle { get; set; }
        public string SliderSubTitle { get; set; }
        public string Location { get; set; }
        public string DiscountPerc { get; set; }
        public decimal Price { get; set; }
        public string BtnTxt { get; set; }
        public string BtnUrl { get; set; }
    }
}
