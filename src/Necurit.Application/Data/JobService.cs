using Microsoft.Extensions.Logging;
using Necruit.Domain.Entities;
using Necruit.Infrastructure.Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Necurit.Application.Data
{
    public class JobService : ServiceBase
    {
        IGenericRepository<Job> jobRepository;
        public JobService(ILogger Logger, IGenericRepository<Job> jobRepository) : base(Logger)
        {
            this.jobRepository = jobRepository;

        }

        public ServiceResult CreateJob()
        {
            ServiceResult result = new ServiceResult();

            result.Success = RunInTryCatch(() =>
            {
                Job job = new Job();

                jobRepository.Add(job);
                jobRepository.Save();


            });

            return result;

        }
    }
}
