using System;
using System.Collections.Generic;

namespace Necruit.Domain.Entities
{
    public class Interview : Entity
    {
        public Interview() : base()
        {
        }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public String Description { get; set; }
        public Recruitment Recruitment { get; set; }
        public ICollection<User> Users { get; set; }
        public ICollection<InterviewFeedback> InterviewFeedbacks { get; set; }
    }
}