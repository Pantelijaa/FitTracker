using AutoMapper;
using FitTracker.BuildingBlocks.Core.Domain;
using FluentResults;

namespace FitTracker.BuildingBlocks.Core.UseCases
{
    public class CrudService<TDomain, TDto> : BaseService<TDomain, TDto> where TDomain : Entity
    {
        protected readonly IUnitOfWork UnitOfWork;
        protected readonly ICrudRepository<TDomain> CrudRepository;

        public CrudService(IUnitOfWork unitOfWork, ICrudRepository<TDomain> repository, IMapper mapper) : base(mapper)
        {
            UnitOfWork = unitOfWork;
            CrudRepository = repository;
        }

        public Result<TDto> Get(int id)
        {
            var result = CrudRepository.Get(id);
            return result == null ? Result.Fail(FailureCode.NotFound) : MapToDto(result);
        }

        public Result<PagedResult<TDto>> GetPaged(int page, int pageSize)
        {
            var result = CrudRepository.GetPaged(page, pageSize);
            return MapToDto(result);
        }

        public virtual Result<TDto> Create(TDto dto)
        {
            var entity = MapToDomain(dto);
            var result = CrudRepository.Create(entity);

            var savedResult = UnitOfWork.Save();

            return savedResult.IsFailed ? savedResult : MapToDto(result);
        }

        public virtual Result<TDto> Update(TDto dto)
        {
            var entity = MapToDomain(dto);
            var result = CrudRepository.Update(entity);

            var savedResult = UnitOfWork.Save();

            return savedResult.IsFailed ? savedResult : MapToDto(result);
        }

        public virtual Result Delete(int id)
        {
            var entity = CrudRepository.Get(id);
            if (entity is null)
                return Result.Fail(FailureCode.NotFound);

            CrudRepository.Delete(entity);

            var savedResult = UnitOfWork.Save();
            
            return savedResult.IsFailed ? savedResult : Result.Ok();
        }
    }
}
