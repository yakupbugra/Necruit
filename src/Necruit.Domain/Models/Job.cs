using System;
using System.Collections.Generic;
using System.Text;

namespace Necruit.Domain.Models
{
    public class Job : Entity
    {
        public string Title { get; set; }
        public string Definition { get; set; }
        public int Quantity { get; set; }
        public IEnumerable<User> Candidates { get; set; }
        public bool IsActive { get; set; }
    }
}