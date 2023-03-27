namespace Infrastructure.BusinessObjects
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public AddressCustomer Address { get; set; }
        public ContactCustomer Contact { get; set; }
        public List<Purchase> Orders { get; set; }
    }
}
