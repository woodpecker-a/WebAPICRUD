using I.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace W.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize]
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public AdminController(ILogger<AdminController> logger,UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            _logger = logger;
            _userManager = userManager;
            _roleManager = roleManager;

        }
        public async Task<IActionResult> Index()
        {
            await _roleManager.CreateAsync(new ApplicationRole("Admin"));
            await _roleManager.CreateAsync(new ApplicationRole("Customer"));
            await _roleManager.CreateAsync(new ApplicationRole("Seller"));

            return View();
        }

        public async Task<IActionResult> SetRole(ApplicationUser user)
        {
            await _userManager.AddToRoleAsync(user, new string[] { "Customer" });

            return View();
        }
    }
}
