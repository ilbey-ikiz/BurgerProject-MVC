namespace BurgerProject_MVC_G4.Models.Entites
{
    public class Product
    {
        public Product()
        {
            Menus=new List<Menu>();
            UserMenus = new List<ProductUserMenu>();
            Garnitures = new List<Garniture>();
        }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string? CoverImage { get; set; }
        public ICollection<Menu>? Menus { get; set; }
        public ICollection<ProductUserMenu>? UserMenus { get; set; }
        public ICollection<Garniture>? Garnitures { get; set; }
        public int CategoryID { get; set; }
        public Category? Category { get; set; }

    }
}
