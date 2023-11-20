using LangelandsPizza.Models.Dbfiles;
using LangelandsPizza.Models.Interfaces;
using LangelandsPizza.Models.Repository;
using LangelandsPizza.Models.ShopingCart;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();//gets checksession method to work 
builder.Services.AddScoped(sc => ShopingCart.CheckSession(sc));//gets checksession method to work 
builder.Services.AddSession();
builder.Services.AddTransient<IAllOrders, OrderFunctions>();
builder.Services.AddTransient<IFoodItem, FoodItemFunctions>();

//Authentication
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie(options =>
        {
            options.ExpireTimeSpan = TimeSpan.FromMinutes(30); // Log user out after 30 mins
            options.SlidingExpiration = true;      // extend timespan if user is active
            
        });


var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


    app.UseHttpsRedirection();
    app.UseStaticFiles();

    app.UseRouting();
    app.UseSession();

    app.UseAuthentication();
    app.UseAuthorization();

Dbinitializer.Initializer(app);
Dbinitializer.AddUsers(app);

app.MapControllerRoute(
        name: "default",
        pattern: "{controller=FoodItem}/{action=Index}/{id?}");


app.Run();


