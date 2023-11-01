using LangelandsPizza.Models.Dbfiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace LangelandsPizza.Models.ShopingCart
{
    public class ShopingCart
    {

        public AppDbContext _Context { get; set; }

        public int ID { get; set; }

        public string ShopingCartID { get; set; }

        public List<ShopingCartItem> ShopingCartItems { get; set; }

        public ShopingCart(AppDbContext context)
        {
            _Context = context;
        }
        

        public static ShopingCart CheckSession(IServiceProvider services) //check if there is a session with that card id and if not create a new  sessionid
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session; //if not null create new
            var context = services.GetService<AppDbContext>();

            string cartID = session.GetString("CartID") ?? Guid.NewGuid().ToString(); //if cart id is null generate new
            session.SetString("CartID", cartID);
            
            return new ShopingCart(context) {ShopingCartID = cartID};
        }

        public void AddItemToCart(FoodItem foodItem)
        {
            var shopingCartItem = _Context.ShopingCartItem.FirstOrDefault(n => n.FoodItem.Id == foodItem.Id && n.ShopingCartID == ShopingCartID);

            if (shopingCartItem == null)
            {
                shopingCartItem = new ShopingCartItem()
                {
                    ShopingCartID = ShopingCartID,
                    FoodItem = foodItem,
                    Amount = 1

                };
                _Context.ShopingCartItem.Add(shopingCartItem);
            }
            else
            {
                shopingCartItem.Amount++;
            }
            _Context.SaveChanges();
        }

        public FoodItem AddItemByID(int id)
        {
            var result = _Context.FoodItems.FirstOrDefault(n => n.Id == id);
            return result;
        }


        public void RemoveItemFromCart(FoodItem foodItem)
        {
            var shopingCartItem = _Context.ShopingCartItem.FirstOrDefault(n => n.FoodItem.Id == foodItem.Id && n.ShopingCartID == ShopingCartID);

            if (shopingCartItem != null)
            {
                if (shopingCartItem.Amount > 1)
                {
                    shopingCartItem.Amount--;
                }
                else
                {
                    _Context.ShopingCartItem.Remove(shopingCartItem);
                }

            }

            _Context.SaveChanges();

        }

        public List<ShopingCartItem> GetShopingCartItems()
        {

            return ShopingCartItems ?? (ShopingCartItems = _Context.ShopingCartItem.Where(n => n.ShopingCartID == ShopingCartID).Include(n => n.FoodItem).ToList());

        }



        public double GetShoppingCartTotal() //Calcutale total price of the shopingcart
        {
            var total = _Context.ShopingCartItem.Where(n => ShopingCartID == ShopingCartID).Select(n => n.FoodItem.Price * n.Amount).Sum();
            return total;
        }



    }

}





      







       




