namespace Infrastructure.BusinessObjects
{
    public class AddressCustomer
    {
        public Guid Id { get; set; }
        public Customer Customer { get; set; }
        public Address Address { get; set; }
    }
}
