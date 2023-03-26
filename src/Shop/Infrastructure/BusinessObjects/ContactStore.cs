namespace Infrastructure.BusinessObjects
{
    public class ContactStore
    {
        public Guid Id { get; set; }
        public Store Store { get; set; }
        public Contact Contact { get; set; }
    }
}
