using AutoMapper;
using Necruit.Application.Mapping;
using Necruit.Domain.Entities;
using System.Linq;

namespace Necruit.Application.Service.Jobs.Dto
{
    public class JobDetailDto : IHaveCustomMappings
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Definition { get; set; }
        public int Quantity { get; set; }
        public JobUserDto User { get; set; }
        public int RecruitmentCount { get; set; }

        public void CreateMapping(Profile profile)
        {
            profile.CreateMap<Job, JobDetailDto>().ForMember(m => m.RecruitmentCount, opts => opts.MapFrom(s => s.Recruitments.Count()));
        }
    }
}