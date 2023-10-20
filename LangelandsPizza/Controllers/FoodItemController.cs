using LangelandsPizza.Models;
using LangelandsPizza.Models.Dbfiles;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LangelandsPizza.Controllers
{
    public class FoodItemController : Controller
    {
        //private readonly ICategory _category;
        //private readonly IFoodItem _foodItem;

        //public FoodItemController (ICategory category, IFoodItem foodItem)
        //{
        //    _category = category;
        //    _foodItem = foodItem;
        //}   

        private readonly AppDbContext _category; 
        public FoodItemController (AppDbContext context)
        {
            _category = context;
        }


        public ViewResult Index()
        {
            var food = _category.FoodItems.Include(c => c.Category).ToList();
            return View(food);
        }
    }
}
