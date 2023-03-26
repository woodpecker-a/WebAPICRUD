using Infrastructure.Entities;

namespace Infrastructure.Repositories
{
    public interface ICustomerRepository : IRepository<Customer, Guid>
    {
    }
}