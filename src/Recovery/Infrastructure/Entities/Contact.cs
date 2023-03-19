namespace Infrastructure.Entities
{
    public class Contact
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public List<string> Moblie { get; set; }
    }
}