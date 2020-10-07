using System.Collections.Generic;

namespace Necruit.Domain.Entities
{
    public class User : Entity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string MobilePhone { get; set; }
        public string Location { get; set; }
        public ICollection<Interview> Interviews { get; set; }
        public ICollection<InterviewFeedback> InterviewFeedbacks { get; set; }
        public List<Talent> Talents { get; set; }
    }
}