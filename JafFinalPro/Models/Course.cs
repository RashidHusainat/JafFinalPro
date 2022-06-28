using JafFinalPro.SharedProp;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JafFinalPro.Models
{
    public class Course:CommonProp
    {
        public Guid CourseId { get; set; }
        [Required]
        public string CourseName { get; set; }
        public string CourseDesc { get; set; }
      
        public decimal Price { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.DateTime)]
        public TimeSpan StarTime { get; set; }
        public string CourseImg { get; set; }
        public int VenuId { get; set; }
        public Venu Venu { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
