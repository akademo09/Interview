using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using NUnit.Framework;

namespace Interview.Tests
{
    [TestFixture]
    public class RepositoryTests

    {
        [Test]
        public void Repository_Constructor_CreatesEmptyRepository()
        {
            //Arrange
            var repository = new PassengerRepository(new List<Passenger>());

            //Act
            var res = repository.GetAll();

            //Assert
            Assert.AreEqual(0, res.ToList().Count());
        }
        [Test]
        public void Repository_Save_StoresTheItemAddedToList()
        {
            //Arrange
            var repository = new PassengerRepository(new List<Passenger>());

            //Act
            var passenger = new Passenger {Id = 1, Name = "Name1"};
            repository.Save(passenger);

            //Assert
            var numItemsInRepository = repository.GetAll().Count();
            Assert.AreEqual(1, numItemsInRepository);
        }
        [Test]
        public void Repository_Get_ReturnsTheItemAddedToRepository()
        {
            //Arrange
            var repository = new PassengerRepository(new List<Passenger>());

            //Act
            int passengerId = 2;
            string passengerName = "Name1";
            var passenger = new Passenger {Id = passengerId, Name = passengerName};
            repository.Save(passenger);

            //Assert
            var itemAddedInRepository = repository.Get(passengerId);
            Assert.AreEqual(passengerId, itemAddedInRepository.Id);
            Assert.AreEqual(passengerName, itemAddedInRepository.Name);
        }
        [Test]
        public void Repository_Delete_DeletesAGivenItemFromRepository()
        {
            //Arrange
            var repository = new PassengerRepository(new List<Passenger>());

            //Act
            int passengerId1 = 1;
            int passengerId2 = 2;
            var passenger1 = new Passenger { Id = passengerId1, Name = "Name1"};
            var passenger2 = new Passenger { Id = passengerId2, Name = "Name2"};

            repository.Save(passenger1);
            repository.Save(passenger2);

            var numItemsInRepositoryAferSave = repository.GetAll().Count();

            repository.Delete(passengerId1);

            var numItemsInRepositoryAferDelete = repository.GetAll().Count();

            //Assert
            Assert.AreEqual(2, numItemsInRepositoryAferSave);
            Assert.AreEqual(1, numItemsInRepositoryAferDelete);

        }
        [Test]
        public void Repository_Save_DuplicateIdValueAddedToRepository()
        {
            //Arrange 
            var repository = new PassengerRepository(new List<Passenger>());

            //Act
            int passengerId1 = 1;
            int passengerId2 = 1;
            string passengerId1Name = "Name1";
            string passengerId2Name = "Name2";
            var passenger1 = new Passenger { Id = passengerId1, Name = passengerId1Name };
            var passenger2 = new Passenger { Id = passengerId2 , Name = passengerId2Name};

            repository.Save(passenger1);

            //Assert
            Assert.Throws<InvalidOperationException>(() => repository.Save(passenger2));
        }
        [Test]
        public void Repository_Save_NullItemPassedToSave()
        {
            //Arrange 
            var repository = new PassengerRepository(new List<Passenger>());

            //Act
            //Assert
            Assert.Throws<ArgumentNullException>(() => repository.Save(null));
        }

        [Test]
        public void Repository_Get_IdPassedToGetDoesNotExit()
        {
            //Arrange
            var repository = new PassengerRepository(new List<Passenger>());

            //Act
            var res = repository.Get(-1);

            //Assert
            Assert.AreEqual(null, res);
        }

        [Test]
        public void Repository_Delete_NonExistingIdPassed()
        {
            //Arrange
            var repository = new PassengerRepository(new List<Passenger>());

            //Act
            //Assert
            Assert.Throws<InvalidOperationException>(() => repository.Delete(100));
        }
        [Test]
        [Ignore("Need to revisit this test to optimize the Save() operation")]
        public void Repository_Save_AddLargeNumberOfItemsStressTest()
        {
            //Arrange
            var passengersList = new List<Passenger>();
            var repository = new PassengerRepository(passengersList);

            //Act
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            for(int i=0;i<100000;i++)
            {
                var passenger = new Passenger { Id = i };
                repository.Save(passenger);
            }

            stopWatch.Stop();

            //Assert
            Assert.AreEqual(100000, repository.GetAll().Count());
            Assert.AreEqual(60 * 1000, stopWatch.ElapsedMilliseconds);
        }
        [Test]
        public void Repository_Constructor_NullParameterPassed()
        {
            //Arrange
            //Act
            //Assert
            Assert.Throws<NullReferenceException>(ConstructorExceptionHelper);
        }

        void ConstructorExceptionHelper()
        {
            var repository = new PassengerRepository(null);
        }

        [Test]
        public void Repository_Save_NegativeIdValuePassed()
        {
            //Arrange
            var repository = new PassengerRepository(new List<Passenger>());
            var passenger = new Passenger {Id = -1};

            //Act
            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(()=>repository.Save(passenger));
        }

        [Test]
        public void Repository_Save_InvalidEntityPassed()
        {
            //Arrange
            var repository = new PassengerRepository(new List<Passenger>());
            var passenger = new Passenger {Id = 1, Name = null};

            //Act
            //Assert
            Assert.Throws<ArgumentNullException>(()=> repository.Save(passenger));
        }
    }
}
