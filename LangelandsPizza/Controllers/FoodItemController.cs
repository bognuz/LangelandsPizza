using LangelandsPizza.Models;
using LangelandsPizza.Models.Dbfiles;
using LangelandsPizza.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LangelandsPizza.Controllers
{
    public class FoodItemController : Controller
    {
        
        private readonly IFoodItem _foodItem;

        public FoodItemController(IFoodItem foodItem)
        {
            
            _foodItem = foodItem;
        }




        public ViewResult Index()
        {
            var food = _foodItem.GetFoodItems();
            return View(food);
        }
    }
}
