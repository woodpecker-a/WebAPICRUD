namespace Infrastructure.BusinessObjects
{
    public class Purchase
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }
        public List<Product>? Products { get; set; }
        public Guid StoreId { get; set; }
        public Store Store { get; set; }
        public int Quantity { get; set; }
        public double TotalPrice { get; set; }

    }
}
