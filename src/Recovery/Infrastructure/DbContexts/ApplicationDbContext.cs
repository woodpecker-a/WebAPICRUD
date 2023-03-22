﻿using Infrastructure.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DbContexts
{
    public class ApplicationDbContext : IdentityDbContext, IApplicationDbContext
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public ApplicationDbContext(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString,
                    b => b.MigrationsAssembly(_migrationAssemblyName)
                );
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Address>().ToTable("Addresses");
            builder.Entity<Purchase>().ToTable("Purchases");
            builder.Entity<Contact>().ToTable("Contacts");
            builder.Entity<AddressCustomer>().ToTable("AddressCustomer");
            builder.Entity<AddressStore>().ToTable("AddressStore");

            builder.Entity<Customer>()
                .HasOne(a => a.Address)
                .WithOne(c => c.Customer)
                .HasForeignKey<AddressCustomer>(ca => ca.Id);

            builder.Entity<Store>()
                .HasOne(a => a.Address)
                .WithOne(s => s.Store)
                .HasForeignKey<AddressStore>(sa => sa.Id);

            base.OnModelCreating(builder);
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Store> Stores { get; set; }
    }
}