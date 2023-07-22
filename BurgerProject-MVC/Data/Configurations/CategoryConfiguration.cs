using BurgerProject_MVC_G4.Models.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BurgerProject_MVC_G4.Data.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                new Category { CategoryID = 1, CategoryName = "Burger" },
                new Category { CategoryID = 2, CategoryName = "Potatoes" },
                new Category { CategoryID = 3, CategoryName = "Sauce" },
                new Category { CategoryID = 4, CategoryName = "Beverage" },
                new Category { CategoryID = 5, CategoryName = "Extra" });
        }
    }
}
