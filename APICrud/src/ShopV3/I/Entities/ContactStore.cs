using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I.Entities
{
    public class ContactStore : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public Store Store { get; set; }
        public Contact Contact { get; set; }
    }
}
