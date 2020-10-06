using System;
using System.Collections.Generic;
using System.Text;

namespace Necruit.Domain.Models
{
    public class Recruitment:Entity
    {
        public Talent Talent { get; set; }
        public Job Job { get; set; }
        public RecruitmentStage Stage { get; set; }
        public IEnumerable<Interview> Interviews { get; set; }
    }
}
