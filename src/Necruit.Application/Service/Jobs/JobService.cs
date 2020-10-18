using AutoMapper;
using Microsoft.Extensions.Logging;
using Necruit.Application.Service.Jobs.Dto;
using Necruit.Domain.Entities;
using Necruit.Infrastructure.Persistence.Repository;

namespace Necruit.Application.Service.Jobs
{
    public class JobService : CrudService<Job, CreateUpdateJobDto, CreateUpdateJobDto, JobDto, JobDto, JobPatchDto>, IJobService
    {
        private IGenericRepository<Job> jobRepository;
        private IMapper mapper;

        public JobService(
            ILogger<JobService> Logger,
            IGenericRepository<Job> jobRepository,
            IMapper mapper) : base(Logger, jobRepository, mapper)
        {
            this.jobRepository = jobRepository;
            this.mapper = mapper;
        }
    }
}