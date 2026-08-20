using FitTracker.BuildingBlocks.Core.Domain;

namespace FitTracker.Workouts.Core.Domain
{
    public class ExerciseSetSnapshot : ValueObject
    {
        public int Repetitions { get; private set; }
        public float Weight { get; private set; }
        public DateTime ChangedAt { get; private set; }

        public ExerciseSetSnapshot() { }
        public ExerciseSetSnapshot(int repetitions, float weight, DateTime changedAt)
        {
            Repetitions = repetitions;
            Weight = weight;
            ChangedAt = changedAt;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Repetitions;
            yield return Weight;
            yield return ChangedAt;
        }
    }
}
