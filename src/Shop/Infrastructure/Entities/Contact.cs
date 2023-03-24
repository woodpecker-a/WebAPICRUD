namespace Infrastructure.Entities
{
    public class Contact : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Moblie { get; set; }
    }
}