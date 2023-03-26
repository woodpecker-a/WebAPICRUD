using BO = Infrastructure.BusinessObjects;
using Infrastructure.UnitOfWorks;
using Infrastructure.Entities;

namespace Infrastructure.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IApplicationUnitOfWork _works;
        public CustomerService(IApplicationUnitOfWork work)
        {
            _works = work;
        }
        public void CreateCustomer(BO.Customer customer)
        {
            Customer customerEntity = new();
            customer.Id = Guid.NewGuid();
            customer.FirstName = "Abdul";
            customer.LastName = "Basit";

            _works.Customers.Add(customerEntity);
            _works.Save();
        }
    }
}
