namespace FitTracker.BuildingBlocks.Core.UseCases
{
    public class PagedResult<T>
    {
        public List<T> Result { get; }
        public int TotalCount { get; }

        public PagedResult(List<T> result, int totalCount)
        {
            Result = result;
            TotalCount = totalCount;
        }

    }
}
