using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities
{
    public class AddressStore
    {
        public Guid Id { get; set; }
        public Store Store { get; set; }
        public Address Address { get; set; }
    }
}
