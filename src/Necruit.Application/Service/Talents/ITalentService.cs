using Necruit.Application.Service.Talents.Dto;
using System.Threading.Tasks;

namespace Necruit.Application.Service.Talents
{
    public interface ITalentService
    {
        Task<int> Create(CreateUpdateTalentDto request);

        Task<int> Update(int id, CreateUpdateTalentDto request);

        Task Delete(int id);

        Task<TalentDetailDto> GetDetail(int id);

        Task<PagedResult<TalentDetailDto>> GetActives(PageRequest request);

        Task<PagedResult<TalentDetailDto>> GetPassives(PageRequest request);

        Task<PagedResult<TalentDetailDto>> GetTalentsInPool(PageRequest request);


        Task Patch(int id, TalentPathcDto request);
    }
}