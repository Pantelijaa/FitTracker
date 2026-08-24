using AutoMapper;
using FitTracker.BuildingBlocks.Core.Domain;
using FluentResults;

namespace FitTracker.BuildingBlocks.Core.UseCases
{
    public abstract class BaseService<TDomain, TDto> where TDomain : Entity
    {
        private readonly IMapper _mapper;

        protected BaseService(IMapper mapper)
        {
            _mapper = mapper;
        }

        protected TDomain MapToDomain(TDto dto)
        {
            return _mapper.Map<TDomain>(dto);
        }

        protected List<TDomain> MapToDomain(List<TDto> dtos)
        {
            return dtos.Select(dto => _mapper.Map<TDomain>(dto)).ToList();
        }

        protected TDto MapToDto(TDomain domain)
        {
            return _mapper.Map<TDto>(domain);
        }

        protected Result<List<TDto>> MapToDto(Result<List<TDomain>> domains)
        {
            if (domains.IsFailed)
                return Result.Fail<List<TDto>>(domains.Errors);

            return domains.Value.Select(_mapper.Map<TDto>).ToList();
        }

        protected Result<PagedResult<TDto>> MapToDto(Result<PagedResult<TDomain>> domains)
        {
            if (domains.IsFailed)
                return Result.Fail<PagedResult<TDto>>(domains.Errors);

            var items = domains.Value.Result.Select(_mapper.Map<TDto>).ToList();
            return new PagedResult<TDto>(items, domains.Value.TotalCount);
        }
    }
}
