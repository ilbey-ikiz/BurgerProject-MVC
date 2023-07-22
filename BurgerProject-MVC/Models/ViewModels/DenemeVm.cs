using BurgerProject_MVC_G4.Models.Entites;

namespace BurgerProject_MVC_G4.Models.ViewModels
{
    public class DenemeVm
    {
        public Product Product { get; set; }
        public ICollection<Garniture> Garnitures { get; set; }
    }
}
