using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Interview.Tests
{
    [TestClass]
    public class RepositoryTests

    {
        [TestMethod]
        public void Repository_Constructoy_CreatesEmptyRepository()
        {
            //Arrange
            var repository = new PassengerRepository();

            //Act
            var res = repository.GetAll();

            //Assert
            Assert.AreEqual(res.ToList().Count(), 0);
        }
        [TestMethod]
        public void Repository_Save_StoresTheItemAddedToList()
        {
            //Arrange
            var repository = new PassengerRepository();

            //Act
            var passenger = new Passenger();
            passenger.Id = 1;
            repository.Save(passenger);

            //Assert
            var numItemsInRepository = repository.GetAll().Count();
            Assert.AreEqual(numItemsInRepository, 1);
        }
        [TestMethod]
        public void Repository_Get_ReturnsTheItemAddedToRepository()
        {
            //Arrange
            var repository = new PassengerRepository();

            //Act
            int passengerId = 2;
            var passenger = new Passenger();
            passenger.Id = passengerId;
            repository.Save(passenger);

            //Assert
            var itemAddedInRepository = repository.Get(passengerId);
            Assert.AreEqual(itemAddedInRepository.Id, passengerId);
        }
    }
}
