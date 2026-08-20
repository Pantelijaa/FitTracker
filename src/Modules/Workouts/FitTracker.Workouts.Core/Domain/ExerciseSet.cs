using FitTracker.BuildingBlocks.Core.Domain;

namespace FitTracker.Workouts.Core.Domain
{
    public class ExerciseSet : Entity
    {
        public int Repetitions { get; private set; }
        public float Weight { get; private set; }
        public List<ExerciseSetSnapshot> ChangeHistory { get; private set; } = new();

        public ExerciseSet() { }
        public ExerciseSet(int repetitions, float weight)
        {
            Repetitions = repetitions;
            Weight = weight;
        }

        public void Update(int repetitions, float weight)
        {
            var snapshot = new ExerciseSetSnapshot(Repetitions, Weight, DateTime.Now);
            ChangeHistory.Add(snapshot);

            Repetitions = repetitions;
            Weight = weight;
        }
    }
}
