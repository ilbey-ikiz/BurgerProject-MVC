using BurgerProject_MVC_G4.Models.Entites;
using Microsoft.EntityFrameworkCore;
using Uygulama2106.Repository.Abstract;

namespace BurgerProject_MVC_G4.Repository.Abstract
{
    public interface IProductRepository : IRepository<Product> 
    {

        public  Task<ICollection<Product>> GetHamburgerListAsync();


        public Task<ICollection<Product>> GetBeveragesListAsync();

        public Task<ICollection<Product>> GetPotatoesListAsync();


        public Task<ICollection<Product>> GetSaucesListAsync();


        public Task<ICollection<Product>> GetExtrasListAsync();

        public Task<Product> GetProductById(int id);
        public List<Product> GetAllProductIncluCategory();

    }
}
