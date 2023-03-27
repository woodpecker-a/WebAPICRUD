using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities
{
    public class AddressCustomer : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public Customer Customer { get; set; }
        public Address Address { get; set; }
    }
}
