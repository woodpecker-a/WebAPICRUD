using Infrastructure.Entities;

namespace Infrastructure.Repositories
{
    public interface IProductRepository : IRepository<Product, Guid>
    {
    }
}