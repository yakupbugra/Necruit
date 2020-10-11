using Necruit.Application.Service.Jobs.Dto;
using System.Collections.Generic;

namespace Necruit.Application.Service.Jobs
{
    public interface IJobService
    {
        ServiceResult<int> CreateJob(CreateJobRequest request);

        ServiceResult<List<JobInfo>> ListJobs();
        ServiceResult<JobInfo> GetJobDetail(int id);
        ServiceResult<int> UpdateJob(int id, CreateJobRequest request);
    }
}