using BurgerProject_MVC_G4.Data;
using BurgerProject_MVC_G4.Models.Entites;
using BurgerProject_MVC_G4.Models.ViewModels;
using BurgerProject_MVC_G4.Repository.Abstract;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Uygulama2106.Repository.Abstract;

namespace BurgerProject_MVC_G4.Controllers
{
    public class UserSettingsController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly IUserRepository userRepository;
        private readonly IRepository<Address> addresRepository;
        private readonly IOrderRepository orderRepository;

        public UserSettingsController(UserManager<AppUser> userManager, IUserRepository userRepository, IRepository<Address> addresRepository , IOrderRepository orderRepository)
        {
            this.userManager = userManager;
            this.userRepository = userRepository;
            this.addresRepository = addresRepository;
            this.orderRepository = orderRepository;
        }
        public async Task<IActionResult> Index()
        {
            AppUser user = await userManager.FindByNameAsync(User.Identity.Name);
            return View(user);
        }

        public async Task<IActionResult> UserInformation()
        {
            AppUser user = await userManager.FindByNameAsync(User.Identity.Name);
            return PartialView("_UserInformationPartial2", user);
        }

        public async Task<IActionResult> UserPasswordChange()
        {
            AppUser user = await userManager.FindByNameAsync(User.Identity.Name);
            return PartialView("_UserPasswordChange", user);
        }
        public async Task<IActionResult> UserAddressChange()
        {
            AppUser user = await userManager.FindByNameAsync(User.Identity.Name);
            user = userRepository.GetUserIncludeAddresses(user.Id);
            return PartialView("_UserAddressChange", user);
        }
        public async Task<IActionResult> OrderHistory()
        {
            AppUser user = await userManager.FindByNameAsync(User.Identity.Name);
            ICollection<Order> orders = orderRepository.GetUserOrders(user.Id);
            var data = (user, orders);
            return PartialView("_OrderHistoryPartial" , data);
        }

        [HttpPost]
        public async Task<IActionResult> SaveUserInformation(UserInformationUpdateVM userInformation)
        {
            AppUser user = await userManager.FindByNameAsync(User.Identity.Name);
            user.Name = userInformation.Name;
            user.Surname = userInformation.Surname;
            user.PhoneNumber = userInformation.PhoneNumber;
            user.Email = userInformation.EMail;
            user.UserName = userInformation.EMail;
            userManager.UpdateAsync(user);

            return View("Index");
        }
        [HttpPost]
        public async Task<IActionResult> UpdateUserPassword(string password, string newPassword, string confirmPassword)
        {
            AppUser user = await userManager.FindByNameAsync(User.Identity.Name);

            bool isPasswordCorrect = await userManager.CheckPasswordAsync(user, password);


            if (isPasswordCorrect && newPassword == confirmPassword)
            {
                user.PasswordHash = userManager.PasswordHasher.HashPassword(user, newPassword);
                await userManager.UpdateAsync(user);
                return RedirectToAction("Index");
            }
            else if (!isPasswordCorrect)
            {
                return BadRequest("Mevcut şifre yanlış.");
            }
            else
            {
                return BadRequest("Yeni şifreler uyuşmuyor.");
            }
        }

        public IActionResult DeleteAddress(int id)
        {
            addresRepository.Delete(addresRepository.GetById(id));
            return Ok();
        }

        [HttpPost]
        public IActionResult UpdateAddress(int id , string description)
        {
            Address address= addresRepository.GetById(id);
            address.AddressDescription = description;
            addresRepository.Update(address);
            return Ok();
        }

        public IActionResult AddAddress(string newAddress, int id)
        {
            Address address = new Address();
            address.AddressDescription = newAddress;
            address.AppUserID = id;
            addresRepository.Add(address);

            string[] data = new string[] { address.AddressID.ToString(), address.AddressDescription };
            return Json(data);
        }


    }


}
