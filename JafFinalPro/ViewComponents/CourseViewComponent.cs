using JafFinalPro.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JafFinalPro.ViewComponents
{
    public class CourseViewComponent:ViewComponent
    {
        private JafDbContext db;
        public CourseViewComponent(JafDbContext _db)
        {
            this.db = _db;
        }
        public IViewComponentResult Invoke()
        {
            var data = db.Courses.Include(x=>x.Venu).Include(c=>c.Category)
                .OrderByDescending(x=>x.CourseId).Take(6);
            return View(data);
        }
    }
}
