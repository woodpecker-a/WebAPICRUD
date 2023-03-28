namespace I.Entities
{
    public class AddressCustomer : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public Customer Customer { get; set; }
        public Address Address { get; set; }
    }
}
