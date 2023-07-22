using BurgerProject_MVC_G4.Models.Entites;
using Uygulama2106.Repository.Abstract;

namespace BurgerProject_MVC_G4.Repository.Abstract
{
    public interface IOrderRepository : IRepository<Order>
    {
        public ICollection<Order> GetUserOrders(int id);
        public ICollection<Order> GetAllOrders();
        public decimal MonthlyMoneyEarned();
        public decimal WeeklyMoneyEarned();
        public decimal TodayMoneyEarned();
        public decimal TotalMoneyEarned();
        public int TotalSalesOfTheProduct(int id);
        public int TotalSalesOfTheMenu(int id);
    }
}
