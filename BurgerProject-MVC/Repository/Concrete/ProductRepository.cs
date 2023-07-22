using BurgerProject_MVC_G4.Data;
using BurgerProject_MVC_G4.Models.Entites;
using BurgerProject_MVC_G4.Repository.Abstract;
using Microsoft.EntityFrameworkCore;
using Uygulama2106.Repository.Concrete;

namespace BurgerProject_MVC_G4.Repository.Concrete
{
    public class ProductRepository :GenericRepository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext dbContext;
        public ProductRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }


        public async Task<ICollection<Product>> GetHamburgerListAsync()
        {
            return await dbContext.Products.Include(s=>s.Garnitures).Where(d=>d.CategoryID==1).ToListAsync();
        }

        public async Task<ICollection<Product>> GetBeveragesListAsync()
        {
            return await dbContext.Products.Where(d => d.CategoryID == 4).ToListAsync();
        }

        public async Task<ICollection<Product>> GetPotatoesListAsync()
        {
            return await dbContext.Products.Where(d => d.CategoryID == 2).ToListAsync();
        }

        public async Task<ICollection<Product>> GetSaucesListAsync()
        {
            return await dbContext.Products.Where(d => d.CategoryID == 3).ToListAsync();
        }

        public async Task<ICollection<Product>> GetExtrasListAsync()
        {
            return await dbContext.Products.Where(d => d.CategoryID == 5).ToListAsync();
        }

        public async Task<Product> GetProductById(int id)
        {
            return await dbContext.Products.FirstOrDefaultAsync(d => d.ProductID == id);
        }

        public List<Product> GetAllProductIncluCategory()
        {
            return dbContext.Products.Include(d => d.Category).ToList();
        }





    }
}
