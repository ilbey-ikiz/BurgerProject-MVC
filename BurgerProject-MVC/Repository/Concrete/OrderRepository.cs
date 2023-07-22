using BurgerProject_MVC_G4.Data;
using BurgerProject_MVC_G4.Models.Entites;
using BurgerProject_MVC_G4.Repository.Abstract;
using Microsoft.EntityFrameworkCore;
using Uygulama2106.Repository.Concrete;

namespace BurgerProject_MVC_G4.Repository.Concrete
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        private readonly ApplicationDbContext dbContext;
        public OrderRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public ICollection<Order> GetUserOrders(int id)
        {
            return dbContext.Orders.Include(s => s.Address).Include(s => s.Carts).ThenInclude(s => s.Menu).Include(s => s.Carts).ThenInclude(s => s.UserMenu).ThenInclude(s => s.Products).ThenInclude(s => s.Product).Include(s => s.Carts).ThenInclude(s => s.Products).Where(s => s.Carts.Any(p => p.AppUserID == id && p.Active == false)).ToList();
        }

        public ICollection<Order> GetAllOrders()
        {
            return dbContext.Orders.Include(s => s.Address).Include(s => s.Carts).ThenInclude(s => s.AppUser).Include(s => s.Carts).ThenInclude(s => s.Menu).Include(s => s.Carts).ThenInclude(s => s.UserMenu).ThenInclude(s => s.Products).ThenInclude(s => s.Product).Include(s => s.Carts).ThenInclude(s => s.Products).Where(s => s.Carts.Any(p => p.Active == false)).ToList();
        }

        public decimal TotalMoneyEarned()
        {
            decimal money = 0;
            var orders = dbContext.Orders.ToList();
            foreach (var order in orders)
            {
                money += order.TotalPrice;
            }
            return money;
        }

        public decimal MonthlyMoneyEarned()
        {
            decimal money = 0;
            var orders = dbContext.Orders.Where(s => s.OrderDate > DateTime.Now.AddMonths(-1)).ToList();
            foreach (var order in orders)
            {
                money += order.TotalPrice;
            }
            return money;
        }

        public decimal WeeklyMoneyEarned()
        {
            decimal money = 0;
            var orders = dbContext.Orders.Where(s => s.OrderDate > DateTime.Now.AddDays(-7)).ToList();
            foreach (var order in orders)
            {
                money += order.TotalPrice;
            }
            return money;
        }

        public decimal TodayMoneyEarned()
        {
            decimal money = 0;
            var orders = dbContext.Orders.Where(s => s.OrderDate > DateTime.Now.AddDays(-1)).ToList();
            foreach (var order in orders)
            {
                money += order.TotalPrice;
            }
            return money;
        }

        public int TotalSalesOfTheProduct(int id)
        {
            int number = 0;
            var orders = dbContext.Orders.Include(s => s.Carts).ThenInclude(s => s.Menu).Include(s => s.Carts).ThenInclude(s => s.UserMenu).ThenInclude(s => s.Products).Include(s => s.Carts).ThenInclude(s => s.Products).Where(s => s.Carts.Any(p => p.Active == false)).ToList();

            foreach (var order in orders)
            {

                foreach (var card in order.Carts)
                {
                    if (card.UserMenu == null)
                    {
                        if (card.ProductsID == id)
                            number++;
                    }
                }

                foreach (var card2 in order.Carts)
                {
                    if (card2.UserMenu != null)
                    {
                        foreach (var product in card2.UserMenu.Products)
                        {
                            if(product.ProductID==id)
                                number++;
                        }
                    }
                }
            }
            return number;
        }

        public int TotalSalesOfTheMenu(int id)
        {
            int totalSales = 0;
            var orders = dbContext.Orders.Include(s => s.Carts).ThenInclude(s => s.Menu).ToList();
            foreach (var order in orders)
            {
                foreach (var card in order.Carts)
                {
                    if (card.MenuID != null && card.MenuID==id)
                    {
                        totalSales++;
                    }
                }
            }
            return totalSales;
        }


    }
}
