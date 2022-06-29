using JafFinalPro.Data;
using JafFinalPro.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JafFinalPro.Controllers
{
    public class HomeController : Controller

    {
        private readonly JafDbContext db;

        public HomeController(JafDbContext db)
        {
            this.db = db;
        }

        public async Task< IActionResult> Index()
        {
            CourseInstructorViewModel model = new CourseInstructorViewModel { Courses =await db.Courses.Include(v => v.Venu).Include(c => c.Category).OrderByDescending(ds => ds.CourseId).Take(6).ToListAsync(),
                Instractors = await db.Instractors.OrderByDescending(ds => ds.InstractorId).ToListAsync(),
                Venus =await db.Venus.ToListAsync()
            
            };

            ViewBag.AllVenus = await db.Venus.ToListAsync();
            return View(model);
        }
    }
}
