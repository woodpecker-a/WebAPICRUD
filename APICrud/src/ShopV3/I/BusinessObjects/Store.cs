namespace I.BusinessObjects
{
    public class Store
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public AddressStore Address { get; set; }
        public ContactStore Contact { get; set; }

    }
}
