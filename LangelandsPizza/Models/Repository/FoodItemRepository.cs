using LangelandsPizza.Models.Dbfiles;
using LangelandsPizza.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LangelandsPizza.Models.Repository
{
    public class FoodItemRepository : IFoodItem
    {
        private readonly AppDbContext appDbConctext;

        public FoodItemRepository(AppDbContext appDbConctext)
        {
            this.appDbConctext = appDbConctext;
        }

        public IEnumerable<FoodItem> GetFoodItems() => appDbConctext.FoodItems.Include(c => c.Category);
       
    }
}
