
using LangelandsPizza.Models.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LangelandsPizza.Models.Dbfiles
{
    public class Dbinitializer // initializes data in database if no data is found
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

                        );
                    context.SaveChanges();
                }
            }



        }

        public static async void AddUsers(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                //Creating roles
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Creating Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

                var workerUser = await userManager.FindByEmailAsync("worker@lglpizza.dk");

                if (workerUser == null)
                {
                    var newWorkerUser = new IdentityUser()
                    {
                        UserName = "worker",
                        Email = "worker@lglpizza.dk",
                        EmailConfirmed = true

                    };

                    await userManager.CreateAsync(newWorkerUser, "Kode3453%");
                    await userManager.AddToRoleAsync(newWorkerUser, UserRoles.User);



                }







            }
        }
    }
}
