using System.Collections.Generic;
using System.Linq;
using TrainerWebApi.Models;
using TrainerWebApi.Repositories;

namespace TrainerWebApi.Tests.Fakes
{
    public class FakeExerciseRepository : IRepository<ExerciseCard>
    {
        private List<ExerciseCard> _exercises;

        public FakeExerciseRepository()
        {
            _exercises = new List<ExerciseCard>
            {
                new ExerciseCard() {Id=0, Name="Bicep curl", Description = "Curl the biceps!"},
                new ExerciseCard() {Id=1, Name="Back rows", Description = "Row the back!"},
                new ExerciseCard() {Id=2, Name="Leg press", Description = "Press the legs!"},
            };
        }

        public ExerciseCard GetById(int id)
        {
            return _exercises.FirstOrDefault(e => e.Id.Equals(id));
        }

        public IEnumerable<ExerciseCard> GetAll()
        {
            return _exercises;
        }

        public void Add(ExerciseCard exercise)
        {
            _exercises.Add(exercise);
        }

        public void Remove(ExerciseCard exercise)
        {
            _exercises.Remove(exercise);
        }

        public void Update(ExerciseCard exercise)
        {
            throw new System.NotImplementedException();
        }
    }
}