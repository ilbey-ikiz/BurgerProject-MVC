using BurgerProject_MVC_G4.Models.Enum;

namespace BurgerProject_MVC_G4.Models.Entites
{
    public class Order
    {
        public Order()
        {
            Carts = new List<Cart>();
        }
        public int OrderID { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public string? UserMassage { get; set; }
        public ICollection<Cart>? Carts { get; set; }
        public int AddressID { get; set; }
        public Address? Address { get; set; }
    }
}
