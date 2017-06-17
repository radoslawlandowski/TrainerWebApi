using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace TrainerWebApi.Models
{
    public class ExerciseCard
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Name of the exercise card cannot be empty")]
        [StringLength(30, ErrorMessage = "Name cannot exceed 30 characters")]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Description of the exercise card cannot be empty")]
        [StringLength(200, ErrorMessage = "Description cannot exceed 200 characters")]
        public string Description { get; set; }

        public virtual ICollection<Muscle> MusclesInvolved { get; set; }

        public ExerciseCard()
        {
            MusclesInvolved = new List<Muscle>();
        }
    }
}