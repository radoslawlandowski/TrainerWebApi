using System;
using TrainerWebApi.Enums;

namespace TrainerWebApi.Models
{
    public class Report
    {
        public int Id { get; set; }

        public DateTime DateTime { get; set; }

        public Training Training { get; set; }
    }
}