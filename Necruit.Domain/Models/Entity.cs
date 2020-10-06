using System;
using System.Collections.Generic;
using System.Text;

namespace Necruit.Domain.Models
{
    public class Entity
    {
        public int Id { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime LastUpdateTime { get; set; }

        public bool IsActive { get; set; }
    }
}
