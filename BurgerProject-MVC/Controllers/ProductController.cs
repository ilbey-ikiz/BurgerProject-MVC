using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BurgerProject_MVC_G4.Data;
using BurgerProject_MVC_G4.Models.Entites;
using BurgerProject_MVC_G4.Repository.Abstract;
using Uygulama2106.Repository.Abstract;
using BurgerProject_MVC_G4.Models.ViewModels;
using System.Drawing.Printing;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace BurgerProject_MVC_G4.Controllers
{
    public class ProductController : Controller
    {
        private readonly UserManager<AppUser> userManager;

        public IProductRepository ProductRepository { get; }
        public IMenuRepository menuRepository { get; }
        public ApplicationDbContext Context { get; }

        public ProductController(IProductRepository productRepository, IMenuRepository menuRepository, ApplicationDbContext context, UserManager<AppUser> userManager)
        {
            ProductRepository = productRepository;
            this.menuRepository = menuRepository;
            Context = context;
            this.userManager = userManager;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            return View();
        }
        public async Task<IActionResult> ProductList(int id)
        {
            ProductDetailVM detailVM = new ProductDetailVM();

            if (id == 1)
            {
                detailVM.Product = await ProductRepository.GetHamburgerListAsync();
                detailVM.AllGarnitures = Context.Garnitures.ToList();
            }

            else if (id == 2)
                detailVM.Product = await ProductRepository.GetPotatoesListAsync();
            else if (id == 3)
                detailVM.Product = await ProductRepository.GetSaucesListAsync();
            else if (id == 4)
                detailVM.Product = await ProductRepository.GetBeveragesListAsync();
            else if (id == 5)
                detailVM.Product = await ProductRepository.GetExtrasListAsync();

            return PartialView("_ProductsPartial", detailVM);
        }

        public async Task<IActionResult> MenuList()
        {
            MenuDetailVM detailVM = new MenuDetailVM();
            detailVM.Menus = await menuRepository.GetMenuInculedeGarnituresAsync();
            detailVM.Sauces = Context.Products.Where(s => s.CategoryID == 3).ToList();
            detailVM.Potatoes = Context.Products.Where(s => s.CategoryID == 2).ToList();
            detailVM.Beverages = Context.Products.Where(s => s.CategoryID == 4).ToList();
            detailVM.Extras = Context.Products.Where(s => s.CategoryID == 5).ToList();
            return PartialView("_MenusPartial", detailVM);
        }


        public async Task<IActionResult> AddMenuAsCard(int BeverageID, int PotatoID, decimal Price, int Sauce1, int Sauce2, int[] BurgerID, int[] ExtraID, int quantity , int MenuID)
        {
            if (User.Identity.Name != null)
            {
                AppUser user = await userManager.FindByNameAsync(User.Identity.Name);

                List<int> Products = new List<int> { BeverageID, PotatoID, Sauce1, Sauce2, };
                foreach (var item in BurgerID)
                {
                    Products.Add(item);
                }
                foreach (var item in ExtraID)
                {
                    Products.Add(item);
                }
                UserMenu userMenu = new UserMenu();
                userMenu.Amount = Price;
                Context.UserMenus.Add(userMenu);
                Context.SaveChanges();
                foreach (var productID in Products)
                {
                    ProductUserMenu productUserMenu = new ProductUserMenu();
                    productUserMenu.ProductID = productID;
                    productUserMenu.UserMenuID = userMenu.UserMenuID;
                    productUserMenu.Amount = 1;
                    Context.ProductsUserMenus.Add(productUserMenu);
                }
                Context.SaveChanges();

                Cart cart = new Cart();
                cart.Active = true;
                cart.AppUserID = user.Id;
                cart.UserMenuID= userMenu.UserMenuID;
                cart.Quantity = quantity;
                cart.MenuID = MenuID;
                Context.Carts.Add(cart);
                Context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("Index");
        }

        public async Task<IActionResult> AddProductAsCard(int quantity , int ProductID)
        {
            if (User.Identity.Name != null)
            {
                AppUser user = await userManager.FindByNameAsync(User.Identity.Name);
                Cart cart = new Cart();
                cart.Active = true;
                cart.AppUserID = user.Id;
                cart.ProductsID = ProductID;
                cart.Quantity= quantity;
                Context.Carts.Add(cart);    
                Context.SaveChanges();
                return View("Index");   
            }
            return RedirectToAction("Index");
        }



    }
}
