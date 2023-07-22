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
using System.Data;
using BurgerProject_MVC_G4.Repository.Abstract;

namespace BurgerProject_MVC_G4.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IOrderRepository orderRepository;

        public OrdersController(ApplicationDbContext context , IOrderRepository orderRepository)
        {
            _context = context;
            this.orderRepository = orderRepository;
        }
        public async Task<IActionResult> Index()
        {
            ICollection<Order> orders= orderRepository.GetAllOrders();
            List<AppUser> users = new List<AppUser>();

            foreach (var order in orders)
            {
                foreach (var card in order.Carts)
                {
                    users.Add(card.AppUser);
                    break;
                }
            }
            var data = (orders, users);
            return View(data);
        }
        
    }
}
