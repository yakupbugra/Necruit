using System;
using System.Collections.Generic;
using System.Text;

namespace Necruit.Domain.Models
{
    public class Interview : Entity
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public String Description { get; set; }
        public Recruitment Recruitment { get; set; }
        public IEnumerable<User> Interviewers { get; set; }
        public IEnumerable<InterviewFeedback> InterviewFeedbacks { get; set; }
    }
}
