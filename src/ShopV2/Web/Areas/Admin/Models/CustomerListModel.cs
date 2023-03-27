using Autofac;
using Infrastructure.Services;
using Web.Models;

namespace Web.Areas.Admin.Models
{
    public class CustomerListModel : BaseModel
    {
        private ICustomerService _service;
        public CustomerListModel() : base() { }
        public CustomerListModel(ICustomerService service)
        {
            _service = service;
        }
        public override void ResolveDependency(ILifetimeScope scope)
        {
            base.ResolveDependency(scope);
            _service = _scope.Resolve<ICustomerService>();
        }
        internal object GetPagedCustomer(DataTablesAjaxRequestModel model)
        {
            var data = _service.GetCustomers(
                model.PageIndex, model.PageSize, model.SearchText,
                model.GetSortText(new string[] { "FirstName", "LastName" })
                );

            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,

                data = data.records.Select(x => new string[]
                {
                    x.FirstName, x.LastName, /*x.Contact.Contact.Phone, x.Contact.Contact.Email,*/ x.Id.ToString()
                }).ToArray()
            };
        }
        internal void DeleteCustomer(Guid id)
        {
            _service.DeleteCustomer(id);
        }
    }
}
