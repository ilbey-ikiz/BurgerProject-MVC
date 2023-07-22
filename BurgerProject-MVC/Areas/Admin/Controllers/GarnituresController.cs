using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BurgerProject_MVC_G4.Data;
using BurgerProject_MVC_G4.Models.Entites;
using Microsoft.AspNetCore.Authorization;

namespace BurgerProject_MVC_G4.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class GarnituresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GarnituresController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Garnitures
        public async Task<IActionResult> Index()
        {
              return _context.Garnitures != null ? 
                          View(await _context.Garnitures.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Garnitures'  is null.");
        }

        // GET: Admin/Garnitures/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Garnitures == null)
            {
                return NotFound();
            }

            var garniture = await _context.Garnitures
                .FirstOrDefaultAsync(m => m.GarnitureID == id);
            if (garniture == null)
            {
                return NotFound();
            }

            return View(garniture);
        }

        // GET: Admin/Garnitures/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Garnitures/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GarnitureID,GarnitureName")] Garniture garniture)
        {
            if (ModelState.IsValid)
            {
                _context.Add(garniture);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(garniture);
        }

        // GET: Admin/Garnitures/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Garnitures == null)
            {
                return NotFound();
            }

            var garniture = await _context.Garnitures.FindAsync(id);
            if (garniture == null)
            {
                return NotFound();
            }
            return View(garniture);
        }

        // POST: Admin/Garnitures/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GarnitureID,GarnitureName")] Garniture garniture)
        {
            if (id != garniture.GarnitureID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(garniture);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GarnitureExists(garniture.GarnitureID))
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
            return View(garniture);
        }

        // GET: Admin/Garnitures/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Garnitures == null)
            {
                return NotFound();
            }

            var garniture = await _context.Garnitures
                .FirstOrDefaultAsync(m => m.GarnitureID == id);
            _context.Garnitures.Remove(garniture);
            _context.SaveChanges();
            if (garniture == null)
            {
                return NotFound();
            }

            return Ok();
        }


        private bool GarnitureExists(int id)
        {
          return (_context.Garnitures?.Any(e => e.GarnitureID == id)).GetValueOrDefault();
        }
    }
}
