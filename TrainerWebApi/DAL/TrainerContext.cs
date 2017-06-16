using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using TrainerWebApi.Models;

namespace TrainerWebApi.DAL
{
    public class TrainerContext : IdentityDbContext<User>
    {
        public DbSet<ExerciseCard> ExerciseCards { get; set; }
        public DbSet<ExercisePlan> ExercisePlans { get; set; }
        public DbSet<Muscle> Muscles { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Training> Trainings { get; set; }
    }
}