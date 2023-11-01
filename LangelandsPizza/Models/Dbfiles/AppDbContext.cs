using LangelandsPizza.Models.ShopingCart;
using Microsoft.EntityFrameworkCore;

namespace LangelandsPizza.Models.Dbfiles
{
    public class AppDbContext : DbContext
    {
        //files bruges som mellemled mellem database og models. 
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<FoodItem> FoodItems { get; set; }
        public DbSet<Category> Category { get; set; }   

        public DbSet<ShopingCartItem> ShopingCartItem { get; set; }

    }
}
