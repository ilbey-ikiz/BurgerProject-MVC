using BurgerProject_MVC_G4.Data;
using BurgerProject_MVC_G4.Models.Entites;
using BurgerProject_MVC_G4.Repository.Abstract;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BurgerProject_MVC_G4.Controllers
{
    public class BasketController : Controller
    {
        private readonly ICartRepository cartRepository;
        private readonly UserManager<AppUser> userManager;
        private readonly ApplicationDbContext context;
        private readonly IUserRepository userRepository;

        public BasketController(ICartRepository cartRepository, UserManager<AppUser> userManager, ApplicationDbContext context , IUserRepository userRepository )
        {
            this.cartRepository = cartRepository;
            this.userManager = userManager;
            this.context = context;
            this.userRepository = userRepository;
        }
        public async Task<IActionResult> Index()
        {
                AppUser appUser = await userManager.FindByNameAsync(User.Identity.Name);
                var userMenuCarts = cartRepository.GetCartsUserMenuByUserID(appUser.Id);
                var userProductsCarts = cartRepository.GetCartsProductByUserID(appUser.Id);
                var data = (userMenuCarts, userProductsCarts);
                return View(data);
        }

        public async Task<IActionResult>  Checkout(string[] CardMenuIdList ,decimal totalPrice)
        {
            totalPrice = totalPrice / 100;
            AppUser user = await userManager.FindByNameAsync(User.Identity.Name);
            AppUser user2=userRepository.GetUserIncludeAddresses(user.Id);
            
            var data = (user2,CardMenuIdList,totalPrice);
            return View(data);
        }


        public IActionResult OrderConfirm(int addressID , string userMessage , string[] idList  , BurgerProject_MVC_G4.Models.Enum.PaymentMethod paymentMethod ,decimal totalPrice) 
        {
            Order order = new Order();
            order.AddressID = addressID;
            order.UserMassage = userMessage;
            order.PaymentMethod = paymentMethod;
            order.TotalPrice = totalPrice;
            order.OrderDate = DateTime.Now.ToLocalTime();
            foreach (var id in idList)
            {
                Cart card = cartRepository.GetById(int.Parse(id));
                card.Active = false;
                order.Carts.Add(card);

            }
            context.Orders.Add(order);
            context.SaveChanges();
            return RedirectToAction("Index" , "Home");
        }

        public IActionResult DeleteCard(int id)
        {
            Cart cart = cartRepository.GetById(id);
            cart.Active = false;
            context.SaveChanges();
            return RedirectToAction("Index");

        }


    }
}
