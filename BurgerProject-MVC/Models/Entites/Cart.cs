namespace BurgerProject_MVC_G4.Models.Entites
{
    public class Cart
    {
        public int CartID { get; set; }
        public int AppUserID { get; set; }
        public int Quantity { get; set; }
        public bool Active { get; set; }
        public AppUser? AppUser { get; set; }
        public int? UserMenuID { get; set; }
        public UserMenu? UserMenu { get; set; }
        public int? ProductsID { get; set; }
        public Product? Products { get; set; }
        public int? MenuID { get; set; }
        public Menu? Menu { get; set; }
        public int? OrderID { get; set; }
        public Order? Order { get; set; }
    }
}
