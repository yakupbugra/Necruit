using Necurit.Application.Data.Request;
using System.Collections.Generic;

namespace Necurit.Application.Data.Service
{
    public interface IJobService
    {
        ServiceResult<int> CreateJob(CreateJobRequest request);
        ServiceResult<List<JobListResponse>> ListJobs();
    }
}