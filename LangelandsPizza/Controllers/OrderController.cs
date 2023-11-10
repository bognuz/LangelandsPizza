using LangelandsPizza.Models.Dbfiles;
using LangelandsPizza.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.AccessControl;

using LangelandsPizza.Models.Interfaces;
using LangelandsPizza.Models.ShopingCart;
using LangelandsPizza.Models.Order;

namespace LangelandsPizza.Controllers
{
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



     
    }
}
