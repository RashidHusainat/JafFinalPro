using JafFinalPro.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JafFinalPro.ViewComponents
{
    public class InstractorViewComponent: ViewComponent
    {
       
            private JafDbContext db;
            public InstractorViewComponent(JafDbContext _db)
            {
                this.db = _db;
            }
            public IViewComponentResult Invoke()
            {
                var data = db.Instractors
                    .OrderByDescending(x => x.InstractorId).Take(6);
                return View(data);
            }
        }
    }

