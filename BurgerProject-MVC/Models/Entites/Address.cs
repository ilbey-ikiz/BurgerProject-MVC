namespace BurgerProject_MVC_G4.Models.Entites
{
    public class Address
    {
        public Address()
        {
            Orders = new List<Order>();
        }
        public string AddressDescription { get; set; }
        public int AddressID { get; set; }
        public int AppUserID { get; set; }
        public AppUser? AppUser { get; set; }
        public ICollection<Order>? Orders { get; set; }

    }
}
