using Infrastructure.BusinessObjects;
using System.Text.RegularExpressions;

namespace Infrastructure.Services
{
    public interface ICustomerService
    {
        void CreateCustomer(Customer customer);
        void EditCustomer(Customer customer);
        void DeleteCustomer(Guid id);
        Customer GetCustomerById(Guid id);
        (int total, int totalDisplay, IList<Customer> records) GetCustomers(int pageIndex, int pageSize, string searchText, string orderby);

    }
}