using BurgerProject_MVC_G4.Models.Entites;
using Humanizer;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Reflection.Emit;

namespace BurgerProject_MVC_G4.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<AppRole> AppRoles { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Garniture> Garnitures { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductUserMenu> ProductsUserMenus { get; set; }
        public DbSet<UserMenu> UserMenus { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            builder.Entity<Cart>().HasKey(x => x.CartID);
            builder.Entity<Category>().HasKey(x => x.CategoryID);
            builder.Entity<Garniture>().HasKey(x => x.GarnitureID);
            builder.Entity<Menu>().HasKey(x => x.MenuID);
            builder.Entity<Order>().HasKey(x => x.OrderID);
            builder.Entity<Product>().HasKey(x => x.ProductID);
            builder.Entity<UserMenu>().HasKey(x => x.UserMenuID);
            builder.Entity<ProductUserMenu>().HasKey(x => x.ProductUserMenuID);
            builder.Entity<Address>().HasKey(x => x.AddressID);

            //builder.Entity<Order>()
            //.HasOne(o => o.Cart)
            //.WithMany()
            //.HasForeignKey(o => o.CartID)
            //.OnDelete(DeleteBehavior.NoAction);

            builder.Entity<AppRole>().HasData(
                new AppRole { Id = 1, Name = "Admin", NormalizedName = "ADMIN" },
                new AppRole { Id = 2, Name = "User", NormalizedName = "USER" }
                );
            base.OnModelCreating(builder);
        }
    }
}