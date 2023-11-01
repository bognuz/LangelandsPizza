using LangelandsPizza.Models.ShopingCart;

namespace LangelandsPizza.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

       
        public List<FoodItem> FoodItems { get; set; }   //one category can have many fooditems 

    }
}
