using System;
using TrainerWebApi.Enums;
using TrainerWebApi.Helpers;

namespace TrainerWebApi.Models
{
    public class Report
    {
        public int Id { get; set; }

        public DateTime DateTime { get; set; }

        public virtual Training Training { get; set; }
    }
}