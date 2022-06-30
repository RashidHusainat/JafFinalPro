using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JafFinalPro.Data;
using JafFinalPro.Models;
using Microsoft.AspNetCore.Hosting;
using JafFinalPro.Models.ViewModels;
using System.IO;

namespace JafFinalPro.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SlidersController : Controller
    {
        private readonly JafDbContext _context;
        private IWebHostEnvironment _host;
        public SlidersController(JafDbContext context,IWebHostEnvironment host )
        {
            _context = context;
            _host = host;
        }

        // GET: Admin/Sliders
        public async Task<IActionResult> Index()
        {
            return View(await _context.Sliders.ToListAsync());
        }

        // GET: Admin/Sliders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slider = await _context.Sliders
                .FirstOrDefaultAsync(m => m.SliderId == id);
            if (slider == null)
            {
                return NotFound();
            }

            return View(slider);
        }

        // GET: Admin/Sliders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Sliders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateSliderViewModel slider)
        {
            if (ModelState.IsValid)
            {
               string imgname= UploadNewFile(slider);
                Slider _slider = new Slider {

                    DiscountPerc = slider.DiscountPerc,
                    CreationDate = DateTime.Now,
                    BtnTxt = slider.BtnTxt,
                    BtnUrl = slider.BtnUrl,
                    IsActive = true,
                    IsDeleted=false,
                    Location=slider.Location,
                    Price=slider.Price,
                    SliderSubTitle=slider.SliderSubTitle,
                    SliderTitle=slider.SliderTitle,
                    SliderImg=imgname
                    
                
                };


                _context.Sliders.Add(_slider);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(slider);
        }

        public string UploadNewFile(CreateSliderViewModel model)
        {
            string newFullImageName=null;
            if (model.SliderImg!=null)
            {
                string fileRoot = Path.Combine(_host.WebRootPath, @"Images\");
                string newFileName = Guid.NewGuid() + "_" + model.SliderImg.FileName;
                string fullpath = Path.Combine(fileRoot, newFileName);

                using (var myfile = new FileStream(fullpath, FileMode.Create))
                {
                  model.SliderImg.CopyTo(myfile);
                }
                newFullImageName = @"~/Images/" + newFileName;

                return newFullImageName;
            }

            return newFullImageName;
        }

        // GET: Admin/Sliders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slider = await _context.Sliders.FindAsync(id);
            if (slider == null)
            {
                return NotFound();
            }
            return View(slider);
        }

        // POST: Admin/Sliders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SliderId,SliderTitle,SliderSubTitle,Location,DiscountPerc,Price,BtnTxt,BtnUrl,SliderImg,IsDeleted,IsActive,CreationDate")] Slider slider)
        {
            if (id != slider.SliderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(slider);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SliderExists(slider.SliderId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(slider);
        }

        // GET: Admin/Sliders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slider = await _context.Sliders
                .FirstOrDefaultAsync(m => m.SliderId == id);
            if (slider == null)
            {
                return NotFound();
            }

            return View(slider);
        }

        // POST: Admin/Sliders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var slider = await _context.Sliders.FindAsync(id);
            _context.Sliders.Remove(slider);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SliderExists(int id)
        {
            return _context.Sliders.Any(e => e.SliderId == id);
        }
    }
}
