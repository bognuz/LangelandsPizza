namespace LangelandsPizza.Models.ShopingCart
{
    public class ShopingCartItem
    {
        public int Id { get; set; }
        public FoodItem FoodItem { get; set; }

        public int Amount { get; set;  }

        public string ShopingCartID { get; set;  }
    }
}
