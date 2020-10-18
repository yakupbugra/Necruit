using Necruit.Api.Filters;
using Necruit.Application.Service.Jobs.Dto;
using System.Threading.Tasks;

namespace Necruit.Application.Service.Jobs
{
    public interface IJobService
    {
        Task<int> Create(CreateUpdateJobDto request);

        Task<int> Update(int id, CreateUpdateJobDto request);

        Task Delete(int id);

        Task<JobDto> GetDetail(int id);

        Task<PagedResult<JobDto>> GetActives(PageRequest request);

        Task<PagedResult<JobDto>> GetPassives(PageRequest request);

        Task Patch(int id, JobDto request);
    }
}