using LangelandsPizza.Models.Order;
using LangelandsPizza.Models.ShopingCart;
using Microsoft.EntityFrameworkCore;
using System.Runtime.ConstrainedExecution;

namespace LangelandsPizza.Models.Dbfiles
{
    public class AppDbContext : DbContext
    {
        //fil bruges som mellemled mellem database og models. 
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<FoodItem> FoodItems { get; set; }
        public DbSet<Category> Category { get; set; }   

        public DbSet<ShopingCartItem> ShopingCartItem { get; set; }


        public DbSet<Order.Order> Order { get; set; }
        public DbSet<OrderItem> OrderItem { get; set;  }

        

    }
}
