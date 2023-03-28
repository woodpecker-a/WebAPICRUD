using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using I.Entities;

namespace I.DbContexts
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid,
        ApplicationUserClaim, ApplicationUserRole, ApplicationUserLogin, ApplicationRoleClaim, ApplicationUserToken>, IApplicationDbContext
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public ApplicationDbContext(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Store> Stores { get; set; }

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
            builder.Entity<Contact>().ToTable("Contacts");
            builder.Entity<AddressCustomer>().ToTable("AddressCustomer");
            builder.Entity<AddressStore>().ToTable("AddressStore");
            builder.Entity<ContactCustomer>().ToTable("ContactCustomer");
            builder.Entity<ContactStore>().ToTable("ContactStore");

            builder.Entity<Customer>()
                .HasOne(a => a.Address)
                .WithOne(c => c.Customer)
                .HasForeignKey<AddressCustomer>(k => k.Id);
            
            builder.Entity<Store>()
                .HasOne(a => a.Address)
                .WithOne(c => c.Store)
                .HasForeignKey<AddressStore>(k => k.Id);

            builder.Entity<Customer>()
                .HasOne(a => a.Contact)
                .WithOne(c => c.Customer)
                .HasForeignKey<ContactCustomer>(k => k.Id);

            builder.Entity<Store>()
                .HasOne(a => a.Contact)
                .WithOne(c => c.Store)
                .HasForeignKey<ContactStore>(k => k.Id);

            base.OnModelCreating(builder);
        }
    }
}
