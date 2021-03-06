﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace TrainerWebApi.Models
{
    public class Training
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        public virtual ICollection<ExercisePlan> Exercises { get; set; } 

        [JsonIgnore]
        public virtual User User { get; set; }

        public Training()
        {
            Exercises = new List<ExercisePlan>();
        }
    }
}