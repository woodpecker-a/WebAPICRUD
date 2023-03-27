using Infrastructure.Repositories;

namespace Infrastructure.UnitOfWorks
{
    public interface IApplicationUnitOfWork : IUnitOfWork
    {
        ICustomerRepository Customers { get; }
        //IProductRepository Products { get; }
        //IStoreRepository Stores { get; }


    }
}