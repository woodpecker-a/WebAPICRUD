using Infrastructure.DbContexts;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace Infrastructure.Repositories
{
    public class CustomerRepository : Repository<Customer, Guid>, ICustomerRepository
    {
        public CustomerRepository(IApplicationDbContext context) : base((DbContext)context)
        {
            
        }

        public (IList<Customer> data, int total, int totalDisplay) GetCustomers(int pageIndex, int pageSize, string searchText, string orderby)
        {
            (IList<Customer> data, int total, int totalDisplay) results =
                    GetDynamic(x => x.FirstName.Contains(searchText), orderby,
                    string.Empty, pageIndex, pageSize, true);

            return results;
        }
    }
}
