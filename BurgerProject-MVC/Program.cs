using BurgerProject_MVC_G4;
using BurgerProject_MVC_G4.Data;
using BurgerProject_MVC_G4.Models;
using BurgerProject_MVC_G4.Models.Entites;
using BurgerProject_MVC_G4.Repository.Abstract;
using BurgerProject_MVC_G4.Repository.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Uygulama2106.Repository.Abstract;
using Uygulama2106.Repository.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("ConnStr");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
//builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddSession(x => x.IdleTimeout = TimeSpan.FromSeconds(300));

builder.Services.AddIdentity<AppUser, AppRole>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<AppRole>() 
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddTransient<IProductRepository,ProductRepository>();
builder.Services.AddTransient<IMenuRepository,MenuRepository>();
builder.Services.AddTransient<ICartRepository,CartRepository>();
builder.Services.AddTransient<IUserRepository,UserRepository>();
builder.Services.AddTransient<IOrderRepository,OrderRepository>();
builder.Services.AddTransient(typeof(IRepository<>), typeof(GenericRepository<>));

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.UseSession();


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

var scope = app.Services.CreateScope();
var userManager = (UserManager<AppUser>)scope.ServiceProvider.GetService(typeof(UserManager<AppUser>));
ForLogin.AddSuperUserAsync(userManager);

app.Run();
