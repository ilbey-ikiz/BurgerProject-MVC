using BurgerProject_MVC_G4.Data;
using BurgerProject_MVC_G4.Models.Entites;
using BurgerProject_MVC_G4.Repository.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using Uygulama2106.Repository.Concrete;

namespace BurgerProject_MVC_G4.Repository.Concrete
{
    public class MenuRepository : GenericRepository<Menu>, IMenuRepository
    {
        private readonly ApplicationDbContext dbContext;
        public MenuRepository(ApplicationDbContext dbContext):base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<ICollection<Menu>> GetMenuInculedeGarnituresAsync()
        {
            return await dbContext.Menus.Include(f => f.Products).ThenInclude(p => p.Garnitures).ToListAsync();
        }
        
    }
}
