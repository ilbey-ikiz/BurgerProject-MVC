namespace BurgerProject_MVC_G4.Models.Entites
{
    public class Menu
    {
        public Menu()
        {
            Products = new List<Product>();
        }
        public int MenuID { get; set; }
        public string MenuName { get; set; }
        public decimal? SmallPrice { get; set; }
        public decimal? MiddlePrice { get; set; }
        public decimal? BigPrice { get; set; }
        public string? CoverImage { get; set; }
        public ICollection<Product>? Products { get; set; }
        public ICollection<Cart> Carts { get; set; }

    }
}
