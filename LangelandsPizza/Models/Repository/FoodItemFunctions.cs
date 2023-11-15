using LangelandsPizza.Models;
using LangelandsPizza.Models.Dbfiles;
using LangelandsPizza.Models.Interfaces;
using LangelandsPizza.Models.ShopingCart;
using Microsoft.EntityFrameworkCore;

namespace LangelandsPizza.Models.Repository
{
    public class FoodItemFunctions : IFoodItem
    {

        private readonly AppDbContext _context;

        public FoodItemFunctions(AppDbContext context)
        {
            _context = context;    
        }
        public List<FoodItem> GetFoodItems()
        {
            return _context.FoodItems.Include(c => c.Category).ToList();
        }
    }
}

