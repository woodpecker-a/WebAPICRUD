using I.Entities;
using Microsoft.EntityFrameworkCore;

namespace I.DbContexts
{
    public interface IApplicationDbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Store> Stores { get; set; }
    }
}