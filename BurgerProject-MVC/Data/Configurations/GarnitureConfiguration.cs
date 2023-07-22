using BurgerProject_MVC_G4.Models.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BurgerProject_MVC_G4.Data.Configurations
{
    public class GarnitureConfiguration : IEntityTypeConfiguration<Garniture>
    {
        public void Configure(EntityTypeBuilder<Garniture> builder)
        {
            builder.HasData(
                new Garniture { GarnitureID = 1, GarnitureName = "Tomatoes" },
                new Garniture { GarnitureID = 2, GarnitureName = "Ketchup" },
                new Garniture { GarnitureID = 3, GarnitureName = "Mayonnaise" },
                new Garniture { GarnitureID = 4, GarnitureName = "Barbeque" },
                new Garniture { GarnitureID = 5, GarnitureName = "Lettuce" },
                new Garniture { GarnitureID = 6, GarnitureName = "Onion" },
                new Garniture { GarnitureID = 7, GarnitureName = "Cheese" }
                );
        }
    }
}
