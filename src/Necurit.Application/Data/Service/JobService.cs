using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.Extensions.Logging;
using Necruit.Domain.Entities;
using Necruit.Infrastructure.Persistence.Repository;
using Necurit.Application.Data.Request;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Necurit.Application.Data.Service
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

        public ServiceResult<int> CreateJob(CreateJobRequest request)
        {
            ServiceResult<int> result = new ServiceResult<int>();

            try
            {
                Job job = mapper.Map<Job>(request);
                job.User = userRepository.FindById(request.UserId);


                jobRepository.Add(job);
                jobRepository.Save();

                result.Data = job.Id;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                result.Fail(ex);
            }

            return result;
        }

        public ServiceResult<List<JobListResponse>> ListJobs()
        {
            ServiceResult<List<JobListResponse>> result = new ServiceResult<List<JobListResponse>>();

            try
            {
                result.Data = jobRepository.AllActives().ProjectTo<JobListResponse>(mapper.ConfigurationProvider).ToList();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                result.Fail(ex);
            }

            return result;
        }
    }
}