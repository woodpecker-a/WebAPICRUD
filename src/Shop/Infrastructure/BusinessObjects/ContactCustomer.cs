namespace Infrastructure.BusinessObjects
{
    public class ContactCustomer
    {
        public Guid Id { get; set; }
        public Customer Customer { get; set; }
        public Contact Contact { get; set; }
    }
}
