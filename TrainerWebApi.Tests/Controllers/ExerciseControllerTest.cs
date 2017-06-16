using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Results;
using FakeItEasy;
using NUnit.Framework;
using TrainerWebApi.Controllers;
using TrainerWebApi.Models;
using TrainerWebApi.Repositories;
using TrainerWebApi.Tests.Fakes;

namespace TrainerWebApi.Tests.Controllers
{
    [TestFixture]
    public class ExerciseControllerTest
    {
        private IRepository<ExerciseCard> _fakeRepository; 
        private IEnumerable<ExerciseCard> _fakeExercises;

        [SetUp]
        public void SetUp()
        {
            _fakeRepository = A.Fake<IRepository<ExerciseCard>>();

            _fakeExercises = new List<ExerciseCard>
            {
                new ExerciseCard() {Id=0, Name="Bicep curl", Description = "Curl the biceps!"},
                new ExerciseCard() {Id=1, Name="Back rows", Description = "Row the back!"},
                new ExerciseCard() {Id=2, Name="Leg press", Description = "Press the legs!"},
            };
        }

        [Test]
        public void WhenGettingAllExercises_Then_ItShouldReturnACollectionOfExercises()
        {
            A.CallTo(() => _fakeRepository.GetAll()).Returns(_fakeExercises);
            var ExerciseController = new ExerciseCardController(_fakeRepository);

            var accuired = ExerciseController.GetAllExercises();

            A.CallTo(() => _fakeRepository.GetAll()).MustHaveHappened(Repeated.Exactly.Once);
            Assert.AreEqual(_fakeExercises, accuired);
        }

        [Test]
        public void WhenGettingExerciseById_Then_ItShouldReturnOneExercise()
        {
            A.CallTo(() => _fakeRepository.GetById(1)).Returns(_fakeExercises.ElementAt(1));
            var ExerciseController = new ExerciseCardController(_fakeRepository);

            var accuired = ExerciseController.GetExercise(1);

            A.CallTo(() => _fakeRepository.GetById(1)).MustHaveHappened(Repeated.Exactly.Once);
            Assert.IsInstanceOf(typeof(OkNegotiatedContentResult<ExerciseCard>), accuired);
        }

        [Test]
        public void WhenGettingExerciseByInvalidId_Then_ItShouldReturnNotFound()
        {
            A.CallTo(() => _fakeRepository.GetById(5)).Returns(null);
            var ExerciseController = new ExerciseCardController(_fakeRepository);

            var accuired = ExerciseController.GetExercise(5);

            A.CallTo(() => _fakeRepository.GetById(5)).MustHaveHappened(Repeated.Exactly.Once);
            Assert.IsInstanceOf(typeof(NotFoundResult), accuired);
        }
    }
}
