using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I.Entities
{
    public class Store : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public AddressStore Address { get; set; }
        public ContactStore Contact { get; set; }

    }
}
