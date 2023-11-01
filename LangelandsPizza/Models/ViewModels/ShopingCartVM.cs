using LangelandsPizza.Models.ShopingCart;

namespace LangelandsPizza.Models.ViewModels
{
    public class ShopingCartVM
    {
        public ShopingCart.ShopingCart ShopingCart { get; set; }
        public double ShoppingCartTotal { get; set;  }
    }
}
