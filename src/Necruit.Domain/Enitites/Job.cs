using System.Collections.Generic;

namespace Necruit.Domain.Entities
{
    public class Job : Entity
    {
        public Job() : base()
        {
        }

        public string Title { get; set; }
        public string Definition { get; set; }
        public int Quantity { get; set; }
        public ICollection<Recruitment> Recruitments { get; set; }
        public User User { get; set; }

    }
}