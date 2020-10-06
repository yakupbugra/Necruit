using System;
using System.Collections.Generic;
using System.Text;

namespace Necruit.Domain.Models
{
    public class Role:Entity
    {
        public int Name { get; set; }
        public IEnumerable<User> Users { get; set; }
    }
}
