using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationCarStore.Data;
using WebApplicationCarStore.Data.Entities;

namespace WebApplicationCarStore.Controllers.Admin
{
    public class AdminCarsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminCarsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        { 
            return View(await _context.Models.ToListAsync());
        }

        public async Task<IActionResult> ModelColors()
        {
            return View(await _context.Colors.ToListAsync());
        }

        public async Task<IActionResult> ModelModificationColors()
        {
            /*
            var applicationDbContext = _context.ModificationColors
                .Include(m => m.Color)
                .Include(m => m.Modification)
                .Where(mod => mod.ModificationId == id);
            */

            ViewData["Modifications"] = new SelectList(_context.Modifications, "Id", "Name");
            ViewData["Colors"] = new SelectList(_context.Colors, "Id", "Name");

            return View();
        }

        public async Task<IActionResult> ModelModifications(Guid? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            ViewBag.OpenModel = _context.Models.First(model => model.Id == id);
            var mod = _context.Modifications
                .Include(modification => modification.ModificationColors)
                .ThenInclude(modificationColor => modificationColor.Color)
                .Where(mod => mod.ModelId == id);

            return View(await mod.ToListAsync());
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateModifications([Bind("Id,ModelId,Slug,Name")] Modification modification, IFormFile fileToStorage)
        {
            if (ModelState.IsValid)
            {
                modification.Id = Guid.NewGuid();
                modification.ImgUrl = await Helpers.Media.UploadImage(fileToStorage, "modification_thumbs");
                _context.Add(modification); 
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index), new { Id = modification.ModelId});
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateColor([Bind("Id,Slug,Name")] Color color, IFormFile fileToStorage)
        {
            if (ModelState.IsValid)
            {
                color.Id = Guid.NewGuid();
                color.ImgUrl = await Helpers.Media.UploadImage(fileToStorage, "color_thumbs");
                _context.Add(color);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }

      

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateModificationColors([Bind("Id,Slug,ModificationId,ColorId")] ModificationColor modificationColor, IFormFile fileToStorage)
        {
            if (ModelState.IsValid)
            {
                modificationColor.Id = Guid.NewGuid();
                _context.Add(modificationColor);
                modificationColor.ImgUrl = await Helpers.Media.UploadImage(fileToStorage, "modification_colors_thumbs");


                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateModel([Bind("Id,Slug,Name")] Model model, IFormFile fileToStorage)
        {
            if (ModelState.IsValid)
            {
                model.Id = Guid.NewGuid();
                _context.Add(model);
                model.ImgUrl = await Helpers.Media.UploadImage(fileToStorage, "modification_thumbs");
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }

    }
}
