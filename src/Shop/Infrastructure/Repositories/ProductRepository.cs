﻿using Infrastructure.DbContexts;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ProductRepository : Repository<Product, Guid>
    {
        public ProductRepository(IApplicationDbContext context) : base((DbContext)context) { }
    }
}
