using System;
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
            var repository = new Repository();

            //Act
            var res = repository.GetAll();

            //Assert
            Assert.AreEqual(res.Count(), 0);
        }
    }
}
