using LangelandsPizza.Models.Dbfiles;
using LangelandsPizza.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.AccessControl;

using LangelandsPizza.Models.Interfaces;
using LangelandsPizza.Models.ShopingCart;
using LangelandsPizza.Models.Order;
using Microsoft.AspNetCore.Authorization;

namespace LangelandsPizza.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        
        private readonly IAllOrders _orders;
        private readonly ShopingCart _shopingCart;

        public OrderController (IAllOrders orders, ShopingCart shoppingCart)
        {
            _orders = orders;
            _shopingCart = shoppingCart;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            var items = _shopingCart.GetShopingCartItems();


            if (items.Count == 0)
            {
                TempData["OrdreFejl"] = "Fejl du skal have varene i kurven";
                return RedirectToAction("Index", "ShopingCart");
            }

            TempData.Remove("OrdreFejl");
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult CheckOut(Order Order)
        {
            
            _orders.CreateAndStoreOrder(Order);
            _shopingCart.RemoveItemsFromDisposedShoppingCart();

            return View();
        }

        public IActionResult ShowNotCompletedOrders()
        {
            var orders = _orders.GetNotCompletedOrders();
            return View(orders);
        }

        public IActionResult ShowCompletedOrders()
        {
            var orders = _orders.GetCompletedOrders();
            return View(orders);
        }


        public IActionResult MarkOrderAsCompleted(int orderID)
        {
            _orders.MarkOrderAsComplete(orderID);
            return RedirectToAction("ShowNotCompletedOrders");
        }



     
    }
}
