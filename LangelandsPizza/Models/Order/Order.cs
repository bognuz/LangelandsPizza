namespace LangelandsPizza.Models.Order
{
    public class Order
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        
        public string Email { get; set; }

        public string TelefonNumber { get; set;}

        public List<OrderItem> OrderItems { get; set;  }
    }
}
