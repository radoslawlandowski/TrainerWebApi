using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace TrainerWebApi.Models
{
    public class Muscle
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }
        public string Description { get; set; }

        [JsonIgnore]
        public virtual ICollection<ExerciseCard> ExerciseCards { get; set; }

        public Muscle()
        {
            ExerciseCards = new List<ExerciseCard>();
        }
    }
}