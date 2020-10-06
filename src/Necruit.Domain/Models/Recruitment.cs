﻿using System.Collections.Generic;

namespace Necruit.Domain.Models
{
    public class Recruitment : Entity
    {
        public Talent Talent { get; set; }
        public Job Job { get; set; }
        public RecruitmentStage Stage { get; set; }
        public ICollection<Interview> Interviews { get; set; }
    }
}
