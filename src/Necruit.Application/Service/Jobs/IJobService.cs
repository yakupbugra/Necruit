using Necruit.Application.Request;
using System.Collections.Generic;

namespace Necruit.Application.Service.Jobs
{
    public interface IJobService
    {
        ServiceResult<int> CreateJob(CreateJobRequest request);
        ServiceResult<List<JobInfo>> ListJobs();
    }
}