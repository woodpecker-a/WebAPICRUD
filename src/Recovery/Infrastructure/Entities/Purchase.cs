using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities
{
    public class Purchase
    {
        public Guid Id { get; set; }
        public Customer Customer { get; set; }
        public List<Product> Products { get; set; }
        public Store StoreName { get; set; }
        public int Quantity { get; set; }
        public double TotalPrice { get; set; }

    }
}
