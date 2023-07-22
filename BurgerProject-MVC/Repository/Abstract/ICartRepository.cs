using BurgerProject_MVC_G4.Models.Entites;
using Uygulama2106.Repository.Abstract;

namespace BurgerProject_MVC_G4.Repository.Abstract
{
    public interface ICartRepository : IRepository<Cart>
    {
        public ICollection<Cart> GetCartsProductByUserID(int id);
        public ICollection<Cart> GetCartsUserMenuByUserID(int id);
        public int GetUserActiveCardCount(string name);
    }
}
