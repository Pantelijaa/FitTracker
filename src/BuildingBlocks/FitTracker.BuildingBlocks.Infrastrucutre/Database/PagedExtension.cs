using Microsoft.EntityFrameworkCore;
using FitTracker.BuildingBlocks.Core.UseCases;
using FitTracker.BuildingBlocks.Core.Domain;


namespace FitTracker.BuildingBlocks.Infrastrucutre.Database;
public static class PagedExtension
{
    public static async Task<PagedResult<T>> GetPagedById<T>(this IQueryable<T> source, int pageIndex, int pageSize) where T : Entity
    {
        var count = await source.CountAsync();

        if (pageSize != 0 && pageIndex != 0)
        {
            source = source.OrderBy(x => x.Id).Skip((pageIndex - 1) * pageSize).Take(pageSize);
        }

        var items = await source.ToListAsync();
        return new PagedResult<T>(items, count);
    }
}
