using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Runtime.Remoting.Channels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Ninject.Infrastructure.Language;
using TrainerWebApi.Models;

namespace TrainerWebApi.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<TrainerWebApi.DAL.TrainerContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(TrainerWebApi.DAL.TrainerContext context)
        {
            if (System.Diagnostics.Debugger.IsAttached == false)
                System.Diagnostics.Debugger.Launch();

            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            var userStore = new UserStore<User>(context);
            var userManager = new UserManager<User>(userStore);

            roleManager.Create(new IdentityRole("admin"));
            roleManager.Create(new IdentityRole("athlete"));
            roleManager.Create(new IdentityRole("trainer"));

            var admin = new User
            {
                Id = "1",
                UserName = "admin",
                FirstName = "Admin",
                LastName = "Admin",
                Email = "admin@a.a",
                PasswordHash = new PasswordHasher().HashPassword("admin"),
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var test_athlete = new User
            {
                Id = "2",
                UserName = "testathlete",
                FirstName = "Testathlete",
                LastName = "Testathlete",
                Email = "testathlete@ta.ta",
                PasswordHash = new PasswordHasher().HashPassword("testathlete"),
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var test_trainer = new User
            {
                Id = "3",
                UserName = "testtrainer",
                FirstName = "Testtrainer",
                LastName = "TestTrainer",
                Email = "testtrainer@tt.tt",
                PasswordHash = new PasswordHasher().HashPassword("testtrainer"),
                SecurityStamp = Guid.NewGuid().ToString()
            };

            context.Users.AddOrUpdate(admin);
            context.Users.AddOrUpdate(test_athlete);
            context.Users.AddOrUpdate(test_trainer);

            context.Muscles.AddOrUpdate(
                m => m.Name,
                new Muscle {Id = 1, Name = "Bicep"},    
                new Muscle {Id = 2, Name = "Tricep"},    
                new Muscle {Id = 3, Name = "Forearm"},    
                new Muscle {Id = 4, Name = "Minor Chest"},    
                new Muscle {Id = 5, Name = "Major Chest"},    
                new Muscle {Id = 6, Name = "Back"},    
                new Muscle {Id = 7, Name = "Trapezoid"},    
                new Muscle {Id = 8, Name = "Hamstrings"},    
                new Muscle {Id = 9, Name = "ABS"},    
                new Muscle {Id = 10, Name = "Legs"}    
            );

            context.SaveChanges();

            var bicepCurlMuscles = context.Muscles.Where(m => m.Id == 1 || m.Id == 3).ToList();
            var benchPressMuscles = context.Muscles.Where(m => m.Id == 4 || m.Id == 5 || m.Id == 2).ToList();
            var rowsMuscles = context.Muscles.Where(m => m.Id == 1 || m.Id == 6 || m.Id == 7 || m.Id == 3).ToList();
            var frontSquatsMuscles = context.Muscles.Where(m => m.Id == 10 || m.Id == 9 || m.Id == 7 || m.Id == 8).ToList();
            var backSquatsMuscles = context.Muscles.Where(m => m.Id == 10 || m.Id == 9 || m.Id == 7 || m.Id == 8).ToList();

            context.ExerciseCards.AddOrUpdate(
                e => e.Name,
                new ExerciseCard { Name = "Bicep Curl", Description = "Curl the biceps", MusclesInvolved = bicepCurlMuscles},
                new ExerciseCard { Name = "Bench Press", Description = "Curl the biceps", MusclesInvolved = benchPressMuscles},
                new ExerciseCard { Name = "Rows", Description = "Curl the biceps", MusclesInvolved = rowsMuscles},
                new ExerciseCard { Name = "Front Squats", Description = "Curl the biceps", MusclesInvolved = frontSquatsMuscles},
                new ExerciseCard { Name = "Back Squats", Description = "Curl the biceps", MusclesInvolved = backSquatsMuscles},
                new ExerciseCard { Name = "Deadlift", Description = "Curl the biceps" },
                new ExerciseCard { Name = "Hip Thrusts", Description = "Curl the biceps" }
            );

            context.SaveChanges();

            context.Trainings.AddOrUpdate(
                t => t.Name,
                new Training
                {
                    Name = "test_training_1",
                    Exercises = new List<ExercisePlan>
                    {
                        new ExercisePlan
                        {
                            Name = "Bicep Curl",
                            Sets = new List<ExerciseSet>()
                            {
                                new ExerciseSet { Reps = 10, Weight = 10 },
                                new ExerciseSet { Reps = 8, Weight = 12 },
                                new ExerciseSet { Reps = 7, Weight = 14 },
                                new ExerciseSet { Reps = 6, Weight = 16 },
                                new ExerciseSet { Reps = 4, Weight = 18 },
                            } 
                        },
                        new ExercisePlan
                        {
                            Name = "Bench Press",
                            Sets = new List<ExerciseSet>()
                            {
                                new ExerciseSet { Reps = 10, Weight = 50 },
                                new ExerciseSet { Reps = 8, Weight = 55 },
                                new ExerciseSet { Reps = 7, Weight = 60 },
                                new ExerciseSet { Reps = 6, Weight = 65 },
                                new ExerciseSet { Reps = 4, Weight = 70 },
                            }
                        },
                        new ExercisePlan
                        {
                            Name = "Rows",
                            Sets = new List<ExerciseSet>()
                            {
                                new ExerciseSet { Reps = 10, Weight = 30 },
                                new ExerciseSet { Reps = 8, Weight = 35 },
                                new ExerciseSet { Reps = 7, Weight = 40 },
                                new ExerciseSet { Reps = 6, Weight = 45 },
                                new ExerciseSet { Reps = 4, Weight = 50 },
                            }
                        },
                        new ExercisePlan
                        {
                            Name = "Deadlift",
                            Sets = new List<ExerciseSet>()
                            {
                                new ExerciseSet { Reps = 8, Weight = 110 },
                                new ExerciseSet { Reps = 6, Weight = 115 },
                                new ExerciseSet { Reps = 5, Weight = 120 },
                                new ExerciseSet { Reps = 4, Weight = 125 },
                                new ExerciseSet { Reps = 3, Weight = 130 },
                            }
                        },
                    }
                        
                }    
            );

            var tr = context.Trainings.FirstOrDefault(t => t.Name == "test_training_1");
            var testAth = context.Users.FirstOrDefault(u => u.UserName == "testathlete");

            tr.User = testAth;

            context.Trainings.AddOrUpdate(
               t => t.Name,
               new Training
               {
                   Name = "test_training_2",
                   User = testAth,
                   Exercises = new List<ExercisePlan>
                   {
                        new ExercisePlan
                        {
                            Name = "Rows",
                            Sets = new List<ExerciseSet>()
                            {
                                new ExerciseSet { Reps = 10, Weight = 70 },
                                new ExerciseSet { Reps = 8, Weight = 75 },
                                new ExerciseSet { Reps = 7, Weight = 80 },
                            }
                        },
                        new ExercisePlan
                        {
                            Name = "Deadlift",
                            Sets = new List<ExerciseSet>()
                            {
                                new ExerciseSet { Reps = 18, Weight = 60 },
                                new ExerciseSet { Reps = 16, Weight = 65 },
                                new ExerciseSet { Reps = 15, Weight = 70 },
                                new ExerciseSet { Reps = 14, Weight = 75 },
                                new ExerciseSet { Reps = 13, Weight = 80 },
                            }
                        },
                   }

               }
           );

            context.Reports.AddOrUpdate(
                r => r.Id,
                new Report
                {
                    DateTime = DateTime.Parse("30-01-2017"),
                    Training = context.Trainings.FirstOrDefault(t => t.Name == "test_training_1")
                },
                new Report
                {
                    DateTime = DateTime.Parse("05-02-2017"),
                    Training = context.Trainings.FirstOrDefault(t => t.Name == "test_training_1")
                },
                new Report
                {
                    DateTime = DateTime.Parse("10-02-2017"),
                    Training = context.Trainings.FirstOrDefault(t => t.Name == "test_training_1")
                },
                new Report
                {
                    DateTime = DateTime.Parse("15-02-2017"),
                    Training = context.Trainings.FirstOrDefault(t => t.Name == "test_training_1")
                },
                new Report
                {
                    DateTime = DateTime.Parse("20-02-2017"),
                    Training = context.Trainings.FirstOrDefault(t => t.Name == "test_training_1")
                }    
            );

            try
            {
                context.SaveChanges();

                userManager.AddToRole("1", "admin");
                userManager.AddToRole("2", "athlete");
                userManager.AddToRole("3", "trainer");

                context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                var a = "a";
            }

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
