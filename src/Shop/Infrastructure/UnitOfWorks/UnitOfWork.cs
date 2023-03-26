
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.UnitOfWorks
{
    public abstract class UnitOfWork : IUnitOfWork
    {
        protected readonly DbContext _context;
        public UnitOfWork(DbContext context) => _context = context;
        public void Dispose() => _context.Dispose();

        public void Save() => _context.SaveChanges();
    }
}
