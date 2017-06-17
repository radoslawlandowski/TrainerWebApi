using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using TrainerWebApi.Filters.Action;
using TrainerWebApi.Models;
using TrainerWebApi.Repositories;

namespace TrainerWebApi.Controllers
{
    public class ExerciseCardController : ApiController
    {
        private readonly IRepository<ExerciseCard> _exerciseCardRepository;

        public ExerciseCardController(IRepository<ExerciseCard> exerciseCardRepository)
        {
            _exerciseCardRepository = exerciseCardRepository;
        }

        public IEnumerable<ExerciseCard> GetAllExercises()
        {
            return _exerciseCardRepository.GetAll();
        }

        public IHttpActionResult GetExercise(int id)
        {
            var exercise = _exerciseCardRepository.GetById(id);
            if (exercise == null)
            {
                return NotFound();
            }
            return Ok(exercise);
        }
         
        [ResponseType(typeof(ExerciseCard))]
        public HttpResponseMessage PostExercise(HttpRequestMessage request, ExerciseCard exercise)
        {
            var exerciseCard = _exerciseCardRepository.Add(exercise);

            return exerciseCard == null ? request.CreateErrorResponse(HttpStatusCode.Accepted, "Exercise cannot be created") : request.CreateResponse(HttpStatusCode.OK, exerciseCard);
        }
    }
}
