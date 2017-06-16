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
    public class ReportController : ApiController
    {
        private readonly IRepository<Report> _trainingSessionRepository;

        public ReportController(IRepository<Report> trainingSessionRepository)
        {
            _trainingSessionRepository = trainingSessionRepository;
        }

        public IEnumerable<Report> GetTrainingSessions()
        {
            return _trainingSessionRepository.GetAll();
        }

        public IHttpActionResult GetTrainingSession(int id)
        {
            var session = _trainingSessionRepository.GetById(id);
            if (session == null)
            {
                return NotFound();
            }
            return Ok(session);
        }

        public IHttpActionResult PostTrainingSession(Report session)
        {
            _trainingSessionRepository.Add(session);
            return Ok();
        }
    }
}
