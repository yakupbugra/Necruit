using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Necruit.Api.Filters;
using Necruit.Application.Exceptions;
using Necruit.Application.Mapping;
using Necruit.Domain.Entities;
using Necruit.Infrastructure.Persistence.Repository;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Necruit.Application.Service
{
    public abstract class CrudService<TEntity, TCreate, TUpdate, TDetail, TList, TPatch> : ServiceBase
        where TEntity : Entity
        where TCreate : MapTo<TEntity>
        where TUpdate : MapTo<TEntity>
        where TDetail : MapFrom<TEntity>
    {
        private IGenericRepository<TEntity> repository;
        private IMapper mapper;

        public CrudService(
            ILogger<CrudService<TEntity, TCreate, TUpdate, TDetail, TList, TPatch>> Logger,
            IGenericRepository<TEntity> jobRepository,
            IMapper mapper) : base(Logger)
        {
            this.repository = jobRepository;
            this.mapper = mapper;
        }

        public virtual async Task<int> Create(TCreate request)
        {
            TEntity entity = mapper.Map<TEntity>(request);

            repository.Add(entity);
            await repository.SaveAsync();

            return entity.Id;
        }

        public virtual async Task<int> Update(int id, TUpdate request)
        {
            try
            {
                TEntity entity = repository.FindById(id);
                if (entity == null)

                    return 0;

                var entiy = mapper.Map<TUpdate, TEntity>(request, entity);

                repository.Update(entiy);
                await repository.SaveAsync();

                return entity.Id;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw new ServiceException();
            }
        }

        public virtual async Task Delete(int id)
        {
            try
            {
                repository.Delete(id);
                await repository.SaveAsync();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw new ServiceException();
            }
        }

        public virtual async Task<TDetail> GetDetail(int id)
        {
            try
            {
                return await repository.FindBy(x => x.Id == id).ProjectTo<TDetail>(mapper.ConfigurationProvider).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw new ServiceException();
            }
        }

        public virtual async Task<PagedResult<TList>> GetActives(PageRequest request)
        {
            try
            {
                var pagedData = await repository.AllActives()
                    .ProjectTo<TList>(mapper.ConfigurationProvider)
                    .Skip((request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ToListAsync();
                var count = await repository.AllActives().CountAsync();

                return new PagedResult<TList>(pagedData, request.PageNumber, request.PageSize, count);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw new ServiceException();
            }
        }

        public virtual async Task<PagedResult<TList>> GetPassives(PageRequest request)
        {
            try
            {
                var pagedData = await repository.AllPassives()
                    .ProjectTo<TList>(mapper.ConfigurationProvider)
                    .Skip((request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ToListAsync();
                var count = await repository.AllPassives().CountAsync();

                return new PagedResult<TList>(pagedData, request.PageNumber, request.PageSize, count);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw new ServiceException();
            }
        }

        public virtual async Task Patch(int id, TPatch request)
        {
            try
            {
                TEntity job = repository.FindById(id);
                mapper.Map<TPatch, TEntity>(request, job);
                repository.Update(job);
                await repository.SaveAsync();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw new ServiceException();
            }
        }
    }
}