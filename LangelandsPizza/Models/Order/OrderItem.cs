namespace LangelandsPizza.Models.Order
{
    public class OrderItem
    {
        public int Id { get; set; }    

        public int Amount { get; set; }

        public double Price { get; set;  }

        public int FoodItemID { get; set; } 
        public FoodItem FoodItem { get; set; }

        public int OrderID { get; set;  }

        public Order Order { get; set;  }
    }
}
