using Autofac;
using AutoMapper;
using Infrastructure.BusinessObjects;
using Infrastructure.Services;

namespace Web.Models
{
    public class CustomerCreateModel : BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //public AddressCustomer Address { get; set; }
        //public ContactCustomer Contact { get; set; }
        //public List<Purchase> Orders { get; set; }
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
        }

        public async Task CreateCustomer()
        {
            var project = _mapper.Map<Customer>(this);

        }
    }
}
