using FitTracker.Workouts.API.Public;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FitTracker.API.Controllers
{
    [Route("api/workouts")]
    public class WorkoutController : BaseController
    {
        private readonly IWorkoutService _workoutService;

        public WorkoutController(IWorkoutService workoutService)
        {
            _workoutService = workoutService;
        }

        [HttpGet("trainee/{traineeId}/calendar/{year}/{month}")]
        public ActionResult GetCalendar(int traineeId, int year, int month)
        {
            var result = _workoutService.GetCalendar(traineeId, year, month);
            return CreateResponse(result);
        }
    }
}
