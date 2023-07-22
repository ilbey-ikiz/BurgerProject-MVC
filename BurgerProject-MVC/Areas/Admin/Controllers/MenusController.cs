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
    public class MenusController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MenusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Menus
        public async Task<IActionResult> Index()
        {
            return _context.Menus != null ?
                        View(await _context.Menus.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.Menus'  is null.");
        }

        // GET: Admin/Menus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Menus == null)
            {
                return NotFound();
            }

            var menu = await _context.Menus
                .FirstOrDefaultAsync(m => m.MenuID == id);
            if (menu == null)
            {
                return NotFound();
            }

            return View(menu);
        }

        // GET: Admin/Menus/Create
        public IActionResult Create()
        {
            Menu menu = new();
            ViewBag.Hamburgers = new SelectList(_context.Products.Where(x => x.CategoryID == 1).ToList(), "ProductID", "ProductName");

            ViewBag.Potatoes = new SelectList(_context.Products.Where(x => x.CategoryID == 2).ToList(), "ProductID", "ProductName");


            ViewBag.Sauces = new SelectList(_context.Products.Where(x => x.CategoryID == 3).ToList(), "ProductID", "ProductName");

            ViewBag.Beverages = new SelectList(_context.Products.Where(x => x.CategoryID == 4).ToList(), "ProductID", "ProductName");

            ViewBag.Extras = new SelectList(_context.Products.Where(x => x.CategoryID == 5).ToList(), "ProductID", "ProductName");


            return View(menu);
        }

        // POST: Admin/Menus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MenuID,MenuName,SmallPrice,MiddlePrice,BigPrice,CoverImage")] Menu menu, string[] products, IFormFile ImageName)
        {
            ModelState.Remove("ImageName");

            if (ModelState.IsValid)
            {
                if (ImageName!=null)
                {

                _context.Menus.Add(menu);

                Guid guid = Guid.NewGuid();
                string newFileName = guid.ToString() + "_" + ImageName.FileName;
                menu.CoverImage = newFileName;

                FileStream fs = new FileStream("wwwroot/MenuImages/" + newFileName, FileMode.Create);

                await ImageName.CopyToAsync(fs);
                }


                foreach (var productsId in products)
                {
                    Product product = _context.Products.FirstOrDefault(x => x.ProductID == int.Parse(productsId));
                    menu.Products.Add(product);

                }
                _context.Add(menu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));


            }
            return View(menu);
        }

        // GET: Admin/Menus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menu = await _context.Menus.Include(x => x.Products).FirstOrDefaultAsync(x => x.MenuID == id);
            if (menu == null)
            {
                return NotFound();
            }

            var viewModel = new MenuCreateVM
            {
                Menu = menu,
                Hamburgers = await GetProductSelectListAsync("Burger"),
                Sauces = await GetProductSelectListAsync("Sauce"),
                Beverages = await GetProductSelectListAsync("Beverage"),
                Potatoes = await GetProductSelectListAsync("Potatoes"),
                Extras = await GetProductSelectListAsync("Extra")
            };

            return View(viewModel);
        }

        private async Task<List<Product>> GetProductSelectListAsync(string category)
        {
            var products = await _context.Products.Where(p => p.Category.CategoryName == category).ToListAsync();
            return products;
        }

        // POST: Admin/Menus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MenuID,MenuName,SmallPrice,MiddlePrice,BigPrice,CoverImage")] Menu menu, string[] IdList, IFormFile ImageName)
        {

           Menu menu1= await _context.Menus.Include(x=>x.Products).FirstOrDefaultAsync(x=>x.MenuID==menu.MenuID);
            menu1.MenuName = menu.MenuName;
            menu1.MiddlePrice = menu.MiddlePrice;
            menu1.SmallPrice = menu.SmallPrice;
            menu1.BigPrice = menu.BigPrice;
            List<Product> products = new List<Product>();
          
            foreach (var productsId in IdList)
            {
                Product product = _context.Products.FirstOrDefault(x => x.ProductID == int.Parse(productsId));
                products.Add(product);
            }
            menu1.Products = products;
            if (id != menu.MenuID)
            {
                return NotFound();
            }
            ModelState.Remove("ImageName");
            ModelState.Remove("menu.Carts");
            if (ModelState.IsValid)
            {
                _context.Menus.Add(menu1);
                if (ImageName!=null)
                {

                Guid guid = Guid.NewGuid();
                string newFileName = guid.ToString() + "_" + ImageName.FileName;
                menu1.CoverImage = newFileName;

                FileStream fs = new FileStream("wwwroot/MenuImages/" + newFileName, FileMode.Create);

                await ImageName.CopyToAsync(fs);
                }


                try
                {
                    _context.Update(menu1);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MenuExists(menu.MenuID))
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
            return RedirectToAction("Edit", new {id=menu.MenuID});
        }

        // GET: Admin/Menus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Menus == null)
            {
                return NotFound();
            }

            var menu = await _context.Menus
                .FirstOrDefaultAsync(m => m.MenuID == id);
            _context.Menus.Remove(menu);
            await _context.SaveChangesAsync();
            if (menu == null)
            {
                return NotFound();
            }

            return Ok();
        }
        

        private bool MenuExists(int id)
        {
            return (_context.Menus?.Any(e => e.MenuID == id)).GetValueOrDefault();
        }
    }
}
