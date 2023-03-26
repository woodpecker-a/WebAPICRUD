using Infrastructure.DbContexts;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Repositories
{
    public class StoreRepository : Repository<Store, Guid> , IStoreRepository
    {
        public StoreRepository(IApplicationDbContext context) : base((DbContext)context) { }
    }
}
