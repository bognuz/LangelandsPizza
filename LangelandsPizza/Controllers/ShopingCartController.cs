using Azure;
using LangelandsPizza.Models.Dbfiles;
using LangelandsPizza.Models.ShopingCart;
using LangelandsPizza.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LangelandsPizza.Controllers
{
    public class ShopingCartController : Controller
    {


        private readonly AppDbContext _context;
        private readonly ShopingCart _shopingcart; 

        public ShopingCartController (AppDbContext context, ShopingCart shopingCart)
        {
            context = _context;
            _shopingcart = shopingCart;
        }




        public IActionResult Index()
        {

            var items = _shopingcart.GetShopingCartItems();
            _shopingcart.ShopingCartItems = items;

            var responce = new ShopingCartVM()
            {
                ShopingCart = _shopingcart,
                ShoppingCartTotal = _shopingcart.GetShoppingCartTotal()
            };
            return View(responce);

        }

        public RedirectToActionResult AddToShopingCart(int id)
        {
            var item = _shopingcart.AddItemByID(id);

            if(item != null)
            {
                _shopingcart.AddItemToCart(item);

            }
            return RedirectToAction(nameof(Index));



        }


    }
    }

