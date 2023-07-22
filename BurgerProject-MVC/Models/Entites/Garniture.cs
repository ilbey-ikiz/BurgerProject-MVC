namespace BurgerProject_MVC_G4.Models.Entites
{
    public class Garniture
    {
        public Garniture()
        {
            Products = new List<Product>();
        }
        public int GarnitureID { get; set; }
        public string GarnitureName { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
}
