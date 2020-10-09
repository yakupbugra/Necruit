using Necurit.Application.Data.Request;

namespace Necurit.Application.Data.Service
{
    public interface IJobService
    {
        ServiceResult<int> CreateJob(CreateJobRequest request);
    }
}