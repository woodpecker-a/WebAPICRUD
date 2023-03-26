using Autofac;
using Microsoft.AspNetCore.Mvc;
using Web.Models;

namespace Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CustomerController : Controller
    {
        private readonly ILifetimeScope _scope;
        private readonly ILogger<CustomerController> _logger;
        public CustomerController(ILogger<CustomerController> logger, ILifetimeScope scope)
        {
            _scope = scope;
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            CustomerCreateModel model = new CustomerCreateModel();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CustomerCreateModel model)
        {
            if(ModelState.IsValid)
            {
                model.ResolveDependency(_scope);
                await model.CreateCustomer();
            }
            return View(model);
        }
    }
}
