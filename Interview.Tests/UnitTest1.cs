﻿using System;
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
        public void Repository_Constructoy_CreatesEmptyRepository()
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
            var passenger = new Passenger();
            passenger.Id = 1;
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
            var passenger = new Passenger();
            passenger.Id = passengerId;
            repository.Save(passenger);

            //Assert
            var itemAddedInRepository = repository.Get(passengerId);
            Assert.AreEqual(passengerId, itemAddedInRepository.Id);
        }
        [Test]
        public void Repository_Delete_DeletesAGivenItemFromRepository()
        {
            //Arrange
            var repository = new PassengerRepository(new List<Passenger>());

            //Act
            int passengerId1 = 1;
            int passengerId2 = 2;
            var passenger1 = new Passenger { Id = passengerId1 };
            var passenger2 = new Passenger { Id = passengerId2 };

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
        public void Repisitory_Save_DuplicateIdValueAddedToRepository()
        {
            //Arrange 
            var repository = new PassengerRepository(new List<Passenger>());

            //Act
            int passengerId1 = 1;
            int passengerId2 = 1;
            var passenger1 = new Passenger { Id = passengerId1 };
            var passenger2 = new Passenger { Id = passengerId2 };

            repository.Save(passenger1);

            //Assert
            Assert.Throws<InvalidOperationException>(() => repository.Save(passenger2));
        }
        [Test]
        public void Repisitory_Save_NullItemPassedToSave()
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
        public void Repository_Delete_NonExisingIdPassed()
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

    }
}
