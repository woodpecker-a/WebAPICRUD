using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace W.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Policy = "ShopManagementPolicy")]
    public class StoreController : Controller
    {
        private readonly ILogger<StoreController> _logger;
        public StoreController(ILogger<StoreController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
