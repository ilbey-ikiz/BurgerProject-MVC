using BurgerProject_MVC_G4.Models.Entites;

namespace BurgerProject_MVC_G4.Models.ViewModels
{
    public class ProductDetailVM
    {
        public ICollection<Product> Product { get; set; }
        public ICollection<Garniture> AllGarnitures { get; set; }
        public ICollection<Garniture> ProductGarnitures { get; set; }
    }
}
