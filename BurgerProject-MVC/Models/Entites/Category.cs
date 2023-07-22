namespace BurgerProject_MVC_G4.Models.Entites
{
    public class Category
    {
        public Category()
        {
            Products = new List<Product>();
        }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
}
