using Microsoft.AspNetCore.Identity;

namespace BurgerProject_MVC_G4.Models.Entites
{
    public class AppUser : IdentityUser<int>
    {
        public AppUser()
        {
            Carts = new List<Cart>();
            Addresses = new List<Address>();
        }
        public string Name { get; set; }
        public string Surname { get; set; }
        public ICollection<Cart>? Carts { get; set; }
        public ICollection<Address>? Addresses { get; set; }
    }
}
