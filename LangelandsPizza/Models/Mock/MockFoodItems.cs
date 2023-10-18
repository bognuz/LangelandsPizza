using LangelandsPizza.Models.Interfaces;
using System.Runtime.CompilerServices;

namespace LangelandsPizza.Models.Mock
{
    public class MockFoodItems : IFoodItem
    {
        public readonly ICategory _category = new MockCategory();
        IEnumerable<FoodItem> IFoodItem.GetFoodItems()
        {

            return new List<FoodItem>
            {
                new FoodItem {Name = "Margaritta", Price = 60, Category = _category.GetCategories().First() },
                new FoodItem {Name = "Bogdans Pizza",Price = 120, Category = _category.GetCategories().Last() }
            };
        }
    }
}
