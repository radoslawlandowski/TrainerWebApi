using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TrainerWebApi.Models;
using TrainerWebApi.Repositories;

namespace TrainerWebApi.Controllers
{
    public class TrainingController : ApiController
    {
        private readonly IRepository<Training> _trainingRepository;

        public TrainingController(IRepository<Training> trainingRepository)
        {
            _trainingRepository = trainingRepository;
        }

        public IEnumerable<Training> GetTrainings()
        {
            return _trainingRepository.GetAll();
        }

        public IHttpActionResult GetTraining(int id)
        {
            var exercise = _trainingRepository.GetById(id);
            if (exercise == null)
            {
                return NotFound();
            }
            return Ok(exercise);
        }

        public IHttpActionResult PostTraining(Training exercise)
        {
            _trainingRepository.Add(exercise);
            return Ok();
        }
    }
}
