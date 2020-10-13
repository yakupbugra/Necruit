using Necruit.Application.Service.Jobs.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Necruit.Application.Service.Jobs
{
    public interface IJobService
    {
        Task<int> CreateJob(CreateJobRequest request);

        Task<List<JobInfo>> ListJobs();

        Task<JobInfo> GetJobDetail(int id);

        Task<int> UpdateJob(int id, CreateJobRequest request);
    }
}