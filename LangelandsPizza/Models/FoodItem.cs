namespace LangelandsPizza.Models
{
    public class FoodItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }

        public int CategoryID { get; set; }

        public Category Category { get; set; }
    }
}
