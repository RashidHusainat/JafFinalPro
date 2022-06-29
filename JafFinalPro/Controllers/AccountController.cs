using JafFinalPro.Data;
using JafFinalPro.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JafFinalPro.Controllers
{
    public class AccountController : Controller
    {
        private readonly JafDbContext db;

        public AccountController(JafDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var lgn = db.Users.Where(m => m.UName == model.UName && m.Password == model.Password);
                if (lgn.Any())
                {
                    return RedirectToAction("Index","Dashboard",new { area="Admin"});

                }
                ModelState.AddModelError(string.Empty, "Ivalid user anem, or password");
                return View(model);

            }


            return View(model);
        }
    }
}
