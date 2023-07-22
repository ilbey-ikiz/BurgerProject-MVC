using BurgerProject_MVC_G4.Models.Entites;

namespace BurgerProject_MVC_G4.Models.ViewModels
{
    public class MenuSelectVM
    {
        public Menu Menu { get; set; }
        public ICollection<Product> Sauces { get; set; }
        public ICollection<Product> Beverages { get; set; }
        public ICollection<Product> Extras { get; set; }
    }
}
