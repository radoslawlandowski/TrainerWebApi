using System.Collections.Generic;

namespace TrainerWebApi.Models
{
    public class ExercisePlan
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Dictionary<int, double>> Sets { get; set; }

        public ExercisePlan()
        {
            Sets = new List<Dictionary<int, double>>();
        }
    }
}