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

        [Route("api/training/{username}")]
        public IEnumerable<Training> GetTrainings(string username)
        {
            return _trainingRepository.Get(t => t.User.UserName == username);
        }

        [Route("api/training/{username}/name/{name}")]
        public IEnumerable<Training> GetTrainings(string username, string name)
        {
            return _trainingRepository.Get(t => t.User.UserName == username && t.Name == name);
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
