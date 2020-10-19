using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Necruit.Application.Exceptions;
using Necruit.Application.Service.Talents.Dto;
using Necruit.Domain.Entities;
using Necruit.Infrastructure.Persistence.Repository;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Necruit.Application.Service.Talents
{
    public class TalentService : CrudService<Talent, CreateUpdateTalentDto, CreateUpdateTalentDto, TalentDetailDto, TalentDetailDto, TalentPathcDto>, ITalentService
    {
        private IGenericRepository<Talent> talentRepository;
        private IMapper mapper;

        public TalentService(
            ILogger<TalentService> Logger,
            IGenericRepository<Talent> talentRepository,
            IMapper mapper) : base(Logger, talentRepository, mapper)
        {
            this.talentRepository = talentRepository;
            this.mapper = mapper;
        }

        public async Task<PagedResult<TalentDetailDto>> GetTalentsInPool(PageRequest request)
        {
            try
            {
                var filteredData = talentRepository.AllActives().Where(x => x.IsInPool)
                    .ProjectTo<TalentDetailDto>(mapper.ConfigurationProvider);
                var pagedData = await filteredData
                    .Skip((request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ToListAsync();
                var count = await filteredData.CountAsync();

                return new PagedResult<TalentDetailDto>(pagedData, request.PageNumber, request.PageSize, count);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw new ServiceException();
            }
        }
    }
}