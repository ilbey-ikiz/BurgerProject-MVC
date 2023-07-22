namespace BurgerProject_MVC_G4.Models.Entites
{
    public class ProductUserMenu
    {
        public int ProductUserMenuID { get; set; }
        public int Amount { get; set; }
        public int ProductID { get; set; }
        public int UserMenuID { get; set; }
        public UserMenu? UserMenu { get; set; }
        public Product? Product { get; set; }
    }
}
