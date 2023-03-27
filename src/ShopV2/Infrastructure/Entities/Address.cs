namespace Infrastructure.Entities
{
    public class Address : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public int HouseNo { get; set; }
        public string Area { get; set; }
        public string PoliceStation { get; set; }
        public string District { get; set; }
        public string Division { get; set; }
    }
}