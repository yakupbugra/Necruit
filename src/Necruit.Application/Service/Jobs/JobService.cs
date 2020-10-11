using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.Extensions.Logging;
using Necruit.Application.Exceptions;
using Necruit.Application.Service.Jobs.Dto;
using Necruit.Domain.Entities;
using Necruit.Infrastructure.Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public ServiceResult<JobInfo> GetJobDetail(int id)
        {
            ServiceResult<JobInfo> result = new();
            try
            {
                JobInfo job = jobRepository.FindBy(x => x.Id == id).ProjectTo<JobInfo>(mapper.ConfigurationProvider).FirstOrDefault();
                if (job == null)
                    throw new NotFoundException($"Job {id} not found.");
                result.Data = job;
                return result;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                result.Fail(ex);
            }

            return result;
        }

        public ServiceResult<List<JobInfo>> ListJobs()
        {
            ServiceResult<List<JobInfo>> result = new ServiceResult<List<JobInfo>>();

            try
            {
                result.Data = jobRepository.AllActives().ProjectTo<JobInfo>(mapper.ConfigurationProvider).ToList();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                result.Fail(ex);
            }

            return result;
        }

        public ServiceResult<int> UpdateJob(int id, CreateJobRequest request)
        {
            ServiceResult<int> result = new ServiceResult<int>();

            try
            {
                Job job = jobRepository.FindById(id);

                job = mapper.Map<CreateJobRequest, Job>(request, job);

                jobRepository.Update(job);
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
    }
}