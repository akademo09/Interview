using System;
using System.Collections.Generic;
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
            Assert.AreEqual(res.ToList().Count(), 0);
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
            Assert.AreEqual(numItemsInRepository, 1);
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
            Assert.AreEqual(itemAddedInRepository.Id, passengerId);
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
            Assert.AreEqual(numItemsInRepositoryAferSave, 2);
            Assert.AreEqual(numItemsInRepositoryAferDelete, 1);

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
            Assert.AreEqual(res, null);
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

    }
}
