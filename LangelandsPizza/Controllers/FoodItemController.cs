using LangelandsPizza.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LangelandsPizza.Controllers
{
    public class FoodItemController : Controller
    {
        private readonly ICategory _category;
        private readonly IFoodItem _foodItem;

        public FoodItemController (ICategory category, IFoodItem foodItem)
        {
            _category = category;
            _foodItem = foodItem;
        }   

        public ViewResult List()
        {
            var food = _foodItem.GetFoodItems();
            return View(food);
        }
    }
}
