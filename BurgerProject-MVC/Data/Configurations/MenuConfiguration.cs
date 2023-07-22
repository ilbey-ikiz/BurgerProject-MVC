using BurgerProject_MVC_G4.Models.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BurgerProject_MVC_G4.Data.Configurations
{
    public class MenuConfiguration : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            builder.HasData(
                new Menu { MenuID = 1, MenuName = "BigKing Menu", SmallPrice = 190, MiddlePrice = 210, BigPrice = 230, CoverImage = "1BigKingMenu.png" },
                new Menu { MenuID = 2, MenuName = "BigTasty Menu", SmallPrice = 160, MiddlePrice = 180, BigPrice = 200, CoverImage = "2BigTastyMenu.png"},
                new Menu { MenuID = 3, MenuName = "Whooper Menu", SmallPrice = 170, MiddlePrice = 190, BigPrice = 210, CoverImage = "3WhooperMenu.png" },
                new Menu { MenuID = 4, MenuName = "Classic Menu", SmallPrice = 150, MiddlePrice = 170, BigPrice = 190, CoverImage = "4ClassicMenu.png" },
                new Menu { MenuID = 5, MenuName = "Double Quarter Menu", SmallPrice = 190, MiddlePrice = 210, BigPrice = 230, CoverImage = "5DoubleQuarterMenu.png" },
                new Menu { MenuID = 6, MenuName = "Cheese Burger Menu", SmallPrice = 170, MiddlePrice = 190, BigPrice = 210, CoverImage = "6CheeseBurgerMenu.png" }           
                );
        }
    }
}
