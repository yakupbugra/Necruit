using System.Collections.Generic;

namespace Necruit.Domain.Entities
{
    public class Talent : Entity
    {
        public Talent() : base()
        {
        }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string MobilePhone { get; set; }
        public string Location { get; set; }
        public string Skype { get; set; }
        public string Linkedin { get; set; }
        public int ExpectedSalary { get; set; }
        public string Cv { get; set; }
        public string Description { get; set; }
        public bool IsInPool { get; set; }
        public User Owner { get; set; }
        public ICollection<Recruitment> Recruitments { get; set; }
    }
}