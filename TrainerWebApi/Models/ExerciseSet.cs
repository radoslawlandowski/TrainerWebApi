namespace TrainerWebApi.Models
{
    public class ExerciseSet
    {
        public int Id { get; set; }

        public ExercisePlan ExercisePlan { get; set; }

        public int Reps { get; set; }

        public int Weight { get; set; }
    }
}