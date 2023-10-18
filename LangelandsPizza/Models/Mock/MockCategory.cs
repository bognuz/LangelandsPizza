using LangelandsPizza.Models.Interfaces;

namespace LangelandsPizza.Models.Mock
{
    public class MockCategory : ICategory 
    {
         IEnumerable<Category> ICategory.GetCategories(){

            return new List<Category>
                {
                new Category { Name = "Pizzaer med skine" },
                new Category { Name = "Mexikanske Pizzaer"}

                };
        }
    }
}
