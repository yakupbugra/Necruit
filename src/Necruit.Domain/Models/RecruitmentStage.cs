using System;
using System.Collections.Generic;
using System.Text;

namespace Necruit.Domain.Models
{
    public class RecruitmentStage:Entity
    {
        public string Name { get; set; }
        public int Order { get; set; }
        public IEnumerable<Recruitment> Recruitments { get; set; }
    }
}
