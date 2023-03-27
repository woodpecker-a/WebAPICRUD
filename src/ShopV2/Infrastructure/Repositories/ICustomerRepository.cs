using Infrastructure.Entities;
using System.Text.RegularExpressions;

namespace Infrastructure.Repositories
{
    public interface ICustomerRepository : IRepository<Customer, Guid>
    {
        (IList<Customer> data, int total, int totalDisplay) GetCustomers(int pageIndex,
            int pageSize, string searchText, string orderby);
    }
}