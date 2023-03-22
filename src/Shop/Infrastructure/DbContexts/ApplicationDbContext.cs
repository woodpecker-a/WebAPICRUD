using Infrastructure.Entities;
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
            builder.Entity<ContactCustomer>().ToTable("ContactCustomer");
            builder.Entity<ContactStore>().ToTable("ContactStore");

            builder.Entity<Customer>()
                .HasOne(a => a.Address)
                .WithOne(c => c.Customer)
                .HasForeignKey<AddressCustomer>(ca => ca.Id);

            builder.Entity<Store>()
                .HasOne(a => a.Address)
                .WithOne(s => s.Store)
                .HasForeignKey<AddressStore>(sa => sa.Id);

            builder.Entity<Customer>()
                .HasOne(c => c.Contact)
                .WithOne(cs => cs.Customer)
                .HasForeignKey<ContactCustomer>(cc => cc.Id);

            builder.Entity<Store>()
                .HasOne(c => c.Contact)
                .WithOne(cs => cs.Store)
                .HasForeignKey<ContactStore>(cc => cc.Id);

            builder.Entity<Purchase>()
                .HasOne(c => c.Customer)
                .WithMany(s => s.Orders)
                .HasForeignKey(p => p.CustomerId);

            builder.Entity<Purchase>()
                .HasOne(s => s.Store)
                .WithMany(p => p.Sells)
                .HasForeignKey(p => p.StoreId);

            base.OnModelCreating(builder);
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Store> Stores { get; set; }
    }
}