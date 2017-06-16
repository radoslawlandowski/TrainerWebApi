using System.Data.Entity.Validation;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
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

            context.ExerciseCards.AddOrUpdate(
                e => e.Name,
                new ExerciseCard { Name = "Bicep Curl", Description = "Curl the biceps"},
                new ExerciseCard { Name = "Bench Press", Description = "Curl the biceps" },
                new ExerciseCard { Name = "Rows", Description = "Curl the biceps" },
                new ExerciseCard { Name = "Front Squats", Description = "Curl the biceps" },
                new ExerciseCard { Name = "Back Squats", Description = "Curl the biceps" },
                new ExerciseCard { Name = "Deadlift", Description = "Curl the biceps" },
                new ExerciseCard { Name = "Hip Thrusts", Description = "Curl the biceps" }
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
