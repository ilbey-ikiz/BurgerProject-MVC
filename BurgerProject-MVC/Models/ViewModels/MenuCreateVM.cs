using BurgerProject_MVC_G4.Models.Entites;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BurgerProject_MVC_G4.Models.ViewModels
{
    public class MenuCreateVM
    {
        public Menu Menu { get; set; }
        public ICollection<Product> Hamburgers { get; set; }
        public ICollection<Product> Sauces { get; set; }
        public ICollection<Product> Beverages { get; set; }
        public ICollection<Product> Potatoes { get; set; }
        public ICollection<Product> Extras { get; set; }
    }
}
