using BurgerProject_MVC_G4.Data;
using BurgerProject_MVC_G4.Models.Entites;
using BurgerProject_MVC_G4.Repository.Abstract;
using Uygulama2106.Repository.Concrete;

namespace BurgerProject_MVC_G4.Repository.Concrete
{
    public class GarnitureRepository:GenericRepository<Garniture>, IGarnitureRepository
    {
        private readonly ApplicationDbContext dbContext;
        public GarnitureRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
