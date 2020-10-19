using Necruit.Application.Service.Jobs.Dto;
using System.Threading.Tasks;

namespace Necruit.Application.Service.Jobs
{
    public interface IJobService
    {
        Task<int> Create(CreateUpdateJobDto request);

        Task<int> Update(int id, CreateUpdateJobDto request);

        Task Delete(int id);

        Task<JobDetailDto> GetDetail(int id);

        Task<PagedResult<JobDetailDto>> GetActives(PageRequest request);

        Task<PagedResult<JobDetailDto>> GetPassives(PageRequest request);

        Task Patch(int id, JobPatchDto request);
    }
}