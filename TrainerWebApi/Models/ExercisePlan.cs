using System.Collections.Generic;

namespace TrainerWebApi.Models
{
    public class ExercisePlan
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<ExerciseSet> Sets { get; set; }

        public ExercisePlan()
        {
            Sets = new List<ExerciseSet>();
        }
    }
}