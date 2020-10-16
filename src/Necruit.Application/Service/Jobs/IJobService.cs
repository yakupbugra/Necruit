using Necruit.Api.Filters;
using Necruit.Application.Service.Jobs.Dto;
using System.Threading.Tasks;

namespace Necruit.Application.Service.Jobs
{
    public interface IJobService
    {
        Task<int> Create(CreateJobRequest request);

        Task<int> Update(int id, CreateJobRequest request);

        Task Delete(int id);

        Task<JobInfo> GetDetail(int id);

        Task<PagedResult<JobInfo>> GetActives(PageRequest request);

        Task<PagedResult<JobInfo>> GetPassives(PageRequest request);
    }
}