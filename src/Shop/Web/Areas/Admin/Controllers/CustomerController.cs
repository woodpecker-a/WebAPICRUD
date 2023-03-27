using Autofac;
using Microsoft.AspNetCore.Mvc;
using Web.Areas.Admin.Models;
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
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CustomerCreateModel model)
        {
            if(ModelState.IsValid)
            {
                model.ResolveDependency(_scope);
                await model.CreateCustomer();
            }
            return View(model);
        }
        public IActionResult Edit(Guid id)
        {
            var model = _scope.Resolve<CustomerEditModel>();
            model.LoadData(id);

            return View(model);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CustomerEditModel model)
        {
            if(ModelState.IsValid)
            {
                model.ResolveDependency(_scope);
                await model.EditCustomer();
            }

            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Delete(Guid id)
        {
            var model = _scope.Resolve<CustomerListModel>();
            model.DeleteCustomer(id);

            return RedirectToAction("Index");
        }
        public JsonResult GetCustomerData()
        {
            var table = new DataTablesAjaxRequestModel(Request);
            var model = _scope.Resolve<CustomerListModel>();
            return Json(model.GetPagedCustomer(table));
        }
    }
}
