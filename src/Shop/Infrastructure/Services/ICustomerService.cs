using Infrastructure.BusinessObjects;

namespace Infrastructure.Services
{
    public interface ICustomerService
    {
        void CreateCustomer(Customer customer);
    }
}