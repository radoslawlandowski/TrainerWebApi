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
        private readonly IRepository<Report> _reportRepository;

        public ReportController(IRepository<Report> reportRepository)
        {
            _reportRepository = reportRepository;
        }

        public IEnumerable<Report> GetAllReports()
        {
            return _reportRepository.GetAll();
        }

        [Route("api/report/{trainingName}")]
        public IEnumerable<Report> GetReportForTraining(string trainingName)
        {
            return _reportRepository.Get(r => r.Training.Name == trainingName);
        }

        [Route("api/report/{trainingName}/dates/{dateFrom}/{dateTo}")]
        public IEnumerable<Report> GetReportForTrainingByDate(string trainingName, string dateFrom, string dateTo)
        {
            return _reportRepository.Get(r => r.Training.Name == trainingName 
                && r.DateTime >= DateTime.Parse(dateFrom) 
                && r.DateTime <= DateTime.Parse(dateTo)
            );
        }

        public IHttpActionResult GetReport(int id)
        {
            var session = _reportRepository.GetById(id);
            if (session == null)
            {
                return NotFound();
            }
            return Ok(session);
        }

        public IHttpActionResult AddReport(Report session)
        {
            _reportRepository.Add(session);
            return Ok();
        }
    }
}
