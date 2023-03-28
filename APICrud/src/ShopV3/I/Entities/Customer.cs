using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I.Entities
{
    public class Customer : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public AddressCustomer Address { get; set; }
        public ContactCustomer Contact { get; set; }
    }
}
