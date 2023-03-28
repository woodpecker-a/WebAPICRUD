namespace I.Entities
{
    public class AddressStore : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public Store Store { get; set; }
        public Address Address { get; set; }
    }
}
