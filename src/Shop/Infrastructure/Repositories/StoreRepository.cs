using Infrastructure.DbContexts;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class StoreRepository : Repository<Store, Guid>
    {
        public StoreRepository(IApplicationDbContext context) : base((DbContext)context) { }
    }
}
