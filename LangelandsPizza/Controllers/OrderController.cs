using Microsoft.AspNetCore.Mvc;

namespace LangelandsPizza.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
