using Autofac;
using AutoMapper;
using Infrastructure.BusinessObjects;
using Infrastructure.Services;

namespace Web.Areas.Admin.Models
{
    public class CustomerEditModel : BaseModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //public AddressCustomer Address { get; set; }
        //public ContactCustomer Contact { get; set; }
        private ICustomerService _service;
        private IMapper _mapper;
        public CustomerEditModel() : base()
        {
            
        }
        public CustomerEditModel(ICustomerService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        public override void ResolveDependency(ILifetimeScope scope)
        {
            base.ResolveDependency(scope);
            _service = _scope.Resolve<ICustomerService>();
            _mapper = _scope.Resolve<IMapper>();
        }
        internal void LoadData(Guid id)
        {
            Customer customer = _service.GetCustomerById(id);
            if (customer != null)
            {
                _mapper.Map(customer, this);
            }
            else new InvalidOperationException("Customer not found");
        }
        internal async Task EditCustomer()
        {
            var customer = _mapper.Map<Customer>(this);
            _service.EditCustomer(customer);
        }
    }
}
