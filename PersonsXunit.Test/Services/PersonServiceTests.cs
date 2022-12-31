using Business_Access_Layer.Services;
using Data_Access_Layer.Interface;
using Data_Access_Layer.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace PersonsXunit.Test.Services
{
    public class PersonServiceTests
    {
        private PersonService _service;

        private Mock<IRepository<Person>> mockpersonRepository;

        public PersonServiceTests()
        {
            this.mockpersonRepository = new Mock<IRepository<Person>>();

            _service = Createpersonservice(); 
            
        }

        private PersonService Createpersonservice()
        {
            return new PersonService(this.mockpersonRepository.Object);
        }



        [Fact]
        public void GetPersonByUserId_StateUnderTest_ExpectedBehavior()
        {
            // Arrange

            int UserId = 101;
           List<Person> persondata = new List<Person>();
            persondata.Add(new Person {Id=101, UserName = "Preetham", UserPassword = "12345", UserEmail = "987654321", CreatedOn = DateTime.Now, IsDeleted = false });

            mockpersonRepository.Setup(X => X.GetAll()).Returns(persondata);

            // Act
            var result = _service.GetPersonByUserId(UserId);


            // Assert
            Assert.Equal(persondata, result);
        }


        [Fact]
        public void GetAllPersons_StateUnderTest_ExpectedBehavior()
        {
            // Arrange

            List<Person> persondata = new List<Person>();
            persondata.Add(new Person { Id = 101, UserName = "Preetham", UserPassword = "12345", UserEmail = "987654321", CreatedOn = DateTime.Now, IsDeleted = false });
 
            mockpersonRepository.Setup(X => X.GetAll()).Returns(persondata);

            // Act
            var result = _service.GetAllPersons();

            // Assert
            Assert.Equal(persondata, result);
        }

        [Fact]
        public void GetPersonByUserName_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            string UserName = "987654321";
            List<Person> persondata = new List<Person>();
            persondata.Add(new Person { Id = 101, UserName = "Preetham", UserPassword = "12345", UserEmail = "987654321", CreatedOn = DateTime.Now, IsDeleted = false });
    
            mockpersonRepository.Setup(X => X.GetAll()).Returns(persondata);

            // Act
            var result = _service.GetPersonByUserName(UserName);


            // Assert
            Assert.Equal(persondata, result);
        }

        [Fact]
        public async Task AddPerson_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var person = new Person() {Id = 101, UserName = "Preetham", UserPassword = "12345", UserEmail = "987654321", CreatedOn = DateTime.Now, IsDeleted = false };

             mockpersonRepository.Setup(X => X.Create(person)).Returns(Task.FromResult(person));

            // Act
            var result = await _service.AddPerson(person);


            // Assert
            Assert.Equal(person, result);
        }

        [Fact]
        public void DeletePerson_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            int Id = 101;
            List<Person> persondata = new List<Person>();
            persondata.Add(new Person { Id = 101, UserName = "Preetham", UserPassword = "12345", UserEmail = "987654321", CreatedOn = DateTime.Now, IsDeleted = false });

            mockpersonRepository.Setup(X => X.GetAll()).Returns(persondata);

            // Act
            var result = _service.DeletePerson(Id);


            // Assert
            Assert.True(result);
        }

        [Fact]
        public void UpdatePerson_StateUnderTest_ExpectedBehavior()
        {

            // Arrange
            var person = new Person() { Id = 101, UserName = "Preetham Gowda", UserPassword = "12345987", UserEmail = "987654321", CreatedOn = DateTime.Now, IsDeleted = false };

            mockpersonRepository.Setup(X => X.Update(person));


            //Act
            var result = _service.UpdatePerson(person);


            //Assert
            Assert.True(result);
        }
    }
}
