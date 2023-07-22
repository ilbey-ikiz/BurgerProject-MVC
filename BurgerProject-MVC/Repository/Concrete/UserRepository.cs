using BurgerProject_MVC_G4.Data;
using BurgerProject_MVC_G4.Models.Entites;
using BurgerProject_MVC_G4.Repository.Abstract;
using Microsoft.EntityFrameworkCore;
using Uygulama2106.Repository.Concrete;

namespace BurgerProject_MVC_G4.Repository.Concrete
{
    public class UserRepository : GenericRepository<AppUser> , IUserRepository
    {
        private readonly ApplicationDbContext dbContext;
        public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public AppUser GetUserIncludeAddresses(int id)
        {
            return dbContext.AppUsers.Include(s => s.Addresses).FirstOrDefault(s => s.Id == id);
        }

    }
}
