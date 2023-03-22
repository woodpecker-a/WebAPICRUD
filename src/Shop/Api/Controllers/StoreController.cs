using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class StoreController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
