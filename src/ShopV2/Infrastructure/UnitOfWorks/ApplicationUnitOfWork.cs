using Infrastructure.DbContexts;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.UnitOfWorks
{
    public class ApplicationUnitOfWork : UnitOfWork, IApplicationUnitOfWork
    {
        public ICustomerRepository Customers { get; private set; }
        //public IStoreRepository Stores { get; private set; }
        //public IProductRepository Products { get; private set; }

        public ApplicationUnitOfWork(IApplicationDbContext context,
            ICustomerRepository customers
            //IStoreRepository stores,
            //IProductRepository products
            ) : base((DbContext)context)
        {
            Customers = customers;
            //Stores = stores;
            //Products = products;
        }
    }
}
