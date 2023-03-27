using Autofac;
using AutoMapper;
using Infrastructure.BusinessObjects;
using Infrastructure.Services;

namespace Web.Areas.Admin.Models
{
    public class CustomerCreateModel : BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //public AddressCustomer Address { get; set; }
        //public ContactCustomer Contact { get; set; }
        private ICustomerService _service;
        private IMapper _mapper;

        public CustomerCreateModel() : base() { }
        public CustomerCreateModel(ICustomerService service, IMapper mapper)
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

        public async Task CreateCustomer()
        {
            var customer = _mapper.Map<Customer>(this);
            _service.CreateCustomer(customer);
        }
    }
}
