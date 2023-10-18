using LangelandsPizza.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LangelandsPizza.Models.Dbfiles
{
    public class Dbinitializer // initializes database if no data is found
    {
        public static void Initializer(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                context.Database.EnsureCreated();

                if (!context.Category.Any())
                {
                    context.AddRange(

                         new Category { Name = "Speciale Pizzaer" },
                         new Category { Name = "Pizzaer med skinke" },
                         new Category { Name = "Mexikanske Pizzaer" }

                        );
                    context.SaveChanges();
                }

                if (!context.FoodItems.Any())
                {
                    context.AddRange(

                        new FoodItem
                        {
                            Name = "Margaritta",
                            Price = 60,
                            CategoryID = 1
                        },
                        new FoodItem
                        {
                            Name = "Bogdans Pizza",
                            Price = 120,
                            CategoryID = 2
                        },

                        new FoodItem
                        {
                            Name = "Mexico Special",
                            Price = 120,
                            CategoryID = 3
                        }

                        ) ;
                    context.SaveChanges();
                }
            }
        } 

        //public static Dictionary<string, Category> category;
        //public static Dictionary<string, Category> Categories
        //{
        //    get
        //    {
        //        if (category == null)
        //        {
        //            var list = new Category[]
        //            {
        //                 new Category {Name = "Speciale Pizzaer"},
        //                 new Category { Name = "Pizzaer med skinke" },
        //                 new Category { Name = "Mexikanske Pizzaer"}
        //            };

        //            category = new Dictionary<string, Category>();
        //            foreach (Category element in list)
        //            {
        //                category.Add(element.Name, element);
        //            }
        //        }

        //        return category;
        //    }
        //}

    }

}
