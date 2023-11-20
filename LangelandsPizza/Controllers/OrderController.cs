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


        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CheckOut(Order Order)
        {
            
            _orders.CreateAndStoreOrder(Order);

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
