using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplicationCarStore.Data;
using WebApplicationCarStore.Data.Entities;

namespace WebApplicationCarStore.Controllers.Standart
{
    public class StandartModificationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StandartModificationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: StandartModifications
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Modifications.Include(m => m.Model);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: StandartModifications/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modification = await _context.Modifications
                .Include(m => m.Model)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (modification == null)
            {
                return NotFound();
            }

            return View(modification);
        }

        // GET: StandartModifications/Create
        public IActionResult Create()
        {
            ViewData["ModelId"] = new SelectList(_context.Models, "Id", "Name");
            return View();
        }

        // POST: StandartModifications/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Slug,Name,ModelId")] Modification modification, IFormFile fileToStorage)
        {
            if (ModelState.IsValid)
            {
                modification.Id = Guid.NewGuid();
                _context.Add(modification);
                modification.ImgUrl = await Helpers.Media.UploadImage(fileToStorage, "modification_thumbs");


                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ModelId"] = new SelectList(_context.Models, "Id", "Name", modification.ModelId);
            return View(modification);
        }

        // GET: StandartModifications/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ViewBag.Colors = new SelectList(_context.Colors, "Id", "Name");

            var modification = await _context.Modifications
                .Include(mod => mod.ModificationColors)
                .ThenInclude(mc => mc.Color)
                .FirstAsync(mod => mod.Id == id);

            if (modification == null)
            {
                return NotFound();
            }
            ViewData["ModelId"] = new SelectList(_context.Models, "Id", "Name", modification.ModelId);
            return View(modification);
        }

        // POST: StandartModifications/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Slug,Name,ImgUrl,ModelId")] Modification modification)
        {
            if (id != modification.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(modification);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModificationExists(modification.Id))
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
            ViewData["ModelId"] = new SelectList(_context.Models, "Id", "Name", modification.ModelId);
            return View(modification);
        }

        // GET: StandartModifications/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modification = await _context.Modifications
                .Include(m => m.Model)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (modification == null)
            {
                return NotFound();
            }

            return View(modification);
        }

        // POST: StandartModifications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var modification = await _context.Modifications.FindAsync(id);
            _context.Modifications.Remove(modification);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ModificationExists(Guid id)
        {
            return _context.Modifications.Any(e => e.Id == id);
        }
    }
}
