using System;
using Xunit;
using XUnit_Test.Controllers;

namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {

        }

        [Fact]
        public async void Task_GetPersonById_Return_OkResult()
        {
            //Arrange  
            var controller = new PersonDetailsController(repository);
            var UserId = 2123;

            //Act  
            var data = await controller.GetAllPersonByName(UserId);

            //Assert  
            Assert.IsType<OkObjectResult>(data);
        }
    }
}