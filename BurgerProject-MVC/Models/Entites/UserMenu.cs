namespace BurgerProject_MVC_G4.Models.Entites
{
    public class UserMenu
    {
        public UserMenu()
        {
            Products=new List<ProductUserMenu>();
        }
        public int UserMenuID { get; set; }
        public decimal Amount { get; set; }
        public ICollection<ProductUserMenu>? Products { get; set; }
    }
}
