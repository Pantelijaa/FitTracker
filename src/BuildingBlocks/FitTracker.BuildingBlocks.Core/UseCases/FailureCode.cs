using FluentResults;

namespace FitTracker.BuildingBlocks.Core.UseCases
{
    public abstract class FailureCode
    {

        public static readonly IError NotFound = new Error("Resource not found").WithMetadata("Code", "404");
    }
}
