using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities
{
    public class ContactStore
    {
        public Guid Id { get; set; }
        public Store Store { get; set; }
        public Contact Contact { get; set; }
    }
}
