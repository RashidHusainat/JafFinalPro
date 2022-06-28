using JafFinalPro.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JafFinalPro.Data
{
    public class JafDbContext:DbContext
    {
        public JafDbContext(DbContextOptions<JafDbContext> options):base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Instractor> Instractors { get; set; }
        public DbSet<Menu> Menus { get; set; }
       
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Venu> Venus { get; set; }
    }
}
