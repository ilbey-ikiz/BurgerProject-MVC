using BurgerProject_MVC_G4.Models.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BurgerProject_MVC_G4.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product { ProductID = 1, ProductName = "Barbeque", Price = 10, CategoryID = 3, CoverImage = "3Barbeque.png" },
                new Product { ProductID = 2, ProductName = "BigKing", Price = 150, CategoryID = 1, CoverImage = "1BigKing.png" },
                new Product { ProductID = 3, ProductName = "BigTasty", Price = 120, CategoryID = 1, CoverImage = "2BigTasty.png" },
                new Product { ProductID = 4, ProductName = "Whooper", Price = 130, CategoryID = 1, CoverImage = "3Whooper.png" },
                new Product { ProductID = 5, ProductName = "Classic", Price = 110, CategoryID = 1, CoverImage = "4Classic.png" },
                new Product { ProductID = 6, ProductName = "Double Quarter", Price = 150, CategoryID = 1, CoverImage = "5DoubleQuarter.png" },
                new Product { ProductID = 7, ProductName = "Cheese Burger", Price = 130, CategoryID = 1, CoverImage = "6CheeseBurger.png" },
                new Product { ProductID = 8, ProductName = "Nugget", Price = 40, CategoryID = 5, CoverImage = "1Nugget.png" },
                new Product { ProductID = 9, ProductName = "Onion Ring", Price = 40, CategoryID = 5, CoverImage = "2OnionRing.png" },
                new Product { ProductID = 10, ProductName = "Schnitzel", Price = 40, CategoryID = 5, CoverImage = "3Schnitzel.png" },
                new Product { ProductID = 11, ProductName = "French Fries", Price = 30, CategoryID = 2, CoverImage = "1FrenchFries.png" },
                new Product { ProductID = 12, ProductName = "Scalloped", Price = 30, CategoryID = 2, CoverImage = "2Scalloped.png" },
                new Product { ProductID = 13, ProductName = "CocaCola", Price = 30, CategoryID = 4, CoverImage = "1CocaCola.png" },
                new Product { ProductID = 14, ProductName = "Fanta", Price = 30, CategoryID = 4, CoverImage = "2Fanta.png" },
                new Product { ProductID = 15, ProductName = "Sprite", Price = 30, CategoryID = 4, CoverImage = "3Sprite.png" },
                new Product { ProductID = 16, ProductName = "Beer", Price = 30, CategoryID = 4, CoverImage = "4Beer.png" },
                new Product { ProductID = 17, ProductName = "Mayonnaise", Price = 10, CategoryID = 3, CoverImage = "1Mayonnaise.png" },
                new Product { ProductID = 18, ProductName = "Ketchup", Price = 10, CategoryID = 3, CoverImage = "2Ketchup.png" }              
                );
        }
    }

}
