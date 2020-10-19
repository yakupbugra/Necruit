using Necruit.Application.Mapping;
using Necruit.Domain.Entities;

namespace Necruit.Application.Service.Jobs.Dto
{
    public class JobPatchDto : MapFromTo<JobDetailDto, Job>
    {
        public string Title { get; set; }
        public string Definition { get; set; }
        public int Quantity { get; set; }
        public int RecruitmentCount { get; set; }
    }
}