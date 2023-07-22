using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BurgerProject_MVC_G4.Data;
using BurgerProject_MVC_G4.Models.Entites;
using BurgerProject_MVC_G4.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace BurgerProject_MVC_G4.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Products
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Products.Include(p => p.Category);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Admin/Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.ProductID == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Admin/Products/Create
        public IActionResult Create()
        {
            ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryID", "CategoryName");
            ViewBag.Garnitures = new SelectList(_context.Garnitures.ToList(), "GarnitureID", "GarnitureName");
            return View();
        }

        // POST: Admin/Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductID,ProductName,Price,CoverImage,CategoryID")] Product product, IFormFile ImageName, string[] garnitures)
        {

            ModelState.Remove("garnitures");
            ModelState.Remove("ImageName");

            if (ModelState.IsValid)
            {
                if (product.CategoryID == 1)
                {
                    foreach (var garnitureID in garnitures)
                    {
                        product.Garnitures.Add(_context.Garnitures.FirstOrDefault(d => d.GarnitureID == int.Parse(garnitureID)));
                    }
                }
                if (ImageName != null)
                {

                    Guid guid = Guid.NewGuid();
                    string newFileName = guid.ToString() + "_" + ImageName.FileName;
                    product.CoverImage = newFileName;

                    FileStream fs = new FileStream("wwwroot/ProductsImages/" + newFileName, FileMode.Create);

                    await ImageName.CopyToAsync(fs);
                }


                _context.Products.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }



            ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryID", "CategoryName", product.CategoryID);
            return View(product);

        }

        // GET: Admin/Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products.Include(d => d.Garnitures).FirstOrDefaultAsync(d => d.ProductID == id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryID", "CategoryName", product.CategoryID);
            DenemeVm vm = new DenemeVm();


                vm.Product = product;
                vm.Garnitures = _context.Garnitures.ToList();

            return View(vm);
        }

        // POST: Admin/Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductID,ProductName,Price,CoverImage,CategoryID")] Product product, string[] garniture, IFormFile ImageName)
        {
            //if (id != product.ProductID)
            //{
            //    return NotFound();
            //}
            ModelState.Remove("ImageName");
            if (ModelState.IsValid)
            {
                var product1 = await _context.Products.Include(s=>s.Garnitures).FirstOrDefaultAsync(s=> s.ProductID==product.ProductID);
                product1.ProductName = product.ProductName;
                product1.CategoryID = product.CategoryID;
                product1.Price = product.Price;
                var garnitureList = new List<Garniture>();

                if (ImageName != null)
                {

                    Guid guid = Guid.NewGuid();
                    string newFileName = guid.ToString() + "_" + ImageName.FileName;
                    product1.CoverImage = newFileName;

                    FileStream fs = new FileStream("wwwroot/ProductsImages/" + newFileName, FileMode.Create);

                    await ImageName.CopyToAsync(fs);
                }
                foreach (var item in garniture)
                {
                    garnitureList.Add(_context.Garnitures.Find(int.Parse(item)));
                }
                product1.Garnitures = garnitureList;
                try
                {
                    _context.Update(product1);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ProductID))
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
            ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryID", "CategoryName", product.CategoryID);
            return View(product);
        }

        // GET: Admin/Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.ProductID == id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            if (product == null)
            {
                return NotFound();
            }

            return Ok();
        }

        // POST: Admin/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Products == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Products'  is null.");
            }
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return (_context.Products?.Any(e => e.ProductID == id)).GetValueOrDefault();
        }



    }
}
