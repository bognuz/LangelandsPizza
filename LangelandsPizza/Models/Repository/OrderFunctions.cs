using LangelandsPizza.Models.Dbfiles;
using LangelandsPizza.Models.Interfaces;
using LangelandsPizza.Models.Order;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace LangelandsPizza.Models.Repository
{
    public class OrderFunctions : IAllOrders
    {
        private readonly AppDbContext _context;
        private readonly ShopingCart.ShopingCart _shopingcart;

        public OrderFunctions(AppDbContext context, ShopingCart.ShopingCart shopingCart)
        {
            _context = context;
            _shopingcart = shopingCart;
        }

        public void CreateAndStoreOrder(Order.Order order)
        {

            var temp = new Order.Order()
            {
               Name = order.Name,
               Surname = order.Surname,
               Email = order.Email,
               TelefonNumber = order.TelefonNumber
            };

            _context.Order.Add(temp);
            _context.SaveChanges(); 

            
            var items = _shopingcart.GetShopingCartItems();

            foreach (var item in items)
            {
                var orderItem = new OrderItem()
                {
                    Amount = item.Amount,
                    FoodItemID = item.FoodItem.Id,
                    OrderID = temp.Id,
                    Price = item.FoodItem.Price

                };
                _context.OrderItem.Add(orderItem);
            }
            _context.SaveChanges();

        }


        public List<Order.Order> GetOrders()
        {
            var list = _context.Order.Include(a => a.OrderItems).ThenInclude(a => a.FoodItem).ToList();
            return list;
        }

    }
}