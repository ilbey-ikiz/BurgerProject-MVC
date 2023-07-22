using BurgerProject_MVC_G4.Models.Entites;

namespace BurgerProject_MVC_G4.Models.ViewModels
{
    public class MenuDetailVM
    {
        public ICollection<Menu> Menus { get; set; }
        public ICollection<Product> Burgers { get; set; }
        public ICollection<Product> Potatoes { get; set; }
        public ICollection<Product> Sauces { get; set; }
        public ICollection<Product> Beverages { get; set; }
        public ICollection<Product> Extras { get; set; }
    }
}
