using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Necruit.Application.Exceptions;
using Necruit.Application.Service.Jobs.Dto;
using Necruit.Domain.Entities;
using Necruit.Infrastructure.Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Necruit.Application.Service.Jobs
{
    public class JobService : ServiceBase, IJobService
    {
        private IGenericRepository<Job> jobRepository;
        private IGenericRepository<User> userRepository;
        private IMapper mapper;

        public JobService(
            ILogger<JobService> Logger,
            IGenericRepository<Job> jobRepository,
            IGenericRepository<User> userRepository,
            IMapper mapper) : base(Logger)
        {
            this.jobRepository = jobRepository;
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        public async Task<int> CreateJob(CreateJobRequest request)
        {
            Job job = mapper.Map<Job>(request);
            job.User = userRepository.FindById(request.UserId);
            jobRepository.Add(job);
            await jobRepository.SaveAsync();

            return job.Id;
        }

        public async Task<JobInfo> GetJobDetail(int id)
        {
            try
            {
                return await jobRepository.FindBy(x => x.Id == id).ProjectTo<JobInfo>(mapper.ConfigurationProvider).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw new ServiceException();
            }
        }

        public async Task<List<JobInfo>> ListJobs()
        {
            try
            {
                return await jobRepository.AllActives().ProjectTo<JobInfo>(mapper.ConfigurationProvider).ToListAsync();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw new ServiceException();
            }
        }

        public async Task<int> UpdateJob(int id, CreateJobRequest request)
        {
            try
            {
                Job job = jobRepository.FindById(id);

                job = mapper.Map<CreateJobRequest, Job>(request, job);

                jobRepository.Update(job);
                await jobRepository.SaveAsync();

                return job.Id;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw new ServiceException();
            }
        }
    }
}