using BurgerProject_MVC_G4.Data;
using BurgerProject_MVC_G4.Models.Entites;
using BurgerProject_MVC_G4.Repository.Abstract;
using Microsoft.EntityFrameworkCore;
using Uygulama2106.Repository.Concrete;

namespace BurgerProject_MVC_G4.Repository.Concrete
{
    public class CartRepository:GenericRepository<Cart> , ICartRepository
    {
        private readonly ApplicationDbContext dbContext;
        public CartRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public ICollection<Cart> GetCartsUserMenuByUserID(int id)
        {
                return dbContext.Carts
                    .Include(c => c.UserMenu) 
                    .Include(c => c.Menu) 
                    .Where(s => s.AppUserID == id && s.Active == true && s.ProductsID==null)
                    .ToList();
            
        }

        public ICollection<Cart> GetCartsProductByUserID(int id)
        {
            return dbContext.Carts.Include(s=>s.Products).ThenInclude(p=> p.Category).Where(s=> s.AppUserID==id && s.Active==true && s.UserMenuID==null).ToList();
        }

        public int GetUserActiveCardCount(string name)
        {
            AppUser user =dbContext.AppUsers.FirstOrDefault(d => d.UserName == name);
            return GetCartsProductByUserID(user.Id).Count + GetCartsUserMenuByUserID(user.Id).Count;
        }

    }
}
