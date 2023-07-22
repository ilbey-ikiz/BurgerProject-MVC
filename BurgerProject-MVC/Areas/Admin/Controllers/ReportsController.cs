using BurgerProject_MVC_G4.Models.Entites;
using BurgerProject_MVC_G4.Repository.Abstract;
using BurgerProject_MVC_G4.Repository.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace BurgerProject_MVC_G4.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ReportsController : Controller
    {
        private readonly IOrderRepository orderRepository;
        private readonly IProductRepository productRepository;
        private readonly IMenuRepository menuRepository;

        public ReportsController(IOrderRepository orderRepository , IProductRepository productRepository , IMenuRepository menuRepository)
        {
            this.orderRepository = orderRepository;
            this.productRepository = productRepository;
            this.menuRepository = menuRepository;
        }
        public IActionResult Index()
        {
            var sayi = orderRepository.TodayMoneyEarned();
            var sayi1 = orderRepository.WeeklyMoneyEarned();
            var sayi2 = orderRepository.MonthlyMoneyEarned();
            var sayi3 = orderRepository.TotalMoneyEarned();
            var data = (sayi, sayi1, sayi2, sayi3);
            return View(data);
        }

        public IActionResult ProductSalesReport()
        {
            var products =productRepository.GetAllProductIncluCategory();
            return PartialView("_ProductsSalesReportPartial" , products);
        }

        public IActionResult MenuSalesReport()
        {
            var menus = menuRepository.GetAll().ToList();
            return PartialView("_MenuSalesReportPartial", menus);
        }


    }
}
