using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public AddressCustomer Address { get; set; }
        public ContactCustomer Contact { get; set; }
        public List<Purchase> Orders { get; set; }
    }
}
